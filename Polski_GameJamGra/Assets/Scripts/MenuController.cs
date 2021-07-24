using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    Button NewGameButton;
    [SerializeField]
    Button ControlsButton;
    [SerializeField]
    Button CreditsButton;
    [SerializeField]
    Button ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        NewGameButton.onClick.AddListener(NewGameClick);
        ExitButton.onClick.AddListener(ExitClick);
        CreditsButton.onClick.AddListener(CreditsClikcl);
    }

    private void CreditsClikcl()
    {
        SceneManager.LoadScene("Credits");
    }

    private void ExitClick()
    {
        Application.Quit();
    }

    private void NewGameClick()
    {
        SceneManager.LoadScene("Story");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
