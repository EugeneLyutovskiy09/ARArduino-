using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class CloudRainSnow : MonoBehaviour
{
    UduinoManager manager;
    private ParticleSystem ps;

    void Start()
    {
        manager = UduinoManager.Instance;
        ps = GetComponent<ParticleSystem>();
        var shape = ps.shape;

    }

    // Update is called once per frame
    void Update()
    {
        int analogValuePh = manager.analogRead(AnalogPin.A5); // getting value from the photoresistor (Photosensor) 
        int analogValueT = manager.analogRead(AnalogPin.A0); // getting value from the thermoresistor (T-sensor)
        var main = ps.main;

        float mappedPh = (analogValuePh - 0) * (9f - 0f) / (250f - 0f) + 0f; // mapping values from the Ph sensor between the needed range (0f - 9f) for manipulating the startLifetime parameter of the PS system
        float mappedOp = (analogValuePh - 0) * (1f - 0f) / (250f - 0f) + 0f; // mapping values from the Ph sensor between the needed range (0f - 1f) for manipulating the opacity parameter of the PS system to make the cloud disipate smoothly
        float valueLT = 9f - mappedPh; // as we need the value for the above mentioned parameters to derease when the analog value increases
        float valueOp = 1f - mappedOp;

        if (analogValuePh > 250)
        {
            main.startColor = new Color(0.7809719f, 0.7884073f, 0.8490566f, 0f);
            main.startLifetime = 0; // if analog value from the Ph sensor exceedes 250 the cloud needs to desappear completely 
        }
        else {
            main.startLifetime = valueLT; // the lifetime parameter gets mapped sensor value increasing/decresing when light intensity fall/rises accordingly 
            main.startColor = new Color(0.7809719f, 0.7884073f, 0.8490566f, valueOp); // for a smoother transition, alpha (opacity) channel in RGBA colour parameters is manipulated by setting the mapped photo value into it 
        }

    }
}
