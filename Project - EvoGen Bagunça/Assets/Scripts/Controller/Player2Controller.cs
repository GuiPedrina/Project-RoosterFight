using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    private int idPersonagem = 0;
    private Vector2 direcao;

    [SerializeField] private Transform trfPlayer2;
    [SerializeField] private ControlesPlayer2 controle2;
    [SerializeField] private List<GameObject> player2;

    // delegates
    public delegate void HorizontalActions(float horizontal);
    public delegate void JumpActions(InputAction.CallbackContext context);

    //eventos
    public static event HorizontalActions OnHorizontalReceived;
    public static event JumpActions OnJumpReceived;


    private void OnEnable()
    {
        controle2.Enable();
    }

    private void OnDisable()
    {
        controle2.Disable();
    }

    private void Awake()
    {
        controle2 = new ControlesPlayer2();
        GerarPlayer();
    }

    void Start()
    {
       
    }

    void Update()
    {
        Movimento();
    }

    public void GerarPlayer()
    {
        if (idPersonagem == 0)
        {
            Instantiate(player2[0], trfPlayer2.position, trfPlayer2.rotation);
        }

        if (idPersonagem == 1)
        {
            Instantiate(player2[1], trfPlayer2.position, trfPlayer2.rotation);
        }

    }

    public void Movimento()
    {
        direcao = controle2.Player2.movimentacao.ReadValue<Vector2>(); // vector2(-1,0)
        print("to no direção 2:" + direcao);
        if (OnHorizontalReceived != null) { OnHorizontalReceived(this.direcao.x); }
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
