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
    // Start is called before the first frame update
    void Start()
    {
        NewGameButton.onClick.AddListener(NewGameClick);
    }

    private void NewGameClick()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
