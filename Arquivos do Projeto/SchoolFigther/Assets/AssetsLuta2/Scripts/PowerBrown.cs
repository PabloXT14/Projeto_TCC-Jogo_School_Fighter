using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBrown : MonoBehaviour
{

    //VARIÁVEIS DISTÂNCIA MÍNIMA
    private Transform Targetplayer;
    private Transform Targetenemy;
    public float powerRange;
    public float ultimateRange;


    //VARIÁVEIS ENERGIA
    public GameObject energyBrown;//prefab da energi
    public Transform pointPower;//local onde sera criada a energia
    public float velocidadeEnergy;//velocidade da energia

    //VARIÁVEIS ULTIMATE
    public GameObject ultimateBrown;
    public Transform pointUltimate;
    public float velocidadeUltimate;


    //CHECAGEM PARA SOLTAR ENERGIA
    public static bool CheckEnergia;

    //CHECAGEM PARA SOLTAR O ULTIMATE
    public static bool CheckUltimate;


    public static PowerBrown current;



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
            if ((Vector2.Distance(Targetplayer.position, Targetenemy.position) >= powerRange) && (!EnemyJoaoVindo.current.isJumping) && (BarraEnergyEnemy.current.Energ >= 20f) && ((BarraLifeEnemy.current.Life <= 80f) && (BarraLifeEnemy.current.Life > 45f)) && (EnergyBrown.canPowerAgain))
            {
                EnemyJoaoVindo.current.anim.SetBool("isPower", true);
                EnemyJoaoVindo.current.isPower = true;
                EnergyBrown.canPowerAgain = false;

            }

            /*SOLTAR ULTIMATE*/
            if ((Vector2.Distance(Targetplayer.position, Targetenemy.position) >= ultimateRange) && (!EnemyJoaoVindo.current.isJumping) && (BarraEnergyEnemy.current.Energ >= 60f) && (BarraLifeEnemy.current.Life <= 45f) && (UltimateBrown.canUltimateAgain))
            {

                EnemyJoaoVindo.current.anim.SetBool("isUltimate", true);
                EnemyJoaoVindo.current.isPower = true;
                UltimateBrown.canUltimateAgain = false;

            }
        }



    }


    public void SoltarEnergia()
    {

        CheckEnergia = true;

        GameObject energyTile = Instantiate(energyBrown, pointPower.position, transform.rotation);

        //CALCULANDO DIREÇÃO DO INIMIGO
        if (transform.eulerAngles.y == 180)
        {
            energyTile.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeEnergy, 0);
        }
        else
        {
            energyTile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeEnergy, 0);
        }

        EnemyJoaoVindo.current.anim.SetBool("isPower", false);
        EnemyJoaoVindo.current.isPower = false;
    }


    public void SoltarUltimate()
    {

        CheckUltimate = true;

        GameObject ultimateTile = Instantiate(ultimateBrown, pointUltimate.position, transform.rotation);

        //CALCULANDO DIREÇÃO DO INIMIGO
        if (transform.eulerAngles.y == 180)
        {
            ultimateTile.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeUltimate, 0);
        }
        else
        {
            ultimateTile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeUltimate, 0);
        }


        EnemyJoaoVindo.current.anim.SetBool("isUltimate", false);
        EnemyJoaoVindo.current.isPower = false; //--> esta no UltimateIracema
    }



}
