using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDani : MonoBehaviour
{


    //VARIÁVEIS DISTÂNCIA MÍNIMA
    private Transform Targetplayer;
    private Transform Targetenemy;
    public float powerRange;
    public float ultimateRange;


    //VARIÁVEIS ENERGIA
    public GameObject energyDani;//prefab da energi
    public Transform pointPower;//local onde sera criada a energia
    

    //VARIÁVEIS ULTIMATE
    public GameObject ultimateDani;
    public GameObject ultimateLeftDani;
    public Transform pointUltimate;
    public float velocidadeUltimate;


    //CHECAGEM PARA SOLTAR ENERGIA
    public static bool CheckEnergia;

    //CHECAGEM PARA SOLTAR O ULTIMATE
    public static bool CheckUltimate;


    public static PowerDani current;



    void Start()
    {
        current = this;
        Targetplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Targetenemy = GameObject.FindGameObjectWithTag("Inimigo").GetComponent<Transform>();
    }


    void Update()
    {
        if (!PlayerLuta.current.isDead)
        {
            /*SOLTAR ENERGIA*/
            if ((Vector2.Distance(Targetplayer.position, Targetenemy.position) >= powerRange) && (!EnemyJoaoVindo.current.isJumping) && (BarraEnergyEnemy.current.Energ >= 20f) && ((BarraLifeEnemy.current.Life <= 80f) && (BarraLifeEnemy.current.Life > 45f)) && (EnergyDani.canPowerAgain))
            {
                EnemyJoaoVindo.current.anim.SetBool("isPower", true);
                EnemyJoaoVindo.current.isPower = true;
                EnergyDani.canPowerAgain = false;

            }

            /*SOLTAR ULTIMATE*/
            if ((Vector2.Distance(Targetplayer.position, Targetenemy.position) >= ultimateRange) && (!EnemyJoaoVindo.current.isJumping) && (BarraEnergyEnemy.current.Energ >= 60f) && (BarraLifeEnemy.current.Life <= 45f) && (UltimateDani.canUltimateAgain))
            {

                if (transform.localEulerAngles.y == 0)
                {
                    EnemyJoaoVindo.current.anim.SetBool("isUltimate", true);
                }
                else
                {
                    EnemyJoaoVindo.current.anim.SetBool("isUltimateLeft", true);
                }

                EnemyJoaoVindo.current.isPower = true;
                UltimateDani.canUltimateAgain = false;
                
            }
        }



    }


    public void SoltarEnergia()
    {

        CheckEnergia = true;

        GameObject energyTile = Instantiate(energyDani, pointPower.position, transform.rotation);
      
        EnemyJoaoVindo.current.anim.SetBool("isPower", false);
        //EnemyJoaoVindo.current.isPower = false; --> em EnegyDany
    }


    public void SoltarUltimate()
    {
        CheckUltimate = true;

     
        if (transform.eulerAngles.y == 180)//esa para a esquerda
        {
            GameObject ultimatetile = Instantiate(ultimateLeftDani, pointUltimate.position, transform.rotation);
            //ultimatetile.GetComponent<SpriteRenderer>().flipX = true;
            ultimatetile.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeUltimate, 0);
            EnemyJoaoVindo.current.anim.SetBool("isUltimateLeft", false);
        }

        if (transform.eulerAngles.y == 0) //para direita
        {
            GameObject ultimatetile = Instantiate(ultimateDani, pointUltimate.position, transform.rotation);
            ultimatetile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeUltimate, 0);
            EnemyJoaoVindo.current.anim.SetBool("isUltimate", false);
        }


        EnemyJoaoVindo.current.anim.SetBool("isUltimate", false);
        //EnemyJoaoVindo.current.isPower = false; //--> esta no UltimateDani
    }


}
