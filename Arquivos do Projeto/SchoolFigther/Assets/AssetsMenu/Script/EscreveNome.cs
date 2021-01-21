using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EscreveNome : MonoBehaviour
{
    public TextMeshProUGUI CaixaNome;
    string NomePro;

    void Start()
    {
        NomePro = nome.protagonista;
        CaixaNome.text = NomePro;
    }


}
