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
        int analogValuePh = manager.analogRead(AnalogPin.A5);
        int analogValueT = manager.analogRead(AnalogPin.A0);
        var main = ps.main;

        float mappedPh = (analogValuePh - 0) * (9f - 0f) / (250f - 0f) + 0f;
        float mappedOp = (analogValuePh - 0) * (1f - 0f) / (250f - 0f) + 0f;
        float valueLT = 9f - mappedPh;
        float valueOp = 1f - mappedOp;

        if (analogValuePh > 250)
        {
            main.startColor = new Color(0.7809719f, 0.7884073f, 0.8490566f, 0f);
            main.startLifetime = 0;
        }
        else {
            main.startLifetime = valueLT;
            main.startColor = new Color(0.7809719f, 0.7884073f, 0.8490566f, valueOp);
        }

    }
}
