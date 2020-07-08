using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject _trunk, _brench, _foliage_up, _foliage_down;
    public Material tr_mat, fol_mat;

    public int brMinH, brMaxH;
    public float brMinScale, brMaxScale;

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
        GameObject tree = new GameObject("Tree_" + count);
        count++;

        // Set position
        tree.transform.position = new Vector3(0, 0, 0);

        // Create trunk
        var trunk = Instantiate(_trunk, Vector3.zero, Quaternion.Euler(-90, Random.Range(0, 360), 0));
        trunk.GetComponent<MeshRenderer>().material = tr_mat;
        trunk.transform.parent = tree.transform;

        // Create brenches
        float brenchNum = Random.Range(1, 5);
        for (int i = 0; i < brenchNum; i++) {
            var brench = Instantiate(_brench, Vector3.zero, Quaternion.Euler(0, Random.Range(0, 360), 90));
            brench.GetComponent<MeshRenderer>().material = tr_mat;
            brench.transform.parent = trunk.transform;
            float h = Random.Range(brMinH, brMaxH);
            brench.transform.localPosition = new Vector3(0, 0, h);
            float scale = (Random.Range(brMinScale, brMaxScale) + (30 - h) / brDeltaH) / 2;
            brench.transform.localScale = new Vector3(scale, scale, scale);
        }
    }


    void DeleteTree() {
        GameObject tree = GameObject.Find("Tree_" + (count - 1));
        if (tree != null) {
            Destroy(tree);
        }
    }
}
