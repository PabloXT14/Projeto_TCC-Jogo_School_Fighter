using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Seta : MonoBehaviour
{
    public GameObject seta;
    public GameObject seta1;
    public GameObject seta2;
    public GameObject texto;
    public GameObject texto1;
    public GameObject texto2;
    public GameObject sair;
    int controle = 1;
    public string Proxcena; 
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        seta.SetActive(false);
        seta1.SetActive(false);
        seta2.SetActive(false);
       

    }

    // Update is called once per frame
    void Update()
    {
        seta.SetActive(true);
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            controle = controle + 1;
            if (controle > 4)
            {
                controle = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            controle = controle - 1;
            if (controle < 1)
            {
                controle = 4;
            }
        }
        if (controle == 1)
        {
            seta.SetActive(true);
            seta1.SetActive(false);
            seta2.SetActive(false);
            texto.SetActive(true);
            texto1.SetActive(false);
            texto2.SetActive(false);
            // di.text = "O café aumenta sua velocidade de movimento no mapa, Duração: 1 dia  \nR$3,00";
            sair.GetComponent<Renderer>().material.color = Color.white;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                
            }
        }
        if (controle == 2)
        {
            seta.SetActive(false);
            seta1.SetActive(true);
            seta2.SetActive(false);
            texto.SetActive(false);
            texto1.SetActive(true);
            texto2.SetActive(false);
            //di.text = "A água faz com que você comece com um pouco energia na batalha, Duração: 1 batalha \nR$2,50";
            sair.GetComponent<Renderer>().material.color = Color.white;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                
            }
        }
        if (controle == 3)
        {
            seta.SetActive(false);
            seta1.SetActive(false);
            seta2.SetActive(true);
            texto.SetActive(false);
            texto1.SetActive(false);
            texto2.SetActive(true);
            //di.text = "O pão de queijo faz com que você comece com muita energia na batalha, Duração: 1 batalha \nR$3,00";
            sair.GetComponent<Renderer>().material.color = Color.white;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                
            }

        }
        if (controle == 4)
        {
            seta.SetActive(false);
            seta1.SetActive(false);
            seta2.SetActive(false);
            sair.GetComponent<Renderer>().material.color = Color.yellow;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(Proxcena);
            }
        }

    }
}
