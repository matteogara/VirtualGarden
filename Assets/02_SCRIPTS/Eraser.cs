using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    public MovePointer movePointer;


    private void OnTriggerEnter(Collider other)
    {
        if (movePointer.validPointer) {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
