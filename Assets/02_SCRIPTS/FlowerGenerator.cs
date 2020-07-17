using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGenerator : MonoBehaviour
{
    [Header("Models")]
    // public List<GameObject> stem = new List<GameObject>();
    public GameObject stem1;
    public GameObject stem2;
    public GameObject stem3;
    public List<GameObject> corolla = new List<GameObject>();

    [Header("Materials")]
    public Material stemMat;
    public Material corollaMat;

    [Header("corolla settings")]
    public Vector3 corollaOffset = new Vector3(-1.5f, 0, 1.45f);

    private float count;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DeleteFlower();
            CreateFlower(transform.position);
        }

    }


    public void CreateFlower(Vector3 _pos) {
        // Create object
        GameObject _flower = new GameObject("flower_" + count);
        count++;

        // Create stem
        //int index = Random.Range(0, stem.Count - 1);
        var _stem1 = Instantiate(stem1, Vector3.zero, Quaternion.Euler(-90, 0, 0));
        _stem1.GetComponent<MeshRenderer>().material = stemMat;
        _stem1.transform.parent = _flower.transform;

        var _stem2 = Instantiate(stem2, Vector3.zero, Quaternion.Euler(-90, 0, 0));
        _stem2.GetComponent<MeshRenderer>().material = stemMat;
        _stem2.transform.parent = _flower.transform;

        var _stem3 = Instantiate(stem3, Vector3.zero, Quaternion.Euler(-90, 0, 0));
        _stem3.GetComponent<MeshRenderer>().material = stemMat;
        _stem3.transform.parent = _flower.transform;

        // Create corolla
        int index = Random.Range(0, corolla.Count - 1);
        var _corolla = Instantiate(corolla[index], Vector3.zero, Quaternion.Euler(-90, 0, 0));
        _corolla.GetComponent<MeshRenderer>().material = corollaMat;

        _corolla.transform.parent = _stem1.transform;
        _corolla.transform.localPosition = new Vector3(0, 0, 10f);

        _corolla.transform.parent = _stem2.transform;
        _corolla.transform.localPosition = new Vector3(0, 0, 10f);

        _corolla.transform.parent = _stem3.transform;
        _corolla.transform.localPosition = new Vector3(0, 0, 10f);

        // Set position
        _flower.transform.position = _pos;
    }


    void DeleteFlower() {
        GameObject _flower = GameObject.Find("flower_" + (count - 1));
        if (_flower != null) {
            Destroy(_flower);
        }
    }
}
