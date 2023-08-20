using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFogo : MonoBehaviour
{
    private Rigidbody2D rig;
    private Renderer render;

    public float speed;
    public int time;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoProjetil();
        ObjectDestroy();
    }

    void MovimentoProjetil()
    {
        rig.velocity = new Vector2(1f * speed, rig.velocity.y);
    }

    IEnumerator ObjectDestroy()
    {
        if (time >= 0 )
        {
            Destroy(gameObject);
            //render.enabled = false;
        }
        yield return new WaitForSeconds(1);
        time--;
    }
}


