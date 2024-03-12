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

    //private bool cancelaPt = true;

    [SerializeField] private Animator anim;
    //[SerializeField] private ControlesPlayer controle;


    //private void OnEnable()
    //{
    //    controle.Enable();
    //}

    //private void OnDisable()
    //{
    //    controle.Disable();
    //}

    //private void Awake()
    //{
    //    controle = new ControlesPlayer();
    //}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.personagemSelect == true && player2.personagemSelect == true)
        {
            //cancelaPt = false;
            StartCoroutine("TudoPronto");
        }

        
    }


    IEnumerator TudoPronto()
    {
        anim.SetBool("Start", true);


        yield return new WaitForSeconds(3);


        IniciarPt();

        //if (controle.Player1Selection.Voltar.triggered)
        //{
        //    cancelaPt = true;
        //    print("aaaaa");
        //}
        //else if (controle.Player2Selection.Voltar.triggered)
        //{
        //    cancelaPt = true;
        //    print("bbbbb");
        //}

        //if (cancelaPt == false)
        //{
        //    anim.SetBool("Start", true);

        //    yield return new WaitForSeconds(3);

        //}
    }

    void IniciarPt()
    {
        SceneManager.LoadScene(cenaJogo);
    }
}
