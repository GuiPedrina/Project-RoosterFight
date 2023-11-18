using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Selecao : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rig;

    private Vector2 direcao;

    [SerializeField] private ControlesPlayer controle;

    [SerializeField] private int caixa;

    [SerializeField] private Transform trans;


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
        Movimento();
    }

    private void Movimento()
    {
        if (controle.PlayerSelection.Direita.triggered)
        {
            Vector2 move = new Vector2 (trans.localScale.x, 0);
            trans.Translate(move);
        }

        else if (controle.PlayerSelection.Esquerda.triggered)
        {
            Vector2 move = new Vector2(- trans.localScale.x, 0);
            trans.Translate(move);
        }

    }
}
