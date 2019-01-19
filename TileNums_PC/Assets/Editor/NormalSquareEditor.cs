using UnityEngine;
using UnityEditor;
using TMPro;
using System.Linq;


/// <summary>
/// Edytor kwadratów na scenie
/// </summary>
[CustomEditor(typeof(NormalSquare))]
[CanEditMultipleObjects]
public class NormalSquareEditor : Editor {

    //Kwadrat na którym operujemy
    NormalSquare mNormalSquare;

    //Własności kwadratu na którym operujemy
    SerializedProperty value;
    SerializedProperty type;
    SerializedProperty isDestructable;


    public void OnEnable()
    {
        //Przypisanie własności do zmiennych
        mNormalSquare = (NormalSquare)target;
        value = serializedObject.FindProperty("value");
        type = serializedObject.FindProperty("Type");
        isDestructable = serializedObject.FindProperty("IsDestructable");
    }

    public override void OnInspectorGUI()
    {
        //Początek
        //serializedObject.Update();
        EditorGUI.BeginChangeCheck();

        //Ustawienie naszych własności wewnątrz edytora
        EditorGUILayout.PropertyField(value);
        EditorGUILayout.PropertyField(type);
        EditorGUILayout.PropertyField(isDestructable);

        //Ustawienie wartości i fontu kwadratu
        mNormalSquare.SetSquareValue();
        mNormalSquare.SetSquareFont();

        
        //Nie chcemy żeby w edytorze można było ustawić wartość kwadratu mniejszą niż zero
        if (mNormalSquare.value < 0)
            mNormalSquare.value = 0;


        //Ustawienie koloru kwadratu w zależności od tego jakiego jest typu
        SpriteRenderer sprite = mNormalSquare.gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        Sprite[] squares = Resources.LoadAll<Sprite>(@"Sprites/squares");

        switch (mNormalSquare.Type)
        {
            case SquareType.Empty:
                sprite.sprite = squares.Single(s => s.name == "white");
                break;
            case SquareType.Wall:
                sprite.sprite = squares.Single(s => s.name == "black");
                break;
            case SquareType.Adding:
                sprite.sprite = squares.Single(s => s.name == "green");
                break;
            case SquareType.Subtracting:
                sprite.sprite = squares.Single(s => s.name == "red");
                break;
            case SquareType.Multiplicating:
                sprite.sprite = squares.Single(s => s.name == "blue");
                break;
            case SquareType.Dividing:
                sprite.sprite = squares.Single(s => s.name == "yellow");
                break;
            case SquareType.NumAdding:
                sprite.sprite = squares.Single(s => s.name == "pink");
                break;
            case SquareType.Powering:
                sprite.sprite = squares.Single(s => s.name == "brown");
                break;
            case SquareType.Finish:
                sprite.sprite = squares.Single(s => s.name == "finish");
                break;
        }

        //Zapisujemy wszelkie zmiany jakich dokonaliśmy wewnątrz edytora
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}