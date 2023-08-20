using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atk2 : MonoBehaviour
{

    public ControlesPlayer controles;

    private Animator anim;
    public Transform atkPoint;
    public LayerMask LayerEnemy;


    public float nextAtkMeele;
    public float attackMeeleRate = 2f;
    public float atkRange;


 





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

        if (controles.Player.AtkRanged.triggered)
        {
            AtkRanged();
        }
    }
    private void AtkMeele()
    {
        
            anim.SetTrigger("Punch");
            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, LayerEnemy);

            foreach (Collider2D damage in hitEnemy)
            {
                damage.GetComponent<Player2>().life -= 10;
            }
       
    }

    private void AtkRanged()
    {
        Transform rotate;
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



}
