using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorGrabber : MonoBehaviour {
  public string arduinoColor;
  public string materialNameStart;

    void Start() {
        string colorName;

        List<Renderer> rendererList = new List<Renderer>();
        GetComponentsInChildren<Renderer>(false, rendererList);
        //Debug.Log("rendererList: " + rendererList);
        if (rendererList != null){
            
            //Accedi a tutti i materiali del prefab
            foreach(Renderer r in rendererList) {
                Material m = r.material;
                
                //Quando trovi un materiale che inizia per stringa predefinita, allora prendi quello che segue
                if(m.name.StartsWith(materialNameStart)){
                    colorName = m.name.Substring(materialNameStart.Length);
                  //  Debug.Log("colorName: " + colorName);
                    if (colorName.StartsWith("Green")){
                        arduinoColor = "g";
                    }
                    else if (colorName.StartsWith("Blue")){
                        arduinoColor = "b";
                    }
                    else if (colorName.StartsWith("Red")){
                        arduinoColor = "r";
                    }
                    else if (colorName.StartsWith("Yellow")){
                        arduinoColor = "y";
                    }
                    else if (colorName.StartsWith("Orange")){
                        arduinoColor = "w";
                    }
                    return;
                }
            }
           
        }
    }
    
    void Update() {
     
    }

  
}

