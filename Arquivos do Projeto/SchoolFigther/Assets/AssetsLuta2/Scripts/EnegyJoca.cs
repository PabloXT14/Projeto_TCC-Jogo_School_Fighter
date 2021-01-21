using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnegyJoca : MonoBehaviour
{
    //public float tempoDeVida;
    //public float Speed;
    public float damage;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<Collider2D>().enabled = true;
        //Invoke("DestroyEnergy", tempoDeVida);
    }

    void DestroyEnergy()
    {
        Destroy(gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.Translate(-Vector2.right * 5f);
            collision.gameObject.GetComponent<PlayerLuta>().FullTakeDamage(damage);
            gameObject.GetComponent<Collider2D>().enabled = false;

        }

        if (collision.gameObject.tag == "Barreira")
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }

    }
}
