using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCal : MonoBehaviour
{

    public float timePower;

    //VARIÁVEIS DISTÂNCIA MÍNIMA
    private Transform Targetplayer;
    private Transform Targetenemy;
    public float powerRange;
    public float ultimateRange;


    //VARIÁVEIS ULTIMATE
    public GameObject ultimateCal;//prefab do ultimate
    public Transform pointUltimate;//local onde sera criado o ultimate
    public float velocidadeUltimate;//velocidade do ultimate



    //CHECAGEM PARA SOLTAR ENERGIA
    public static bool CheckEnergia;

    //CHECAGEM PARA SOLTAR O ULTIMATE
    public static bool CheckUltimate;


    public static PowerCal current;



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
            if ((Vector2.Distance(Targetplayer.position, Targetenemy.position) <= powerRange) && (!EnemyJoaoVindo.current.isJumping) && (BarraEnergyEnemy.current.Energ >= 20f) && ((BarraLifeEnemy.current.Life <= 80f) && (BarraLifeEnemy.current.Life > 45f)))
            {
                EnemyJoaoVindo.current.anim.SetBool("isPower", true);
                EnemyJoaoVindo.current.isPower = true;

            }

            /*SOLTAR ULTIMATE*/

            if ((Vector2.Distance(Targetplayer.position, Targetenemy.position) <= ultimateRange) && (!EnemyJoaoVindo.current.isJumping) && (BarraEnergyEnemy.current.Energ >= 60f) && (BarraLifeEnemy.current.Life <= 45f))
            {

                EnemyJoaoVindo.current.anim.SetBool("isUltimate", true);
                EnemyJoaoVindo.current.isPower = true;

            }

        }


    }


    public void SoltarEnergia()
    {
        CheckEnergia = true;

        EnemyJoaoVindo.current.anim.SetBool("isPower", false);
        EnemyJoaoVindo.current.isPower = false;
    }


    public void SoltarUltimate()
    {
        CheckUltimate = true;

        GameObject ultimateTile = Instantiate(ultimateCal, pointUltimate.position, transform.rotation);

        //CALCULANDO DIREÇÃO DO INIMIGO
        if(transform.eulerAngles.y == 180)
        {
            ultimateTile.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeUltimate, 0);
        }
        else
        {
            ultimateTile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeUltimate, 0);
        }


        EnemyJoaoVindo.current.anim.SetBool("isUltimate", false);
        EnemyJoaoVindo.current.isPower = false;

    }




}
