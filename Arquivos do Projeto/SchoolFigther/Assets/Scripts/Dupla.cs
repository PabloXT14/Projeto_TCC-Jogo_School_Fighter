﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Dupla : MonoBehaviour
{
    public int sx;
    public float Speedy;
    public float Speedx;
    public float Tam;
    public GameObject Press;
    public GameObject Wall;
    public GameObject PlayerFem;
    public GameObject PlayerMasc;
    public GameObject CaixaDialogo;
    private SpriteRenderer sprite;
    private Rigidbody2D rig;
    private Animator anim;
    public static bool chat;
    public static bool chat1;
    public static bool chat2;
    private bool offDialogo;
    private bool offFrase;
    public GameObject Brown;
    public GameObject Mogli;

    // Start is called before the first frame update
    void Start()
    {
        sx = EscolhaSX.sexo;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (sx == 0)
        {
            PlayerFem.SetActive(false);
        }
        if (sx == 1)
        {
            PlayerMasc.SetActive(false);
        }
    }


    void OnTriggerStay2D(Collider2D contact)
    {
        if (contact.gameObject.tag == "Trigger")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 10;
        }
        if (contact.gameObject.tag == "Row 1")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 3;
        }
        if (contact.gameObject.tag == "Row 2")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 5;
        }
        if (contact.gameObject.tag == "Row 3")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 7;
        }
        if (contact.gameObject.tag == "Row 4")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 9;
        }
        if (contact.gameObject.tag == "Row 5")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 11;
        }
        if (contact.gameObject.tag == "Row 6")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 13;
        }
        if (contact.gameObject.tag == "Row 7")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 15;
        }
        if (contact.gameObject.tag == "Row 8")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 17;
        }
        if (contact.gameObject.tag == "OpostTrigger")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 1;
        }
        if (contact.gameObject.tag == "ChangeRef1")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(31);
            }
        }
        if (contact.gameObject.tag == "ChangeRef2")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(45);
            }
        }
        if (contact.gameObject.tag == "ChangeInfo1")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(28);
            }
        }
        if (contact.gameObject.tag == "ChangeInfo2")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(26);
            }
        }
        if (contact.gameObject.tag == "ChangeCant")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(35);
            }
        }
        if (contact.gameObject.tag == "ChangeAula")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(22);
            }
        }
        if (contact.gameObject.tag == "ChangeSala3°")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(37);
            }
        }
        if (contact.gameObject.tag == "ChangeVal1")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(27);
            }
        }
        if (contact.gameObject.tag == "ChangeVal2")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(24);
            }
        }
        if (contact.gameObject.tag == "ChangeQua")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(33);
            }
        }
        if (contact.gameObject.tag == "ChangeBib")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(30);
            }
        }
        if (contact.gameObject.tag == "ChangeEnf")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(25);
            }
        }
        if (contact.gameObject.tag == "InfoExt")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(9);
            }
        }
        if (contact.gameObject.tag == "CalTransi")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(29);
            }
        }
        if (contact.gameObject.tag == "RefExt")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(11);
            }
        }
        if (contact.gameObject.tag == "BibExt")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(14);
            }
        }
        if (contact.gameObject.tag == "AudiExt")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(18);
            }
        }
        if (contact.gameObject.tag == "AulaExt")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(15);
            }
        }
        if (contact.gameObject.tag == "Cutscene")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(7);
            }
        }
        if (contact.gameObject.tag == "ChangeAudi")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(34);
            }
        }
        if (contact.gameObject.tag == "CozCorr")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(46);
            }
        }
        if (contact.gameObject.tag == "CozQua")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(33);
            }
        }
        if (contact.gameObject.tag == "CorrVal")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(42);
            }
        }
        if (contact.gameObject.tag == "ValCal")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(43);
            }
        }
        if (contact.gameObject.tag == "Cut5")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(39);
            }
        }
        if (contact.gameObject.tag == "QuaCoz")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(31);
            }
        }
        if (contact.gameObject.tag == "CalVal")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(44);
            }
        }
        if (contact.gameObject.tag == "AulaExt3")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(17);
            }
        }
        if (contact.gameObject.tag == "AudiCoz")
        {
            Press.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(33);
            }
        }
        if (contact.gameObject.tag == "Peixebolagato")
        {
            CaixaDialogo.SetActive(true);
        }


        if (contact.gameObject.tag == "Wall")
        {
            Wall.SetActive(true);
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 3;
        }
        if (contact.gameObject.tag == "Diminui")
        {
        }
        if (contact.gameObject.tag == "Aumenta")
        {
        }
        if (contact.gameObject.tag == "GameController")
        {
            CaixaDialogo.SetActive(true);
        }
        if (contact.gameObject.tag == "Veterano")
        {

            if (Input.GetKey(KeyCode.E))
            {
                CaixaDialogo.SetActive(true);
                chat = true;
            }
        }

        if (contact.gameObject.tag == "Chat1")
        {
            if (Input.GetKey(KeyCode.E))
            {
                chat1 = true;
                Brown.SetActive(true);
            }
        }
        if (contact.gameObject.tag == "Chat2")
        {
            if (Input.GetKey(KeyCode.E))
            {
                chat2 = true;
                Mogli.SetActive(true);
            }
        }

    }
    void OnTriggerExit2D(Collider2D contact)
    {
        Press.SetActive(false);
        if (contact.gameObject.tag == "Trigger")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 1;
        }
        if (contact.gameObject.tag == "Row 1")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 15;
        }
        if (contact.gameObject.tag == "Row 2")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 15;
        }
        if (contact.gameObject.tag == "Row 3")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 15;
        }
        if (contact.gameObject.tag == "Row 4")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 15;
        }
        if (contact.gameObject.tag == "Row 5")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 15;
        }
        if (contact.gameObject.tag == "Row 6")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 15;
        }
        if (contact.gameObject.tag == "Row 7")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 15;
        }
        if (contact.gameObject.tag == "Row 8")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 15;
        }
        if (contact.gameObject.tag == "OpostTrigger")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 10;
        }
        if (contact.gameObject.tag == "Wall")
        {
            Wall.SetActive(false);
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 1;
        }
        if (contact.gameObject.tag == "GameController")
        {
            CaixaDialogo.SetActive(false);
        }
        if (contact.gameObject.tag == "Peixebolagato")
        {
            CaixaDialogo.SetActive(false);
        }
        if (contact.gameObject.tag == "Chat1")
        {
            chat1 = false;
            Brown.SetActive(false);
        }
        if (contact.gameObject.tag == "Chat2")
        {
            chat2 = false;
            Mogli.SetActive(false);
        }

    }

    void Update()
    {
        offDialogo = Conversa.endChat;
        offFrase = Dialogos_Geral.End;

        if (((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow))) || ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.S) || (chat == true))))
        {
            if (chat == true)
            {
                Speedy = 0;
                Speedx = 0;
            }
            if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.A)))
            {
                if ((anim.GetBool("R") == true) || ((anim.GetBool("D") == true)) || ((anim.GetBool("U") == true)))
                {
                    if (anim.GetBool("U") == true)
                    {
                        Speedx = 0;
                        rig.velocity = new Vector2(rig.velocity.x, Speedy);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("R", false);
                        anim.SetBool("D", false);
                        anim.SetBool("L", false);
                        anim.SetBool("U", false);
                    }
                    if (anim.GetBool("D") == true)
                    {
                        Speedx = 0;
                        rig.velocity = new Vector2(rig.velocity.x, -Speedy);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("D", false);
                        anim.SetBool("U", false);
                        anim.SetBool("R", false);
                        anim.SetBool("L", false);
                    }
                    if (anim.GetBool("R") == true)
                    {
                        Speedy = 0;
                        rig.velocity = new Vector2(Speedx, rig.velocity.y);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("U", false);
                        anim.SetBool("D", false);
                        anim.SetBool("R", false);
                        anim.SetBool("L", false);
                    }
                }
                else
                {
                    rig.velocity = new Vector2(-Speedx, rig.velocity.y);
                    anim.SetBool("IsWalking", true);
                    anim.SetBool("L", true);
                    anim.SetBool("D", false);
                    anim.SetBool("U", false);
                    anim.SetBool("R", false);
                    Speedy = 0;
                }
            }

            if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.D))) 
            {
                if ((anim.GetBool("L") == true) || ((anim.GetBool("D") == true)) || ((anim.GetBool("U") == true)))
                {
                    if (anim.GetBool("U") == true)
                    {
                        Speedx = 0;
                        rig.velocity = new Vector2(rig.velocity.x, Speedy);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("U", false);
                        anim.SetBool("D", false);
                        anim.SetBool("R", false);
                        anim.SetBool("L", false);
                    }
                    if (anim.GetBool("D") == true)
                    {
                        Speedx = 0;
                        rig.velocity = new Vector2(rig.velocity.x, -Speedy);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("D", false);
                        anim.SetBool("L", false);
                        anim.SetBool("U", false);
                        anim.SetBool("R", false);
                    }
                    if (anim.GetBool("L") == true)
                    {
                        Speedy = 0;
                        rig.velocity = new Vector2(-Speedx, rig.velocity.y);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("L", false);
                        anim.SetBool("D", false);
                        anim.SetBool("U", false);
                        anim.SetBool("R", false);
                    }
                }
                else
                {
                    rig.velocity = new Vector2(Speedx, rig.velocity.y);
                    anim.SetBool("IsWalking", true);
                    anim.SetBool("L", false);
                    anim.SetBool("D", false);
                    anim.SetBool("U", false);
                    anim.SetBool("R", true);
                    Speedy = 0;
                }
            }

            if ((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.W)))
            {
                if ((anim.GetBool("L") == true) || ((anim.GetBool("D") == true)) || ((anim.GetBool("R") == true)))
                {
                    if (anim.GetBool("D") == true)
                    {
                        Speedx = 0;
                        rig.velocity = new Vector2(rig.velocity.x, -Speedy);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("R", false);
                        anim.SetBool("D", false);
                        anim.SetBool("U", false);
                        anim.SetBool("L", false);
                    }
                    if (anim.GetBool("R") == true)
                    {
                        Speedy = 0;
                        rig.velocity = new Vector2(Speedx, rig.velocity.y);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("D", false);
                        anim.SetBool("L", false);
                        anim.SetBool("R", false);
                        anim.SetBool("U", false);
                    }
                    if (anim.GetBool("L") == true)
                    {
                        Speedy = 0;
                        rig.velocity = new Vector2(-Speedx, rig.velocity.y);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("L", false);
                        anim.SetBool("D", false);
                        anim.SetBool("R", false);
                        anim.SetBool("U", false);
                    }
                }
                else
                {
                    rig.velocity = new Vector2(rig.velocity.x, Speedy);
                    anim.SetBool("IsWalking", true);
                    anim.SetBool("U", true);
                    anim.SetBool("D", false);
                    anim.SetBool("R", false);
                    anim.SetBool("L", false);
                    Speedx = 0;
                }
            }
            if ((Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.S))) 
            {
                if ((anim.GetBool("L") == true) || ((anim.GetBool("U") == true)) || ((anim.GetBool("R") == true)))
                {
                    if (anim.GetBool("U") == true)
                    {
                        Speedx = 0;
                        rig.velocity = new Vector2(rig.velocity.x, Speedy);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("R", false);
                        anim.SetBool("U", false);
                        anim.SetBool("D", false);
                        anim.SetBool("L", false);
                    }
                    if (anim.GetBool("R") == true)
                    {
                        Speedy = 0;
                        rig.velocity = new Vector2(Speedx, rig.velocity.y);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("U", false);
                        anim.SetBool("L", false);
                        anim.SetBool("R", false);
                        anim.SetBool("D", false);
                    }
                    if (anim.GetBool("L") == true)
                    {
                        Speedy = 0;
                        rig.velocity = new Vector2(-Speedx, rig.velocity.y);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("L", false);
                        anim.SetBool("U", false);
                        anim.SetBool("R", false);
                        anim.SetBool("D", false);
                    }
                }
                else
                {
                    rig.velocity = new Vector2(rig.velocity.x, -Speedy);
                    anim.SetBool("IsWalking", true);
                    anim.SetBool("D", true);
                    anim.SetBool("L", false);
                    anim.SetBool("U", false);
                    anim.SetBool("R", false);
                    Speedx = 0;
                }
            }
        }

        else
        {
            anim.SetBool("IsWalking", false);
            rig.velocity = new Vector2(0, 0);
            Speedx = 6;
            Speedy = 6;
        }
        if (offDialogo == true)
        {
            chat = false;
        }
        if (offFrase == true)
        {
            chat1 = false;
            CaixaDialogo.SetActive(false);
        }

        if (offFrase == true)
        {
            chat2 = false;
            CaixaDialogo.SetActive(false);
        }

    }
}

