using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class Snow : MonoBehaviour
{
    UduinoManager manager;
    private ParticleSystem ps;

    void Start()
    {
        manager = UduinoManager.Instance;
        ps = GetComponent<ParticleSystem>();
        var shape = ps.shape;

    }

    void Update()
    {
        int analogValueT = manager.analogRead(AnalogPin.A0); // getting value from the thermoresistor (T-sensor)
        int analogValuePh = manager.analogRead(AnalogPin.A5); // getting value from the photoresistor (Photosensor)
        var main = ps.main;

        float mappedLifeTime = (analogValuePh - 0) * (9f - 0f) / (250f - 0f) + 0f; // mapping values from the Ph sensor within the needed range (0f - 9f) for manipulating the startLifetime parameter of the PS system
        float valueLT = 9f - mappedLifeTime;

        if (analogValueT > 85)
        {
            main.startLifetime = 0; // if temp exceeds 85 units the snow is repleced by rain (see previous script). setting this value provides smooth transition between snowy and rainy weather conditions (sometimes both can be seen in the scene) 
        }
        else
        {
            main.startLifetime = valueLT; // mapped value decreases due to rising sunlight and dissipating cloud
        }

    }
}
