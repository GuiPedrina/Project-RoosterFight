using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zhang : PersonagemBase
{
    private void OnEnable()
    {
        ControlerInputEnable(idControler);
    }

    private void OnDisable()
    {
        ControlerInputDisable(idControler);
    }

    private void Update()
    {
        IsGround();
        NoAr();
        anim.SetFloat("Fall", rig.velocity.y);
        //print(NoAr());

    public void SaiVoando()
    {
        rig.velocity = new Vector2(rig.velocity.x + lifePercentage, rig.velocity.y + 5);
    }

    
    

    //public void SetMovimento(Vector2 anda)
    //{
    //    movimento = anda;
    //}

}
