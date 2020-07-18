using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;


public class PickUp : MonoBehaviour {
    
    public ArduinoEvent send;
    public ArduinoEvent InOnExit;

    [SerializeField]
    private PickUpInstr pickupValues;

    private bool pickedUp;
    private bool inPickArea;
    private bool toPlaceBack = false;

    public Transform destinationObj;

    //private Vector3 currentFlowerPosition;
    private Vector3 pickDestination;
    public Vector3 initialFlowerPosition;

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

            string arduinoColor = gameObject.GetComponent<ColorGrabber>().arduinoColor;
            send.Invoke(arduinoColor);

            toPlaceBack = true;

        } else if (pickedUp==false){
            this.transform.position = initialFlowerPosition;
            if (toPlaceBack == true){
                string arduinoColor = gameObject.GetComponent<ColorGrabber>().arduinoColor;
                string exit = arduinoColor.ToUpper();
                InOnExit.Invoke(exit);
                toPlaceBack = false;
            }
        }
    }
    
}
