using Mecanica;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zhang : PersonagemBase
{
    private HUD hud;
    private bool voando = false;
    private Vector2 direcaoVoo;
    private KnockBack knockback;
    private int vida;
    private int peso = 6;

    private void OnEnable()
    {
        ControlerInputEnable(idControler);
    }

    private void OnDisable()
    {
        ControlerInputDisable(idControler);
    }

    public void ControlerInputLeleEnable(int idControler)
    {
        if (idControler == 0)
        {
            Player1Controller.OnPunchReceived += Punch;
        }

        else if (idControler == 1)
        {
            //Player2Controller.OnPunchReceived += Pular;
        }
    }

    public void ControlerInputLeleDisable(int idControler)
    {
        if (idControler == 0)
        {
            Player1Controller.OnPunchReceived -= Punch;
        }

        else if (idControler == 1)
        {
        }
    }




    private void Awake()
    {
        hud = FindAnyObjectByType<HUD>();
        knockback = new KnockBack();
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

    private void FixedUpdate()
    {
        SaiVoando();
    }

    public void AtivarSairVonado(Vector2 posicaoDano)
    {
        voando = true;
        StartCoroutine(timeKnockBack());

        direcaoVoo = posicaoDano;
    }
    public void SaiVoando()
    {
        //rig.velocity = new Vector2(rig.velocity.x + lifePercentage, rig.velocity.y + 10);
        if (voando)
        {
            //knockback.lancar(gameObject, direcaoVoo, 1, vida, gameObject.tag);

            //Vector2 direction = (this.transform.position - direcaoVoo.transform.position).normalized;
            //rig.AddForce(new Vector2((lifePercentage * direcaoVoo.x) * 0.1f, (lifePercentage *  direcaoVoo.y) * 0.1f), ForceMode2D.Impulse);
            rig.AddForce(direcaoVoo.normalized * vida * 0.1f, ForceMode2D.Impulse);
        }
    }

    private void Punch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            anim.SetTrigger("Punch");
        }
    }


    public void Dano(int dano)
    {
        lifePercentage += dano;
        vida += dano;
        hud.atualizaVida(lifePercentage);
    }

    IEnumerator timeKnockBack() 
    {
        yield return new WaitForSeconds(0.5f);
        voando = false;
    }
    

    //public void SetMovimento(Vector2 anda)
    //{
    //    movimento = anda;
    //}

}
