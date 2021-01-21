using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    private Animator anim;
    public Transform targetPlayer;
    private SpriteRenderer spriteRenderer;
    public Sprite viraB;
    public int Speed;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }


    void Update()
    {

        rig.velocity = new Vector2(rig.velocity.x, Speed);
        if (transform.position.y == targetPlayer.position.y)
        {
            spriteRenderer.sprite = viraB;
        }
    }
    void OnTriggerEnter2D(Collider2D contact)
    {
        if (contact.gameObject.tag == "Player")
        {
            anim.SetInteger("Ct", 1);
            Speed = 0;
            rig.bodyType = RigidbodyType2D.Static;
        }
    }
}
