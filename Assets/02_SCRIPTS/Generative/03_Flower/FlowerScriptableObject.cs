using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowerData", menuName = "ScriptableObjects/FlowerScriptableObject", order = 1)]
public class FlowerScriptableObject : ScriptableObject
{
    [Header("Master scale")]
    public float masterScale = 1;

    [Header("Models")]
    public List<GameObject> stems = new List<GameObject>();
    public List<float> stemsHeights = new List<float>();
    public List<GameObject> corollas = new List<GameObject>();

    [Header("Materials")]
    public Material stemMat;
    public Material corollaMat;
}
