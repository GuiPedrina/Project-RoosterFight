using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public int life;
    public float speed;
    private Vector2 moviment;
    public bool isJumping, isDoubleJumping = false;
    public int forceJumping;
    

    private Rigidbody2D rig;
    private SpriteRenderer sprite;
    private ControlesPlayer controles;
    private Animator anim;


    private void Awake()
    {
        controles = new ControlesPlayer();
    }

    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Disable();
    }
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


        life = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Morte();
        Movimento();
        Jumping();
    }

    private void Morte()
    {
        if (life <= 0)
        {
            sprite.enabled = false;
            rig.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void dano (int dano)
    {
        life -= dano;
    }

    public void Movimento()
    {
        moviment = controles.Player2.Movimentacao.ReadValue<Vector2>();

        rig.velocity = new Vector2(moviment.x * speed, rig.velocity.y);

        if(moviment.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);

            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
        }

        if (moviment.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);

            if (!isJumping)
            {
               anim.SetInteger("transition", 1);
            }
        }

        if (moviment.x == 0 && isJumping == false)
        {
           anim.SetInteger("transition", 0);
        }
    }

    private void Jumping()
    {
        if (controles.Player2.Jump.triggered)
        {
            if (!isJumping)
            {
                rig.velocity = new Vector2(rig.velocity.x, 0f); // Isso evita que a velocidade vertical acumule durante os pulos.
                rig.AddForce(new Vector2(0f, forceJumping), ForceMode2D.Impulse);
                anim.SetInteger("transition", 2);
                isJumping = true;
            }

        }
            if (isDoubleJumping && isJumping)
            {
                rig.velocity = new Vector2(rig.velocity.x, 0f); // Isso evita que a velocidade vertical acumule durante os pulos.
                rig.AddForce(new Vector2(0f, forceJumping), ForceMode2D.Impulse);
                anim.SetInteger("transition", 2);
                isJumping = true;
                isDoubleJumping = false;
            }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            anim.SetInteger("transition", 0);
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isJumping = true;
            
        }
    }
}
