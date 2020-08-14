using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;


public class Lifetime : MonoBehaviour
{
    private ParticleSystem ps;
    UduinoManager manager;
    public float mappedPh;
    public uint v0;

    void Start()
    {
        manager = UduinoManager.Instance;
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        int analogValueT = manager.analogRead(AnalogPin.A0); // getting value from the thermoresistor (T-sensor)
        int analogValuePh = manager.analogRead(AnalogPin.A5); // getting value from the photoresistor (Photosensor)
        var main = ps.main;
        main.startLifetime = 1; // lifetime parameter is set to a constant value 

        float mappedPh = (analogValuePh - 0) * (7f - 0f) / (490f - 0f) + 0.1f; // mapping the photosensor analig value onto the range (0 - 7), as we want start speed parameter to be changed within this figures 

            main.startSpeed = mappedPh; // setting the mapped photosensor analog value into the start speed parameter of the particle system. Gradually increasing/decreasng size of the sun rays when photosensor indicates rising/falling intensity 

        float mappedT = (analogValueT - 0) * (1.0f - 0.1f) / (1000f - 0f) + 0.1f; // mapping Tsensor analog value onto the range (0-0.1)
        
        float valueColour = 1 - mappedT; // we need the opposite value for the needed shade in the green channel 
        
        main.startColor = new Color(1, valueColour, 0, 1); // setting values into the green channel in the RGBA parameters in order to change the colours of the rays towards red colour when temp goes up  

    }
}
