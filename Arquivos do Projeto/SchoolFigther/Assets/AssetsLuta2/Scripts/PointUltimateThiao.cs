using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUltimateThiao : MonoBehaviour
{

    public float i;
    public GameObject BandeiraThiao;

    private int AtVeterano;
    public int AtributoDano;
    private float Damage;

    void Start()
    {
        i = 0;

        AtVeterano = EscolhaVet.vet;
        Damage = AtributoDano * 0.7f;
    }

    void Update()
    {



        /*
        i += Time.deltaTime;

        
        if (i <= 4)
        {
            PlayerLuta.current.LifePlayer -= 1;
            EnemyJoaoVindo.current.LifeEnemy += 1;
            
        }
        
        
        if(i == 5)
        {
            EnemyJoaoVindo.current.GetComponent<Animator>().speed = 1;
            PlayerLuta.current.GetComponent<Animator>().speed = 1;

            PlayerLuta.current.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            EnemyJoaoVindo.current.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            EnemyJoaoVindo.current.anim.SetBool("isUltimate", false);
            EnemyJoaoVindo.current.isPower = false;

            PlayerLuta.current.FullTakeDamage(0f);

            PlayerLuta.current.GetComponent<Transform>().transform.Translate(-Vector2.right * 5f);
            BandeiraThiao.SetActive(false);
        }  
        */

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        BandeiraThiao.SetActive(true);

        if (((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "PointAtk")) && (!PlayerLuta.current.isDefense) )
        {
            EnemyJoaoVindo.current.GetComponent<Animator>().speed = 0;
            PlayerLuta.current.GetComponent<Animator>().speed = 0;

            PlayerLuta.current.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            EnemyJoaoVindo.current.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

        if ((collision.gameObject.tag == "Player") && (PlayerLuta.current.isDefense))
        {
            EnemyJoaoVindo.current.GetComponent<Transform>().transform.Translate(-Vector2.right * 5f);
        }
        */

        if ((collision.gameObject.tag == "Player") && (PlayerLuta.current.isDefense == false))
        {
            PlayerLuta.current.FullTakeDamage(Damage);
            EnemyJoaoVindo.current.LifeEnemy += 9;
            collision.gameObject.transform.Translate(-Vector2.right * 4f);


        }

        if ((collision.gameObject.tag == "Player") && (PlayerLuta.current.isDefense == true))
        {
            EnemyJoaoVindo.current.GetComponent<Transform>().transform.Translate(-Vector2.right * 4f);
        }




    }
  



}