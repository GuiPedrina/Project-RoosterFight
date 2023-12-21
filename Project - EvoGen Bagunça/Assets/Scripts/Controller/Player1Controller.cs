using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controller : MonoBehaviour
{
    public static int idPersonagem;
    private Vector2 direcao;

    [SerializeField] private Transform trfPlayer1;
    [SerializeField] private ControlesPlayer controle;

    [SerializeField] private List <GameObject> player1;

    // delegates
    public delegate void HorizontalActions(float horizontal);
    public delegate void JumpActions(InputAction.CallbackContext context);
    public delegate void PunchActions(InputAction.CallbackContext context);

    //eventos
    public static event HorizontalActions OnHorizontalReceived;
    public static event JumpActions OnJumpReceived;
    public static event PunchActions OnPunchReceived;


    public Zhang zhang;
    public Lele lele;
    private GameObject personagemInstanciado;


    // Start is called before the first frame update
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
        PersonagemBase.idControler = 0;
        GerarPlayer();  
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        Troca();
    }

    public void GerarPlayer()
    {
        if(idPersonagem == 0)
        {
            personagemInstanciado = Instantiate(player1[0], trfPlayer1.position, trfPlayer1.rotation);
        }

        if (idPersonagem == 1)
        {
            personagemInstanciado = Instantiate(player1[1], trfPlayer1.position, trfPlayer1.rotation);
        }

    }

    public void Troca()
    {
        if (controle.Player.Troca.triggered && idPersonagem == 1)
        {
            Destroy(personagemInstanciado);
            idPersonagem = 0;
            personagemInstanciado = Instantiate(player1[0], trfPlayer1.position, trfPlayer1.rotation);
        }
        else if (controle.Player.Troca.triggered && idPersonagem == 0)
        {
            Destroy(personagemInstanciado);
            idPersonagem = 1;
            personagemInstanciado = Instantiate(player1[1], trfPlayer1.position, trfPlayer1.rotation);
        }
    }

    public void Movimento()
    {
        
        direcao = controle.Player.Movimentacao.ReadValue<Vector2>(); // vector2(-1,0)
        //print("to no direção 1:" + direcao);
        if (OnHorizontalReceived != null) { OnHorizontalReceived(direcao.x); }            
    }



    public void Pulo(InputAction.CallbackContext context)
    {

        if (OnJumpReceived != null) { OnJumpReceived(context); }
    }

    public void Punch(InputAction.CallbackContext context) 
    {
        if (OnPunchReceived != null) { OnPunchReceived(context); }
    }

    public void SetIdPersonagem(int id) 
    {
        idPersonagem = id;
    }

    public int GetIdPersonagem()
    {
        return idPersonagem;
    }




}
