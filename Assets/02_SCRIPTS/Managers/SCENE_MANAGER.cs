using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCENE_MANAGER : MonoBehaviour
{
    [HideInInspector]
    public int[] selection = { 0, 0 };
    [HideInInspector]
    public bool creativeMode = false;
    [HideInInspector]
    public bool UI_on = false;

    public GameObject pointer;
    public GameObject spawner;
    public GameObject eraser;
    public DrawColoredAreas canvas;

    SpawnMarker marker;


    private void Awake()
    {
        marker = pointer.GetComponent<SpawnMarker>();
    }


    // Start is called before the first frame update
    void Start()
    {
        selection[0] = 0;
        selection[1] = 0;

        creativeMode = false;

        pointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) {
            int[] newSel = { 5, selection[1] };
            updateSelection(newSel);
        }
    }


    public void updateSelection(int[] _sel) {
        selection = _sel;

        canvas.ChangeCol(_sel[0]);
        marker.ChangeMarker(_sel[0]);

        spawner.SetActive(!(_sel[0] == 5));
        eraser.SetActive(_sel[0] == 5);
    }

    public void toggleMode() {
        creativeMode = !creativeMode;

        pointer.SetActive(creativeMode);
        canvas.ShowAreas(creativeMode);
    }
}
