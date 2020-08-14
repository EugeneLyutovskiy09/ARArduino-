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
        int analogValueT = manager.analogRead(AnalogPin.A0); // getting value from the thermoresistor (Tsensor) 
        int analogValuePh = manager.analogRead(AnalogPin.A5); // getting value from the photoresistor (Photosensor) 
        var main = ps.main;
        if (analogValueT > 250 && analogValuePh < 150) // as we do not need lightning to strike all the time, we set a limited condition: it only appears when temp exceeds 250 units and when the cloud is still at least partially there
        {
            main.startLifetime = 0.4f;
        }
        else
        {
            main.startLifetime = 0f;
        }
    }
}
