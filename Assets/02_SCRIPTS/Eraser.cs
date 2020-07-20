using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    public MovePointer movePointer;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Eraser");
        if (movePointer.validPointer && Input.GetKey(KeyCode.Mouse0)) {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
