using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    private Rigidbody2D rig;
    public BoxCollider2D box;

    public float speed;
    public bool Side;
    public int dmg; 


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Side)
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
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Player2>().Dano(dmg);
            Destroy(gameObject);
        }
    }
}
