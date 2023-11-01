using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public int life;
    private bool isCair = false;
    public float speed;
    public float rangeMorte;
    [SerializeField]private Vector2 moviment;
    public bool isJumping, isDoubleJumping = false;
    public int forceJumping;
    public LayerMask layerMorte;
    

    private Rigidbody2D rig;
    private SpriteRenderer sprite;
    private ControlesPlayer2 controles2;
    private Animator anim;


    private void Awake()
    {
        controles2 = new ControlesPlayer2();
    }

    private void OnEnable()
    {
        controles2.Enable();
    }

    private void OnDisable()
    {
        controles2.Disable();
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
        Jumping();
        Movimento();
        anim.SetFloat("fall", rig.velocity.y);
        rig.velocity = new Vector2(moviment.x * speed, rig.velocity.y);
    }

    private void Morte()
    {
        Collider2D[] morto = Physics2D.OverlapCircleAll(rig.position,rangeMorte , layerMorte);

        foreach (Collider2D morte in morto)
        {
            gameObject.transform.position = new Vector2(3.89f, -0.22f);
        }
    }

    public void dano (int dano)
    {
        life -= dano;
    }

    public void Movimento()
    {
        moviment = controles2.Player2.movimentacao.ReadValue<Vector2>();

       

        if(moviment.x < 0 && !isCair)
        {
            transform.eulerAngles = new Vector2(0f, 180f);

            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
                
            }
        }

        if (moviment.x > 0 && !isCair)
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
        if (controles2.Player2.Pulo.triggered)
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, forceJumping), ForceMode2D.Impulse);
                anim.SetInteger("transition", 2);
                isJumping = true;
            }

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
