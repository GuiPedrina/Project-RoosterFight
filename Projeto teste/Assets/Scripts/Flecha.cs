using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public bool Side;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
}
