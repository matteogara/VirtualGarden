using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Previewer : MonoBehaviour
{
   public SCENE_MANAGER sceneManager;
   public Generator generator;

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
           if (generatedBush != null) {
              Destroy(generatedBush);
            }
          if (generatedHerb != null) {
             Destroy(generatedHerb);
           }
          if (generatedFlower != null) {
             Destroy(generatedFlower);
           }
          if (generatedMushroom != null) {
             Destroy(generatedMushroom);
           }
          generatedTree = generator.CreateTree(transform.position, treeData[sceneManager.selection[0]]);
        }

        // If selected, spawn a bush
        if (sceneManager.selection[1] == 1 && nearBushes.Count < 1)
        {
          if (generatedBush != null) {
             Destroy(generatedBush);
           }
         if (generatedTree != null) {
            Destroy(generatedTree);
          }
          if (generatedHerb != null) {
             Destroy(generatedHerb);
           }
         if (generatedFlower != null) {
            Destroy(generatedFlower);
         }
         if (generatedMushroom != null) {
            Destroy(generatedMushroom);
           }
          generatedBush = generator.CreateBush(transform.position, bushData[sceneManager.selection[0]]);
        }

        // If selected, spawn a flower, mushroom or herb
        if (sceneManager.selection[1] == 2 && nearGrass.Count < 1)
        {
          if (generatedHerb != null) {
             Destroy(generatedHerb);
           }
          if (generatedFlower != null) {
             Destroy(generatedFlower);
          }
          if (generatedMushroom != null) {
             Destroy(generatedMushroom);
            }
          if (generatedBush != null) {
            Destroy(generatedBush);
          }
          if (generatedTree != null) {
             Destroy(generatedTree);
           }
          generatedFlower = generator.CreateFlower(transform.position = new Vector3(-1f,0,0), flowerData[sceneManager.selection[0]]);
          generatedMushroom = generator.CreateMushroom(transform.position = new Vector3(0,0,0), mushroomData[sceneManager.selection[0]]);
          generatedHerb = generator.CreateHerb(transform.position = new Vector3(1f,0,0), herbData[sceneManager.selection[0]]);
          }
        }
    }
