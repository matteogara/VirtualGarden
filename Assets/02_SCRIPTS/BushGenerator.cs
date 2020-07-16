using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushGenerator : MonoBehaviour
{
    [Header("Models")]
    public GameObject shrubs;
    public GameObject prefab;

    [Header("Materials")]
    public Material shrubsMat;

    [Header("Shrubs settings")]
    public int shrMinL = 1;
    public int shrMaxL = 5;
    public float minScale = 0.8f;
    public float maxScale = 1.3f;
    public Vector3 shrOffset = new Vector3(-1.5f, 0, 1.45f);

    public bool largerShrubsBelow = true;


    private float count;
    private int brDeltaH;


    // Start is called before the first frame update
    void Start()
    {
        brDeltaH = Mathf.Abs(shrMaxL - shrMinL);
    }

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Space))
       {
         GameObject clone = InstantiateRandomScale(prefab, 1, 5);
         // set up clone further.
       }
    }

    GameObject InstantiateRandomScale(GameObject source, float minScale, float maxScale)
    {
    GameObject clone = Instantiate(source) as GameObject;
    clone.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
    return clone;
    }

    public GameObject CreateBush(Vector3 _pos) {
        // Create object
        GameObject _bush = new GameObject("Bush_" + count);
        count++;

        float _shrubsNum = Random.Range(1, 5);
        for (int i = 0; i < _shrubsNum; i++) {
            var _shrubs = Instantiate(shrubs, Vector3.zero, Quaternion.Euler(-90, Random.Range(0, 360), 90));
            _shrubs.GetComponent<MeshRenderer>().material = shrubsMat;
            float _x = Random.Range(shrMinL, shrMaxL);
            float s;
            if (largerShrubsBelow)
            {
                s = (Random.Range(minScale, maxScale) + (shrMaxL - _x) / brDeltaH) / 2;
            }
            else
            {
                s = Random.Range(minScale, maxScale);
            }
            _shrubs.transform.localScale = new Vector3(s, s, s);
            _shrubs.transform.parent = _shrubs.transform;
            _shrubs.transform.localPosition = new Vector3(_x, 0, 0);

        }

        // Set position
        _bush.transform.position = _pos;

        return _bush;
    }
}
