﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
    /*
    void Update(){
        public Transform theDest;
}*/

    void OnMouseDown(){
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    void OnMouseUp(){
        this.transform.parent = null;
    }
}
