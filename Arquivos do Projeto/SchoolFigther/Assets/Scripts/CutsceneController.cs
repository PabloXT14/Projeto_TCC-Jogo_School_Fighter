using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public int LutaScene;
    public bool veteranoScene;
    public int veterano;
    public GameObject DaniBoy;
    public GameObject Brown;
    public GameObject Mogli;
    public int Y;
    public int Entercontroller;
    public GameObject X;
    private Animator anim;
    public bool control;
    public static int Cs;

    void Start()
    {
        Cs = 0;
        anim = GetComponent<Animator>();
        anim.SetInteger("Ct", 0);
        Entercontroller = Y;
        veterano = EscolhaVet.vet;
        if (veteranoScene == true)
        {
            if (veterano == 0)
            {
                Brown.SetActive(false);
                DaniBoy.SetActive(true);
                Mogli.SetActive(false);
            }
            if (veterano == 1)
            {
                Brown.SetActive(true);
                DaniBoy.SetActive(false);
                Mogli.SetActive(false);
            }
            if (veterano == 2)
            {
                Brown.SetActive(false);
                DaniBoy.SetActive(false);
                Mogli.SetActive(true);
            }
        }
    }


    void Update()
    {
        LutaScene = Controller.lutas;
        control = Conversa.continua;
        if ((Input.GetKeyDown(KeyCode.Return)) && (control == true))
        {
            Entercontroller += 1;
        }
        if ((X.CompareTag("Player") || X.CompareTag("João Vindo")) && (Entercontroller == 1))
        {
            anim.SetInteger("Ct", 1);
            
        }
        if (X.CompareTag("Veterano") && (Entercontroller == 4))
        {
            anim.SetInteger("Ct", 1);
        }
        // Transição luta
        if ((Entercontroller == 7) && (Y == 0) && (X.CompareTag("Transição")))
        {
            anim.SetInteger("Ct", 1);
            StartCoroutine(Delay());
            control = true;
        }
        if ((Entercontroller == 19) && (Y == 16) && (X.CompareTag("Transição")))
        {
            anim.SetInteger("Ct", 1);
            StartCoroutine(Delay());
            control = true;
        }
        if ((Entercontroller == 27) && (Y == 23) && (X.CompareTag("Transição")))
        {
            anim.SetInteger("Ct", 1);
            StartCoroutine(Delay());
            control = true;
        }
        if ((Entercontroller == 32) && (Y == 28) && (X.CompareTag("Transição")))
        {
            anim.SetInteger("Ct", 1);
            StartCoroutine(Delay());
            control = true;
        }
        if ((Entercontroller == 46) && (Y == 40) && (X.CompareTag("Transição")))
        {
            anim.SetInteger("Ct", 1);
            StartCoroutine(Delay());
            control = true;
        }
        if ((Entercontroller == 57) && (Y == 52) && (X.CompareTag("Transição")))
        {
            anim.SetInteger("Ct", 1);
            StartCoroutine(Delay());
            control = true;
        }
        if ((X.CompareTag("Transição")) && (Y == 8))
        {
            anim.SetInteger("Ct", 2);
            Y = 1;
        }
        // Transição luta
        if (Entercontroller == 9)
        {
            anim.SetInteger("Ct", 2);
        }
        if (X.CompareTag("Veterano") && (Entercontroller == 14))
        {
            anim.SetInteger("Ct", 3);
        }
        if (Entercontroller == 13)
        {
            SceneManager.LoadScene(20);
            Cs += 1;
        }
        if (X.CompareTag("Professor") && (Entercontroller == 18))
        {
            anim.SetInteger("Ct", 1);
        }

        if (Entercontroller == 22)
        {
            SceneManager.LoadScene(23);
            Cs += 1;
        }
        if ((Entercontroller == 24) && (!X.CompareTag("Transição")))
        {
            anim.SetInteger("Ct", 1);
        }
        if ((Entercontroller == 25) && (!X.CompareTag("Transição")))
        {
            anim.SetInteger("Ct", 2);
        }
        if (Entercontroller == 28)
        {
            anim.SetInteger("Ct", 3);
        }
        if (Entercontroller == 29)
        {
            anim.SetInteger("Ct", 4);
        }
        if (Entercontroller == 34)
        {
            anim.SetInteger("Ct", 3);
        }
        if (Entercontroller == 39)
        {
            SceneManager.LoadScene(52);
            Cs += 1;
        }
        if (Entercontroller == 51)
        {
            SceneManager.LoadScene(29);
            Cs += 1;
        }


    }
    IEnumerator Delay()  
    {
        yield return new WaitForSeconds(0.5f);
        if(LutaScene == 0)
        {
            SceneManager.LoadScene(35);
            anim.SetInteger("Ct", 2);
        }
        if (LutaScene == 1)
        {
            SceneManager.LoadScene(39);
            anim.SetInteger("Ct", 2);
        }
        if (LutaScene == 2)
        {
            SceneManager.LoadScene(45);
            anim.SetInteger("Ct", 2);
        }
        if (LutaScene == 3)
        {
            SceneManager.LoadScene(46);
            anim.SetInteger("Ct", 2);
        }
        if (LutaScene == 4)
        {
            SceneManager.LoadScene(49);
            anim.SetInteger("Ct", 2);
        }
        if (LutaScene == 5)
        {
            if(veterano == 0)
            {
                SceneManager.LoadScene(54);
            }
            if (veterano == 1)
            {
                SceneManager.LoadScene(55);
            }
            if (veterano == 2)
            {
                SceneManager.LoadScene(55);
            }
            anim.SetInteger("Ct", 2);
        }
    }
}

