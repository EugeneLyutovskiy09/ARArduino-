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
        int analogValueT = manager.analogRead(AnalogPin.A0);
        int analogValuePh = manager.analogRead(AnalogPin.A5);
        var main = ps.main;

        float mappedLifeTime = (analogValuePh - 0) * (9f - 0f) / (250f - 0f) + 0f;
        float mappedOp = (analogValuePh - 0) * (1f - 0f) / (250f - 0f) + 0f;
        float valueLT = 9f - mappedLifeTime;
        float valueOp = 1f - mappedOp;

        if (analogValueT > 85)
        {
            main.startLifetime = 0;
        }
        else
        {
            main.startLifetime = valueLT;
        }

    }
}