using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;


public class PickUp : MonoBehaviour {

    public ArduinoEvent send;
    public ArduinoEvent InOnExit;

    public bool pickedUp = false;
    public bool inPickArea;
    public bool toPlaceBack = false;

    public string flowerScent;
    public string noFlowerScent;

    private GameObject destinationObj;
    private GameObject flowerObj;

    private Vector3 pickDestination;
    public Vector3 initialFlowerPosition;
    

    void Start(){
       
        // Assegna DestinationPickUp alla variabile
       destinationObj = GameObject.Find("DestinationPickUp");
    }

    void Update(){

        //Aggiorna la posizione di destinazione del pick
        pickDestination = destinationObj.transform.position;

        //Cambia lo status di pickedUp a seconda dei tasti
        if (this.inPickArea == true && this.pickedUp == false && Input.GetKey("e")){
            this.pickedUp = true;
            send.Invoke(flowerScent);
            Debug.Log("FIORE/MUSH: in mano e profumo attivato");
        } else if (this.pickedUp == true && Input.GetKey("q")){
            this.pickedUp = false;
            InOnExit.Invoke(noFlowerScent);
            Debug.Log("FIORE/MUSH: a terra e profumo disattivato");
        }

        //Cambia la posizione di flowerObj a seconda di pickedUp
        if(this.pickedUp == true){
            flowerObj.transform.parent.position = pickDestination;         
            this.toPlaceBack = true;
        } else if (this.pickedUp == false && this.toPlaceBack == true){
            flowerObj.transform.parent.position = initialFlowerPosition;
            this.toPlaceBack = false;
        }

    }

    private void OnTriggerEnter(Collider other){
       
        if (this.toPlaceBack == false && other.gameObject.transform.parent.tag == "Spawn_Grass"){

            flowerObj = other.gameObject;
            initialFlowerPosition = flowerObj.transform.parent.position;

            //flowerScent = flowerObj.GetComponentInParent<ColorGrabber>().arduinoColor;

            //la versione maiuscola della lettera del colore su Arduino triggera l'OFF del led corrispondente
            //noFlowerScent = flowerScent.ToUpper();
            Debug.Log("FIORE/MUSH: colore rilevato = " + flowerScent);

            this.inPickArea = true;
        }

    }

    private void OnTriggerExit(Collider other){
        
        if (other.gameObject == flowerObj){
            this.inPickArea = false;
        }

    }
}
