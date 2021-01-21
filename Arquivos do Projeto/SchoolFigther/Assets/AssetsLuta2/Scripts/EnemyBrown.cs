using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyBrown : MonoBehaviour
{
    
    public float Speed;
    private Transform Target;
    private Player player;

    private Animator anim;
    public int LifeEnemy;//vida do inimigo

    //DETECÇÃO DE ATAQUE
    private bool isAtacado = false;

    /*********************************/

    //private bool facingRight = true;
    private bool isDead = false;
    private float Distance;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
        anim = GetComponent<Animator>();
           
    }

    // Update is called once per frame
    void Update()
    {
        /*TESTE DE VIDA*/
        if(LifeEnemy <= 0)
        {
            anim.SetTrigger("isDeath");
            Invoke("DestroyBody", 0.5f);//Chamando metodo de destruir Enemy depois de 0.5 segundos
        }

        //MOVIMENTO SEGUIR PLAYER   
        if(Target != null && !isAtacado) 
        { 
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Target.position.x, transform.position.y), Speed * Time.deltaTime);//1º: posição de origem/2º:posição de destino /3º:Velocidade
        }

        //ROTACIONAR INIMIGO
        if(player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        //DISTANCIA LIMITE
        Distance = player.transform.position.x - transform.position.x;
        if(Mathf.Abs(Distance) < 1.5f)
        {

        }


        /*
        //MOVIMENTA INIMIGO
        transform.Translate(Vector2.right * Speed * Time.deltaTime);

        TimeDirection += Time.deltaTime;

        //INVERTE O BOOLEANO "DIRECTION" DE ACORDO COM O TEMPO    
        if(TimeDirection >= DurationDirection)
        {
            TimeDirection = 0;
            Direction = !Direction;
        }
        */


    }

    //DANO NO INIMIGO
    public void TakeDamage(int damage)
    {
        LifeEnemy -= damage;
    }

    //DESTROI INIMIGO
    private void DestroyBody()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Energy")
        {
            isAtacado = true;
        }
        else
        {
            isAtacado = false;
        }
    }
}
