using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour{

    private Vector3 panelDestination;

    private GameObject panelObj;

    //questo potrebbe essere il valore della rotazione del controller, al momento lo modifico dall'inspector per debuggare
    public Quaternion controllerRotation;
   
    void Start(){
        panelObj = GameObject.Find("Panel");
    }

    void Update(){
        panelDestination = GameObject.Find("panelDestination").transform.position;
        Debug.Log("Panel destination: " + panelDestination);

        //controllerRotation = GameObject.Find("NOME CONTROLLER").transform.rotation;
        //Debug.Log("Panel rotation: " + controllerRotation);

        panelObj.transform.position = panelDestination;

        panelObj.transform.rotation = controllerRotation;

    }
}
