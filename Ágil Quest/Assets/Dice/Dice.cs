using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;

    public TurnManager turnManager; // Referência ao TurnManager

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

        if (turnManager.currentPlayer == 1)
        {
            turnManager.player1.GetComponent<PlayerMovement>().MovePlayer(finalSide);
        }
        else
        {
            turnManager.player2.GetComponent<PlayerMovement>().MovePlayer(finalSide);
        }

        yield return new WaitForSeconds(0.5f); // Espera para garantir que o movimento foi concluído

        // Finaliza o turno e passa para o próximo jogador
        turnManager.EndTurn();
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
