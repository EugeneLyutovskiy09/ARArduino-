using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class Lightning : MonoBehaviour
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
        if (analogValueT > 250 && analogValuePh < 150)
        {
            main.startLifetime = 0.4f;
        }
        else
        {
            main.startLifetime = 0f;
        }
    }
}