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

    [Header("body settings")]
    public float bodyMinScale = 0.5f;
    public float bodyMaxScale = 1f;

    [Header("head settings")]
    public float headMinScale = 1f;
    public float headMaxScale = 1.5f;
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
        var _body = Instantiate(body[index], Vector3.zero, Quaternion.Euler(Random.Range(-80, -100), Random.Range(0, 360), 0));
        _body.GetComponent<MeshRenderer>().material = bodyMat;
        float _bodyR = Random.Range(bodyMinScale, bodyMaxScale);
        float _bodyH = Random.Range(bodyMinScale, bodyMaxScale);
        _body.transform.localScale = new Vector3(_bodyR, _bodyR, _bodyH);
        _body.transform.parent = _mushrooms.transform;

        // Create head
        index = Random.Range(0, head.Count - 1);
        var _head = Instantiate(head[index], Vector3.zero, Quaternion.Euler(Random.Range(-85, -95), Random.Range(0, 360), 0));
        _head.GetComponent<MeshRenderer>().material = headMat;
        float _headR = Random.Range(headMinScale, headMaxScale);
        float _headH = Random.Range(headMinScale, headMaxScale);
        _head.transform.localScale = new Vector3(_headR, _headR, _headH);
        _head.transform.parent = _body.transform;
        _head.transform.localPosition = new Vector3(0, 0, 1.75f);

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
