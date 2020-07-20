using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorGrabber : MonoBehaviour {
  public string arduinoColor;
    public string materialNameStart;

    /*void Start(){

        Color blueColor = new Color(57f, 144f, 229f);
        Color greenColor = new Color(105f, 198f, 229f);
        Color yellowColor = new Color(255f, 174f, 100f);
        Color orangeColor = new Color(250f, 112f, 100f);
        Color redColor = new Color(243f, 100f, 134f);


        List<Renderer> rendererList = new List<Renderer>();
        GetComponentsInChildren<Renderer>(false, rendererList);

        if (rendererList != null){
                        
            foreach (Renderer r in rendererList){
                Color objColor = r.material.GetColor("_Tint");
            

                if (objColor == blueColor){
                    arduinoColor = "b";
                } else if (objBluComp == 206){
                    arduinoColor = "g";
                } else if (objBluComp == 124){
                    arduinoColor = "y";
                } else if (objBluComp == 120){
                    arduinoColor = "w";
                } else if (objBluComp == 134){
                    arduinoColor = "r";
                }
                return;
                
            }

        }
    }*/



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
                //Debug.Log("colorName: " + colorName);
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

}

