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
        int analogValueT = manager.analogRead(AnalogPin.A0); // getting value from the t-sensor
        int analogValuePh = manager.analogRead(AnalogPin.A5); // getting value from the photoresistor (photosensor) 
        var main = ps.main;
        if (analogValueT > 90 && analogValuePh > 170 && analogValuePh < 230)
        {
            main.startLifetime = 1.66f; // rainbow appears only in strict conditions: when it rains and when the clouds are not thik enough and the sun rays can penetrate them. 
        else // No rainbow is possible when it snows, so temp also needs to be taken into account
        {
            main.startLifetime = 0f;   
        }
        }
    }
}
