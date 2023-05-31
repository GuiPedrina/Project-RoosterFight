using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Golpe : MonoBehaviour
{
    public Animator anim;
    public Transform Atkpoint2;
    private ControlesPlayer Controles;

    public float AtkRange = 0.5f;
    public int AtkDamage;

    public LayerMask layerEnemy;

    public float attackMeeleRate = 2f;
    public float nextAttackMeele = 0;

    public bool isSoco;

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

    // Update is called once per frame
    void Update()
    {
     if(Time.time >= nextAttackMeele)
        {
            if (Controles.Player2.MeeleAtk.triggered)
            {
                AttackMeele();
                nextAttackMeele = Time.time + 1f / attackMeeleRate;
            }
        }   
    }

    public void AttackMeele()
    {
         anim.SetTrigger("MeeleAtk2");

        Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(Atkpoint2.position, AtkRange, layerEnemy);
        foreach (Collider2D enemy in hitEnemis)
        {
            
            //enemy.GetComponent<Enemy>().Damage(AtkDamage);
            enemy.GetComponent<Player>().Dano(AtkDamage);

        }
        //StartCoroutine("Soco");
    }

    //IEnumerator Soco()
    //{
        //anim.SetInteger("transition", 4);
        //isSoco = true;

        //Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(Atkpoint2.position, AtkRange, layerEnemy);
        //foreach (Collider2D enemy in hitEnemis)
        //{
        //    enemy.GetComponent<Enemy>().Damage(AtkDamage);

        //}
        //yield return new WaitForSeconds(0.67f);
        //anim.SetInteger("transition", 0);
        //isSoco = false;
    //}
}
