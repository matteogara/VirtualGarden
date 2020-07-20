using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorGrabber : MonoBehaviour {
    public string arduinoColor;
    private float greenComponent;

    void Start(){
        
        float blueGreenComponent = 0.5647059f;
        float greenGreenComponent = 0.7764706f;
        float yellowGreenComponent = 0.6821074f;
        float orangeGreenComponent = 0.439802f;
        float redGreenComponent = 0.39102f;


        List<MeshRenderer> rendererList = new List<MeshRenderer>();
        GetComponentsInChildren<MeshRenderer>(false, rendererList);

        if (rendererList != null){
                        
            foreach (MeshRenderer rendererPart in rendererList){
                greenComponent = rendererPart.material.GetColor("_Color").g;
                //Debug.Log("elenco lista " + rendererPart.ToString() + "colore verde: " + greenComponent);

               if (greenComponent == blueGreenComponent){
                    arduinoColor = "b";
                    Debug.Log("Ho trovato un oggetto blu");
                    break;
                 } else if (greenComponent == greenGreenComponent){
                    arduinoColor = "g";
                    break;
                } else if (greenComponent == yellowGreenComponent){
                    arduinoColor = "y";
                    break;
                } else if (greenComponent == orangeGreenComponent){
                    arduinoColor = "w";
                    break;
                } else if (greenComponent == redGreenComponent){
                    arduinoColor = "r";
                    break;
                }
                 
            }

        }
    }
}

