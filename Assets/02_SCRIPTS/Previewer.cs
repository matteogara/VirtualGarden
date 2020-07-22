using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Previewer : MonoBehaviour
{
   public SCENE_MANAGER sceneManager;
   public Generator generator;

   public enum TypeOfVegetation {Tree, Bush, Flower, Mushroom, Herb}
   [Header("Choose type of vegetation to spawn")]
   public TypeOfVegetation typeOfVegetation;

   [Header("Array di scriptable objects, uno per ogni tipo di pianta")]
   public TreeScriptableObject[] treeData;
   public BushScriptableObject[] bushData;
   public FlowerScriptableObject[] flowerData;
   public MushroomScriptableObject[] mushroomData;
   public HerbScriptableObject[] herbData;

   List<GameObject> nearTrees = new List<GameObject>();
   List<GameObject> nearBushes = new List<GameObject>();
   List<GameObject> nearGrass = new List<GameObject>();


   private float count;
   private GameObject generatedTree;
   private GameObject generatedBush;
   private GameObject generatedFlower;
   private GameObject generatedMushroom;
   private GameObject generatedHerb;

   GameObject preview; //


   public void UpdatePreview() { //
        Debug.Log("Creo la preview"); //

        // If selected, spawn a tree
        if (sceneManager.selection[1] == 0 && nearTrees.Count < 1)
        {
          if (generatedTree != null) {
             Destroy(generatedTree);
           }
          generatedTree = generator.CreateTree(transform.position, treeData[sceneManager.selection[0]]);
        }

        // If selected, spawn a bush
        if (sceneManager.selection[1] == 1 && nearBushes.Count < 1)
        {
          if (generatedBush != null) {
             Destroy(generatedBush);
           }
          generatedBush = generator.CreateBush(transform.position, bushData[sceneManager.selection[0]]);
        }

        // If selected, spawn a flower, mushroom or herb
        if (sceneManager.selection[1] == 2 && nearGrass.Count < 1)
        {
          if (generatedHerb != null) {
             Destroy(generatedHerb);
           }
          generatedHerb = generator.CreateFlower(transform.position, flowerData[sceneManager.selection[0]]);
          generatedHerb = generator.CreateMushroom(transform.position, mushroomData[sceneManager.selection[0]]);
          generatedHerb = generator.CreateHerb(transform.position, herbData[sceneManager.selection[0]]);
          }
        }
    }
