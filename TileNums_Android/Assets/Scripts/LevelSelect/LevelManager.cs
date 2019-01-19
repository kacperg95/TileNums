using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Skrypt potrzebny do wczytywania progressu w wyborze poziomów, aby można było określić które poziomy są odblokowane
/// </summary>
public class LevelManager : MonoBehaviour {

    void Awake()
    {
        Game.Load();
    }
}
