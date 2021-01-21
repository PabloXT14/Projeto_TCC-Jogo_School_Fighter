using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateJoca : MonoBehaviour
{

    //public float tempoDeVida;
    //public float Speed;
    public float damage;

    private Rigidbody2D rig;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //Invoke("DestroyUltimate", tempoDeVida);
       
    }

    void DestroyUltimate()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.transform.Translate(-Vector2.right * 5f);
            collision.gameObject.GetComponent<PlayerLuta>().FullTakeDamage(damage);
     

        }

        if (collision.gameObject.tag == "Barreira")
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
