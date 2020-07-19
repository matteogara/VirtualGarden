using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
//using static ColorGrabber;


public class PickUp : MonoBehaviour {

    public bool pickedUp = false;
    public bool inPickArea = false;
    public bool toPlaceBack = false;

    private GameObject destinationObj;
    private GameObject flowerObj;

    private bool banana = false;

   // private Collider flowerCollider;

    private Vector3 pickDestination;
    public Vector3 initialFlowerPosition;

    void Start(){
        // Assegna DestinationPickUp alla variabile
        destinationObj = GameObject.Find("DestinationPickUp");
        //Debug.Log(destinationObj.name);
    }

    void Update(){

        //Aggiorna la posizione di destinazione del pick
        pickDestination = destinationObj.transform.position;
        

        //Cambia lo status di pickedUp a seconda dei tasti
        if (inPickArea == true && pickedUp == false && Input.GetKey("e")){
            pickedUp = true;
            //Debug.Log("Picked up status: " + pickedUp);
        } else if (pickedUp == true && Input.GetKey("q")){
            pickedUp = false;
            //Debug.Log("Picked up status: " + pickedUp);
        }

        //Cambia la posizione di flowerObj a seconda di pickedUp
        if(pickedUp == true){
            flowerObj.transform.position = pickDestination;
            toPlaceBack = true;
        } else if (pickedUp == false && toPlaceBack == true){
            flowerObj.transform.position = initialFlowerPosition;
            toPlaceBack = false;
        }

        //Disattiva o attiva collider se il fiore è in mano o no
        /*if (toPlaceBack == true){
            flowerCollider.enabled = false;
           //Debug.Log("Collider fiore disattivato");
        } else if (toPlaceBack == false){
            flowerCollider.enabled = true;
        }*/
    }

    void OnTriggerEnter(Collider other){
        /*Debug.Log("Place Back status: " + toPlaceBack);
        Debug.Log("FlowerObj: " + flowerObj);
        Debug.Log("Oggetto collisione: " + other.gameObject.name);
        Debug.Log("in pick area status: " + inPickArea);*/

        if(toPlaceBack == true){
            Debug.Log("Non posso entrare");
        }

        
        if (toPlaceBack == false){
            Debug.Log(toPlaceBack);
            if (other.gameObject.name.StartsWith("ArduinoTestFiore")){

                //Assegna other alla variabile, ricorda la sua posizione, attiva inPickArea
                flowerObj = other.gameObject;

                //flowerObj.AddComponent<ColorGrabber>();

                initialFlowerPosition = flowerObj.transform.position;
                inPickArea = true;

                //Prendi il colore di flowerObj
                //string arduinoColor = flowerObj.GetComponent<ColorGrabber>().arduinoColor;
                //Debug.Log("arduinoColor");

                //Debug.Log("Dentro area pickUp");

                Debug.Log("CAZZOCollisione con: " + flowerObj.name + "\n Posizione: " + initialFlowerPosition);
            }
        }

    }

    void OnTriggerExit(Collider other){

        //Controlla se l'oggetto other è flowerObj
        if (other.gameObject == flowerObj){
            inPickArea = false;
            //Debug.Log("Fuori area pickUp");
        }

    }
        



    /* public ArduinoEvent send;
     public ArduinoEvent InOnExit;

     [SerializeField]
     private PickUpInstr pickupValues;

     private bool pickedUp = false;
     private bool inPickArea = false;
     private bool toPlaceBack = false;

     private GameObject destinationObj;
     private GameObject flowerObj;


     //private Vector3 currentFlowerPosition;
     private Vector3 pickDestination;
     public Vector3 initialFlowerPosition;

     void Start(){
         destinationObj = GameObject.Find("DestinationPickUp");
     }

     void Update(){
         pickDestination = destinationObj.transform.position;
         //Debug.Log("Destination: " + pickDestination);

         if (pickedUp == true){
             flowerObj.transform.position = pickDestination;
             Debug.Log("Posizione su pick");
             // string arduinoColor = flowerObj.GetComponent<ColorGrabber>().arduinoColor;
             // send.Invoke(arduinoColor);

             toPlaceBack = true;

         } else if (pickedUp == false){
             flowerObj.transform.position = initialFlowerPosition;
             if (toPlaceBack == true){
               //  string arduinoColor = flowerObj.GetComponent<ColorGrabber>().arduinoColor;
               //  string exit = arduinoColor.ToUpper();
               //  InOnExit.Invoke(exit);
                 toPlaceBack = false;
             }
         } else if (pickedUp == false && inPickArea == true && Input.GetKey("e")){
             pickedUp = true;
             Debug.Log("Picked: " + pickedUp);
         } else if (pickedUp == true && Input.GetKey("q")){
             pickedUp = false;
             Debug.Log("Picked: " + pickedUp);
         }
     }

     void OnTriggerEnter(Collider other){

         if (other.gameObject.name.StartsWith("ArduinoTestFiore")){
             flowerObj = other.gameObject;
             initialFlowerPosition = flowerObj.transform.position;
             Debug.Log("Posizione fiore: " + initialFlowerPosition);
             inPickArea = true;
             Debug.Log("Dentro area");
         }
     }

     void OnTriggerExit(Collider other){
         inPickArea = false;
         Debug.Log("Fuori area");
     }*/
}
