using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int columns = 8;
    public int rows = 8;

    void Start()
    {
        SetupBoard();
    }

    public void SetupBoard()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }
}
