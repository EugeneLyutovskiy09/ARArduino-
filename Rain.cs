using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class RainSnow : MonoBehaviour
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
        int analogValueT = manager.analogRead(AnalogPin.A0); // getting value from the thermoresistor (Tsensor) 
        int analogValuePh = manager.analogRead(AnalogPin.A5); // getting value from the photoresistor (Photosensor) 
        var main = ps.main;

        float mappedPh = (analogValuePh - 0) * (9f - 0f) / (250f - 0f) + 0f; // mapping value from photosensor onto the range (0-9) 
        float valueLT = 9f - mappedPh;
    

        if (analogValueT < 85) 
        {
            main.startLifetime = 0; // if temp drops lower 85 units, rain stops and is replaced by snow (see next script)
        }
        else
        {
            main.startLifetime = valueLT; // the higher the LT value the less it rains as the cloud starts to dissipate once the light intensity rises 
        }

    }
}
