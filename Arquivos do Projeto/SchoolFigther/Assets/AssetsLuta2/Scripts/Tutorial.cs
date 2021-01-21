using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    //public GameObject JVLuta;
    public bool tutorial;
    public GameObject barrirer;
    public GameObject Dani;
    public GameObject Brown;
    public GameObject Mogli;
    public GameObject conversa;
    public bool conversaOn = true;
    private int Vet;
    public int entercontrole;
    public bool control;
    private bool tutor = false;
    private bool Parte1;
    private bool Parte2;
    private bool Parte3;
    private bool Parte4;
    private bool Parte5;
    public bool Parte6;

    public static Tutorial current;

    void Start()
    {
        current = this;

        if (tutorial == true)
        {
            if( (PlayerPrefs.GetInt("Veterano") != null) && (PlayerPrefs.GetInt("Veterano") != -10) )
            {
                Vet = PlayerPrefs.GetInt("Veterano");
            }
            else
            {
                Vet = EscolhaVet.vet;
            }
            
            if (Vet == 0)
            {
                Mogli.SetActive(false);
                Dani.SetActive(true);
                Brown.SetActive(false);
            }
            if (Vet == 1)
            {
                Mogli.SetActive(false);
                Dani.SetActive(false);
                Brown.SetActive(true);
            }
            if (Vet == 2)
            {
                Dani.SetActive(false);
                Brown.SetActive(false);
                Mogli.SetActive(true);
            }
        }
    }

    void Update()
    {

        if (tutorial == true)
        {
            control = Conversa.continua;

            if ((Input.GetKeyUp(KeyCode.Return)) && (control == true) && (tutor == false))
            {
                entercontrole += 1;
            }
            if (entercontrole == 4)
            {
                tutor = true;
                conversaOn = false;
                Dani.SetActive(false);
                Brown.SetActive(false);
                conversa.SetActive(false);
                if (Input.GetKeyDown(KeyCode.D) && (conversaOn == false))
                {
                    Parte2 = true;
                }
                if (Input.GetKeyDown(KeyCode.A) && (conversaOn == false))
                {
                    Parte1 = true;
                }

            }
            if ((Parte1 == true) && (Parte2 == true))
            {
                if (Vet == 0)
                {
                    Dani.SetActive(true);
                }
                if (Vet == 1)
                {
                    Brown.SetActive(true);
                }
                conversa.SetActive(true);
                conversaOn = true;
                tutor = false;

            }

            if (entercontrole == 6)
            {
                tutor = true;
                conversaOn = false;
                Dani.SetActive(false);
                Brown.SetActive(false);
                conversa.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space) && (conversaOn == false))
                {
                    Parte3 = true;
                }


            }
            if (Parte3 == true)
            {
                if (Vet == 0)
                {
                    Dani.SetActive(true);
                }
                if (Vet == 1)
                {
                    Brown.SetActive(true);
                }
                conversa.SetActive(true);
                conversaOn = true;
                tutor = false;


            }
            if (entercontrole == 8)
            {
                tutor = true;
                conversaOn = false;
                Dani.SetActive(false);
                Brown.SetActive(false);
                conversa.SetActive(false);
                if (Input.GetKeyDown(KeyCode.S) && (conversaOn == false))
                {
                    Parte4 = true;
                }

            }
            if (Parte4 == true)
            {
                if (Vet == 0)
                {
                    Dani.SetActive(true);
                }
                if (Vet == 1)
                {
                    Brown.SetActive(true);
                }
                conversa.SetActive(true);
                conversaOn = true;
                tutor = false;

            }
            if (entercontrole == 10)
            {
                tutor = true;
                conversaOn = false;
                Dani.SetActive(false);
                Brown.SetActive(false);
                conversa.SetActive(false);
                if (Input.GetKeyDown(KeyCode.M) && (conversaOn == false))
                {
                    Parte5 = true;
                }
            }
            if (Parte5 == true)
            {
                if (Vet == 0)
                {
                    Dani.SetActive(true);
                }
                if (Vet == 1)
                {
                    Brown.SetActive(true);
                }
                conversa.SetActive(true);
                conversaOn = true;
                tutor = false;


            }
            if (entercontrole == 17)
            {
                tutor = true;
                conversaOn = false;
                Dani.SetActive(false);
                Brown.SetActive(false);
                conversa.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Q) && (conversaOn == false))
                {                  
                    Parte6 = true;
                }
            }
            if (Parte6 == true)
            {
                if (Vet == 0)
                {
                    Dani.SetActive(true);
                }
                if (Vet == 1)
                {
                    Brown.SetActive(true);
                }
                tutor = true;
                conversaOn = false;
                Dani.SetActive(false);
                Brown.SetActive(false);
                conversa.SetActive(false);
                barrirer.SetActive(false);
                tutorial = false;
            }
            
            if (tutorial == false)
            {
                conversaOn = false;
                Dani.SetActive(false);
                Brown.SetActive(false);
                conversa.SetActive(false);
                barrirer.SetActive(false);
            }
            
        }
        else
        {
            tutorial = false;
        }
        if (tutorial == false)
        {
            conversaOn = false;
            Dani.SetActive(false);
            Brown.SetActive(false);
            conversa.SetActive(false);
            barrirer.SetActive(false);
        }


    }
 }
