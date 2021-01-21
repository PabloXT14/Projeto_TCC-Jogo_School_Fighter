using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VeteranoChat : MonoBehaviour
{
    public GameObject Dani;
    public GameObject Brown;
    public GameObject Mogli;
    public GameObject Pablo;
    public GameObject Protagonista;
    public int veterano;
    public bool turn;
    public bool turn1;
    public bool turn2;
    public bool turn3;
    public GameObject SpriteDani;
    public GameObject SpriteDani2;
    public GameObject SpriteBrown;
    public GameObject SpriteBrown2;
    public GameObject SpriteMogli;
    public GameObject SpriteMogli2;
    public GameObject SpritePablo;
    public GameObject SpritePablo2;

    void Start()
    {
        if( (PlayerPrefs.GetInt("Veterano") != null) && (PlayerPrefs.GetInt("Veterano") != -10) )
        {
            veterano = PlayerPrefs.GetInt("Veterano");
        }
        else
        {
            veterano = EscolhaVet.vet;
        }
        


        if (veterano == 0)
        {
            Dani.tag = "Veterano";
            Brown.tag = "Chat1";
            Mogli.tag = "Chat2";
            Pablo.tag = "Chat3";
        }
        if (veterano == 1)
        {
            Brown.tag = "Veterano";
            Dani.tag = "Chat0";
            Mogli.tag ="Chat2";
            Pablo.tag = "Chat3";
        }
        if (veterano == 2)
        {
            Mogli.tag = "Veterano";
            Brown.tag = "Chat1";
            Dani.tag = "Chat0";
            Pablo.tag = "Chat3";
        }
    }
    void Update()
    {
        turn = Player.chat;
        turn1 = Player.chat1;
        turn2 = Player.chat2;
        turn3 = Player.chat3;

            if (turn == true) 
            {
                SpriteDani.SetActive(false);
                SpriteDani2.SetActive(true);
            }
            else if (turn == false) 
            {
                SpriteDani.SetActive(true);
                SpriteDani2.SetActive(false);
            }
            if (turn1 == true)
            {
                SpriteBrown.SetActive(false);
                SpriteBrown2.SetActive(true);
            }
            else if (turn1 == false)
            {
                SpriteBrown.SetActive(true);
                SpriteBrown2.SetActive(false);
            }
            if (turn2 == true)
            {
                SpriteMogli.SetActive(false);
                SpriteMogli2.SetActive(true);
            }
            else if (turn2 == false)
            {
                SpriteMogli.SetActive(true);
                SpriteMogli2.SetActive(false);
            }
            if (turn3 == true)
            {
            SpritePablo.SetActive(false);
            SpritePablo2.SetActive(true);
            }
            else if (turn3 == false)
            {
            SpritePablo.SetActive(true);
            SpritePablo2.SetActive(false);
            }

    }

}
