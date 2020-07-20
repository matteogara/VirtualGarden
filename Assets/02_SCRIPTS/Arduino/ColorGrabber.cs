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
                //Debug.Log("elenco lista: " + rendererPart.ToString() + " colore: " + greenComponent);

                if (Mathf.Approximately(greenComponent, blueGreenComponent)){
                    arduinoColor = "b";
                    Debug.Log("QUI!!!! Ho trovato un oggetto blu");
                    break;
                 } else if (Mathf.Approximately(greenComponent, greenGreenComponent)){
                    arduinoColor = "g";
                    Debug.Log("QUI!!!! Ho trovato un oggetto verde");
                    break;
                } else if (Mathf.Approximately(greenComponent, yellowGreenComponent)){
                    arduinoColor = "y";
                    Debug.Log("QUI!!!! Ho trovato un oggetto giallo");
                    break;
                } else if (Mathf.Approximately(greenComponent, orangeGreenComponent)){
                    arduinoColor = "w";
                    Debug.Log("QUI!!!! Ho trovato un oggetto arancio");
                    break;
                } else if (Mathf.Approximately(greenComponent, redGreenComponent)){
                    arduinoColor = "r";
                    Debug.Log("QUI!!!! Ho trovato un oggetto rosso");
                    break;
                }
            }

        }
    }
}

