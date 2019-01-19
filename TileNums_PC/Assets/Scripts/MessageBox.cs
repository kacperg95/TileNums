using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour {

    //private Action ButtonClick;

    private TMP_Text messageText;
    private Button messageButton;

	// Use this for initialization
	void Awake () {
        messageText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        messageButton = gameObject.GetComponentInChildren<Button>();
	}
	
    /// <summary>
    /// Ustawia treść wiadomości
    /// </summary>
    /// <param name="text">Treść wiadomości</param>
    public void SetText(string text)
    {
        messageText.text = text;
    }


    /// <summary>
    /// Ustawia tekst wewnątrz przycisku
    /// </summary>
    /// <param name="text">Tekst przycisku</param>
    public void SetButtonText(string text)
    {
#pragma warning disable CS0618 // Typ lub element członkowski jest przestarzały
        var test = messageButton.GetComponentInChildren<GUIText>();
#pragma warning restore CS0618 // Typ lub element członkowski jest przestarzały
    }

    /// <summary>
    /// Ustawia funkcję, jaka ma się wykonywać po naciśnięciu przycisku
    /// </summary>
    /// <param name="action">Wybrana funkcja</param>
    public void SetButtonClick(UnityAction action)
    {
        messageButton.onClick.AddListener(action);
    }


    /// <summary>
    /// Określa typ Message Boxa i co ma wykonywać po naciśnijęciu przycisku
    /// </summary>
    /// <param name="type">Typ</param>
    public void SetMessageType(MessageType type)
    {
        switch (type)
        {
            //Zwykła informacja
            case MessageType.Info:
                messageButton.onClick.AddListener(() =>
                {
                    Destroy(gameObject);
                });
                break;
            //Restart poziomu
            case MessageType.RestartLevel:
                messageButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    PlayerPrefs.SetInt("DontShowStartingMessage", 1);
                });
                SetButtonText("Restart");
                break;
            //Przejście do kolejnego poziomu
            case MessageType.NextLevel:
                messageButton.onClick.AddListener(() =>
                {
                    //SceneManager.LoadScene(string.Format(@"Scenes/Levels/LVL {0}", Game.GetLevel() + 1));
                    string sceneName = string.Format(@"Scenes/Levels/LVL {0}", Game.GetLevel() + 1);
                    Initiate.Fade(sceneName, Color.black, 8f);
                    PlayerPrefs.SetInt("DontShowStartingMessage", 0);
                });
                break;
        }
    }


}
