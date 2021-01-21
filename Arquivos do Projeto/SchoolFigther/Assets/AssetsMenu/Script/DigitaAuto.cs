using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DigitaAuto : MonoBehaviour
{
    public GameObject auto;
    public TextMeshProUGUI TextoFinal;
    public TextMeshProUGUI TextoEntrada;
    string mensagem = "";
    char TextoSaida;
    public bool controle;
    string convert;

    public void Start()
    {
        convert = TextoEntrada.text;
    }
 
    // Update is called once per frame
    public void Update()
    {
            //Se Controle for Verdadeiro
            if (controle)
        {
            //Chama TypeWriter
            StartCoroutine(TypeRight());
        }
    }

    
    IEnumerator TypeRight()
    {
        //Desliga o controle para que ele não se inicialize a cada frame da função Update()
        controle = false;
        for (int i = 0; i < convert.Length; i++)
        {
            //Pega Caracter por Caracter da string TextoEntrada
            TextoSaida = convert[i];
            //Agrupa todos os caracteres da String a cada Loop
            mensagem += TextoSaida;
            TextoFinal.text = mensagem;
            //Cria um Tempo de 1 milessimos de segundos
            yield return new WaitForSeconds(0.05f);
            
            }
        
    }
 
  
}


