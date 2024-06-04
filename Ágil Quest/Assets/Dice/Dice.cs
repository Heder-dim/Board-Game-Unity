using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;


    public TurnManager turnManager; // Referência ao TurnManager
    public GameObject espere;
    public Quest quest;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");

    }

    private void OnMouseDown()
    {
        if (rend.enabled) // Verifica se o dado está ativado
        {
            StartCoroutine(RollTheDice());
        }
    }

    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;
        int finalSide = 0;

        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6); // 0 a 5, inclusive
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        finalSide = randomDiceSide + 1;
        Debug.Log(finalSide);
        espere.SetActive(true);

        if (turnManager.currentPlayer == 1)
        {
            turnManager.player1.GetComponent<PlayerMovement>().MovePlayer(finalSide);
        }
        else
        {
            turnManager.player2.GetComponent<PlayerMovement>().MovePlayer(finalSide);
        }

        yield return new WaitForSeconds(1.0f);

        // Finaliza o turno e passa para o próximo jogador
        turnManager.EndTurn();
        espere.SetActive(false);

        int random = Random.Range(0, 15);
        quest.setQuest(random, finalSide, turnManager.currentPlayer);
    }

    public void EnableDice()
    {
        rend.enabled = true;
    }

    public void DisableDice()
    {
        rend.enabled = false;
    }
}
