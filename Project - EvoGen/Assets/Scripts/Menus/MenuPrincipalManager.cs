using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string proximaCena;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelSons;
    [SerializeField] private GameObject painelControles;

    [SerializeField] private Button ButtonOpcoes;

    [SerializeField] private Button ButtonFazL;

    [SerializeField] private AudioSource fazL;

    [SerializeField] private AudioSource fundoMusical;

   
    private void Awake(){
        ButtonOpcoes.onClick.AddListener(OnButtonAbrirOpcoes);
        //ButtonFazL.onClick.AddListener(FazL);
    }

  
    public void Jogar()
    {
        SceneManager.LoadScene(proximaCena);
    }
 
    public void OnButtonAbrirOpcoes()
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

    //public void FazL(){
    //    fazL.Play();
    //    fundoMusical.Stop();
    //}
}