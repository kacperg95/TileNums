using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class NormalSquare : Square {


    //Typ kwadratu
    [SerializeField]
    public SquareType Type;

    //Czy po wejściu na kwadrat znika
    [SerializeField]
    public bool IsDestructable;


    public override void Start() {
        base.Start();
        SetSquareFont();
        SetSquareValue();
    }


    /// <summary>
    /// Ustawia font kwadratu w zależności od jego typu
    /// </summary>
    public void SetSquareFont()
    {
        if (Type == SquareType.Finish)
        {
            valueText.color = Color.red;
            valueText.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/Bitter-Bold SDF - Big Outline");
            valueText.outlineColor = Color.black;

        }
        else if (IsDestructable)
        {
            valueText.color = Color.white;
            valueText.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/Bitter-Bold SDF - Big Outline");
        }
        else
        {
            valueText.color = Color.black;
            valueText.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/Bitter-Bold SDF - No Outline");
        }
    }

    /// <summary>
    /// Ustawia wartość kwadratu
    /// </summary>
    public void SetSquareValue()
    {
        valueText.outlineColor = Color.black;

        if (Type == SquareType.Empty || Type == SquareType.Wall)
            valueText.text = string.Empty;
        else
            valueText.text = value.ToString();
    }


    /// <summary>
    /// Wyłącza kwadrat gdy na niego staniemy
    /// </summary>
    public void DisableSquare()
    {
        SpriteRenderer sprite = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        Sprite[] squares = Resources.LoadAll<Sprite>(@"Sprites/squares");

        Type = SquareType.Wall;
        sprite.sprite = squares.Single(s => s.name == "black");

        valueText.enabled = false;
    }


	public override void Update () {
        base.Update();
	}
}
