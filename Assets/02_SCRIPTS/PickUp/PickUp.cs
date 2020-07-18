using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PickUp : MonoBehaviour {

    [SerializeField]
    private PickUpInstr pickupValues;

    private bool pickedUp;
    private bool inPickArea;

    public Transform destinationObj;

    //private Vector3 currentFlowerPosition;
    private Vector3 pickDestination;
    private Vector3 initialFlowerPosition;

    void Start(){
        initialFlowerPosition = gameObject.transform.position;
        //Debug.Log("Flower: " + initialFlowerPosition);       
    }

    void Update(){
        pickDestination = destinationObj.position;
        //Debug.Log("Destination: " + pickDestination);

        pickedUp = pickupValues.pickedUp;
        inPickArea = pickupValues.inPickArea;

        if (pickedUp==true){
            this.transform.position = pickDestination;
        } else if (pickedUp==false){
            this.transform.position = initialFlowerPosition;
        }
    }
    
}
