using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2Versus : MonoBehaviour
{
    

    public float Speed;
    public float JumpForce;
    public bool isJumping;//para identificar se est pulando
    public float LifePlayer;
    public bool isDead;

    private Rigidbody2D rig;
    private Animator anim;

    // Vetrano Atributos
    public int AtVeterano;
    public float Def;



    //VARIÁVEIS DE ATAQUE
    public bool isAtk;
    private float timeAtk;
    public GameObject pointAtk;//ponto de ataque

    //VARIÁVEIS DE DEFESA
    public bool isDefense;
    private float timeDefense;
    public GameObject pointDefense;
    
    
    //VARIÁVEIS DA ENERGIA
    public GameObject energy;//prefabe da energia
    public Transform pointPower;//ponto de energia
    public float velocidadeEnergy;//velocidade da energia
    public bool isPower;

    //VARIÁVEIS DO ULTIMATE
    public GameObject ultimate;//prefab do ultimate
    public GameObject ultimateLeft;//prefab do ultimate indo para
    public Transform pointUltimate;//ponto do ultimate
    public float velocidadeUltimate;//velocidade do ultimate
    public bool isUltimate;//verificar se esta soltando o ultimate
    
    
    //VARIÁVEIS DE COMBO
    public int noOfClicks = 0;//contador de hits
    float lastClickedTime = 0;//ultimo ataque que o player  deu
    public float maxComboDelay;//maximo de delay para ir para outro ataque do combo
    ////
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    //VÁRIAVEIS DE SOM
    public AudioSource AudioPunch;


    public static bool CheckUltimate;
    public static bool CheckEnergia;

    public static Player2Versus current;
    public GameObject transitionRound;    

    
    
    void Start()
    {

        if( (PlayerPrefs.GetInt("Veterano") != null) && (PlayerPrefs.GetInt("Veterano") != -10) )
        {
            AtVeterano = PlayerPrefs.GetInt("Veterano");
            Debug.Log(AtVeterano);
        }
        else
        {
            AtVeterano = EscolhaVet.vet;
        }
        
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        current = this;

        if (AtVeterano == 0)
        {
            Def = 0.2f * 3;
            Speed = Speed * 1;  
        }
        if (AtVeterano == 1)
        {
            Def = 0.2f * 2;
            Speed = Speed * 1;
        }
        if (AtVeterano == 2)
        {
            Def = 0.2f * 2;
            Speed = Speed * 1.6f;
        }

    }

    
    void Update()
    {
        

     if((!isDead) && (!PlayerVersus.current.isDead) && (Time.timeScale == 1) )
     {   
        
        
        if((Input.GetKey(KeyCode.D)) && (!isDefense) && (isAtk == false) && (ControlVersus.current.canPlay == true) && (!isPower) && (!PlayerVersus.current.isDead) && (PlayerVersus.current.GetComponent<PlayerVersus>().enabled) ) 
        {
            rig.velocity = new Vector2(Speed * Time.deltaTime, rig.velocity.y);
            anim.SetBool("isWalking", true);
            transform.localEulerAngles = new Vector3(0, 0, 0);//rotacionado para a direita
        }
        else
        {
            rig.velocity = new Vector2(0f, rig.velocity.y);
            anim.SetBool("isWalking", false);
        }

        if( (Input.GetKey(KeyCode.A)) && (!isDefense) && (isAtk == false) && (ControlVersus.current.canPlay == true) && (!isPower) && (!PlayerVersus.current.isDead) && (PlayerVersus.current.GetComponent<PlayerVersus>().enabled) )
        {
            rig.velocity = new Vector2(-Speed * Time.deltaTime, rig.velocity.y);
            anim.SetBool("isWalking", true);
            transform.localEulerAngles = new Vector3(0, 180, 0);//rotacionado para a esquerda
            }

        /*PULO*/
        if((Input.GetKeyDown(KeyCode.Space)) && (!isJumping))
        {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            isJumping = true;
        }
         

        /*ATAQUE - COMBO*/
        if(Time.time - lastClickedTime > maxComboDelay)//verificando se ultrapassou o tempo para dar outro ataque do combo, para não continuar o combo
        {
            noOfClicks = 0;
            anim.SetBool("isAtk", false);
        }
    
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.M) && (PlayerVersus2.current.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic) )
            {
                //AudioPunch.Play();
                anim.SetBool("isJumping", false);//para poder dar golpe no ar
            
            
                //verifica se clicou
                lastClickedTime = Time.time;
                noOfClicks++;

                if(noOfClicks == 1)
                {
                    anim.SetBool("isAtk", true);
                    isAtk = true;
                }
                noOfClicks = Mathf.Clamp(noOfClicks, 0, 3); //numero absoluto de cliques/ataques do combo entre 0 e 3 

                nextAttackTime = Time.time + 0.5f / attackRate;
            }
        }

        /*DEFESA*/
        if((Input.GetKeyDown(KeyCode.S)) && (!isDefense))
        {
            anim.SetBool("isDefense", true);
            //anim.SetBool("isJumping", false);
            isDefense = true;

            timeDefense = 2f;//duração da defesa

            pointDefense.SetActive(isDefense);
           
        }           

        timeDefense -= Time.deltaTime;
        
        if((timeDefense <= 0) || (Input.GetKeyUp(KeyCode.S)) )
        {
            isDefense = false;
            anim.SetBool("isDefense", isDefense);
            pointDefense.SetActive(isDefense);
           
        }



        /*SOLTAR ENERGIA*/
        if ((Input.GetKeyDown(KeyCode.Q)) && (!isJumping) && ((BarraEnergy.current.Energy >= BarraEnergy.current.gastoEnergy) || (BarraEnergy.current.Energ >= 20f)) )
        {    
            anim.SetBool("isPower", true);
            isPower = true;
            //SoltarEnergia();
        }
         

        /*SOLTAR ULTIMATE*/
        if ((Input.GetKeyDown(KeyCode.E)) && (!isJumping) && (BarraEnergy.current.Energ >= 60f) )
        {
            
            if(transform.localEulerAngles.y == 0)
            {
                anim.SetBool("isUltimate", true);
            }
            else
            {
                anim.SetBool("isUltimateLeft", true);
            }
            //SoltarUltimate();
        }
        
        
        
      }
      else
      {
            anim.SetBool("isWalking", false);
      }
    
        
    }

    //SOLTAR ENERGIA
    public void SoltarEnergia()
    {
           CheckEnergia = true;
       

            GameObject energytile = Instantiate(energy, pointPower.position, transform.rotation);//criando energia no ponto deinido
        

            //calculo direção do player 
            if(transform.eulerAngles.y == 180)//esta para a esquerda
            {
                energytile.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeEnergy, 0);
            }
            else
            {
                energytile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeEnergy, 0); 
            }

            
            anim.SetBool("isPower", false);
            isPower = false;
       
    }


    //SOLTAR ULTIMATE
    public void SoltarUltimate()
    {
        CheckUltimate = true;
        

            if(transform.eulerAngles.y == 180)//esa para a esquerda
            {
                GameObject ultimatetile = Instantiate(ultimateLeft, pointUltimate.position, transform.rotation);
                //ultimatetile.GetComponent<SpriteRenderer>().flipX = true;
                ultimatetile.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeUltimate, 0);
                anim.SetBool("isUltimateLeft", false);
            }
            
            if(transform.eulerAngles.y == 0) //para direita
            {
                GameObject ultimatetile = Instantiate(ultimate, pointUltimate.position, transform.rotation);
                ultimatetile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeUltimate, 0);
                anim.SetBool("isUltimate", false);
            }
            
            
    }




    //verifica se clicou mais de umas no ataque, para mandar outro hit do combo
    public void return1()
    {
        if(noOfClicks >= 1)
        {
            anim.SetBool("isAtk2", true);
            anim.SetBool("isAtk", false);
        }
        else
        {
            anim.SetBool("isAtk", false);//desativa o o primerio hit pois não clicou para continuar
            noOfClicks = 0;
            isAtk = false;
        }
    }

    public void return2()
    {
        if(noOfClicks >= 2)
        {
            anim.SetBool("isAtk3", true);
        }
        else
        {
            anim.SetBool("isAtk2", false);//desativa o segundo hit pois não clicou para continuar
            //anim.SetBool("isAtk", false);
            noOfClicks = 0;
            isAtk = false;
            
        }
    }

    public void return3()
    {
        
        //desativa todos se não clicar por muito tempo
       // anim.SetBool("isAtk", false);
        anim.SetBool("isAtk2", false);
        anim.SetBool("isAtk3", false);
        noOfClicks = 0;
        isAtk = false;

    }



    //DESATIVANDO PULO
    private void OnCollisionEnter2D(Collision2D colisor)
    {
        if ( (colisor.gameObject.layer == 8)  )
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }
      
    }



    //DANO COMUM NO PLAYER
    public void TakeDamage(float FullDamage)
    {
        FullDamage -= Def;
        LifePlayer -= FullDamage;

        if(!isPower)
        {
            anim.SetTrigger("isDamage");
        }
           

        if(LifePlayer <= 0)
        {

            isDead = true;
            anim.SetBool("isDead", true);
            //DestroyBody();
            PlayerVersus.current.DestroyBody();

        }
        
    }


    //SUPER DANO NO PLAYER
    public void FullTakeDamage(float damage)
    {
        damage -= Def;
        LifePlayer -= damage;

        if (!isPower)
        {
            anim.SetTrigger("isFullDamage");
        }


        if (LifePlayer <= 0)
        {

            isDead = true;
            anim.SetBool("isDead", true);
            //DestroyBody();
            PlayerVersus.current.DestroyBody();

        }

    }

    //ROUND PERDIDO / GAME OVER
    public void DestroyBody()
    {
        //GetComponent<BoxCollider2D>().enabled = false;
        //GetComponent<CircleCollider2D>().enabled = false;
        //GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //transitionRound.SetActive(true);


        
    }

    //REATIVANDO PLAYER
    public void ReativeBody()
    {
        anim.SetBool("isDead", false);

        //gameObject.GetComponent<Transform>().position = new Vector3(-11.34f, -1.71f, 0);//colocando player na posição inicial
        //Cam.current.GetComponent<Transform>().position = new Vector3(0.29f, 2.95f, -4f);//colocando camera na posição inicial

        transform.localEulerAngles = new Vector3(0, 0, 0);//rotacionando para a direita
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //isDead = true;

        this.enabled = true;
             

    }

   




}
