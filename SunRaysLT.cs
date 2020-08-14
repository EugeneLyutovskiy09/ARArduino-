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
        int analogValueT = manager.analogRead(AnalogPin.A0);
        int analogValuePh = manager.analogRead(AnalogPin.A5);
        var main = ps.main;
        main.startLifetime = 1;
        //float mappedT = analogValueT / 100;

        float mappedPh = (analogValuePh - 0) * (7f - 0f) / (490f - 0f) + 0.1f;
        //float value = 0.5f - mappedPh;
           
            main.startSpeed = mappedPh;

        // float mappedPh = (analogValuePh - 0) * (2f - 0.1f) / (250f - 0f) + 0.1f;
        //main.startLifetime = mappedPh;

        float mappedT = (analogValueT - 0) * (1.0f - 0.1f) / (1000f - 0f) + 0.1f;
        float valueColour = 1 - mappedT;
        main.startColor = new Color(1, valueColour, 0, 1);

    }
}