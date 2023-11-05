using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public  class PersonagemBase : MonoBehaviour
{
    // isGround()
    // isPlatform()
    // Jump
    // movement
    // speed
    // vida/dano


    public Rigidbody2D rig;
    private Transform posicao;
    public Animator anim;
    private BoxCollider2D box;
    
    

    //public Vector2 movement;
    private bool grounded;
    private bool isDoubleJumping;
    private bool isJumping = false;
    private bool isAir = false;
    private int pulosExtras;


    public int lifePercentage;
    public Transform groundCheck;
    public float raioGround;
    public LayerMask layerChao;
    


    [SerializeField] private float jumpForce = 12.0f;
    [SerializeField] private float speed = 0.5f;

    public static int idControler { get; set; }

    
    public void ControlerInputEnable(int idControler)
    {
        if(idControler == 0)
        {
            Player1Controller.OnHorizontalReceived += Andar;
            Player1Controller.OnJumpReceived += Pular;
        }

        else if(idControler == 1)
        {
            Player2Controller.OnHorizontalReceived += Andar;
            Player2Controller.OnJumpReceived += Pular;
        }
    }

    public void ControlerInputDisable(int idControler)
    {
        if (idControler == 0)
        {
            Player1Controller.OnHorizontalReceived -= Andar;
            Player1Controller.OnJumpReceived -= Pular;
        }

        else if (idControler == 1)
        {
            Player2Controller.OnHorizontalReceived -= Andar;
            Player2Controller.OnJumpReceived -= Pular;
        }
    }

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        posicao = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        lifePercentage = 0;
    }


    void Andar(float horizontal)
    {
        // Lógica para processar os inputs recebidos
        // Por exemplo, mover o objeto com base nos inputs

        Vector2 movimento = new Vector2(horizontal * speed, rig.velocity.y);
        print(horizontal);
        
        rig.velocity= movimento;

        if(!isAir && !isJumping)
        {
            anim.SetInteger("transition", 1);
        }
        if(horizontal == 0 && !isAir && !isJumping) 
        {
            anim.SetInteger("transition", 0);
        }
        

        if (!Mathf.Approximately(horizontal, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);
        }
    }

    void Pular(InputAction.CallbackContext context)
     {
        if (grounded && context.performed)
        {
            
            isJumping = true;
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            anim.SetInteger("transition", 2);
            pulosExtras++;
            rig.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        else if (!grounded && context.performed && pulosExtras > 0)
        {
            isJumping = true;
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            anim.SetTrigger("DoubleJump");
            pulosExtras--;

        }

        if (context.canceled && rig.velocity.y > 0f)
        {
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y * 0.5f);
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

    public bool IsGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheck.position, raioGround, layerChao);

        if(collider.Length >= 0)
        {
            for(int i = 0; i < collider.Length; i++)
            {
                //Confere c não é o player
                if(collider[i].gameObject != gameObject)
                {
                    
                    if (isJumping == false)
                    {
                    rig.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
                    }
                    pulosExtras = 1;
                    return grounded = true;
                    
                }

            }
        }
        rig.constraints = RigidbodyConstraints2D.FreezeRotation;
        isJumping = false;
        return  grounded = false;
    }

    public bool NoAr()
    {
        if (rig.velocity.y != 0)
        {
            
            return isAir = true;
        }
        else
        {
            return isAir = false;
        }
    }

}
