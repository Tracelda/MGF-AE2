using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScrpt : MonoBehaviour {
    public StaticScrpt StaticScrpt;
    public GameObject Text;
    public Text TextVal;
	void Start ()
    {
        Text = GameObject.Find("Text");
        TextVal = Text.GetComponent<Text>();
        if (StaticScrpt.lives > 0)
        {
            TextVal.text = "You have won!!!";
        }
        else if (StaticScrpt.lives == 0)
        {
            TextVal.text = "Game Over";
        }
	}
}
