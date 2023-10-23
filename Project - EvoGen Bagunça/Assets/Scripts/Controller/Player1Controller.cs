using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controller : MonoBehaviour

{
    [SerializeField] private int idPersonagem = 1;
    private Vector2 direcao;

    [SerializeField] private Transform trfPlayer1;
    [SerializeField] private ControlesPlayer controle;

    [SerializeField] private List <GameObject> player1;

    // delegates
    public delegate void HorizontalActions(float horizontal);
    public delegate void JumpActions(InputAction.CallbackContext context);

    //eventos
    public static event HorizontalActions OnHorizontalReceived;
    public static event JumpActions OnJumpReceived;




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
        GerarPlayer();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    public void GerarPlayer()
    {
        if(idPersonagem == 0)
        {
            Instantiate(player1[0], trfPlayer1.position, trfPlayer1.rotation);
        }

        if (idPersonagem == 1)
        {
            Instantiate(player1[1], trfPlayer1.position, trfPlayer1.rotation);
        }

    }

    public void Movimento()
    {
            direcao = controle.Player.Movimentacao.ReadValue<Vector2>(); // vector2(-1,0)
            if (OnHorizontalReceived != null) { OnHorizontalReceived(direcao.x); }            
    }

    public void Pulo(InputAction.CallbackContext context)
    {
            if (OnJumpReceived != null) { OnJumpReceived(context); }
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
