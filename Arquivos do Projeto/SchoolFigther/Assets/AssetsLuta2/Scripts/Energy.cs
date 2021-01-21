using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    // public float Speed;
    // private Player player;
    // private SpriteRenderer spritePlayer;
    // private Transform rotacao;
    // private bool directional;

    /************************/
    // public int dano;
    public float tempoDeVida;
    // public float distancia;
    // public LayerMask layerInimigo;

    public float Speed;
    public float damage;
    private Rigidbody2D rig;

    private int AtVeterano;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //GetComponent<Collider2D>().enabled = true;
        AtVeterano = EscolhaVet.vet;
        if (AtVeterano == 0)
        {
            damage = damage * 3;
        }
        if (AtVeterano == 1)
        {
           damage = damage * 2;
        }
        
        // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        // rotacao = player.GetComponent<Transform>();
        // Destroy(gameObject, 3f);
        Invoke("DestroyEnergy", tempoDeVida);//Chamando metodo de destruir Energia depois de um tempoDeVida segundos
        
        //if(Tutorial.current.tutorial == true)
        //{
            
        //}
    }

    /*
    void Update()
    {
        
            // if((rotacao.transform.eulerAngles.y == 180) &&(player.isEnergy = true))
            // {
            //     transform.localEulerAngles = new Vector3(0, 180, 0); 
            //     transform.Translate(Vector2.right * Time.deltaTime * Speed); //fica right pois rotacionol o gameObejct
            // }
            // else if((rotacao.transform.eulerAngles.y == 0) &&(player.isEnergy = true))
            // {
            //     //transform.localEulerAngles = new Vector3(0, 0, 0); 
            //     transform.Translate(Vector2.right * Time.deltaTime * Speed);
            // }
        

        //RaycastHit2D = basicamente uma linha invisivel que a unity desenha, que vai de um ponto de origem até um ponto de destino
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distancia, layerInimigo);//ponto de origem - direção - distancia percorrida da linha - layer especifica a ser atingida
        
        if(hitInfo.collider != null)//Testa se colidiu com algo
        {
            // if(hitInfo.collider.CompareTag("Inimigo"))//Testa se colidiu com alguma tag especifica
            // {
            //     hitInfo.collider.GetComponent<EnemyDaniel>().TakeDamage(dano);//passando dano que o inimigo vai tomar
            //     hitInfo.collider.GetComponent<EnemyBrown>().TakeDamage(dano);
            // }

            DestroyEnergy();//ira destruir depois de colidir com o inimigo
        }

    }
    */
    

    //DESTROI A ENERGIA
    void DestroyEnergy()
    {
        Destroy(gameObject);
        //Pode tacar um som de destruição aqui
    }

    private void OnCollisionEnter2D(Collision2D colisor)
    {

        if (Tutorial.current.tutorial == false)
        {

            if (colisor.gameObject.tag == "Inimigo")
            {
                colisor.gameObject.transform.Translate(-Vector2.right * 5f);
                gameObject.GetComponent<Collider2D>().enabled = false;
                colisor.gameObject.GetComponent<EnemyJoaoVindo>().FullTakeDamage(damage);

            }

            if (colisor.gameObject.tag == "Barreira")
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
            }

        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }

    }

}
