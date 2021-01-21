using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateDani : MonoBehaviour
{
    public float tempoDeVida;   
    public float damage;

    private Rigidbody2D rig;
    private int AtVeterano;
    public static bool canUltimateAgain = true;

    void Start()
    {
        GetComponent<Collider2D>().enabled = true;
        AtVeterano = EscolhaVet.vet;
        rig = GetComponent<Rigidbody2D>();

        if (AtVeterano == 0)
        {
            damage = damage * 3;
        }
        if (AtVeterano == 1)
        {
            damage = damage * 2;
        }
        Invoke("DestroyUltimate", tempoDeVida);//Chamando metodo de destruir Energia depois de um tempoDeVida segundos



    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "BarDefense")) && (PlayerLuta.current.isDefense == false))
        {
            
            collision.gameObject.transform.Translate(-Vector2.right * 4f);
            gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.GetComponent<PlayerLuta>().FullTakeDamage(damage);
            EnemyJoaoVindo.current.isPower = false;
        }

        if (((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "BarDefense")) && (PlayerLuta.current.isDefense == true))
        {           
            collision.gameObject.transform.Translate(-Vector2.right * 2f);
            gameObject.GetComponent<Collider2D>().enabled = false;
            EnemyJoaoVindo.current.isPower = false;
        }

        if (collision.gameObject.tag == "Barreira")
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            EnemyJoaoVindo.current.isPower = false;
        }

    }

    //DESTROI O ULTIMATE DO ÔNIBUS
    void DestroyUltimate()
    {
        Destroy(gameObject);
        canUltimateAgain = true;
        //EnemyJoaoVindo.current.isPower = false;
    }



}
