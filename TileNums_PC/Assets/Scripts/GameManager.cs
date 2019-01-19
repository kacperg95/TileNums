using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// SKrypt obsługujący różne zdarzenia w trakcie przebiegu gry
/// </summary>
public class GameManager : MonoBehaviour {


    void OnEnable()
    {
        Game.Load();
        Game.ShowStartingMessage();
        var UI = Resources.Load("Prefabs/UI");
        Instantiate(UI);
    }

    void OnDisable()
    {
        Game.Save();
        Game.Squares.Clear();
    }
}
