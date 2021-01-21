using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDani : MonoBehaviour
{
    public float damage;
    public float tempoDeVida;


    private Rigidbody2D rig;
    private Animator anim;
    private int AtVeterano;
    public static bool canPowerAgain = true;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        AtVeterano = EscolhaVet.vet;

        if (AtVeterano == 0)
        {
            damage *= 3;
        }

        if (AtVeterano == 1)
        {
            damage *= 2;
        }



    }

    void Update()
    {
        tempoDeVida -= Time.deltaTime;

        if(tempoDeVida <=0 )
        {
            DestroyEnergy();
        }


    }

    //ATINGIR PLAYER
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Tutorial.current.tutorial == false)
        {
            if( ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "BarDefense")) && (PlayerLuta.current.isDefense == false) ) 
            {
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                collision.gameObject.transform.Translate(-Vector2.right * 4f);
                gameObject.GetComponent<Collider2D>().enabled = false;
                collision.gameObject.GetComponent<PlayerLuta>().FullTakeDamage(damage);
                anim.SetBool("isDestroy", true);

            }

            if ( ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "BarDefense")) && (PlayerLuta.current.isDefense == true) ) 
            {
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                collision.gameObject.transform.Translate(-Vector2.right * 2f);
                gameObject.GetComponent<Collider2D>().enabled = false;
                anim.SetBool("isDestroy", true);
            }

            if (collision.gameObject.tag == "Barreira")
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                anim.SetBool("isDestroy", true);
            }

        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }

    }

    //DESTROIR ENERGY
    public void DestroyEnergy()
    {
        Destroy(gameObject);
        canPowerAgain = true;
        EnemyJoaoVindo.current.isPower = false;
    }
}
