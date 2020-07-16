using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushGenerator : MonoBehaviour
{
    [Header("Models")]
    public GameObject shrubs;

    [Header("Materials")]
    public Material shrubsMat;

    [Header("Shrubs settings")]
    public int shrMaxL = 5;
    public float minScale = 0.8f;
    public float maxScale = 1.3f;
    public Vector3 shrOffset = new Vector3(-1.5f, 0, 1.45f);

    public bool largerShrubsAtCenter = true;


    private float count;
    //private int brDeltaH;


    // Start is called before the first frame update
    void Start()
    {
        //brDeltaH = Mathf.Abs(shrMaxL - shrMinL);
    }

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Space))
       {
            // set up clone further.

            CreateBush(transform.position);
       }
    }

    //GameObject InstantiateRandomScale(GameObject source, float minScale, float maxScale)
    //{
    //GameObject clone = Instantiate(source) as GameObject;
    //clone.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
    //return clone;
    //}

    public GameObject CreateBush(Vector3 _pos) {
        // Create object
        GameObject _bush = new GameObject("Bush_" + count);
        count++;

        float _shrubsNum = Random.Range(1, 5);
        for (int i = 0; i < _shrubsNum; i++) {
            Vector3 offset = new Vector3(Random.Range(-shrMaxL, shrMaxL), 0, Random.Range(-shrMaxL, shrMaxL));

            var _shrubs = Instantiate(shrubs, offset, Quaternion.Euler(-90, Random.Range(0, 360), 90));

            _shrubs.GetComponent<MeshRenderer>().material = shrubsMat;

            Vector3 s = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale), Random.Range(minScale, maxScale) * 2);
            if (largerShrubsAtCenter)
            {
                s /= (offset.magnitude + 1);
            }

            _shrubs.transform.localScale = s;
            _shrubs.transform.parent = _bush.transform;

        }

        // Set position
        _bush.transform.position = _pos;

        return _bush;
    }
}
