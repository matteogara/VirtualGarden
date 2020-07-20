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

    private bool mushy = false;

    public string flowerScent;
    public string noFlowerScent;

    private GameObject destinationObj;
    private GameObject flowerObj;

    private Vector3 pickDestination;
    public Vector3 initialFlowerPosition;
    

    void Start(){
        // Assegna DestinationPickUp alla variabile
       destinationObj = GameObject.Find("DestinationPickUp");
       //Debug.Log(destinationObj.name);
    }

    void Update(){

        //Debug.Log("thistoplaceback pickup: " + this.toPlaceBack);
        //Aggiorna la posizione di destinazione del pick
        pickDestination = destinationObj.transform.position;
        Debug.Log("pickdestinationflower: " + pickDestination);

        //Cambia lo status di pickedUp a seconda dei tasti
        if (this.inPickArea == true && this.pickedUp == false && Input.GetKey("e")){
            this.pickedUp = true;
            send.Invoke(flowerScent);
            Debug.Log("Picked up status: " + pickedUp);
        } else if (this.pickedUp == true && Input.GetKey("q")){
            this.pickedUp = false;
            InOnExit.Invoke(noFlowerScent);
            Debug.Log("Picked up status: " + pickedUp);
        }

        //Cambia la posizione di flowerObj a seconda di pickedUp
        if(this.pickedUp == true){
            flowerObj.transform.parent.position = pickDestination;         
            this.toPlaceBack = true;
            Debug.Log("Il fiore si sposta");
        } else if (this.pickedUp == false && this.toPlaceBack == true){
            flowerObj.transform.parent.position = initialFlowerPosition;
            this.toPlaceBack = false;
            Debug.Log("Il fiore ritorna al suo posto");
        }
    }

    private void OnTriggerEnter(Collider other){
        if (this.toPlaceBack == false && (other.gameObject.name.StartsWith("FlowerSmellCollider") || other.gameObject.name.StartsWith("MushSmellCollider"))){

            flowerObj = other.gameObject;
            initialFlowerPosition = flowerObj.transform.parent.position;
            Debug.Log("Fiore toccato: " + flowerObj.name);

            flowerScent = flowerObj.GetComponentInParent<ColorGrabber>().arduinoColor;
            noFlowerScent = flowerScent.ToUpper();

            this.inPickArea = true;
            Debug.Log("Dentro area pickUp");
        }
    }

    private void OnTriggerExit(Collider other){

        if (other.gameObject == flowerObj){
            this.inPickArea = false;
            Debug.Log("Fuori area pickUp");
        }
    }
}
