using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContactTrigger : MonoBehaviour {
    public GameObject player;
    public ArduinoEvent send;
    public ArduinoEvent InOnExit;
    public bool tracking = false;

    public SphereCollider collisionTriggerCollider;
    public MeshCollider bodyCollider;

    void Start() {
        
    }
    
    void Update() {

      //Detecta collisione
      if (tracking)  {
            float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.z - player.transform.position.z, 2)) - 0.25f;
            int proximityValueForArduino = 255 - Mathf.RoundToInt(distance* 255/collisionTriggerCollider.radius);
        }  
    }

    private void OnTriggerEnter(Collider other)  {
        if (!tracking && other.gameObject==player) {
          
            //Prendi il colore e invialo
            string arduinoColor = gameObject.GetComponent<ColorGrabber>().arduinoColor;
            send.Invoke(arduinoColor);
            tracking = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject == player) {
            tracking = false;
            
            //Prendi il colore, mettilo maiuscolo e invia
            string arduinoColor = gameObject.GetComponent<ColorGrabber>().arduinoColor;
            string exit = arduinoColor.ToUpper();
            
            InOnExit.Invoke(exit);
        }
        
    }
}

