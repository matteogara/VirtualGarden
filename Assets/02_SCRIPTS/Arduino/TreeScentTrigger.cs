﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreeScentTrigger : MonoBehaviour {

    [SerializeField]
    private PickUp pickUpValues;

    public ArduinoEvent send;
    public ArduinoEvent InOnExit;

    public string treeScent;
    public string noTreeScent;

    private bool toPlaceBack;

    private GameObject treeObj;

    void Update(){
        this.toPlaceBack = pickUpValues.toPlaceBack;
        Debug.Log("toplaceback tree: " + this.toPlaceBack);
    }

    private void OnTriggerEnter(Collider other){

        if (this.toPlaceBack == false && (other.gameObject.name.StartsWith("TreeSmellCollider") || other.gameObject.name.StartsWith("BushSmellCollider"))){
            treeObj = other.gameObject;
            Debug.Log("Dentro area treeScent");

            treeScent = treeObj.GetComponentInParent<ColorGrabber>().arduinoColor;
            send.Invoke(treeScent);
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.name.StartsWith("TreeSmellCollider") || other.gameObject.name.StartsWith("BushSmellCollider")){
            Debug.Log("Fuori area treeScent");

            noTreeScent = treeScent.ToUpper();
            InOnExit.Invoke(noTreeScent);
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

