using Mecanica;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lele : PersonagemBase
{

    [SerializeField] private Transform punchCheck;
    [SerializeField] private float raioSoco;
    [SerializeField] private LayerMask layerRivals;

    public KnockBack knockBack;


    private void OnEnable()
    {
        ControlerInputLeleEnable(idControler);
        ControlerInputEnable(idControler);
        

    }

    private void OnDisable()
    {
        ControlerInputLeleDisable(idControler);
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
        knockBack = new KnockBack();
    }

    void Update()
    {
        //Chamada de fun��o dessa classe
        IsGround();
        NoAr();

        //Anima�oes
        anim.SetFloat("Fall", rig.velocity.y);

        //Clhamada da classe m�e
        ControlerInputEnable(idControler);
        ControlerInputDisable(idControler);

        ControlerInputLeleEnable(idControler);
        ControlerInputLeleDisable(idControler);


    }

    private void Punch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            anim.SetTrigger("Punch");
        }
    }

    private void PunchColider()
    {

        Collider2D[] collider = Physics2D.OverlapCircleAll(punchCheck.position, raioSoco, layerRivals);
        foreach (Collider2D punched in collider)
        {
            if(punched.gameObject != gameObject)
            {
                if (punched.CompareTag("Zhang"))
                {
                    var posicaoGolpe = knockBack.AnguloVetor(punched.transform, gameObject.transform);

                    punched.GetComponent<Zhang>().Dano(10);
<<<<<<< HEAD:Project - EvoGen/Assets/Scripts/persongens/Lele.cs
                    punched.GetComponent<Zhang>().AtivarSairVonado(posicaoGolpe);
=======
                    punched.GetComponent<Zhang>().SaiVoando(punchCheck);
>>>>>>> b5ea2da60a7d920fddfd30c37f6ba36ff2a13de9:Project - EvoGen Bagunça/Assets/Scripts/persongens/Lele.cs
                }
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(punchCheck.position, 0.5f);
    }
}
