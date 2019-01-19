using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Square : MonoBehaviour {

    #region Variables

    //Wartość i pozycja na jakiej znajduje się kwadrat
    [SerializeField]
    public int value;
    internal int posX, posY;

    //Określa czy wszystkie kwadraty mają przypisanych sąsiadów (wykonuje się tylko raz)
    bool neighboursSet;

    //Sąsiednie kwaraty
    public Square leftSquare;
    public Square rightSquare;
    public Square bottomSquare;
    public Square topSquare;

    //Tekst wewnątrz kwadratów
    public TMP_Text valueText;

    #endregion

    #region Methods

    public virtual void Start()
    {

        //Dajemy znać, że trzeba ustawić sąsiadów
        neighboursSet = false;

        //Przypisanie obiektu tekstu do zmiennej
        valueText = gameObject.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text;

        //Ustalenie koordynatów kwadratu
        posX = (int)(this.gameObject.transform.localPosition.x / 0.899);
        posY = (int)(this.gameObject.transform.localPosition.y / 0.899);


        //Dodanie kwadratu do listy wszystkich kwadratów
        Game.Squares.Add(this);
    }


    public virtual void Update()
    {
        //Set all neighbour squares (executes only once!)
        if (!neighboursSet)
        {
            leftSquare = Game.AddSquare(posX - 1, posY);
            rightSquare = Game.AddSquare(posX + 1, posY);
            bottomSquare = Game.AddSquare(posX, posY - 1);
            topSquare = Game.AddSquare(posX, posY + 1);
            neighboursSet = true;
        }
    }


    #endregion

}
