using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[SelectionBase]
public class MainSquare : Square {

    //Kwadrat w któego miejsce się poruszamy gdy naciśniemy przycisk
    NormalSquare squareToMove = null;

    //Jeżeli po wejsciu na kolejny kwadrat powstanie liczba ujemna albo niepodzielna, te zmienne załatwią sprawę
    private bool negativeNumber = false;
    private bool badDivision = false;

	public override void Start () {
        base.Start();
        Game.MainSquare = this;
	}

    public override void Update()
    {
        base.Update();

        //Przechwytywanie naciśnięcia klawiszy
        if(squareToMove == null) //Upewniamy się że nasz kwadrat akurat się nie porusza
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && topSquare != null)
                Move(MoveDirection.Up);
            else if (Input.GetKeyDown(KeyCode.RightArrow) && rightSquare != null)
                Move(MoveDirection.Right);
            else if (Input.GetKeyDown(KeyCode.DownArrow) && bottomSquare != null)
                Move(MoveDirection.Down);
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && leftSquare != null)
                Move(MoveDirection.Left);
        }


        //Jeżeli kwadrat się porusza
        if (squareToMove != null)
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, squareToMove.gameObject.transform.position, Time.deltaTime*5);

            //Jeeli kwadrat dotarł do celu
            if (this.gameObject.transform.position == squareToMove.gameObject.transform.position)
            {
                //Jeżeli powstała liczba ujemna
                if (negativeNumber)
                    Game.NegativeNumberMessage();

                //Jeżeli powstała liczba niepodzielna
                if (badDivision)
                    Game.BadDivisionMessage();

                //Jeżeli kwadrat na który wchodzimy jest finishujący
                if (squareToMove.Type == SquareType.Finish)
                    StepOnFinishSquare(squareToMove);

                //Jeżeli poprzedni kwadrat nie był niezniszczalny, zamieniamy go na szary
                if (squareToMove.IsDestructable)
                {
                    squareToMove.DisableSquare();
                }
               

                //Odświeżanie naszego kwadratu
                squareToMove = null;
                this.valueText.text = value.ToString();
            }
        }
    }


    /// <summary>
    /// Rozpoczyna ruch po tym jak nakażemy naszemu kwadratowi się ruszyć
    /// </summary>
    /// <param name="direction">Kierunek poruszania się</param>
    public void Move(MoveDirection direction)
    {
        switch(direction)
        {
            case MoveDirection.Up:
                PerformAction(this.topSquare);
                break;
            case MoveDirection.Right:
                PerformAction(this.rightSquare);
                break;
            case MoveDirection.Down:
                PerformAction(this.bottomSquare);
                break;
            case MoveDirection.Left:
                PerformAction(this.leftSquare);
                break;
        }

    }


    /// <summary>
    /// Cała operacja związana z ruchem naszego kwadratu rozpoczynająca animacje ruchu
    /// </summary>
    /// <param name="square">Square we are operating on</param>
    public void PerformAction(Square square)
    {
        //Nie poruszamy się w miejsce ścian
        if ((square as NormalSquare).Type == SquareType.Wall)
            return;


        //Przypisanie głównemu kwadratowi nowych sąsiadów
        this.topSquare = square.topSquare;
        this.rightSquare = square.rightSquare;
        this.bottomSquare = square.bottomSquare;
        this.leftSquare = square.leftSquare;

        //Kwadrat w kierunku którego się poruszamy
        squareToMove = square as NormalSquare;

        NormalSquare sq = square as NormalSquare;

        //Nowa wartość dla głównego kwadratu
        switch(sq.Type)
        {
            case SquareType.Empty:
                break;
            case SquareType.Adding:
                this.value += square.value;
                break;
            case SquareType.Subtracting:
                if (this.value - square.value < 0)
                    negativeNumber = true;
                else
                    this.value -= square.value;
                break;
            case SquareType.Multiplicating:
                this.value *= square.value;
                break;
            case SquareType.Dividing:
                if (this.value % square.value != 0)
                    badDivision = true;
                else
                    this.value /= square.value;
                break;
            case SquareType.NumAdding:
                this.value =  this.value*10 + square.value;
                break;
            case SquareType.Powering:
                this.value = (int)Mathf.Pow((float)value, (float)square.value);
                break;          
        }

    }

    /// <summary>
    /// Wykonuje się gdy wejdziemy na finishowy kwadrat
    /// </summary>
    public void StepOnFinishSquare(NormalSquare finishSquare)
    {
        //Nasz kwadrat i finishowy mają tą samą wartość
        if(this.value == finishSquare.value)
        {
            int finishSquareCount = 0;
            foreach (var square in Game.Squares)
            if (square is NormalSquare && (square as NormalSquare).Type == SquareType.Finish) finishSquareCount++;

            //Jeżeli wszystkie finishowe kwadraty zostały ukończone, to kończymy poziom
            if (finishSquareCount == 1)
            {
                if (Game.GetLevel() >= Game.GameProgress)
                    Game.ProgressHasBeenMade = true;


                //Jeżeli ukończyliśmy całą grę
                if(Game.GetLevel() == 20)
                {
                    var message = Game.ShowMessageBox("Congratulations! You've beat my first game. That's why it's so short by the way, but hope you enjoyed it :)");
                    message.SetButtonClick(() =>
                    {
                        Initiate.Fade("Scenes/MainMenu", Color.black, 8f);
                    });                  
                }
                else
                {
                    Game.LevelCompleteMessage();
                }                
            }
        }
        //Nasz kwadrat nie ma tej samej wartości co finishowy
        else
        {
            Game.LevelNotCompleteMessage();
        }
        
    }


}
