using UnityEngine;
using System.IO.Ports;
using System.Linq;

public class Sending : MonoBehaviour
{
    public string portName = "COM3";
    public static SerialPort sp;
    float timePassed = 0.0f;


void Start()
    {
        sp = new SerialPort("\\\\.\\" + portName, 9600);
        OpenConnection();
    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp.Open();            // opens the connection
                sp.ReadTimeout = 16;  // sets the timeout value before reporting error
                print("Port Opened!");
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
        Debug.Log("Close");
    }

    //Invia messaggio ad Arduino
    public void SendColor(string color){
        sp.Write(color);
        Debug.Log("enter: " + color);
    }

    public void SendExit(string exit) {
        sp.Write(exit);
        Debug.Log("Exit:" + exit);
    }

   public void SendWind(string windIntensity){
        sp.Write(windIntensity);
        Debug.Log("Wind:" + windIntensity);
    }


    /*
    public void SendGreen()
    {
        //Debug.Log("g+" + proximityValueForArduino);
        sp.Write("g");
    }

    public void SendBlue()
    {
        //Debug.Log("b+" + proximityValueForArduino);
        sp.Write("b");
    }

    public void SendRed()
    {
        //Debug.Log("r+" + proximityValueForArduino);
        sp.Write("r");
    }

    public void SendYellow()
    {
        //Debug.Log("y+" + proximityValueForArduino);
        sp.Write("y");
    }

    public void SendWhite()
    {
        //Debug.Log("w+" + proximityValueForArduino);
        sp.Write("w");
    }

    public void ExitGreen()
    {
        Debug.Log("EG");
        sp.Write("f");
    }

    public void ExitBlue()
    {
        Debug.Log("EB");
        sp.Write("v");
    }

    public void ExitRed()
    {
        Debug.Log("ER");
        sp.Write("e");
    }

    public void ExitYellow()
    {
        Debug.Log("EY");
        sp.Write("t");
    }

    public void ExitWhite()
    {
        Debug.Log("EW");
        sp.Write("q");
    }*/
}