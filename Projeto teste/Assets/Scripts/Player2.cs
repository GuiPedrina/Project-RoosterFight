using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private bool isJump;
    public int maxHealth;
    private int currentHealth;

    public Vector2 moviment;
    private ControlesPlayer Controle;
    private Animator anim;

    private Rigidbody2D rig;
    private void Awake()
    {
        Controle = new ControlesPlayer();
    }

    void Start()
    {
        currentHealth = maxHealth;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Controle.Enable();
    }

    private void OnDisable()
    {
        Controle.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    public void Dano(int dano)
    {
        currentHealth -= dano;

        anim.SetTrigger("isDamege");

        if (currentHealth > 0)
        {
            anim.SetInteger("transition", 0);
        }
        if (currentHealth < 0)
        {
            Die();
        }
    }

    void Move()
    {
        moviment = Controle.Player2.Movimentacao.ReadValue<Vector2>();
        rig.velocity = new Vector2(moviment.x * speed, rig.velocity.y);

        if (moviment.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
            if (!isJump)
            {
                anim.SetInteger("transition", 1);
            }
        }
        
        if (moviment.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
            if (!isJump)
            {
                anim.SetInteger("transition", 1);
            }
        }

        if(moviment.x == 0 && !isJump && !GetComponent<Player2Golpe>().isSoco)
        {
            anim.SetInteger("transition", 0);
        }
    }

    void Jump()
    {
        if (Controle.Player2.Jump.triggered)
        {
            if (!isJump)
            {
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJump = true;
                anim.SetInteger("transition", 2);

            }
        }
    }

    void Die()
    {
        //animação de morte
        

        //desabilitando personagem
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = true;
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJump = false;
        }
    }
}
