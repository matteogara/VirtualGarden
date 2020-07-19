using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private float treeCount, bushCount, flowerCount, mushroomCount, grassCount;



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


    public GameObject CreateBush(Vector3 _pos, BushScriptableObject _data)
    {
        // Create object
        GameObject _bush = new GameObject("Bush_" + bushCount);
        bushCount++;

        float _shrubsNum = Random.Range(1, 3);
        for (int i = 0; i < _shrubsNum; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-_data.shrMaxDist, _data.shrMaxDist), 0, Random.Range(-_data.shrMaxDist, _data.shrMaxDist));

            var _shrubs = Instantiate(_data.shrubs, offset, Quaternion.Euler(-90, Random.Range(0, 360), 90));

            _shrubs.GetComponent<MeshRenderer>().material = _data.shrubsMat;

            Vector3 s = new Vector3(Random.Range(_data.minScale, _data.maxScale), Random.Range(_data.minScale, _data.maxScale), Random.Range(_data.minScale, _data.maxScale));
            if (_data.largerShrubsAtCenter)
            {
                s /= (offset.magnitude + 1);
            }

            _shrubs.transform.localScale = s;
            _shrubs.transform.parent = _bush.transform;
        }

        // Set position
        _bush.transform.position = _pos;

        // Set master scale
        _bush.transform.localScale *= _data.masterScale;

        return _bush;
    }


    public void CreateFlower(Vector3 _pos, FlowerScriptableObject _data)
    {
        // Create object
        GameObject _flower = new GameObject("flower_" + flowerCount);
        flowerCount++;

        // Create stem
        int stemIndex = Random.Range(0, _data.stems.Count);
        var _stem = Instantiate(_data.stems[stemIndex], Vector3.zero, Quaternion.Euler(-90, 0, 0));
        _stem.GetComponent<MeshRenderer>().material = _data.stemMat;
        _stem.transform.parent = _flower.transform;

        // Create corolla
        int corollaIndex = Random.Range(0, _data.corollas.Count);
        var _corolla = Instantiate(_data.corollas[corollaIndex], Vector3.zero, Quaternion.Euler(-90, 0, 0));
        _corolla.GetComponent<MeshRenderer>().material = _data.corollaMat;

        _corolla.transform.parent = _stem.transform;
        _corolla.transform.localPosition = new Vector3(0, 0, _data.stemsHeights[stemIndex]);

        // Set position
        _flower.transform.position = _pos;

        // Set master scale
        _flower.transform.localScale *= _data.masterScale;
    }


    public void CreateMushroom(Vector3 _pos, MushroomScriptableObject _data)
    {
        // Create object
        GameObject _mushroom = new GameObject("mushrooms_" + mushroomCount);
        mushroomCount++;

        // Create body
        int index = Random.Range(0, _data.body.Count - 1);
        var _body = Instantiate(_data.body[index], Vector3.zero, Quaternion.Euler(Random.Range(-85, -95), Random.Range(0, 360), 0));
        _body.GetComponent<MeshRenderer>().material = _data.bodyMat;
        float _bodyR = Random.Range(_data.bodyMinScale, _data.bodyMaxScale);
        float _bodyH = Random.Range(_data.bodyMinScale, _data.bodyMaxScale);
        _body.transform.localScale = new Vector3(_bodyR, _bodyR, _bodyH);
        _body.transform.parent = _mushroom.transform;

        // Create head
        index = Random.Range(0, _data.head.Count - 1);
        var _head = Instantiate(_data.head[index], Vector3.zero, Quaternion.Euler(Random.Range(-85, -95), Random.Range(0, 360), 0));
        _head.GetComponent<MeshRenderer>().material = _data.headMat;
        float _headR = Random.Range(_data.headMinScale, _data.headMaxScale);
        float _headH = Random.Range(_data.headMinScale, _data.headMaxScale);
        _head.transform.localScale = new Vector3(_headR, _headR, _headH);
        _head.transform.parent = _body.transform;
        _head.transform.localPosition = new Vector3(0, 0, 1.75f);

        // Set position
        _mushroom.transform.position = _pos;

        // Set master scale
        _mushroom.transform.localScale *= _data.masterScale;
    }


    // CreateGrass
}
