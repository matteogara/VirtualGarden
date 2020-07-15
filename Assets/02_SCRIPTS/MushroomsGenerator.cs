﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomsGenerator : MonoBehaviour
{
    [Header("Models")]
    public List<GameObject> body = new List<GameObject>();
    public List<GameObject> head = new List<GameObject>();

    [Header("Materials")]
    public Material bodyMat;
    public Material headMat;

    [Header("head settings")]
    public Vector3 headOffset = new Vector3(-1.5f, 0, 1.45f);

    private float count;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DeleteMushrooms();
            CreateMushrooms(transform.position);
        }
    }


    public void CreateMushrooms(Vector3 _pos) {
        // Create object
        GameObject _mushrooms = new GameObject("mushrooms_" + count);
        count++;

        // Create body
        int index = Random.Range(0, body.Count - 1);
        var _body = Instantiate(body[index], Vector3.zero, Quaternion.Euler(-90, Random.Range(0, 360), 0));
        _body.GetComponent<MeshRenderer>().material = bodyMat; //materiale
        _body.transform.parent = _mushrooms.transform;

        // Create body foliage
        index = Random.Range(0, head.Count - 1);
        var _head = Instantiate(head[index], Vector3.zero, Quaternion.Euler(-90, Random.Range(0, 360), 0));
        _head.GetComponent<MeshRenderer>().material = headMat;
        _head.transform.parent = _body.transform;
        _head.transform.localPosition = new Vector3(0, 0, 2f);

        // Set position
        _mushrooms.transform.position = _pos;
    }


    void DeleteMushrooms() {
        GameObject _mushrooms = GameObject.Find("mushrooms_" + (count - 1));
        if (_mushrooms != null) {
            Destroy(_mushrooms);
        }
    }
}