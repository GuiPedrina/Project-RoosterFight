using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFogo : MonoBehaviour
{
    private Rigidbody2D rig;
    private Renderer render;

    public float speed;
    public int time;
    public bool side;

    private int damage = 10;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    { 
      MovimentoProjetil();       
    }

    void MovimentoProjetil()
    {
        if (side)
        {
            rig.velocity = new Vector2(1f * speed, rig.velocity.y);
        }
        if(side == false)
        {
            rig.velocity = new Vector2(-1f * speed, rig.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Player2>().dano(damage);
        Destroy(gameObject);
    }

}


