using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class nome : MonoBehaviour
{
    public static string protagonista;
    public int sex;
    [SerializeField] public TextMeshProUGUI campoTexto;
    

    private void Start()
    {
        sex = EscolhaSX.sexo;
        if (sex == 0)
        {
            protagonista = "SEBASTIÃO";
        }
        if (sex == 1)
        {
            protagonista = "RENATA";
        }

    }

    public void EntradaDeCaractere(string _caractere)
    {
        campoTexto.text += _caractere;
        protagonista = campoTexto.text;
        if (campoTexto.text == "")
        {
            if (sex == 0)
            {
                protagonista = "SEBASTIÃO";
            }
            if (sex == 1)
            {
                protagonista = "RENATA";
            }
        }
    }

    public void ApagarCaractere()
    {
        if(campoTexto.text != "") {
        campoTexto.text = campoTexto.text.Substring(0, campoTexto.text.Length - 1);
        }
    }
    public void Verificarnome()
    {
        if (campoTexto.text == "")
        {
            if (sex == 0)
            {
                protagonista = "SEBASTIÃO";
            }
            if (sex == 1)
            {
                protagonista = "RENATA";
            }
        }
    }

}
