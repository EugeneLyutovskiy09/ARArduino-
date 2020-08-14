using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class Rainbow : MonoBehaviour
{
    UduinoManager manager;
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        manager = UduinoManager.Instance;
        ps = GetComponent<ParticleSystem>();
        var shape = ps.shape;
    }

    // Update is called once per frame
    void Update()
    {
        int analogValueT = manager.analogRead(AnalogPin.A0);
        int analogValuePh = manager.analogRead(AnalogPin.A5);
        var main = ps.main;
        if (analogValueT > 90 && analogValuePh > 170 && analogValuePh < 230)
        {
            main.startLifetime = 1.66f;
        }
        else
        {
            main.startLifetime = 0f;
        }
    }
}