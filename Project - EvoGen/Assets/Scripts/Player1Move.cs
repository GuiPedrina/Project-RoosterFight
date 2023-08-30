using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{

    public float speed;
    public float jumpingForce;
    private int vida;
    public bool isJumping;

    private Rigidbody2D rig;
    private ControlesPlayer controles;
    public Vector2 moviment;
    public Animator anim;
    public SpriteRenderer sprite;


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
        Jumping();
        anim.SetFloat("Fall", rig.velocity.y);
    }

    private void Dano(int dano) 
    {
        vida -= dano;
    }

    private void Morte()
    {
        if (vida <= 0)
        {
            sprite.enabled = false;
            rig.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    //função de movimentação do player 1 
    private void Move()
    {
        //comando que chama os botoes do input
        moviment = controles.Player.Movimentacao.ReadValue<Vector2>();

        //comando que faz o personagem se mover
        rig.velocity = new Vector2(moviment.x * speed, rig.velocity.y);
        
        //condição que vê se está andando pra direita
        if (moviment.x > 0)
        {
            //rotaciona o player pra direita
            transform.eulerAngles = new Vector2(0f, 0f);
            if (!isJumping)
            {
                //ativa o comando de animação de walk
                anim.SetInteger("transition", 1);
            }

        }

        //condição que vê se está andando pra esquerda
        if (moviment.x < 0)
        {
            //rotaciona o player pra esquerda
            transform.eulerAngles = new Vector2(0f, 180f);
            if (!isJumping)
            {
                //ativa o comando de animação de walk
                anim.SetInteger("transition", 1);
            }
        }

        //condição que vê se está parado
        if (moviment.x == 0 && isJumping == false)
        {
                //ativa o comando de animação de iddle
                anim.SetInteger("transition", 0);
        }
    }

    //função de pulo
    private void Jumping()
    {
        if (controles.Player.Jump.triggered)
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpingForce), ForceMode2D.Impulse);
                anim.SetInteger("transition", 2);
                isJumping = true;
                
            }
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
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isJumping = true;

        }
    }


}
