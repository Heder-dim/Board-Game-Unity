using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public GameObject[] questions;
    private int[] correctAnswers = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // Respostas corretas para cada pergunta
    private int currentQuestionIndex = -1;
    public Text ponto1;
    public Text ponto2;
    private int pontos, player;
    public Text messageText;


    void Start()
    {
        // Inicialize todas as perguntas como inativas
        foreach (GameObject question in questions)
        {
            question.SetActive(false);
        }
    }

    void Update()
    {

    }

    public void setQuest(int quest, int pt, int p)
    {
        // Desative a pergunta atual, se houver uma ativa
        if (currentQuestionIndex != -1)
        {
            questions[currentQuestionIndex].SetActive(false);
        }

        // Ative a nova pergunta
        currentQuestionIndex = quest - 1;
        questions[currentQuestionIndex].SetActive(true);
        pontos = pt;
        player = p;
    }

    public void click(int selectedAnswer)
    {
        if (currentQuestionIndex == -1)
        {
            return; // Nenhuma pergunta ativa
        }

        int correctAnswer = correctAnswers[currentQuestionIndex];

        if (selectedAnswer == correctAnswer)
        {
            Debug.Log("Resposta correta!");
            // Lógica para quando a resposta está correta
            questions[currentQuestionIndex].SetActive(false);
            if (player == 1)
            {
                int valor = int.Parse(ponto1.text);
                valor += pontos;
                ponto1.text = valor.ToString();
            }
            else
            {
                int valor = int.Parse(ponto2.text);
                valor += pontos;
                ponto2.text = valor.ToString();
            }
            DisplayMessage("Parabéns!!");
        }
        else
        {
            Debug.Log("Resposta incorreta!");
            // Lógica para quando a resposta está incorreta
            questions[currentQuestionIndex].SetActive(false);
            DisplayMessage("Incorreto!!");

        }


    }

    
    public void DisplayMessage(string message)
    {
        StartCoroutine(DisplayMessageCoroutine(message));
    }

    private IEnumerator DisplayMessageCoroutine(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true); // Torna o texto visível
        yield return new WaitForSeconds(2f); // Espera por 2 segundos
        messageText.gameObject.SetActive(false); // Oculta o texto novamente
    }
}
