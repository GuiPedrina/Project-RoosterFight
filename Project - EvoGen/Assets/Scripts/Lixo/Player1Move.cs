using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Move : MonoBehaviour
{

    public float speed;
    public float jumpingForce;
    private int vida;
    public bool isJumping;
    public float rangeMorte;
    public LayerMask layerMorte;

    public bool doubleJump;
    public bool isPuloCair = false;

    private Rigidbody2D rig;
    private ControlesPlayer controles;
    public Vector2 moviment;
    public Animator anim;
    public SpriteRenderer sprite;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckTamanho = 0.2f;
    [SerializeField] private bool cheked;


    private void Awake()
    {
        controles = new ControlesPlayer();
    }
    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        vida = 100;

    }

    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        anim.SetFloat("Fall", rig.velocity.y);
        Morte();
 
        
    }

    private void Dano(int dano) 
    {
        vida -= dano;
    }

    private void Morte()
    {
        Collider2D[] morto = Physics2D.OverlapCircleAll(rig.position, rangeMorte, layerMorte);

        foreach (Collider2D morte in morto)
        {
            gameObject.transform.position = new Vector2(-3.39f, -0.14f);
        }
    }

    

    //fun��o de movimenta��o do player 1 
    private void Move()
    {
        //comando que chama os botoes do input
        moviment = controles.Player.Movimentacao.ReadValue<Vector2>();

        //comando que faz o personagem se mover
<<<<<<< Updated upstream:Project - EvoGen Bagunça/Assets/Scripts/Lixo/Player1Move.cs
        //rig.velocity = new Vector2(moviment.x * speed, rig.velocity.y);

        Vector2 movimento =  new Vector2(moviment.x, moviment.y) * speed * Time.time ;
        transform.Translate(movimento);
=======
        rig.velocity = new Vector2(moviment.x * speed, rig.velocity.y);
        print(rig.velocity.y);
>>>>>>> Stashed changes:Project - EvoGen/Assets/Scripts/Player1Move.cs
        
        //condi��o que v� se est� andando pra direita
        if (moviment.x > 0)
        {
            //rotaciona o player pra direita
            transform.eulerAngles = new Vector2(0f, 0f);
            if (!isJumping)
            {
                //ativa o comando de anima��o de walk
                anim.SetInteger("transition", 1);
            }

        }

        //condi��o que v� se est� andando pra esquerda
        if (moviment.x < 0)
        {
            //rotaciona o player pra esquerda
            transform.eulerAngles = new Vector2(0f, 180f);
            if (!isJumping)
            {
                //ativa o comando de anima��o de walk
                anim.SetInteger("transition", 1);
            }
        }

        //condi��o que v� se est� parado
        if (moviment.x == 0 && isJumping == false)
        {
                //ativa o comando de anima��o de iddle
                anim.SetInteger("transition", 0);
        }
    }

    private bool isGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckTamanho, groundLayer);

        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                
                if(colliders[i].gameObject != gameObject)
                {
                    print("to dentro");
                    return true;
                    
                }
            }
        }

        print("to fora");
        return false;
    }

    //fun��o de pulo
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && (isGround()|| !doubleJump))
        {
            rig.velocity = new Vector2(rig.velocity.y, jumpingForce);     
            anim.SetInteger("transition", 2);
            isJumping = true;
            doubleJump = !doubleJump;


        }
        if(rig.velocity.y < 0 && isPuloCair == false)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpingForce);
            anim.SetInteger("transition", 2);
            isJumping = true;
            isPuloCair = true;
        }


        if(context.canceled && rig.velocity.y > 0f)
        {
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y * 0.5f);
            anim.SetInteger("transition", 2);

        }
    }

    private int getVida()
    {
        return vida;
    }

    private void setVida(int somaVida)
    {
        vida += somaVida; 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isJumping = false;
            anim.SetInteger("transition", 0);
        }
    }
}
