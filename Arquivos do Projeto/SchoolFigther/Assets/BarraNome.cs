using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarraNome : MonoBehaviour
{
    public GameObject PlayerF;
    public GameObject PlayerM;
    public TextMeshProUGUI barraNome;
    private string NomeP;
    public int sex;


    void Start()
    {
        if( (PlayerPrefs.GetString("Nome") != null) && (PlayerPrefs.GetString("Nome") != "-10") )
        {
            NomeP = PlayerPrefs.GetString("Nome");
        }
        else
        {
            NomeP = nome.protagonista;
        }
        
        if( (PlayerPrefs.GetInt("Sexo") != EscolhaSX.sexo) && (PlayerPrefs.GetInt("Sexo") != -10) )
        {         
            sex = EscolhaSX.sexo;
        }
        else
        {
            sex = PlayerPrefs.GetInt("Sexo");
        }
        
        barraNome.text = NomeP;
    }

    // Update is called once per frame
    void Update()
    {

        if (EscolhaSX.sexo == 0)
        {
            PlayerF.SetActive(false);
            PlayerM.SetActive(true);
            //Destroy(PlayerF);
                 
        }

        if (EscolhaSX.sexo == 1)
        {
            //Destroy(PlayerM);
            PlayerM.SetActive(false);
            PlayerF.SetActive(true);
            
            
        }
    }
}
