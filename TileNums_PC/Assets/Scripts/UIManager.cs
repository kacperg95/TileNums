using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {


    #region Komponenty UI
    public Button MenuButton;
    public Button LevelButton;
    public Button RestartButton;
    public TMP_Text LevelLabel;
    #endregion


    // Use this for initialization
    void Start () {


        //LEVEL TEXT
        LevelLabel.text = string.Format("LEVEL {0} - {1}", Game.GetLevel(), TextData.LevelName[Game.GetLevel()]);


        //PRZYCISKI

        //Menu Główne
        MenuButton.onClick.AddListener(() =>
        {
            Initiate.Fade("Scenes/MainMenu",Color.black, 8.0f);
        });

        //Wybór poziomu
        LevelButton.onClick.AddListener(() =>
        {
            Initiate.Fade("Scenes/LevelSelect", Color.black, 8.0f);
        });

        //Restart
        RestartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PlayerPrefs.SetInt("DontShowStartingMessage", 1);
        });
	}
	
}
