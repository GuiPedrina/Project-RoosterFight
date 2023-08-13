using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFogo : MonoBehaviour
{
    private Rigidbody2D rig;
    private BoxCollider2D box;

    public float speed;
    public float dmg;
    public bool side;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (side)
        {
            rig.velocity = new Vector2(1f * speed, 0f);
        }
        else
        {
            rig.velocity = new Vector2(-1f * speed, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
