using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreeScentTrigger : MonoBehaviour {

    [SerializeField]
    private PickUp pickUpValues;

    
    //private bool banana = false;

    void Update(){
       
    }

    void OnTriggerEnter(Collider other){
        if (pickUpValues.toPlaceBack == false && (other.gameObject.name.StartsWith("ArduinoTree") || other.gameObject.name.StartsWith("ArduinoBush"))){
            string arduinoColor = other.gameObject.GetComponent<ColorGrabber>().arduinoColor;
            Debug.Log("Colore collisione albero: " + arduinoColor);
        }
    }






    /* [SerializeField]
     private PickUp pickUpValues;

     public GameObject player;
     public ArduinoEvent send;
     public ArduinoEvent InOnExit;

     private bool flowerInHand;

    // public bool tracking = false;

     public SphereCollider collisionTriggerCollider;
    // public MeshCollider bodyCollider;

     void Start() {

     }

     void Update() {
         flowerInHand = pickUpValues.toPlaceBack;

         Debug.Log("Flower in hand: " + flowerInHand);
       //Detecta collisione
       if (tracking)  {
             float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.z - player.transform.position.z, 2)) - 0.25f;
             int proximityValueForArduino = 255 - Mathf.RoundToInt(distance* 255/collisionTriggerCollider.radius);
         } 
     }

     private void OnTriggerEnter(Collider other)  {
         if (other.gameObject.tag == "Player") {

             //Prendi il colore e invialo

             string arduinoColor = gameObject.GetComponent<ColorGrabber>().arduinoColor;
             send.Invoke(arduinoColor);
             //tracking = true;
         }
     }

     private void OnTriggerExit(Collider other) {

             //Prendi il colore, mettilo maiuscolo e invia
             string arduinoColor = gameObject.GetComponent<ColorGrabber>().arduinoColor;
             string exit = arduinoColor.ToUpper();

             InOnExit.Invoke(exit);


         if (other.gameObject == player)
         {
             tracking = false;

             //Prendi il colore, mettilo maiuscolo e invia
             string arduinoColor = gameObject.GetComponent<ColorGrabber>().arduinoColor;
             string exit = arduinoColor.ToUpper();

             InOnExit.Invoke(exit);
         }

     }*/
}

