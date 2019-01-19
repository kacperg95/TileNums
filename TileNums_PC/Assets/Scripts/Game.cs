using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa kontrolująca wszystkie kwadraty na scenie i zaiwerająca wszystkie statyczne metody
/// </summary>
public class Game : MonoBehaviour {

    #region Zmienne

    //Lista wszystkich kwadratów
    public static List<Square> Squares = new List<Square>();

    //Główny kwadrat, którym sterujemy
    public static Square MainSquare;

    //Postępy w grze
    public static int GameProgress;
    public static bool ProgressHasBeenMade = false;

    //Poziomy zawierające wiadomość startową
    private static int[] StartingMessageLevels = { 1, 5, 6, 8, 9, 12, 18 };

    #endregion

    #region Operacja na kwadratach
    /// <summary>
    /// Dodaje koordynaty do kwadratów
    /// </summary>
    /// <param name="x">Parametr X</param>
    /// <param name="y"> Parametr Y</param>
    /// <returns>Kwadrat do którego przypisujemy koordynaty</returns>
    public static Square AddSquare(int x, int y)
    {
        foreach (Square s in Squares)
        {
            if (!(s is MainSquare)) //Jeżeli s jest głównym kwadratem, to nie przypisujemy do niego koordynatów, bo tworzy to exceptiony
                if (s.posX == x && s.posY == y)
                    return s;
        }
        return null;
    }
    #endregion

    #region MessageBox

    /// <summary>
    /// Funkcja pokazująca MessageBox na ekranie
    /// </summary>
    /// <returns>Skrypt obsługujący MessageBox</returns>
    public static MessageBox ShowMessageBox(string text, MessageType type = MessageType.Custom)
    {
        var gameObject = Resources.Load("Prefabs/Message") as GameObject;
        var instance = GameObject.Instantiate(gameObject);
        var messageBox = instance.GetComponent<MessageBox>();

        messageBox.SetText(text);
        messageBox.SetMessageType(type);

        return messageBox;
    }

    #endregion

    #region Zapisywanie i wczytywanie postępów gry


    /// <summary>
    /// Zapis postępów w grze
    /// </summary>
    public static void Save()
    {
        if (ProgressHasBeenMade)
        {
            string myDocuments = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\TileNums";
            using (StreamWriter writer = new StreamWriter(Path.Combine(myDocuments,"Save.txt"), false))
            {
                writer.Write(GetLevel());
            }
        }
    }

    /// <summary>
    /// Wczytywanie postępów w grze
    /// </summary>
    public static void Load()
    {
        string myDocuments = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\TileNums";

        if (!Directory.Exists(myDocuments))
            Directory.CreateDirectory(myDocuments);

        if (!File.Exists(Path.Combine(myDocuments, "Save.txt")))
        {
            File.Create(Path.Combine(myDocuments, "Save.txt"));
            GameProgress = 1;
        }
        else
        {
            using (StreamReader reader = new StreamReader(Path.Combine(myDocuments, "Save.txt")))
            {
                int.TryParse(reader.ReadLine(), out GameProgress);
                if (GameProgress == 0)
                    GameProgress = 1;
            }
        }
    }


    #endregion

    #region Pobieranie numeru poziomu
    /// <summary>
    /// Metoda zwracająca numer aktualnie granego poziomu
    /// </summary>
    /// <returns>Numer poziomu</returns>
    public static int GetLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string [] sceneStr = sceneName.Split(' ');
        int sceneNumber = 0;

        int.TryParse(sceneStr[1], out sceneNumber);
        return sceneNumber;
    }
    #endregion

    #region Wiadomości
    /// <summary>
    /// Wyświetla wiadomość na początku poszczególnych poziomów
    /// </summary>
    public static void ShowStartingMessage()
    {
        //MessageBox pojawia się tylko wtedy, gdy dany level ma wiadomośc powitalną i nie została już wcześniej wyświetlona
        if(Array.Exists<int>(StartingMessageLevels, level => level == GetLevel()))
            if(PlayerPrefs.GetInt("DontShowStartingMessage") == 0)
                ShowMessageBox(TextData.StartingMessage(), MessageType.Info);
        
    }

    /// <summary>
    /// Wyświetla wiadomość po przejściu poziomu
    /// </summary>
    public static void LevelCompleteMessage()
    {
        ShowMessageBox(TextData.LevelComplete[GetLevel()], MessageType.NextLevel);
    }

    /// <summary>
    /// Wyświetla wiadomość po nie uzyskaniu odpowiedniej liczby
    /// </summary>
    public static void LevelNotCompleteMessage()
    {
        ShowMessageBox(TextData.LevelNotComplete, MessageType.RestartLevel);
    }

    /// <summary>
    /// Metoda wywołująca się gdy liczba głównego kwadratu jest ujemna
    /// </summary>
    public static void NegativeNumberMessage()
    {
        ShowMessageBox(TextData.NegativeNumber, MessageType.RestartLevel);
    }


    /// <summary>
    /// Metoda wywołująca się gdy nie można bez reszty podzielić liczby głównego kwadratu z liczbą kwadratu na który weszliśmy
    /// </summary>
    public static void BadDivisionMessage()
    {
        ShowMessageBox(TextData.BadDivision, MessageType.RestartLevel);
    }

    #endregion

}
