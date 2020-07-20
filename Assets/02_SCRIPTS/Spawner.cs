using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SCENE_MANAGER sceneManager;

    public float maxDist;
    public DrawColoredAreas painter;
    public LayerMask layerMask;

    [Header("Array di scriptable objects, uno per ogni tipo di pianta")]
    public Generator generator;
    public TreeScriptableObject[] treeData;
    public BushScriptableObject[] bushData;
    public FlowerScriptableObject[] flowerData;
    public MushroomScriptableObject[] mushroomData;
    //public GrassScriptableObject[] grassData;


    Vector3 mousePos;
    Transform cam;
    RaycastHit _hit;

    List<GameObject> nearTrees = new List<GameObject>();
    List<GameObject> nearBushes = new List<GameObject>();
    List<GameObject> nearGrass = new List<GameObject>();


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



        // If spawn is possible
        if (Physics.Raycast(ray, out _hit, maxDist, layerMask)) {
            mousePos = _hit.point;

            // If player is spawning
            if (Input.GetKey(KeyCode.Mouse0)) {

                if (sceneManager.selection[0] != 5) {

                    // If selected, spawn a tree
                    if (sceneManager.selection[1] == 0 && nearTrees.Count < 1)
                    {
                        generator.CreateTree(mousePos, treeData[sceneManager.selection[0]]);
                    }

                    // If selected, spawn a bush
                    if (sceneManager.selection[1] == 1 && nearBushes.Count < 1) 
                    {
                        generator.CreateBush(mousePos, bushData[sceneManager.selection[0]]);
                    }

                    // If selected, spawn a flower, mushroom or herb
                    if (sceneManager.selection[1] == 2 && nearGrass.Count < 1)
                    {
                        int index = Random.Range(0, 3);

                        switch(index)
                        {
                            case 0:
                                generator.CreateFlower(mousePos, flowerData[sceneManager.selection[0]]);
                                break;
                            case 1:
                                generator.CreateMushroom(mousePos, mushroomData[sceneManager.selection[0]]);
                                break;
                            case 2:
                                //generator.CreateGrass(mousePos, grassData[sceneManager.selection[0]]);
                                break;
                        }
                    }
                }

                painter.Draw(_hit.textureCoord);
            }
        }

        transform.position = mousePos;

        Debug.Log(nearTrees.Count);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        GameObject collided = other.transform.parent.gameObject;

        switch (collided.tag)
        {
            case "Spawn_Tree":
                nearTrees.Add(collided);
                break;
            case "Spawn_Bush":
                nearBushes.Add(collided);
                break;
            case "Spawn_Grass":
                nearGrass.Add(collided);
                break;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        GameObject collided = other.transform.parent.gameObject;

        switch (collided.tag)
        {
            case "Spawn_Tree":
                nearTrees.Remove(collided);
                break;
            case "Spawn_Bushes":
                nearBushes.Remove(collided);
                break;
            case "Spawn_Grass":
                nearGrass.Remove(collided);
                break;
        }
    }
}
