using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGolpe : MonoBehaviour
{
    public Animator anim;
    public Transform AtkPoint;
    public ControlesPlayer Controles;
    public GameObject Flecha;
    public GameObject flecha;


    public LayerMask EnemyLayers;

    public float AtkRange = 0.5f;
    public int DamageAtk = 10;
    public bool isFire;

    public float attackMeeleRate = 2f;
    public float nextAttackMeele = 0;
    public float attackRangedRate = 5f;
    public float nextAttackRanged = 0f;



    // Update is called once per frame

    private void Awake()
    {
        Controles = new ControlesPlayer();
    }

    private void OnEnable()
    {
        Controles.Enable();
    }

    private void OnDisable()
    {
        Controles.Disable();
    }
    void Update()
    {
        if(Time.time >= nextAttackMeele)
        {
            if (Controles.Player.AtkMeele.triggered)
            {
                AttackMeele();
                nextAttackMeele = Time.time + 1f / attackMeeleRate;
            }
        }
        if (Time.time >= nextAttackRanged)
        {
            if (Controles.Player.AtkRanged.triggered)
            {
                AttackRanged();
                nextAttackRanged = Time.time + 1f / attackRangedRate;
            }
        }
    }

    void AttackMeele()
    {
        //Animeção de ataque
        anim.SetTrigger("MeeleAtk");

        //Colisao de ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AtkPoint.position,AtkRange, EnemyLayers);

        //Dano do ataque
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().Damage(DamageAtk);
            
        }
    }

    //Vou usar uma logica diferente do golpe meele 
    //vou usar coroutine pro ranged por aprendizado
    public void AttackRanged()
    {
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
     
       isFire = true;
       anim.SetInteger("transition", 3);
       flecha = Instantiate(Flecha, AtkPoint.position, AtkPoint.rotation);


        if (GetComponent<Player>().transform.rotation.y == 0)
        {
            flecha.GetComponent<Flecha>().Side = true;
        }

        else if (GetComponent<Player>().transform.rotation.y == -180)
        {
            flecha.GetComponent<Flecha>().Side = false;
        }

        yield return new WaitForSeconds(0.30f);
        anim.SetInteger("transition", 0);
        isFire = false;
    }

    private void OnDrawGizmosSelected()
    {
        if(AtkPoint == null)
        {
            return;

        }
        Gizmos.DrawSphere(AtkPoint.position, AtkRange);
    }
}
