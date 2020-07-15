﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree2Generator : MonoBehaviour
{
    [Header("Models")]
    public GameObject trunk;
    public GameObject brench;
    public GameObject foliage;

    [Header("Materials")]
    public Material trMat;
    public Material folMat;

    [Header("Trunk settings")]
    public float trMinScale = .7f;
    public float trMaxScale = 1.2f;

    [Header("Brenches settings")]
    public int brMinH = 2;
    public int brMaxH = 6;
    public float brMinScale = .8f;
    public float brMaxScale = .3f;
    public bool largerBrenchesBelow = true;

    [Header("Foliage settings")]
    public float folMinScale = .5f;
    public float folMaxScale = 1f;
    public Vector3 folOffset = new Vector3(-1.5f, 0, 1.45f);

    private float count;
    private int brDeltaH;


    // Start is called before the first frame update
    void Start()
    {
        brDeltaH = Mathf.Abs(brMaxH - brMinH);
    }


    public GameObject CreateTree(Vector3 _pos) {
        // Create object
        GameObject _tree = new GameObject("Tree_" + count);
        count++;

        // Create trunk
        var _trunk = Instantiate(trunk, Vector3.zero, Quaternion.Euler(-90, Random.Range(0, 360), 0));
        _trunk.GetComponent<MeshRenderer>().material = trMat;
        _trunk.transform.parent = _tree.transform;
        float _trR = Random.Range(trMinScale, trMaxScale);
        float _trH = Random.Range(trMinScale, trMaxScale);
        _trunk.transform.localScale = new Vector3(_trR, _trR, _trH);

        // Create trunk foliage
        var _trFol = Instantiate(foliage, Vector3.zero, Quaternion.Euler(-90, 0, 0));
        _trFol.GetComponent<MeshRenderer>().material = folMat;
        float _folR = Random.Range(folMinScale, folMaxScale);
        float _folH = Random.Range(folMinScale, folMaxScale) / _trH;
        _trFol.transform.localScale = new Vector3(_folR, _folR, _folR);
        _trFol.transform.parent = _trFol.transform;
        _trFol.transform.localPosition = new Vector3(0, 0, 1);


        // Create brenches
        float _brenchNum = Random.Range(1, 5);
        for (int i = 0; i < _brenchNum; i++) {
            var _brench = Instantiate(brench, Vector3.zero, Quaternion.Euler(-90, Random.Range(0, 360), 90));
            _brench.GetComponent<MeshRenderer>().material = trMat;
            float _z = Random.Range(brMinH, brMaxH);
            float s;
            if (largerBrenchesBelow)
            {
                s = (Random.Range(brMinScale, brMaxScale) + (brMaxH - _z) / brDeltaH) / 2;
            }
            else
            {
                s = Random.Range(brMinScale, brMaxScale);
            }
            _brench.transform.localScale = new Vector3(s, s, s);
            _brench.transform.parent = _trunk.transform;
            _brench.transform.localPosition = new Vector3(0, 0, _z);

            // Create brench foliage
            _trFol = Instantiate(foliage, Vector3.zero, Quaternion.Euler(-90, 0, 0));
            _trFol.GetComponent<MeshRenderer>().material = folMat;
            _folR = Random.Range(folMinScale, folMaxScale);
            _folH = Random.Range(folMinScale, folMaxScale) / _trH;
            _trFol.transform.localScale = new Vector3(_folR, _folR, _folR);
            _trFol.transform.localPosition = new Vector3(0, 0, 1);

        }

        // Set position
        _tree.transform.position = _pos;

        return _tree;
    }
}
