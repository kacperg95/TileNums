using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Button StartButton;
    public Button ExitButton;

    // Use this for initialization
    void Start()
    {
        StartButton.onClick.AddListener(StartButtonClick);
        ExitButton.onClick.AddListener(ExitButtonClick);
    }


    public void StartButtonClick()
    {
        Initiate.Fade("Scenes/LevelSelect", Color.black, 8.0f);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }



}
