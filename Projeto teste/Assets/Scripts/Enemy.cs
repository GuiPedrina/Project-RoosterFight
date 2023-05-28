using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHealth;
    int CurrentHealth;

    public Animator AnimEnemy;

    void Start()
    {
        CurrentHealth = MaxHealth;
        AnimEnemy = GetComponent<Animator>();
    }

    public void Damage (int damage)
    {
        CurrentHealth -= damage;

        //animação de dano
        AnimEnemy.SetTrigger("Damage");

        if (CurrentHealth >= 0)
        {
            AnimEnemy.SetInteger("Transition", 0);
        }
        //Chamando função de morrer
        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enimigo morreu");
        //animação de morte
        AnimEnemy.SetBool("isDead", true);
        //Desabilitando o inimigo
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        this.enabled = true;
    }

}
