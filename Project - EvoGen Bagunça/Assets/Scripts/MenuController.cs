using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   public void IniciarJogo()
    {
        Debug.Log("Meuovo");
        SceneManager.LoadScene("Menu");
    }

    public void SairDoJogo()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }
}
