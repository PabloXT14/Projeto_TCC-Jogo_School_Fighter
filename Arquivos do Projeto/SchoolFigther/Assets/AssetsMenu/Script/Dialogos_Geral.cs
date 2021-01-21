using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogos_Geral : MonoBehaviour
{
    public string dialogos;
    public TextMeshProUGUI campo_text;
    char TextoSaida;
    public bool controle;
    string mensagem = "";
    public static bool End;

    void Start()
    {
        campo_text.text = dialogos;
    }

    // Update is called once per frame
    void Update()
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
        for (int i = 0; i < dialogos.Length; i++)
        {
            //Pega Caracter por Caracter da string TextoEntrada
            TextoSaida = dialogos[i];
            //Agrupa todos os caracteres da String a cada Loop
            mensagem += TextoSaida;
            campo_text.text = mensagem;
            //Cria um Tempo de 1 milessimos de segundos
            yield return new WaitForSeconds(0.05f);
               
        }
    }
   
    public void escreve()
    {
        campo_text.text = dialogos;
    }

    
}
