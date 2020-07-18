using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpInstr : MonoBehaviour{

    public Text pickUpText;
   
    public bool pickedUp = false;
    public bool inPickArea = false;

    void Start(){
        pickUpText.text = "";
    }

    void Update(){
     
        if(pickedUp==false && inPickArea == false){
            writeNothing();
        } else if (pickedUp == false && inPickArea == true){
            writePickText();
        } else if (pickedUp == true){
            writePlaceText();
        }

        if (pickedUp == false && inPickArea == true && Input.GetKey("e")){
            pickedUp = true;
            //Debug.Log("Picked: " + pickedUp);
        } else if (pickedUp == true && Input.GetKey("q")){
            pickedUp = false;
           // Debug.Log("Picked: " + pickedUp);
        }

    }

    void OnTriggerEnter(Collider other){
       
        if (other.gameObject.tag == "Player"){
            inPickArea = true;
           // Debug.Log("Dentro area");
        }

    }

    void OnTriggerExit(Collider other){
        inPickArea = false;
       // Debug.Log("Fuori area");
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


}
