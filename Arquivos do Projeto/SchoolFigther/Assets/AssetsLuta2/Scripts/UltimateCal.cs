using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateCal : MonoBehaviour
{

    public float tempoDeVida;
    public float Speed;
    public float damage;


    private Rigidbody2D rig;
    private int AtVeterano;

    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        AtVeterano = EscolhaVet.vet;

        if(AtVeterano == 0)
        {
            damage *= 3;
        }

        if(AtVeterano == 1)
        {
            damage *= 2;
        }

        Invoke("DestroyUltimate",tempoDeVida);

    }

    //ATINGIR PLAYER
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Tutorial.current.tutorial == false)
        {
            if(collision.gameObject.tag =="Player")
            {
                collision.gameObject.transform.Translate(-Vector2.right *5f);
                gameObject.GetComponent<Collider2D>().enabled = false;
                collision.gameObject.GetComponent<PlayerLuta>().FullTakeDamage(damage);
            }

            if(collision.gameObject.tag == "Barreira")
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
            }

        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }

    }

    //DESTROIR ULTIMATE
    public void DestroyUltimate()
    {
        Destroy(gameObject);
    }


}
