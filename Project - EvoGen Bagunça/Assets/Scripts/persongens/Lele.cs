using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lele : PersonagemBase
{

    [SerializeField] private Transform punchCheck;
    [SerializeField] private float raioSoco;
    [SerializeField] private LayerMask layerRivals;


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

    void Update()
    {
        //Chamada de função dessa classe
        IsGround();
        NoAr();

        //Animaçoes
        anim.SetFloat("Fall", rig.velocity.y);

        //Clhamada da classe mãe
        ControlerInputEnable(idControler);
        ControlerInputDisable(idControler);

        ControlerInputLeleEnable(idControler);
        ControlerInputLeleDisable(idControler);


    }

    private void Punch(InputAction.CallbackContext context)
    {
        anim.SetTrigger("Punch");
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
                    punched.GetComponent<Zhang>().lifePercentage += 10;
                    punched.GetComponent<Zhang>().SaiVoando();
                }
            }
        }
        

    }
}
