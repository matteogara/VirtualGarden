using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MANAGER : MonoBehaviour
{
    public GameObject panel;

    [Header("Row selection")]
    public Button[] rows;

    [Header("Smell selection")]
    public Button[] smells;

    [Header("Vegetation selection")]
    public Button[] vegs;

    int activeRow = 0;
    int[] selection = { 0, 0 };
    int[] rowLength = { 4, 2 };



    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space))
        {
            panel.SetActive(true);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space)) {
            RefreshUI();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.Space))
        {
            panel.SetActive(false);
        }
    }


    void RefreshUI()
    {
        // Update selection
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            activeRow--;
            activeRow = Mathf.Max(activeRow, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selection[activeRow]--;
            selection[activeRow] = Mathf.Max(selection[activeRow], 0);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            activeRow++;
            activeRow = Mathf.Min(activeRow, 1);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            selection[activeRow]++;
            selection[activeRow] = Mathf.Min(selection[activeRow], rowLength[activeRow]);
        }

        // Update selection on UI
        DisableAllButtons();
        rows[activeRow].interactable = true;
        smells[selection[0]].interactable = true;
        vegs[selection[1]].interactable = true;
    }


    void DisableAllButtons() {
        foreach (Button _r in rows) _r.interactable = false;
        foreach (Button _s in smells) _s.interactable = false;
        foreach (Button _v in vegs) _v.interactable = false;
    }
}
