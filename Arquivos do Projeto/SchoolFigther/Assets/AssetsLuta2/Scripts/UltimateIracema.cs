using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateIracema : MonoBehaviour
{
    
    public float damage;
    public float velocidadeUltimate;
    public float tempoDeVida;

    private Rigidbody2D rig;   
    private int AtVeterano;
    public static bool canUltimateAgain = true;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
        AtVeterano = EscolhaVet.vet;

        if (AtVeterano == 0)
        {
            damage *= 3;
        }

        if (AtVeterano == 1)
        {
            damage *= 2;
        }

        Invoke("DestroyUltimate", tempoDeVida);

    }

    //ATINGIR PLAYER
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Tutorial.current.tutorial == false)
        {
            if (((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "BarDefense")) && (PlayerLuta.current.isDefense == false))
            {
                
                collision.gameObject.transform.Translate(-Vector2.right * 2.5f);
                gameObject.GetComponent<Collider2D>().enabled = false;
                collision.gameObject.GetComponent<PlayerLuta>().FullTakeDamage(damage);
                //EnemyJoaoVindo.current.isPower = false;

            }

            if (((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "BarDefense")) && (PlayerLuta.current.isDefense == true))
            {               
                gameObject.GetComponent<Collider2D>().enabled = false;
                collision.gameObject.transform.Translate(-Vector2.right * 2.5f);
                //EnemyJoaoVindo.current.isPower = false;
            }


            if ((collision.gameObject.tag == "Barreira") || (collision.gameObject.layer == 8) )
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                //EnemyJoaoVindo.current.isPower = false;
            }

        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }

    }

    //DESTROIR ENERGY
    public void DestroyUltimate()
    {
        Destroy(gameObject);
        canUltimateAgain = true;
    }


    //FAZER A CRUZ CAIR
    public void crossFalling()
    {
        rig.velocity = new Vector2(0, -velocidadeUltimate);
    }


}
