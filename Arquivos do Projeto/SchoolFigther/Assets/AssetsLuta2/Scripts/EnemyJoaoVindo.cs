using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJoaoVindo : MonoBehaviour
{

    private Rigidbody2D rig;
    public Animator anim;
    public float DefAtributte;
    public float SpeedAtributte;
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public float LifeEnemy = 100;
    public bool isDead = false;

    public static bool isAtk;
    private float timeAtk;

    //VARIÁVEIS SEGUIR PLAYER
    private Transform Target;
    private bool isAtacado;

    //VARIÁVEIS COMBO DO INIMIGO
    public int noOfClicks = 0;//contador de hits
    float lastClickedTime = 0;//ultimo ataque que o inimigo dará
    public float maxComboDelay;//maximo de delay para ir para outro ataque do combo 
    private float DelayInCombo;
    private bool Stop  = true;

    public float attackRange;//distancia minima de ataque

    //VARIÁVEIS PODER
    public bool isPower;

    //VARIÁVEIS DE SOM
    public AudioSource AudioPunch;



    public static EnemyJoaoVindo current;

    private bool tutorial;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        DefAtributte = DefAtributte * 0.2f;
        current = this;
        if (SpeedAtributte == 2)
        {
            SpeedAtributte = 1.4f;
        }
        if (SpeedAtributte == 3)
        {
            SpeedAtributte = 1.6f;
        }
    }

    
    void Update()
    {
        
        tutorial = gameObject.GetComponent<Tutorial>().tutorial;  


      if((!isDead) && (!PlayerLuta.current.isDead) && (tutorial == false) && (Stop == false) && (!isPower) && (!PlayerLuta.current.isDead) && (PlayerLuta.current.GetComponent<PlayerLuta>().enabled) )
      {
            Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            //MOVIMENTO SEGUIR PLAYER
            if (!isJumping)
            {
                if (Target != null && !isAtacado)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(Target.position.x, transform.position.y), Speed * Time.deltaTime);//1º: posição de origem/2º:posição de destino /3º:Velocidade
                    anim.SetBool("isWalking", true);
                }
                //ROTACIONAR INIMIGO
                if (Target.position.x > transform.position.x)
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);//Rotaciona para a direita
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);//Rotaciona para a esquerda
                }

            }
       

        /*SISTEMA DE COMBO DE ATAQUE*/
        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        DelayInCombo -= Time.deltaTime;

        //DISTÂNCIA MINIMA DE ATAQUE
        if((Vector2.Distance(Target.position, rig.position) <= attackRange ) && (DelayInCombo <= 0) )
        {
            DelayInCombo = 0.1f;
            lastClickedTime = Time.time;
            noOfClicks++;

            if(noOfClicks == 1)
            {
                anim.SetBool("isAtk", true);
                isAtk = true;
            }

            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);//numero absoluto de clicks/ataques do combo

            
        }

            //PULO DO INIMIGO
            Jump();

        }
      else
      {
          anim.SetBool("isWalking", false);
      }  
    
       
    }


    //PULO DO INIMIGO
    void Jump()
    {
        if( (Vector2.Distance(Target.position, rig.position) <= attackRange + 5) && (PlayerLuta.current.isJumping == true) && (isJumping == false) )
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            PlayerLuta.current.isJumping = true;
            isJumping = true;
            //Debug.Log("Realizou pulo");           
        }

    }

   
    //DESATIVANDO PULO DO INIMIGO
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.layer == 8)
        {
           
            isJumping = false;
            anim.SetBool("isJumping", false);
        }

    }

    /*MÉTODOS DOS COMBOS DE ATAQUE*/
    public void return1()
    {
        if(noOfClicks >= 2)
        {
            anim.SetBool("isAtk2", true);
        }
        else
        {
            anim.SetBool("isAtk", false);//desativa o primeiro hit pois não clicou para continuar
            noOfClicks = 0;
            isAtk = false;
        }
    }
    public void return2()
    {
        if(noOfClicks >= 3)
        {
            anim.SetBool("isAtk3", true);
            
        }
        else
        {
            anim.SetBool("isAtk2", false);
            noOfClicks = 0;
            isAtk = false;
        }
    }
    public void return3()
    {
        //desativas todos para fazer outra sequencia de combo
        anim.SetBool("isAtk", false);
        anim.SetBool("isAtk2", false);
        anim.SetBool("isAtk3", false);
        noOfClicks = 0;
        isAtk = false;
    }


    //DANO COMUM
    public void TakeDamage(float damage)
    {
        damage -= DefAtributte;
        LifeEnemy -= damage;

        anim.SetTrigger("isDamage");

        if(LifeEnemy <= 0)
        {
            isDead = true;
            anim.SetBool("isDead", true);
            //DestrouBody();
            PlayerLuta.current.DestroyBody();
            
        }
        
    }


    //SUPER DANO
    public void FullTakeDamage(float FullDamage)
    {
        FullDamage -= DefAtributte;
        LifeEnemy -= FullDamage;

        anim.SetTrigger("isFullDamage");
        
        if(LifeEnemy <= 0)
        {
            isDead = true;
            anim.SetBool("isDead", true);
            //DestrouBody();
            PlayerLuta.current.DestroyBody();
        }

    }


    //PERDEU O ROUND/MORREU
    public void DestrouBody()
    {     
        //Speed = 0;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //isDead = true;
        Stop = true;      
    }


    //REATIVANDO INIMIGO
    public void ReativeBody()
    {
        
        anim.SetBool("isDead", false);
        Speed = Speed * SpeedAtributte;

        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //isDead = false
        
        this.enabled = true;
        StopOff();
    }
    public void StopOff()
    {
        Stop = false;
    }

   


}
