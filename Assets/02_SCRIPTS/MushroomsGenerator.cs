using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomsGenerator : MonoBehaviour
{
    [Header("Models")]
    public List<GameObject> body = new List<GameObject>();
    public List<GameObject> head = new List<GameObject>();

    [Header("Materials")]
    public Material trMat;
    public Material folMat;

    [Header("body settings")]
    public float trMinScale = .7f;
    public float trMaxScale = 1.2f;

    [Header("Foliage settings")]
    public float folMinScale = .5f;
    public float folMaxScale = 1f;
    public Vector3 folOffset = new Vector3(-1.5f, 0, 1.45f);

    private float count;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DeleteTree();
            CreateTree(transform.position);
        }
    }


    public void CreateTree(Vector3 _pos) {
        // Create object
        GameObject _tree = new GameObject("Tree_" + count);
        count++;

        // Create body
        int index = Random.Range(0, body.Count - 1);
        var _body = Instantiate(body[index], Vector3.zero, Quaternion.Euler(0, Random.Range(0, 360), 0));
        _body.GetComponent<MeshRenderer>().material = trMat; //materiale
        _body.transform.parent = _tree.transform;
        float _trR = Random.Range(trMinScale, trMaxScale); //raggio
        float _trH = Random.Range(trMinScale, trMaxScale); //altezza
        _body.transform.localScale = new Vector3(_trR, _trR, _trH);

        // Create body foliage
        index = Random.Range(0, head.Count - 1);
        var _trFolDown = Instantiate(head[index], Vector3.zero, Quaternion.Euler(0, Random.Range(0, 360), 0));
        _trFolDown.GetComponent<MeshRenderer>().material = folMat;
        float _folR = Random.Range(folMinScale, folMaxScale);
        float _folH = Random.Range(folMinScale, folMaxScale) / _trH;
        _trFolDown.transform.localScale = new Vector3(_folR, _folR, _folH);
        _trFolDown.transform.parent = _body.transform;
        _trFolDown.transform.localPosition = new Vector3(0, 0, 5.6f);

        // Set position
        _tree.transform.position = _pos;
    }


    void DeleteTree() {
        GameObject _tree = GameObject.Find("Tree_" + (count - 1));
        if (_tree != null) {
            Destroy(_tree);
        }
    }
}
