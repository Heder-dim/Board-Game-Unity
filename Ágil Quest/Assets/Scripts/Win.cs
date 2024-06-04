using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public bool P, P_;
    public GameObject P1Win, P2Win;
    public Text P1, P2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void WinTela()
    {

        int value1 = int.Parse(P1.text);
        int value2 = int.Parse(P2.text);
        if (value1 > value2)
        {
            P1Win.SetActive(true);
        }
        else
        {
            P2Win.SetActive(true);
        }
    }
    public void setchegada(bool player1, bool player2)
    {
        if (!P)
        {
            P = player1;
        }
        if (!P_)
        {
            P_ = player2;
        }
        if(P && P_)
        {
            WinTela();
        }
    }
    public void reiniciar()
    {
        SceneManager.LoadScene(0);
    }
}
