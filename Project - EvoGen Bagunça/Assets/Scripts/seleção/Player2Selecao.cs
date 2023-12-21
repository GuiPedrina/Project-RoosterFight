using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Selecao : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rig;
    private Vector2 direcao;
    [SerializeField] private ControlesPlayer controle;


    [SerializeField] private Transform trans;
    [SerializeField] private SpriteRenderer render;

    [SerializeField] private Transform Zhang;
    [SerializeField] private Transform Lele;
    [SerializeField] private Transform Calango;
    [SerializeField] private Transform Stenion;
    [SerializeField] private Transform Mari;
    [SerializeField] private Transform Bloq;

    public bool personagemSelect = false;

    [SerializeField] private GameObject posterLele;
    [SerializeField] private GameObject posterZhang;

    private void OnEnable()
    {
        controle.Enable();
    }

    private void OnDisable()
    {
        controle.Disable();
    }

    private void Awake()
    {
        controle = new ControlesPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (personagemSelect == false)
        {
            Movimento();
        }

        PersonagemSelect();
    }

    private void Movimento()
    {
        Vector2 posicaoP2 = new Vector2(trans.position.x, trans.position.y);

        if (controle.Player2Selection.Direita.triggered && trans.position.x <= 2.31)
        {
            //Vector2 move = new Vector2 (trans.localScale.x, 0);
            Vector2 move = new Vector2(render.size.x + 0.86f, 0);
            trans.Translate(move);
        }

        else if (controle.Player2Selection.Esquerda.triggered && trans.position.x >= -3.69)
        {
            //Vector2 move = new Vector2(- trans.localScale.x, 0);
            Vector2 move = new Vector2(-render.size.x - 0.86f, 0);
            trans.Translate(move);
        }


        if (controle.Player2Selection.Cima.triggered && trans.position.y <= -3.183)
        {
            //Vector2 move = new Vector2(0, trans.localScale.y);
            Vector2 move = new Vector2(0, render.size.y + 0.86f);
            trans.Translate(move);
        }

        else if (controle.Player2Selection.Baixo.triggered && trans.position.y <= -1.683)
        {
            //Vector2 move = new Vector2(0, - trans.localScale.y);
            Vector2 move = new Vector2(0, -render.size.y - 0.86f);
            trans.Translate(move);
        }

    }

    private void PersonagemSelect()
    {
        Vector2 posicaoP2 = new Vector2(trans.position.x, trans.position.y);

        Vector2 posicaoGalo = new Vector2(Zhang.position.x, Zhang.position.y);
        Vector2 posicaoLele = new Vector2(Lele.position.x, Lele.position.y);
        Vector2 posicaoCalango = new Vector2(Calango.position.x, Calango.position.y);
        Vector2 posicaoPeixe = new Vector2(Stenion.position.x, Stenion.position.y);
        Vector2 posicaoMari = new Vector2(Mari.position.x, Mari.position.y);
        Vector2 posicaoBloq = new Vector2(Bloq.position.x, Bloq.position.y);


        //Galo selecionado
        if (controle.Player2Selection.Enter.triggered && posicaoP2 == posicaoGalo)
        {
            posterZhang.SetActive(true);
            Player2Controller.idPersonagem = 0;
            personagemSelect = true;
            print("Galo");

        }

        ////Lele selecionado
        else if (controle.Player2Selection.Enter.triggered && posicaoP2 == posicaoLele)
        {
            posterLele.SetActive(true);
            Player2Controller.idPersonagem = 1;
            personagemSelect = true;
            print("Lele");
        }

        ////Calango selecionado
        else if (controle.Player2Selection.Enter.triggered && posicaoP2 == posicaoCalango)
        {
            personagemSelect = true;
            print("Calango");
        }

        ////Peixe selecionado
        else if (controle.Player2Selection.Enter.triggered && posicaoP2 == posicaoPeixe)
        {
            personagemSelect = true;
            print("Peixe");
        }

        //Mari selecionado
        else if (controle.Player2Selection.Enter.triggered && posicaoP2 == posicaoMari)
        {
            personagemSelect = true;
            print("Mariposa");
        }

        //Personagem Bloqueado
        else if (controle.Player2Selection.Enter.triggered && posicaoP2 == posicaoBloq)
        {
            print("Personagem Bloqueado");
        }

        //Personagem Desselecionado
        else if (controle.Player2Selection.Voltar.triggered && personagemSelect == true)
        {
            posterLele.SetActive(false);
            posterZhang.SetActive(false);
            personagemSelect = false;
            print("Desselecionado");
        }
    }
}
