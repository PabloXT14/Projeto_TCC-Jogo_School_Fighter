using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerJoca : MonoBehaviour
{
    //VARIÁVEIS DA ENERGIA
    public GameObject energy;//prefabe da energia
    public Transform pointPower;//ponto de criação da energia
    private float timePower;

    //VARIÁVEIS DO ULTIMATE
    public GameObject ultimate;
    public Transform pointUltimate;

    //VARIÁVEIS DISTÂNCIA MÍNIMA
    private Transform Targetplayer;
    private Transform Targetenemy;
    public float powerRange;
    public float ultimateRange;



    //CHECAGEM PARA PODER SOLTAR ENERGIA
    public static bool CheckEnergia;

    //CHECAGEM PARA PODER SOLTAR ULTIMATE
    public static bool CheckUltimate;



    public static PowerJoca current;

    void Start()
    {
        current = this;
        Targetplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Targetenemy = GameObject.FindGameObjectWithTag("Inimigo").GetComponent<Transform>();
    }

    
    void Update()
    {
      

        if(!PlayerLuta.current.isDead)
        {
            /*SOLTAR ENERGIA*/
            if ((Vector2.Distance(Targetplayer.position, Targetenemy.position) <= powerRange) && (!EnemyJoaoVindo.current.isJumping) && (BarraEnergyEnemy.current.Energ >= 20f) && ((BarraLifeEnemy.current.Life <= 80f) && (BarraLifeEnemy.current.Life > 45f)) && (timePower <= 0))
            {
                EnemyJoaoVindo.current.anim.SetBool("isPower", true);
                EnemyJoaoVindo.current.isPower = true;

                //SoltarEnergia();
            }



            /*SOLTAR ULTIMATE*/
            if ((Vector2.Distance(Targetplayer.position, Targetenemy.position) <= ultimateRange) && (!EnemyJoaoVindo.current.isJumping) && (BarraEnergyEnemy.current.Energ >= 60f) && (BarraLifeEnemy.current.Life <= 45f) && (timePower <= 0))
            {
                EnemyJoaoVindo.current.anim.SetBool("isUltimate", true);
                EnemyJoaoVindo.current.isPower = true;



            }

            timePower -= Time.deltaTime;
        }

        

    }


    public void SoltarEnergia()
    {
        CheckEnergia = true;


        if (timePower <= 0)
        {
            timePower = 4f;
            GameObject energytile = Instantiate(energy, pointPower.position, transform.rotation);//criando energia no ponto deinido
        }
        

        /*
        //calculo direção do player 
        if (transform.eulerAngles.y == 180)//esta para a esquerda
        {
            energytile.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeEnergy, 0);
        }
        else
        {
            energytile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeEnergy, 0);
        }
        */


        EnemyJoaoVindo.current.anim.SetBool("isPower", false);
        EnemyJoaoVindo.current.isPower = false;
    }


    public void SoltarUltimate()
    {
        CheckUltimate = true;
        /*
        //DISTÂNCIAR PLAYER
        if (Targetplayer.position.x > transform.position.x)
        {
            PlayerLuta.current.GetComponent<Transform>().transform.position = new Vector3(10f + transform.position.x, transform.position.y, transform.position.z);//distanciando para a esquerda
        }
        else
        {
            PlayerLuta.current.GetComponent<Transform>().transform.position = new Vector3(-10f + transform.position.x, transform.position.y, transform.position.z);//distanciando para a esquerda
        }
        */
        if (timePower <= 0)
        {
            timePower = 4f;
            GameObject ultimatetile = Instantiate(ultimate, pointUltimate.position, transform.rotation);

            //calculo direção do inimigo
            if (transform.eulerAngles.y == 180)//esta para a esquerda
            {
                ultimatetile.GetComponent<Transform>().localEulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                ultimatetile.GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, 0);
            }

        }





        EnemyJoaoVindo.current.anim.SetBool("isUltimate", false);
        EnemyJoaoVindo.current.isPower = false;

    }


}
