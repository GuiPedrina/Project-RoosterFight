using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zhang : PersonagemBase
{
     

    

    private void Update()
    {
        IsGround();
        NoAr();
        anim.SetFloat("Fall", rig.velocity.y);
        //print(NoAr());

    }

    

    //public void SetMovimento(Vector2 anda)
    //{
    //    movimento = anda;
    //}

}
