using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSelection : MonoBehaviour
{
    [SerializeField] private Player1Selecao player1;
    [SerializeField] private GameObject p1Select;

    [SerializeField] private Player2Selecao player2;
    [SerializeField] private GameObject p2Select;

    [SerializeField] private string cenaJogo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.personagemSelect == true && player2.personagemSelect == true)
        {
            IniciarPt();
        }
    }

    void IniciarPt()
    {
        SceneManager.LoadScene(cenaJogo);
    }
}
