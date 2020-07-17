using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SCENE_MANAGER sceneManager;

    public float maxDist;
    public TreeGenerator generator;
    public DrawColoredAreas painter;
    public LayerMask layerMask;

    Vector3 mousePos;
    Transform cam;
    RaycastHit _hit;

    List<GameObject> nearTrees = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }


    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector3(0, 10, 0);

        // If player stands still
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // If player can move around
        Ray ray = new Ray(cam.position, cam.forward);

        // If using oculus quest
        // Raycast dall'asse forward del controller


        if (Physics.Raycast(ray, out _hit, maxDist, layerMask)) {
            mousePos = _hit.point;

            if (Input.GetKey(KeyCode.Mouse0)) {
                if (nearTrees.Count < 1)
                {
                    generator.CreateTree(mousePos);
                }

                painter.Draw(_hit.textureCoord);
            }
        }

        transform.position = mousePos;


        // DA CAMBIARE
        if (sceneManager.selection[0] != 0) {
            foreach (GameObject tree in nearTrees) {
                Destroy(tree);
                nearTrees = new List<GameObject>();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawn_Tree") {
            nearTrees.Add(other.gameObject);
            other.GetComponent<CheckForAreaColor>().enabled = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spawn_Tree") {
            nearTrees.Remove(other.gameObject);
            other.GetComponent<CheckForAreaColor>().enabled = false;
        }
    }
}
