using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    [Header("Models")]
    public GameObject trunk;
    public GameObject brench;
    public GameObject foliage_up;
    public GameObject foliage_down;

    [Header("Materials")]
    public Material trMat;
    public Material folMat;

    [Header("Trunk settings")]
    public float trMinScale;
    public float trMaxScale;

    [Header("Brenches settings")]
    public int brMinH;
    public int brMaxH;
    public float brMinScale;
    public float brMaxScale;
    public bool largerBrenchesBelow;

    [Header("Foliage settings")]
    public float folMinScale;
    public float folMaxScale;
    public Vector3 folOffset;

    private float count = 0;
    private int brDeltaH;


    // Start is called before the first frame update
    void Start()
    {
        brDeltaH = Mathf.Abs(brMaxH - brMinH);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DeleteTree();
            CreateTree();
        }
    }


    void CreateTree() {
        // Create object
        GameObject _tree = new GameObject("Tree_" + count);
        count++;

        // Set position
        _tree.transform.position = new Vector3(0, 0, 0);

        // Create trunk
        var _trunk = Instantiate(trunk, Vector3.zero, Quaternion.Euler(-90, Random.Range(0, 360), 0));
        _trunk.GetComponent<MeshRenderer>().material = trMat;
        _trunk.transform.parent = _tree.transform;
        float _trR = Random.Range(trMinScale, trMaxScale);
        float _trH = Random.Range(trMinScale, trMaxScale);
        trunk.transform.localScale = new Vector3(_trR, _trR, _trH);

        // Create trunk foliage
        var _trFolDown = Instantiate(foliage_down, Vector3.zero, Quaternion.Euler(-90, 0, 0));
        var _trFolUp = Instantiate(foliage_up, Vector3.zero, Quaternion.Euler(-90, 0, 0));
        _trFolDown.GetComponent<MeshRenderer>().material = folMat;
        _trFolUp.GetComponent<MeshRenderer>().material = folMat;
        float _folR = Random.Range(folMinScale, folMaxScale);
        float _folH = Random.Range(folMinScale, folMaxScale) / _trH;
        _trFolDown.transform.localScale = new Vector3(_folR, _folR, _folH);
        _trFolUp.transform.localScale = new Vector3(_folR, _folR, _folR);
        _trFolUp.transform.parent = _trFolDown.transform;
        _trFolUp.transform.localPosition = new Vector3(0, 0, 1);
        _trFolDown.transform.parent = _trunk.transform;
        _trFolDown.transform.localPosition = new Vector3(0, 0, 5.6f);


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
            _trFolDown = Instantiate(foliage_down, Vector3.zero, Quaternion.Euler(-90, 0, 0));
            _trFolUp = Instantiate(foliage_up, Vector3.zero, Quaternion.Euler(-90, 0, 0));
            _trFolDown.GetComponent<MeshRenderer>().material = folMat;
            _trFolUp.GetComponent<MeshRenderer>().material = folMat;
            _folR = Random.Range(folMinScale, folMaxScale);
            _folH = Random.Range(folMinScale, folMaxScale) / _trH;
            _trFolDown.transform.localScale = new Vector3(_folR, _folR, _folH);
            _trFolUp.transform.localScale = new Vector3(_folR, _folR, _folR);
            _trFolUp.transform.parent = _trFolDown.transform;
            _trFolUp.transform.localPosition = new Vector3(0, 0, 1);
            _trFolDown.transform.parent = _brench.transform;
            _trFolDown.transform.localPosition = folOffset;
        }
    }


    void DeleteTree() {
        GameObject _tree = GameObject.Find("Tree_" + (count - 1));
        if (_tree != null) {
            Destroy(_tree);
        }
    }
}
