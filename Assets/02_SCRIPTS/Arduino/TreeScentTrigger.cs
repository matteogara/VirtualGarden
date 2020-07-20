using System.Collections;
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
    private bool pickedUp;
    private bool enteredWhilePickedUp = false;

    private GameObject treeObj;

    void Update(){
        this.pickedUp = pickUpValues.pickedUp;
        
        this.toPlaceBack = pickUpValues.toPlaceBack;
        //Debug.Log("toplaceback tree: " + this.toPlaceBack);

        if(this.enteredWhilePickedUp == true && this.toPlaceBack == false){
            TriggerScent();
        }
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.name.StartsWith("TreeSmellCollider") || other.gameObject.name.StartsWith("BushSmellCollider")){

            treeObj = other.gameObject;

            if (this.pickedUp == true && this.toPlaceBack ==true){
                enteredWhilePickedUp = true;
            }

            if (this.toPlaceBack == false){
                TriggerScent();
            }
            

            //treeScent = treeObj.GetComponentInParent<ColorGrabber>().arduinoColor;
            //send.Invoke(treeScent);
            //Debug.Log("colore albero: " + treeScent);
        }
    }

    private void OnTriggerExit(Collider other){
        enteredWhilePickedUp = false;

        if (other.gameObject.name.StartsWith("TreeSmellCollider") || other.gameObject.name.StartsWith("BushSmellCollider")){
            Debug.Log("Fuori area treeScent");

            noTreeScent = treeScent.ToUpper();
            InOnExit.Invoke(noTreeScent);
        }
    }

    private void TriggerScent(){
        treeScent = treeObj.GetComponentInParent<ColorGrabber>().arduinoColor;
        send.Invoke(treeScent);
    }
}

