using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MANAGER : MonoBehaviour
{
    public SCENE_MANAGER sceneManager;

    public GameObject panel;
    public GameObject intro;
    public GameObject windDebug;
    public GameObject background;

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

    [Header("Preview")]
    public Previewer previewer;

    int activeRow = 0;
    int[] _selection = { 0, 0 };
    int[] rowLength = { 4, 2 };
    bool started = false;

    AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        RefreshUI();
        RefreshVisibilities();
    }


    // Update is called once per frame
    void Update()
    {

        // Standard input
        if (started && sceneManager.creativeMode)
        {
            bool _refresh = false;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                panel.SetActive(true);
                sceneManager.UI_on = true;

                RefreshVisibilities();
            }

            if (Input.GetKey(KeyCode.LeftShift))
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
                     _selection[activeRow]--;
                     if (_selection[activeRow] < 0)
                     {
                         _selection[activeRow] = 0;
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
                     _selection[activeRow]++;
                     if (_selection[activeRow] > rowLength[activeRow])
                     {
                         _selection[activeRow] = rowLength[activeRow];
                     }
                     else
                     {
                         _refresh = true;
                         PlaySound(columnSound);
                     }
                 }
             }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                panel.SetActive(false);
                PlaySound(tabSound);
                sceneManager.UI_on = false;

                RefreshVisibilities();
            }

            if (_refresh)
            {
                RefreshUI();
            }
        }

        // Show / hide controls window
        if (Input.GetKeyDown(KeyCode.Return))
        {
            intro.SetActive(started);
            panel.SetActive(false);

            PlaySound(tabSound);
            started = !started;

            RefreshVisibilities();
        }

        // Switch mode
        if (Input.GetKeyDown(KeyCode.Space) && started) {
            sceneManager.toggleMode();
            panel.SetActive(false);

            RefreshVisibilities();
        }
    }


    void RefreshUI()
    {
        DisableAllButtons();
        rows[activeRow].interactable = true;
        smells[_selection[0]].interactable = true;
        vegs[_selection[1]].interactable = true;
        UpdateText();
        Vibrate();

        sceneManager.updateSelection(_selection);

        if (previewer != null)
        {
            previewer.UpdatePreview();
        }
    }


    void RefreshVisibilities()
    {
        windDebug.SetActive(!sceneManager.creativeMode && started);
        background.SetActive(!started || panel.activeInHierarchy);
    }


    void DisableAllButtons()
    {
        foreach (Button _r in rows) _r.interactable = false;
        foreach (Button _s in smells) _s.interactable = false;
        foreach (Button _v in vegs) _v.interactable = false;
    }


    void UpdateText()
    {
        string _newText = "A " + smellAdjectives[_selection[0]] + " " + objectNames[_selection[1]] + ".";
        description.text = _newText;
    }


    void Vibrate() {

    }


    void PlaySound(AudioClip _clip) {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
