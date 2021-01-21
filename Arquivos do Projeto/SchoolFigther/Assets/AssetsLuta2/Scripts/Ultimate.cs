using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    public float tempoDeVida;
    public float Speed;
    public float damage;

    private Rigidbody2D rig;
    private int AtVeterano;

    
    void Start()
    {
        GetComponent<Collider2D>().enabled = true;
        AtVeterano = EscolhaVet.vet;
        rig = GetComponent<Rigidbody2D>();

        if (AtVeterano == 0)
        {
            damage = damage * 3;
        }
        if(AtVeterano == 1)
        {
            damage = damage * 2;
        }
        Invoke("DestroyUltimate", tempoDeVida);//Chamando metodo de destruir Energia depois de um tempoDeVida segundos
        


    }

    
    //DESTROI O ULTIMATE DO ÔNIBUS
    void DestroyUltimate()
    {
        Destroy(gameObject);
        //Pode tacar um som de destruição aqui
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Inimigo")
        {
            collision.gameObject.transform.Translate(-Vector2.right * 6f);
            collision.gameObject.GetComponent<EnemyJoaoVindo>().FullTakeDamage(damage);
            GetComponent<Collider2D>().enabled = false;
        }
        
        if(collision.gameObject.tag == "Barreira")
        {
            GetComponent<Collider2D>().enabled = false;
            
        }

    }

}
