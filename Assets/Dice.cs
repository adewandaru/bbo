using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public static int whosTurn = 1;
    private bool coroutineAllowed = true;

	// Use this for initialization
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
        //Random.InitState(255);

    }

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed && !Cards.go.active)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {

        Camera.main.GetComponent<Audio>().DiceSound();
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;

        GameControl.MovePlayer(whosTurn);

        coroutineAllowed = true;
    }

    public static void nextTurn()
    {
        UnityEngine.Debug.Log("Turn:" + whosTurn);
        if (whosTurn < GameControl.Players.Count)
        {
            whosTurn++;
        }
        else
        {
            whosTurn = 1;
        }
    }
}
