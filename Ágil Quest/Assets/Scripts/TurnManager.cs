using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Dice dice; 

    private PlayerMovement player1Movement;
    private PlayerMovement player2Movement;
    public int currentPlayer = 1; // Começa com o Player 1
    
    void Start()
    {
        player1Movement = player1.GetComponent<PlayerMovement>();
        player2Movement = player2.GetComponent<PlayerMovement>();

        // Inicia o turno do primeiro jogador
        SetActivePlayer();
    }


    void SetActivePlayer()
    {

        if (currentPlayer == 1)
        {
            player1Movement.enabled = true;
            player2Movement.enabled = false;
        }
        else
        {
            player1Movement.enabled = false;
            player2Movement.enabled = true;
        }
    }
    
 

    public void EndTurn()
    {
        // Alternar o turno
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        SetActivePlayer();

        // Permitir que o próximo jogador role o dado
        dice.EnableDice();
    }


}
