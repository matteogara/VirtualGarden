using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContactTrigger : MonoBehaviour {
    public GameObject player;
    public ArduinoEvent send;
    public ArduinoEvent InOnExit;
    public bool tracking = false;

    public SphereCollider collisionTriggerCollider;
    public SphereCollider bodyCollider;

    void Start() {
        
    }
    
    void Update() {
      if (tracking)  {
            float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.z - player.transform.position.z, 2)) - 0.25f;
            int proximityValueForArduino = 255 - Mathf.RoundToInt(distance* 255 /collisionTriggerCollider.radius);
            //Debug.Log("proximity: " + Mathf.RoundToInt(distance * 255 / collisionTriggerCollider.radius));
            send.Invoke(proximityValueForArduino.ToString());
        }  
    }

    private void OnTriggerEnter(Collider other)  {
        if (!tracking && other.gameObject==player) {
            Debug.Log("entering: " + other.gameObject.name);
           // player = other.gameObject;
            tracking = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject == player) {
            tracking = false;
            Debug.Log("exiting: " + other.gameObject.name);
            InOnExit.Invoke("");
        }
        
    }
}

