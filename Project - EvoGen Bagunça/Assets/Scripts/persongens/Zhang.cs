using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zhang : PersonagemBase
{
    private HUD hud;

    private void OnEnable()
    {
        ControlerInputEnable(idControler);
    }

    private void OnDisable()
    {
        ControlerInputDisable(idControler);
    }

    private void Awake()
    {
        hud = FindAnyObjectByType<HUD>();
    }

    private void Update()
    {
        IsGround();
        NoAr();
        anim.SetFloat("Fall", rig.velocity.y);

        ControlerInputEnable(idControler);
        ControlerInputDisable(idControler);

        //ControlerInputLeleEnable(idControler);
        //ControlerInputLeleDisable(idControler);

        //print(NoAr());
    }
    public void SaiVoando()
    {
        rig.velocity = new Vector2(rig.velocity.x + lifePercentage, rig.velocity.y + 10);
    }

    public void Dano(int dano)
    {
        lifePercentage += dano;
        hud.atualizaVida(lifePercentage);
    }

    
    

    //public void SetMovimento(Vector2 anda)
    //{
    //    movimento = anda;
    //}

}
