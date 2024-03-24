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

    private int countPunch = 1;
    private float timePunch = 1f;

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
        
        if (context.performed)
        {
            switch (countPunch)
            {
                
                case 1:
                    StartCoroutine(RecargaCombo());
                    anim.SetTrigger("Punch1");
                    countPunch++;
                    break;

                case 2:
                    anim.SetTrigger("Punch2");
                    countPunch++;
                    break;

                case 3:
                    anim.SetTrigger("Punch3");
                    countPunch = 1;
                    break;

            }
        }
    }

    private void PunchColiderKnock()
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
                    punched.GetComponent<Zhang>().AtivarSairVonado(posicaoGolpe);
                }
            }
        }

    }

    public void PunchColider()
    {

        Collider2D[] collider = Physics2D.OverlapCircleAll(punchCheck.position, raioSoco, layerRivals);
        foreach (Collider2D punched in collider)
        {
            if (punched.gameObject != gameObject)
            {
                if (punched.CompareTag("Zhang"))
                {
                    var posicaoGolpe = knockBack.AnguloVetor(punched.transform, gameObject.transform);

                    punched.GetComponent<Zhang>().Dano(10);
                }
            }
        }

    }

    IEnumerator RecargaCombo()
    {
        yield return new WaitForSeconds(timePunch);
        switch (countPunch)
        {
            case 1:
                countPunch = 1;
                break;

            case 2:
                yield return new WaitForSeconds(timePunch);
                countPunch = 1;
                break;

            case 3:
                yield return new WaitForSeconds(timePunch * 2);
                countPunch = 1;
                break;
        }
        countPunch = 1;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(punchCheck.position, 0.5f);
    }
}
