using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1.0f;
    public float moveSpeed = 5.0f;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Aguarda a próxima ação (movimento do dado)
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void MovePlayer(int steps)
    {
        // Move o jogador em linha reta para frente o número de passos do dado
        targetPosition += Vector3.up * moveDistance * steps;

        // Alternativamente, adicione lógica para diferentes direções ou caminhos
    }
}
