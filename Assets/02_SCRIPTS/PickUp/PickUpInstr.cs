using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpInstr : MonoBehaviour{
    [SerializeField]
    private PickUp pickUpValues;

    private Text pickUpText;
    private Text placeBackText;

    private bool inPickArea;
    private bool pickedUp;
    private bool toPlaceBack;

    private Vector3 textPosition;

    void Start(){
        pickUpText = GameObject.Find("PickUpText").GetComponent<Text>();
        placeBackText = GameObject.Find("PlaceBackText").GetComponent<Text>();

        pickUpText.text = "";
        placeBackText.text = "";
   
    }

    void Update(){
        inPickArea = pickUpValues.inPickArea;
        pickedUp = pickUpValues.pickedUp;
        toPlaceBack = pickUpValues.toPlaceBack;

        //Debug.Log(toPlaceBack + " trovato");

        pickUpText.transform.position = textPosition;
        placeBackText.transform.position = textPosition;

        pickUpText.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        placeBackText.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        if (inPickArea == true){
            textPosition = pickUpValues.initialFlowerPosition + new Vector3(0, 2, 0);
            pickUpText.text = "Press E \nto pick it up";
            placeBackText.text = "";
        } else if (inPickArea == false && pickedUp == false){
            pickUpText.text = "";
            placeBackText.text = "";
        } 
        
        if (pickedUp == true) {
            placeBackText.text = "Press Q \nto place it back";
            pickUpText.text = "";
        } 

    }

    void writePickText(){
        pickUpText.text = "Press E \nto pick it up";
    }

    void writePlaceText(){
        pickUpText.text = "Press Q \nto place it back";
    }

    void writeNothing(){
        pickUpText.text = "";
    }


    /* [SerializeField]
     private PickUp flowerValues;

     public Text pickUpText;

     public bool pickedUp = false;
     public bool inPickArea = false;

     private Vector3 textPosition;

     void Start(){
         pickUpText.text = "";
         textPosition = flowerValues.initialFlowerPosition + new Vector3(0, 2, 0);

         pickUpText.transform.position = textPosition;

         Debug.Log("text position: " + textPosition);
     }

     void Update(){

         if (pickedUp==false && inPickArea == false){
             writeNothing();
         } else if (pickedUp == false && inPickArea == true){
             writePickText();
             pickUpText.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
         } else if (pickedUp == true){
             writePlaceText();
             pickUpText.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
         }

         if (pickedUp == false && inPickArea == true && Input.GetKey("e")){
             pickedUp = true;
             Debug.Log("Picked: " + pickedUp);
         } else if (pickedUp == true && Input.GetKey("q")){
             pickedUp = false;
             Debug.Log("Picked: " + pickedUp);
         }

     }

     void OnTriggerEnter(Collider other){

         if (other.gameObject.tag == "Player"){
             inPickArea = true;
             Debug.Log("Dentro area");
         }

     }

     void OnTriggerExit(Collider other){
         inPickArea = false;
         Debug.Log("Fuori area");
     }

     void writePickText(){
         pickUpText.text = "Press E \nto pick it up";
     }

     void writePlaceText(){
         pickUpText.text = "Press Q \nto place it back";
     }

     void writeNothing(){
         pickUpText.text = "";
     }*/


}
