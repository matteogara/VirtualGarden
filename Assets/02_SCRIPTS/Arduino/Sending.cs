using UnityEngine;
using System.IO.Ports;
using System.Linq;

public class Sending : MonoBehaviour{
    public string portName = "COM3";
    public static SerialPort sp;
    float timePassed = 0.0f;


void Start(){
       sp = new SerialPort("\\\\.\\" + portName, 9600);
        OpenConnection();
}

public void OpenConnection(){
        if (sp != null){
            if (sp.IsOpen){
                sp.Close();
                print("Closing port, because it was already open!");
            } else {
                sp.Open();            // opens the connection
                sp.ReadTimeout = 16;  // sets the timeout value before reporting error
                print("Port Opened!");
           }
        } else {
            if (sp.IsOpen){
                print("Port is already open");
            } else {
                print("Port == null");
            }
        }
    }

    void OnApplicationQuit(){

        // Null reference exception handling
        if (sp != null)
        {
            sp.Close();
            Debug.Log("Close");
        }

    }

    //Invia messaggio ad Arduino
    public void SendColor(string color){
        sp.Write(color);
   }

    public void SendExit(string exit) {
        sp.Write(exit);
    }

   public void SendWind_R(string windIntensity){
        sp.Write(windIntensity);
    }

    public void SendWind_L(string windIntensity){
        sp.Write(windIntensity);
    }
}
