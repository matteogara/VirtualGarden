using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MANAGER : MonoBehaviour
{
    public GameObject panel;
    public GameObject intro;

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

    [Header("Sounds")]
    public AudioClip rowSound;
    public AudioClip columnSound;
    public AudioClip tabSound;

    int activeRow = 0;
    int[] selection = { 0, 0 };
    int[] rowLength = { 4, 2 };
    bool inGame = false;

    AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        RefreshUI();
    }


    // Update is called once per frame
    void Update()
    {

        // Standard input
        if (inGame)
        {
            bool _refresh = false;

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space))
            {
                panel.SetActive(true);
            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space))
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    activeRow--;
                    if (activeRow < 0)
                    {
                        activeRow = 0;
                    }
                    else
                    {
                        _refresh = true;
                        PlaySound(rowSound);
                    }
                }
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    selection[activeRow]--;
                    if (selection[activeRow] < 0)
                    {
                        selection[activeRow] = 0;
                    }
                    else
                    {
                        _refresh = true;
                        PlaySound(columnSound);
                    }
                }
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    activeRow++;
                    if (activeRow > 1)
                    {
                        activeRow = 1;
                    }
                    else
                    {
                        _refresh = true;
                        PlaySound(rowSound);
                    }
                }
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    selection[activeRow]++;
                    if (selection[activeRow] > rowLength[activeRow])
                    {
                        selection[activeRow] = rowLength[activeRow];
                    }
                    else
                    {
                        _refresh = true;
                        PlaySound(columnSound);
                    }
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.Space))
            {
                panel.SetActive(false);
                PlaySound(tabSound);
            }

            if (_refresh)
            {
                RefreshUI();
            }
        }

        // Show / hide controls window
        if (Input.GetKeyDown(KeyCode.Return)) {
            intro.SetActive(inGame);
            panel.SetActive(false);

            PlaySound(tabSound);
            inGame = !inGame;
        }
    }


    void RefreshUI()
    {
        DisableAllButtons();
        rows[activeRow].interactable = true;
        smells[selection[0]].interactable = true;
        vegs[selection[1]].interactable = true;
        UpdateText();
        Vibrate();
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


    void Vibrate() {

    }


    void PlaySound(AudioClip _clip) {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
