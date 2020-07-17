using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorFeeder : MonoBehaviour
{
    public Generator generator;
    public TreeScriptableObject treeData;

    private GameObject generated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (generated != null) {
                Destroy(generated);
            }

            generated = generator.CreateTree(transform.position, treeData);
        }
    }
}
