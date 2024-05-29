using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoardManager boardManager;

    void Start()
    {
        if (boardManager != null)
        {
            boardManager.SetupBoard();
        }
    }
}
