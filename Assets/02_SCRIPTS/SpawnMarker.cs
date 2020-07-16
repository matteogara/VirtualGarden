using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMarker : MonoBehaviour
{
    public Texture[] markers;

    MeshRenderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeMarker(int _index)
    {
        renderer.material.mainTexture = markers[_index];
    }
}
