using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class GameControl : MonoBehaviour {

    private static GameObject whoWinsTextShadow;
    public static int diceSideThrown = 0;

    public static bool gameOver = false;

    public static List<Player> Players;
    // 2 oggy diajak naik bombomcar = 3
    // 4 oggy gak sengaja cakar = 2
    // 7 oggy minta naik komidi putar = 1
    // 8 oggy dibelikan es krim = 3
    // 10 oggy diajak ke Circus = 3
    // 11 oggy minta kanaya beli es krim = 1
    // 13 oggy nurut, kanaya bilang thank you = 4
    // 16 oggy nyesel buang sampah sembarangan = 2
    public static int[] Stops = { 2, 4, 6, 8, 10, 12, 14, 16 };
    // 1 = Please 2 = Sorry 3 = Thank you 4 = Youre Welcome
    public static int[] Ans = { 3, 2, 1, 3, 3, 1, 4, 2 };

    // Use this for initialization
    void Start () {

        string PlayerStrings = "Kia|Tsabita|Nara|Syarif|Uma|Dia";

        
        string[] names = PlayerStrings.Split('|');
        Players = new List<Player>();
        int idx = 0;
        foreach (string n in names)
        {
            idx++;
            UnityEngine.Debug.Log("Instantiating " + idx);
            Player p = new Player();
            p.name = n;
            p.index = idx;
            
            p.moveText = GameObject.Find("Player"+idx+"MoveText");
            UnityEngine.Debug.Log(p.moveText);
            p.player = GameObject.Find("Player" + idx);
            UnityEngine.Debug.Log(p.player);
            p.player.GetComponent<FollowThePath>().moveAllowed = false;
            p.moveText.gameObject.SetActive(false);
            p.moveText.GetComponent<Text>().text = p.name;
            Players.Add(p);
        }

        Players[0].player.gameObject.SetActive(true);

        GameControl.whoWinsTextShadow = GameObject.Find("WhoWinsText");
        whoWinsTextShadow.gameObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        foreach (Player p in Players)
        {

            if (p.player.GetComponent<FollowThePath>().waypointIndex >
            p.Startwaypoint + diceSideThrown) // check if it is already next stop according to dice.
            {

                p.player.GetComponent<FollowThePath>().moveAllowed = false;


                p.Startwaypoint = p.player.GetComponent<FollowThePath>().waypointIndex - 1;
                UnityEngine.Debug.Log("Startwaypoint" + p.Startwaypoint);
                int idx = Array.IndexOf(Stops, p.Startwaypoint + 1);
                if (idx >= 0)
                {
                    Cards.ShowCards(idx, Ans[idx]);
                }
                else
                {
                    Dice.nextTurn();
                }

            }
            p.moveText.gameObject.SetActive(Dice.whosTurn == p.index);


        }

        foreach (Player p in Players)
        {

            if (p.player.GetComponent<FollowThePath>().waypointIndex ==
                       p.player.GetComponent<FollowThePath>().waypoints.Length && !gameOver)
            {
                Console.WriteLine("winner");
                whoWinsTextShadow.gameObject.SetActive(true);
                whoWinsTextShadow.GetComponent<Text>().text = p.name + " menang!";
                Camera.main.GetComponent<Audio>().WinSound();

                gameOver = true;
            }

        }

    }

    public static void MovePlayer(int playerToMove)
    {
        UnityEngine.Debug.Log("Move P " + playerToMove);
        foreach (Player p in Players)
        {
            if  ( p.index == playerToMove ) { 
                p.player.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            }
        }


    }
}


public class Player
{
    public string name;
    public int Startwaypoint = 0;
    public GameObject moveText;
    public GameObject player;
    public int index = 1;
    public Player()
    {

    }
}
