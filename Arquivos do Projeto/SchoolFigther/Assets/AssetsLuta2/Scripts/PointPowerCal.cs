using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPowerCal : MonoBehaviour
{
    private int AtVeterano;
    public int AtributoDano;
    private float Damage;

    public AudioSource AudioPower;

    void Start()
    {
        AtVeterano = EscolhaVet.vet;
        Damage = AtributoDano * 0.7f;
    }

    
    void Update()
    {
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.tag == "Player") && (PlayerLuta.current.isDefense == false))
        {

            PlayerLuta.current.FullTakeDamage(Damage);
            AudioPower.Play();

            if (EnemyJoaoVindo.current.noOfClicks < 3)
            {
                collision.gameObject.transform.Translate(-Vector2.right * 1.2f);
            }
            else
            {
                collision.gameObject.transform.Translate(-Vector2.right * 2f);

            }



        }

        if ((collision.gameObject.tag == "Player") && (PlayerLuta.current.isDefense == true))
        {

            EnemyJoaoVindo.current.GetComponent<Transform>().transform.Translate(-Vector2.right * 3f);


        }




    }




}
