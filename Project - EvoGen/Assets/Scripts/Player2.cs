using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public int life;

    private Rigidbody2D rig;
    private SpriteRenderer sprite;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();


        life = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            sprite.enabled = false;
            rig.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
