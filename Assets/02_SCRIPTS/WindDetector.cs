using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindDetector : MonoBehaviour{
    public Material windMaterial;
    [Range(0, 45)]
    public int fanAngle;

    public RawImage windDebug;
    public RawImage bar_L;
    public RawImage bar_R;
    public Text fanSpeed_L;
    public Text fanSpeed_R;

    public ArduinoEvent sendWind;

    Vector3 wind = Vector3.zero;

    float windIntensity_L;
    float windIntensity_R;
    Vector3 fanDir_L;
    Vector3 fanDir_R;

    float windSize;
    Vector4 windDir;
    float treeSwaySpeed;
    float treeSwayDisp;
    float treeSwayStutter;
    float treeSwayStutterInfluence;

    public static float Remap(float value, float from1, float to1, float from2, float to2){
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    public AudioSource windSound;

    // Start is called before the first frame update
    void Start(){
        // Get wind material variables
        windSize = windMaterial.GetFloat("_wind_size");
        windDir = windMaterial.GetVector("_wind_dir");
        treeSwaySpeed = windMaterial.GetFloat("_tree_sway_speed");
        treeSwayDisp = windMaterial.GetFloat("_tree_sway_disp");
        treeSwayStutter = windMaterial.GetFloat("_tree_sway_stutter");
        treeSwayStutterInfluence = windMaterial.GetFloat("_tree_sway_stutter_influence");

        windSound = GetComponent<AudioSource>();
    }

    void Update(){
        // Calculate wind in the same way the shader does
        wind.x = (Mathf.Cos(Time.time * 2 * treeSwaySpeed + (transform.position.x / windSize) + (Mathf.Sin(Time.time * 2 * treeSwayStutter * treeSwaySpeed + (transform.position.x / windSize)) * treeSwayStutterInfluence)) + 1) / 2 * treeSwayDisp * windDir.x;
        wind.z = (Mathf.Cos(Time.time * 2 * treeSwaySpeed + (transform.position.z / windSize) + (Mathf.Sin(Time.time * 2 * treeSwayStutter * treeSwaySpeed + (transform.position.z / windSize)) * treeSwayStutterInfluence)) + 1) / 2 * treeSwayDisp * windDir.z;

        // Wind perceived intensity (to ARDUINO)
        fanDir_L = Quaternion.AngleAxis(-fanAngle, Vector3.up) * transform.forward;
        fanDir_R = Quaternion.AngleAxis(fanAngle, Vector3.up) * transform.forward;
        windIntensity_L = - Mathf.Min(Vector3.Dot(wind, fanDir_L), 0);
        windIntensity_R = - Mathf.Min(Vector3.Dot(wind, fanDir_R), 0);

        string windString = Mathf.Round(Remap(windIntensity_L, 0, 1, 0, 8)).ToString();
        sendWind.Invoke(windString);
      
        // Wind sound
        windSound.volume = 0.15f + wind.magnitude * 0.5f;
        float windAngle = Vector3.SignedAngle(windDir, transform.forward, Vector3.up) + 180;
        windSound.panStereo = - Mathf.Sin(windAngle * Mathf.Deg2Rad);

        // Debug
        fanSpeed_L.text = (windIntensity_L * 100).ToString("F0") + "%";
        fanSpeed_R.text = (windIntensity_R * 100).ToString("F0") + "%";
        windDebug.transform.eulerAngles = new Vector3(45, 0, windAngle + 180);
        windDebug.transform.localScale = new Vector3(wind.magnitude + 0.5f, wind.magnitude + 0.5f, wind.magnitude + 0.5f) * 0.7f;
        bar_L.transform.localScale = new Vector3(1, windIntensity_L, 1) * 0.7f;
        bar_R.transform.localScale = new Vector3(1, windIntensity_R, 1) * 0.7f;
    }
}
