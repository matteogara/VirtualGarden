using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private float treeCount;
    private float bushCount;
    private float grassCount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject CreateTree(Vector3 _pos, TreeScriptableObject _data)
    {
        // Create object
        GameObject _tree = new GameObject("Tree_" + treeCount);
        _tree.tag = "Spawn_Tree";
        treeCount++;

        // Collider
        SphereCollider treeCollider = _tree.AddComponent<SphereCollider>();
        treeCollider.radius = Random.Range(_data.minCollScale, _data.maxCollScale);
        treeCollider.isTrigger = true;

        // Create trunk
        var _trunk = Instantiate(_data.trunk, Vector3.zero, Quaternion.Euler(-90, Random.Range(0, 360), 0));
        _trunk.GetComponent<MeshRenderer>().material = _data.trMat;
        _trunk.transform.parent = _tree.transform;
        float _trR = Random.Range(_data.trMinR, _data.trMaxR);
        float _trH = Random.Range(_data.trMinH, _data.trMaxH);
        _trunk.transform.localScale = new Vector3(_trR, _trR, _trH);

        // Create trunk foliage
        var _trFoliage = Instantiate(_data.foliage, Vector3.zero, Quaternion.Euler(-90, 0, 0));

        _trFoliage.GetComponent<MeshRenderer>().material = _data.folMat;

        float _folR = Random.Range(_data.folMinScale, _data.folMaxScale);
        float _folH = Random.Range(_data.folMinScale, _data.folMaxScale) / _trH;
        _trFoliage.transform.localScale = new Vector3(_folR, _folR, _folH);
        _trFoliage.transform.parent = _trunk.transform;
        _trFoliage.transform.localPosition = new Vector3(0, 0, 5.6f);


        // Create brenches
        float _brenchNum = Random.Range(1, 5);
        for (int i = 0; i < _brenchNum; i++)
        {
            var _brench = Instantiate(_data.brench, Vector3.zero, Quaternion.Euler(0, Random.Range(0, 360), 0));
            _brench.GetComponent<MeshRenderer>().material = _data.trMat;
            float _z = Random.Range(_data.brMinH, _data.brMaxH);
            float s;
            if (_data.largerBrenchesBelow)
            {
                float brDeltaH = Mathf.Abs(_data.brMaxH - _data.brMinH);
                s = (Random.Range(_data.brMinScale, _data.brMaxScale) + (_data.brMaxH - _z) / brDeltaH) / 2;
            }
            else
            {
                s = Random.Range(_data.brMinScale, _data.brMaxScale);
            }
            _brench.transform.localScale = new Vector3(s, s, s);
            _brench.transform.parent = _trunk.transform;
            _brench.transform.localPosition = new Vector3(0, 0, _z);

            // Create brench foliage
            _trFoliage = Instantiate(_data.foliage, Vector3.zero, Quaternion.Euler(-90, 0, 0));

            _trFoliage.GetComponent<MeshRenderer>().material = _data.folMat;

            _folR = Random.Range(_data.folMinScale, _data.folMaxScale);
            _folH = Random.Range(_data.folMinScale, _data.folMaxScale) / _trH;
            _trFoliage.transform.localScale = new Vector3(_folR, _folR, _folH);
            _trFoliage.transform.parent = _brench.transform;
            _trFoliage.transform.localPosition = _data.folOffset;
        }

        // Set position
        _tree.transform.position = _pos;

        // Set master scale
        _tree.transform.localScale *= _data.masterScale;

        return _tree;
    }
}
