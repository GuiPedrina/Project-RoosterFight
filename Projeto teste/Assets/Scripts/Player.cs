using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool isJumpin;
    public int maxHealth;
    private int currentHealth;
    public float timeDie;

    public ControlesPlayer Controles;
    public Vector2 movement;
    
    private Rigidbody2D rig;
    private Animator anima;

    private void Awake()
    {
        Controles = new ControlesPlayer();
    }
    void Start()
    {
        currentHealth = maxHealth;
        rig = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Controles.Enable();
    }

    private void OnDisable()
    {
        Controles.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
       // GetComponent<PlayerGolpe>().AttackRanged();
    }

    public void Dano(int dano)
    {
        currentHealth -= dano;

        anima.SetTrigger("isDamege");

        if (currentHealth > 0)
        {
            anima.SetInteger("transition", 0);
        }
        if (currentHealth < 0)
        {
            Die();
        }
    }

    void Move()
    {
         movement = Controles.Player.Movimentacao.ReadValue<Vector2>();
    
            rig.velocity = new Vector2(movement.x * speed, rig.position.y);
        print(rig.velocity.y);
        if (movement.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
            if (!isJumpin)
            {
                anima.SetInteger("transition", 1);
            }
            
            
        }

        if (movement.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
            if (!isJumpin)
            {
                anima.SetInteger("transition", 1);
            }
            
        }
        if(movement.x == 0 && !isJumpin && !GetComponent<PlayerGolpe>().isFire)
        {
            anima.SetInteger("transition", 0);
        }

    }

    void Jump()
    {
        if (Controles.Player.Jump.triggered)
        {
            if (!isJumpin)
            {
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJumpin = true;
                anima.SetInteger("transition", 2);
                
            }
            
        }
    }

    void Die()
    {
        //animação de morte
        anima.SetBool("isDie", true);

        //desabilitando personagem
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        if (Time.time >= timeDie)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            this.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumpin = false;

        }
    }
}
