using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1.0f;
    public float moveSpeed = 5.0f;

    private Vector3 targetPosition;
    private bool isMoving = false;
    private int cima, baixo, dir, esq;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isMoving = false; // Movimento completo
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cima"))
        {
            cima = 1;
            baixo = 0;
            dir = 0;
            esq = 0;
            Debug.Log("cima");

        }
        else if (collision.gameObject.CompareTag("dir"))
        {
            dir = 1;
            baixo = 0;
            cima = 0;
            esq = 0;
            Debug.Log("dir");
        }
        else if (collision.gameObject.CompareTag("esq"))
        {
            esq = 1;
            dir = 0;
            baixo = 0;
            cima = 0;
            Debug.Log("esq");
        }
        else if (collision.gameObject.CompareTag("baixo"))
        {
            baixo = 1;
            esq = 0;
            dir = 0;
            cima = 0;
            Debug.Log("baixo");
        }
    }

    public void MovePlayer(int steps)
    {
        StartCoroutine(MoveSteps(steps));
    }

    private IEnumerator MoveSteps(int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            // Movimenta um passo e aguarda até que a movimentação seja concluída
            if (cima == 1)
            {
                targetPosition += Vector3.up * moveDistance;
            }
            else if (baixo == 1)
            {
                targetPosition += Vector3.down * moveDistance;
            }
            else if (esq == 1)
            {
                targetPosition += Vector3.left * moveDistance;
            }
            else if (dir == 1)
            {
                targetPosition += Vector3.right * moveDistance;
            }

            isMoving = true;
            yield return new WaitUntil(() => !isMoving); // Aguarda até o movimento ser completado

            // Verifica as colisões novamente após mover um passo
            cima = baixo = esq = dir = 0;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            foreach (var collider in colliders)
            {
                OnTriggerEnter2D(collider);
            }
        }
    }
}
