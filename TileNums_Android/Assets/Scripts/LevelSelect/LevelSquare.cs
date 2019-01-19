using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

/// <summary>
/// Klasa odpowiedzialna za kwadraty odpowiadające przyciskom przy wyborze odpowiedniego poziomu
/// </summary>
public class LevelSquare : MonoBehaviour {

    public TMP_Text valueText;
    int level;
    internal bool Unlocked;

	// Use this for initialization
	void Start () {

        //W zależności od tego na jakiej pozycji znajduje się kwadrat za taki poziom odpowiada
        Vector3 levelSquarePosition = gameObject.transform.localPosition;
        level = (int)((levelSquarePosition.x / 2.699 + 1) + 5 * (-levelSquarePosition.y) / 2.699);
        valueText.text = level.ToString();

        //Czy jest odblokowany czy nie
        Unlocked = level <= Game.GameProgress;


        //Nadanie odpowiedniego koloru
        SpriteRenderer sprite = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        Sprite[] squares = Resources.LoadAll<Sprite>(@"Sprites/squares");

        if(Unlocked)
            sprite.sprite = squares.Single(s => s.name == "green");
        else
            sprite.sprite = squares.Single(s => s.name == "red");

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && Unlocked)
        {
            string scenePath = string.Format("Scenes/Levels/LVL {0}", level);
            Initiate.Fade(scenePath, Color.black, 8f);
        }
    }

}
