using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDetector : MonoBehaviour
{
    public Material windMaterial;
    public Transform debug;
    public AudioClip windSound;
    public ArduinoEvent sendWind;

    Vector3 wind = Vector3.zero;
    float windIntensity;

    float windSize;
    Vector4 windDir;
    float treeSwaySpeed;
    float treeSwayDisp;
    float treeSwayStutter;
    float treeSwayStutterInfluence;

    public static float Remap(float value, float from1, float to1, float from2, float to2){
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get wind material variables
        windSize = windMaterial.GetFloat("_wind_size");
        windDir = windMaterial.GetVector("_wind_dir");
        treeSwaySpeed = windMaterial.GetFloat("_tree_sway_speed");
        treeSwayDisp = windMaterial.GetFloat("_tree_sway_disp");
        treeSwayStutter = windMaterial.GetFloat("_tree_sway_stutter");
        treeSwayStutterInfluence = windMaterial.GetFloat("_tree_sway_stutter_influence");
    }

    void Update()
    {
        // Calculate wind in the same way the shader does
        wind.x = (Mathf.Cos(Time.time * 2 * treeSwaySpeed + (transform.position.x / windSize) + (Mathf.Sin(Time.time * 2 * treeSwayStutter * treeSwaySpeed + (transform.position.x / windSize)) * treeSwayStutterInfluence)) + 1) / 2 * treeSwayDisp * windDir.x;
        wind.z = (Mathf.Cos(Time.time * 2 * treeSwaySpeed + (transform.position.z / windSize) + (Mathf.Sin(Time.time * 2 * treeSwayStutter * treeSwaySpeed + (transform.position.z / windSize)) * treeSwayStutterInfluence)) + 1) / 2 * treeSwayDisp * windDir.z;

        // Wind perceived intensity (to ARDUINO)
        windIntensity = - Mathf.Min(Vector3.Dot(wind, transform.forward), 0);
        string windString = Mathf.Round(Remap(windIntensity, 0, 1, 0, 8)).ToString();
        //Debug.Log(windString);
        sendWind.Invoke(windString);
        //sendWind.Invoke(windIntensity);

        // Debug
        debug.localScale = new Vector3(windIntensity, windIntensity, windIntensity);
    }
}
