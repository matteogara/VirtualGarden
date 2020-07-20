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

        if (other.gameObject.transform.parent.tag == "Spawn_Tree" || other.gameObject.transform.parent.tag == "Spawn_Bush"){

            treeObj = other.gameObject;

            if (this.pickedUp == true && this.toPlaceBack ==true){
                enteredWhilePickedUp = true;
            }

            if (this.toPlaceBack == false){
                TriggerScent();
            }
        }
    }

    private void OnTriggerExit(Collider other){
        enteredWhilePickedUp = false;

        if (other.gameObject.transform.parent.tag == "Spawn_Tree" || other.gameObject.transform.parent.tag == "Spawn_Bush"){
            noTreeScent = treeScent.ToUpper();
            InOnExit.Invoke(noTreeScent);
            Debug.Log("ALBERO/BUSH: fuori area e profumo disttivato");
        }
    }

    private void TriggerScent(){
        treeScent = treeObj.GetComponentInParent<ColorGrabber>().arduinoColor;
        Debug.Log("ALBERO/BUSH: colore rilevato = " + treeScent);

        send.Invoke(treeScent);
        Debug.Log("ALBERO/BUSH: in area e profumo attivato");
    }
}

