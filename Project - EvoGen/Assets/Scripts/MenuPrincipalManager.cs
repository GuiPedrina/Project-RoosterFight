using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelSons;
    [SerializeField] private GameObject painelControles;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
        
    }
 
    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
        
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

    public void AbrirSons(){

        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(false);
        painelSons.SetActive(true);
    }

    public void FecharSons(){
        
        painelSons.SetActive(false);
        painelOpcoes.SetActive(true);
        
    }

    public void AbrirControles(){

        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(false);
        painelControles.SetActive(true);
    }

    public void FecharControles(){
        
        painelControles.SetActive(false);
        painelOpcoes.SetActive(true);
        
    }
}
