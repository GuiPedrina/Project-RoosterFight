using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCam : MonoBehaviour
{
    private Transform Player;
    private Transform Player2;
    public float smooth;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Player2 = GameObject.FindGameObjectWithTag("Player2").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Player.position.x >= -1 && Player.position.x <= 29.1 )
        {
            Vector3 following = new Vector3(Player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }
        if(Player2.position.x >= -1 && Player2.position.x <= 29.1)
        {
            Vector3 following = new Vector3(Player2.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }
    }   
}
