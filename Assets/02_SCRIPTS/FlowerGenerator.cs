using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGenerator : MonoBehaviour
{
    [Header("Models")]
    public List<GameObject> stem = new List<GameObject>();
    public List<GameObject> corolla = new List<GameObject>();

    [Header("Materials")]
    public Material stemMat;
    public Material corollaMat;

    [Header("corolla settings")]
    public Vector3 corollaOffset = new Vector3(0.3f, 0, 0);

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
        int index = Random.Range(0, stem.Count - 1);
        var _stem = Instantiate(stem[index], Vector3.zero, Quaternion.Euler(0, 0, 0));
        _stem.GetComponent<MeshRenderer>().material = stemMat;
        _stem.transform.parent = _flower.transform;

        // Create corolla
        index = Random.Range(0, corolla.Count - 1);
        var _corolla = Instantiate(corolla[index], Vector3.zero, Quaternion.Euler(0, 0, 0));
        _corolla.GetComponent<MeshRenderer>().material = corollaMat;
        _corolla.transform.parent = _stem.transform;
        _corolla.transform.localPosition = new Vector3(0, 5.7f, 0);

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
