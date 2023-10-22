using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atk2 : MonoBehaviour
{

    public ControlesPlayer controles;

    private Animator anim;
    public Transform atkPointSoco;
    public Transform atkPointFogo;
    public LayerMask LayerEnemy;


    public float nextAtkMeele;
    public float attackMeeleRate = 2f;
    public float atkRange;
    public float nextAtkRange;
    public float atkRangeRate = 2f;
    public GameObject profBolaDeFogo;


 

    private void Awake()
    {
        controles = new ControlesPlayer();
        
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Disable();
    }


    void Update()
    {
        if(Time.time > nextAtkMeele)
        {
            if (controles.Player.AtkMeele.triggered)
            {
                AtkMeele();
                nextAtkMeele = Time.time + 1f / attackMeeleRate;
            }
        }

        if (Time.time > nextAtkRange)
        {
            if (controles.Player.AtkRanged.triggered)
            {
                AtkRanged();
                nextAtkRange = Time.time + 1f / atkRangeRate;
            }
        }
    }
    private void AtkMeele()
    {
        
            
            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(atkPointSoco.position, atkRange, LayerEnemy);
            anim.SetTrigger("Punch");
            foreach (Collider2D damage in hitEnemy)
            {
                damage.GetComponent<Player2>().life -= 10;
            }
       
    }

    private void AtkRanged()
    {
        Transform rotate;
        StartCoroutine(Atira());

        rotate = GetComponent<Transform>();
        anim.SetTrigger("Fire");
        if(rotate.rotation.y == 0f)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }

        else
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }

        
        
    }

    IEnumerator Atira()
    {
        GameObject gerarFogo = Instantiate(profBolaDeFogo, atkPointFogo.position, atkPointFogo.rotation);

        if (GetComponent<Player1Move>().transform.rotation.y == 0)
        {
            gerarFogo.GetComponent<BolaFogo>().side = true;
        }
        if (GetComponent<Player1Move>().transform.rotation.y == 180)
        {
            gerarFogo.GetComponent<BolaFogo>().side = false;
        }



        yield return new WaitForSeconds(2);
        Destroy(gerarFogo);

    }



}
