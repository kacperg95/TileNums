/// <summary>
/// Klasa zawierająca wszystkie informacje tekstowe (nazwy lvli, informacje pojawiające się w MessageBoxach itp.)
/// </summary>
public class TextData
{


    /// <summary>
    /// Nazwa poziomu
    /// </summary>
    public static string[] LevelName
    {
        get
        {
            return levelName;
        }
    }
    private static string[] levelName =
    {
        "zero",
        "THE EASIEST ONE",                         //1
        "A LITTLE HARDER",                     //2
        "HOW ABOUT THIS ONE?",                 //3
        "AS MUCH AS YOU CAN",                  //4
        "TRY THIS!",                             //5
        "IT'S EASIER THAN YOU THINK",          //6
        "ARE YOU GETTING CONFUSED?",           //7
        "THE TWO-PART STAGE",                      //8
        "THE DEADLY CLOCK",                        //9
        "I'M CONFUSED",                        //10
        "THERE IS NO ESCAPE",                  //11
        "A SMALL LADDER",                        //12
        "THE CASUAL ONE",                          //13
        "DIVIDE WISELY",                       //14
        "THE MEMORY BREAKER",                      //15
        "MULTIDIVISION",                       //16
        "THERE IS ONLY ONE WAY",               //17
        "CAN'T DIVIDE? MOVE BACKWARDS!",       //18
        "UNLIMITED MOVEMENT",                  //19
        "BUILD YOUR OWN SOLUTION",             //20

    };

    /// <summary>
    /// Komunikat pojawiający się po przejściu danego poziomu
    /// </summary>
    public static string[] LevelComplete
    {
        get
        {
            return levelComplete;
        }
    }
    private static string[] levelComplete =
    {
        "zero",
        "That was easy, wasn't it?",                                        //1
        "Very nice!",                                                       //2
        "You are getting it!",                                              //3
        "Hope you aren't getting tired, because it's just beginning :)",    //4
        "So now you know how a red square works!",                            //5
        "Well done! That big square looked scary!",                         //6
        "You think that was hard? Now it's time for the real one!",         //7
        "Good job! Now you know 3 different squares!",                      //8
        "You made it! 😀",                                                  //9
        "Ok. Now I'm impressed!",                                           //10
        "Well done! How many times have you tried? 🙂",                     //11
        "EZ PZ",                                                            //12
        "You are doing great!",                                             //13
        "Very nice!",                                                       //14
        "This was pretty hard, but you made it!",                           //15
        "Good job!",                                                        //16
        "Nice!",                                                            //17
        "This level was really hard! Good job!",                            //18       
        "More and more math!",                                              //19
    };

    /// <summary>
    /// Komunikat pojawiający się gdy nie uzyskamy odpowiedniej liczby
    /// </summary>
    public static string LevelNotComplete
    {
        get
        {
            System.Random rand = new System.Random();
            return levelNotComplete[rand.Next(levelNotComplete.Length)];
        }
    }
    private static string[] levelNotComplete =
    {
        "These numbers aren't equal. Try again!",
        "No, that's not the solution!",
        "You should totally try again!",
        "Don't give up, you almost had it!",
        "Try another way!",
    };

    /// <summary>
    /// Komunikat pojawiający się gdy powstanie negatywna liczba
    /// </summary>
    public static string NegativeNumber
    {
        get
        {
            System.Random rand = new System.Random();
            return negativeNumber[rand.Next(negativeNumber.Length)];
        }
    }
    private static string[] negativeNumber =
    {
        "Oops! You made a negative number. There's no negative numbers in this game.",
        "Hey, don't be so negative! Only positive numbers!",
        "No negative numbers!",
        "Negative, over!",
        "Hey, you need to slow down! There is no negative numbers.",
    };

    /// <summary>
    /// Komunikat pojawiający się gdy powstanie ułamek
    /// </summary>
    public static string BadDivision
    {
        get
        {
            System.Random rand = new System.Random();
            return badDivision[rand.Next(badDivision.Length)];
        }
    }
    private static string[] badDivision =
    {
        "Oops! You made a float number. Try to make dividing properly.",
        "You can't divide these to numbers without remainder!",
        "You made a float number. We don't do that here!",
        "You can make only decimal numbers!",
        "Not so quick! Floating numbers are not allowed!",
    };

    /// <summary>
    /// Wiadomość pokazywane przed rozpoczęciem poziomu 
    /// </summary>
    public static string StartingMessage()
    {
        switch (Game.GetLevel())
        {
            case 1:
                return "Hi, welcome to Tile Nums! This game is so simple, that you will probably figure out everything by yourself. Good luck!";
            case 5:
                return "There's a new square in the hood! Let's see what is it used for.";
            case 6:
                return "There is one thing you should remember. There are no negative numbers in this game! If you make negative one, you lose!";
            case 8:
                return "Hey look! The blue one!\nYou should remember that sometimes there is more than one way to complete the level";
            case 9:
                return "This level might be tricky, so I'll give you one advice. Keep in mind, that there's unindentified white square in the middle!";
            case 12:
                return "Remember when I told you there are no negative numbers? Same for floating ones. Be careful!";
            case 18:
                return "This level is harder than it looks like. There is also a new type of square! If you have any problems, just look at the level name!";

        }
        return string.Empty;
    }

}