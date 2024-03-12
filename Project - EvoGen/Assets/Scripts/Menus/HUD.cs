using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI textVida;
    public string vidaAtual;
    public Zhang zhang;
    
    // Start is called before the first frame update
    void Start()
    {
        textVida = GetComponent<TextMeshProUGUI>();
        zhang = new Zhang();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void atualizaVida(int vida)
    {
        textVida.text = vida.ToString() + "%";
    }
}
