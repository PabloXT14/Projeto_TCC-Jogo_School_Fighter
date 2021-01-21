using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtkEnemy : MonoBehaviour
{
    private int AtVeterano;
    public int AtributoDano;
    private float Damage;

    void Start()
    {
        AtVeterano = EscolhaVet.vet;
        Damage = AtributoDano * 0.7f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if( (collision.gameObject.tag == "Player") && (PlayerLuta.current.isDefense == false) )
        {
            
                 PlayerLuta.current.TakeDamage(Damage);
                 EnemyJoaoVindo.current.AudioPunch.Play();     

                 if (EnemyJoaoVindo.current.noOfClicks < 3)
                 {
                    collision.gameObject.transform.Translate(-Vector2.right * 1.2f);
                 }
                 else
                 {
                    collision.gameObject.transform.Translate(-Vector2.right * 2f);

                 }

                

        }

        if ( (collision.gameObject.tag == "Player") && (PlayerLuta.current.isDefense == true)  )
        {
             
             EnemyJoaoVindo.current.GetComponent<Transform>().transform.Translate(-Vector2.right * 3f);
             
            
        }






    }
}
