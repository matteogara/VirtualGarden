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

    private Vector3 pickDestinationFlower;
    private Vector3 pickDestinationMush;
    public Vector3 initialFlowerPosition;
    

    void Start(){
        // Assegna DestinationPickUp alla variabile
       destinationObj = GameObject.Find("DestinationPickUp");
       //Debug.Log(destinationObj.name);
    }

    void Update(){

        //Debug.Log("thistoplaceback pickup: " + this.toPlaceBack);
        //Aggiorna la posizione di destinazione del pick
        pickDestinationFlower = destinationObj.transform.position;
        pickDestinationMush = destinationObj.transform.position - new Vector3(1, 0, 1);
        Debug.Log("pickdestinationflower: " + pickDestinationFlower);
        Debug.Log("pickdestinationmush: " + pickDestinationMush);


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
            if (this.mushy == false){
                flowerObj.transform.parent.position = pickDestinationFlower;
            } else if (this.mushy == true){
                flowerObj.transform.parent.position = pickDestinationMush;
            }
            
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

            if (other.gameObject.name.StartsWith("FlowerSmellCollider")){
                this.mushy = false;
            } else if (other.gameObject.name.StartsWith("MushSmellCollider")){
                this.mushy = true;
            }

            flowerObj = other.gameObject;
            initialFlowerPosition = flowerObj.transform.position;
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
