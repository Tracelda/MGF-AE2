using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticScrpt {

    public static int currentGame;
    public static int lives;

    public static int CurrentGame
    {
        get
        {
            return currentGame;
        }
        set
        {
            currentGame = value;
        }
    }

    public static int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }
}
