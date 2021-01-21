using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rig;
    private SpriteRenderer sprite;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        anim.SetFloat("Speed", rig.velocity.x);
        anim.SetFloat("Speed2", rig.velocity.y);
    }

    void OnCollisionExit2D(Collider2D contact)
    {
        if (contact.gameObject.tag == "Player")
        {
            
            rig.AddForce(Vector2.up * 0, ForceMode2D.Impulse);
        }
    }

    void OnTriggerExit2D(Collider2D contact)
    {
        if (contact.gameObject.tag == "OpostTrigger")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 3;
        }

    }

    void OnTriggerStay2D(Collider2D contact)
    {
        if (contact.gameObject.tag == "OpostTrigger")
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 1;
        }
    }
}

