using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Cards : MonoBehaviour {

    private static Sprite[] cards;
    private static SpriteRenderer rend;
    public static GameObject go;
    private static int correctans;
    public static Cards self;
    public static GameObject t;
    public static GameObject f;

    // Use this for initialization
    private void Start () {
        rend = GetComponent<SpriteRenderer>();
        cards = Resources.LoadAll<Sprite>("Cards/");
        rend.sprite = cards[5];
        gameObject.SetActive(false);
        Cards.go = gameObject;

        self = this;

	}

    public static void ShowCards(int index, int correctans)
    {
        go.SetActive(true);
        rend.sprite = cards[index];
        Cards.correctans = correctans;
        t = go.transform.Find("True").gameObject;
        f = go.transform.Find("False").gameObject;
        t.SetActive(false);
        f.SetActive(false);
        
    }
        
    public void Hide()
    {
        Invoke("_Hide", 2.0f);

    }

    public void _Hide()
    {

        go.SetActive(false);

    }

    public static void answered(int ans)
    {
          
        if (ans == correctans )
        {
            UnityEngine.Debug.Log("Correct");
            GameControl.diceSideThrown = 1;
            GameControl.MovePlayer(Dice.whosTurn);
            t.SetActive(true);
            Camera.main.GetComponent<Audio>().CorrectSound();

        }
        else
        {
            UnityEngine.Debug.Log("InCorrect");
            f.SetActive(true);
            Dice.nextTurn();


        }
        self.Hide();
    }

}
