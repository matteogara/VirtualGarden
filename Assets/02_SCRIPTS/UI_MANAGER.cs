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

    [Header("Description text")]
    public Text description;
    public string[] smellAdjectives;
    public string[] objectNames;

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
        bool _refresh = false;

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space))
        {
            panel.SetActive(true);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space)) {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                activeRow--;
                activeRow = Mathf.Max(activeRow, 0);
                _refresh = true;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selection[activeRow]--;
                selection[activeRow] = Mathf.Max(selection[activeRow], 0);
                _refresh = true;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                activeRow++;
                activeRow = Mathf.Min(activeRow, 1);
                _refresh = true;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                selection[activeRow]++;
                selection[activeRow] = Mathf.Min(selection[activeRow], rowLength[activeRow]);
                _refresh = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.Space))
        {
            panel.SetActive(false);
        }

        if (_refresh) {
            RefreshUI();
        }
    }


    void RefreshUI()
    {
        DisableAllButtons();
        rows[activeRow].interactable = true;
        smells[selection[0]].interactable = true;
        vegs[selection[1]].interactable = true;
        UpdateText();
    }


    void DisableAllButtons() {
        foreach (Button _r in rows) _r.interactable = false;
        foreach (Button _s in smells) _s.interactable = false;
        foreach (Button _v in vegs) _v.interactable = false;
    }


    void UpdateText() {
        string _newText = "A " + smellAdjectives[selection[0]] + " " + objectNames[selection[1]] + ".";
        description.text = _newText;
    }
}
