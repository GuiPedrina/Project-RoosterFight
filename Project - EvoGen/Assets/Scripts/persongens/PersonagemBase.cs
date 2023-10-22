using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PersonagemBase : MonoBehaviour
{
    // isGround()
    // isPlatform()
    // Jump
    // movement
    // speed
    // vida/dano


    private Rigidbody2D rig;
    private Transform posicao;
    private Animator anim;
    private BoxCollider2D box;
    
    

    public Vector2 movement;
    private bool grouded;
    
    public Transform groundCheck;
    public float raio;
    public LayerMask layerChao;


    [SerializeField] private float jumpForce = 12.0f;
    [SerializeField] private float speed = 0.5f;
    

    

    void OnEnable()
    {
        Player1Controller.OnHorizontalReceived += andar;
        Player1Controller.OnJumpReceived += pular;
    }

    void OnDisable()
    {
        Player1Controller.OnHorizontalReceived -= andar;
    }

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        posicao = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }


    void andar(float horizontal)
    {
        // Lógica para processar os inputs recebidos
        // Por exemplo, mover o objeto com base nos inputs
        Vector2 movimento = new Vector2(horizontal * speed, rig.velocity.y);
        print(horizontal);
        rig.velocity = movimento;

        anim.SetInteger("transition", 1);
        if(horizontal == 0)
        {
            anim.SetInteger("transition", 0);
        }
        


        if (!Mathf.Approximately(horizontal, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);
        }
    }

    void pular(InputAction.CallbackContext context)
    {
        if (grouded && context.performed)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            
        }
    }

    //public bool isGroud()
    //{
    //    Vector3 max = box.bounds.max;
    //    Vector3 min = box.bounds.min;
    //    Vector2 canto1 = new Vector2(max.x, min.y - .1f);
    //    Vector2 canto2 = new Vector2(max.x, min.y - .2f);

    //    Collider2D hit = Physics2D.OverlapArea(canto1, canto2);

    //    return grouded = false;

    //    if(hit != null)
    //    {
    //        return grouded = true;
    //    }

    //}



    //Função que confere c estou no chão
    public bool isGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheck.position, raio, layerChao);

        if(collider.Length >= 0)
        {
            for(int i = 0; i < collider.Length; i++)
            {
                //Confere c não é o player
                if(collider[i].gameObject != gameObject)
                {
                    return grouded = true; 
                }

            }
        }
        return  grouded = false;
    }

}
