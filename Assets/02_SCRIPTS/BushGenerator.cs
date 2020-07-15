using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushGenerator : MonoBehaviour
{
    [Header("Models")]
    public GameObject bush;

    [Header("Materials")]
    public Material bushMat;

    [Header("bush settings")]
    public float bushMinScale = .7f;
    public float bushMaxScale = 1.2f;

    private float count;
    private int brDeltaH;
    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject CreateBush(Vector3 _pos) {
        // Create object
        GameObject _bush = new GameObject("bush_" + count);
        count++;

        // Create trunk
        // var _trunk = Instantiate(trunk, Vector3.zero, Quaternion.Euler(-90, Random.Range(0, 360), 0));
        // _trunk.GetComponent<MeshRenderer>().material = trMat;
        // _trunk.transform.parent = _bush.transform;
        // float _trR = Random.Range(bushMinScale, bushMaxScale);
        // float _trH = Random.Range(bushMinScale, bushMaxScale);
        // _trunk.transform.localScale = new Vector3(_trR, _trR, _trH);


        // Create brenches
        // float _brenchNum = Random.Range(1, 5);
        // for (int i = 0; i < _brenchNum; i++) {
        //     var _brench = Instantiate(brench, Vector3.zero, Quaternion.Euler(-90, Random.Range(0, 360), 90));
        //     _brench.GetComponent<MeshRenderer>().material = trMat;
        //     float _z = Random.Range(brMinH, brMaxH);
        //     float s;
        //     if (largerBrenchesBelow)
        //     {
        //         s = (Random.Range(brMinScale, brMaxScale) + (brMaxH - _z) / brDeltaH) / 2;
        //     }
        //     else
        //     {
        //         s = Random.Range(brMinScale, brMaxScale);
        //     }
        //     _brench.transform.localScale = new Vector3(s, s, s);
        //     _brench.transform.parent = _trunk.transform;
        //     _brench.transform.localPosition = new Vector3(0, 0, _z);


        // Set position
        _bush.transform.position = _pos;

        return _bush;
    }
}
