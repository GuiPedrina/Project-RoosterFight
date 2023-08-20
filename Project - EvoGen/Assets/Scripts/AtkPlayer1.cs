using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkPlayer1 : MonoBehaviour
{

    private Animator anim;
    public Transform AtkPoint;
    public ControlesPlayer controles;
    private GameObject boladeFogo;
    public GameObject BolaFogo;
    public LayerMask enemyLayers;

    public float AtkRange = 0.5f;
    public float nextAtkRanged = 0f;
    public float nextAtkRangedRate = 0.5f;

    public bool isFire;

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


    void Update()
    {
        /*
        if(Time.time >= nextAtkRanged)
        {
            if (controles.Player.AtkRanged.triggered)
            {
                AtkRanged();
                nextAtkRanged = Time.time + 1f / nextAtkRangedRate;
            }
        }
        */
    }

    void Meele()
    {
        anim.SetTrigger("Punch");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AtkPoint.position, AtkRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {

        }
    }
/*
    private void AtkRanged()
    {
       StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        isFire = true;
        anim.SetInteger("transition", 3);
        boladeFogo = Instantiate(BolaFogo, AtkPoint.position, AtkPoint.rotation);

        if(GetComponent<Player1Move>().transform.rotation.y == 0)
        {
            boladeFogo.GetComponent<BolaFogo>().side = false;
        }

        if(GetComponent<Player1Move>().transform.rotation.y == -180)
        {
            boladeFogo.GetComponent<BolaFogo>().side = true;
        }

        yield return new WaitForSeconds(0.30f);
        anim.SetInteger("transition", 0);
        isFire = false;

    }

    private void OnDrawGizmosSelected()
    {
        if (AtkPoint == null)
        {
            return;
        }
        Gizmos.DrawSphere(AtkPoint.position, AtkRange);
    }
    */
}
