using UnityEngine;
using System.Collections;
using Uniduino;

public class NimoController : MonoBehaviour
{

    public Arduino arduino;
    public int pinValueX;
    public int i;
    public float speed = 0.1f;

    private GameObject nimo;
   // private GameObject cube;
    //public Transform Cube;

    // Use this for initialization
    void Start()
    {
        arduino = Arduino.global;
        arduino.Setup(ConfigurePins);

        nimo = GameObject.Find("nimo");
    }
    void ConfigurePins()
    {
        // Use Analog output 0 pin
        arduino.pinMode(0, PinMode.ANALOG);

        arduino.reportAnalog(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        pinValueX = arduino.analogRead(0);

        if (pinValueX > 200) {
            double degX = Mathf.Atan2(pinValueX, -1) / 3.14159 * 180.0 * 100;

            nimo.transform.rotation = Quaternion.Euler((float)degX, 90, 180);
            i++;
            if(i > 950){
                transform.Rotate(-40, 0, 0);
            }
        }
        else{
            transform.rotation = Quaternion.Euler(0, 90, 180);
            if (i > 1000 && i < 1030){
                transform.position += transform.up * speed;
            }else if(i > 1030 || i < 999){
                i = 0;
            }
        }
        /*
        if(pinValueX > 400){

            transform.rotation = Quaternion.Euler(-30, 90, 180);

        }else
        {
            transform.rotation = Quaternion.Euler(0, 90, 180);
        }
        */
    }
}