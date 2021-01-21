using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraEnergyEnemy : MonoBehaviour
{
    public float Energy;
    public float Energ;//barra pequenininha
    private int timeCarga = 14;
    public int gastoEnergy;
    public int AtributoCarg;

    int timer; 

    public Image BarraG;
    public Image BarraP;

    
    public static BarraEnergyEnemy current;//variavel que vai ajudar a no instanciamento, para adicionar ou remover vida através de outros scripts
                                           // Start is called before the first frame update

    private Transform Targetplayer;
    private Transform Targetenemy;

    
    void Start()
    {
        current = this;
        Targetplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Targetenemy = GameObject.FindGameObjectWithTag("Inimigo").GetComponent<Transform>();
        timeCarga -= AtributoCarg;
       
    }

    
    void Update()
    {
        if (Time.timeScale == 1)
        {



            timer += 1;

            BarraG.fillAmount = Energy / 100;
            BarraP.fillAmount = Energ / 100;


            //TEMPO CARREGAMENTO DA BARRA MAIOR
            if ((timer >= timeCarga) && (Energ < 101) && (Energy < 100))
            {
                Energy += 1;
                timer = 0;
            }

            //CARREGAMENTO DA BARRA MENOR DE ENERGIA
            if ((Energy == 100) && (Energ < 100))
            {
                Energy = 0;
                Energ += 20;
            }

            //SUPER ATAQUE
            if ((Energy >= gastoEnergy) || (Energ >= 20))
            {
                if ((PowerJoca.CheckEnergia == true) || (PowerThiao.CheckEnergia == true) || (PowerCal.CheckEnergia == true) || (PowerIracema.CheckEnergia == true) || (PowerBrown.CheckEnergia == true) || (PowerDani.CheckEnergia == true))
                {

                    PowerJoca.CheckEnergia = false;
                    PowerThiao.CheckEnergia = false;
                    PowerCal.CheckEnergia = false;
                    PowerIracema.CheckEnergia = false;
                    PowerBrown.CheckEnergia = false;
                    PowerDani.CheckEnergia = false;


                    if (((Energy - gastoEnergy) < -1) && (Energ > 0))
                    {
                        Energ -= 20;
                    }
                    else
                    {
                        Energy -= gastoEnergy;
                    }


                }
            }


            //ULTIMATE
            if ((Energ >= 60) && ((PowerJoca.CheckUltimate == true) || (PowerThiao.CheckUltimate == true) || (PowerCal.CheckUltimate == true) || (PowerIracema.CheckUltimate == true) || (PowerBrown.CheckUltimate == true) || (PowerDani.CheckUltimate == true)))
            {
                PowerJoca.CheckUltimate = false;
                PowerThiao.CheckUltimate = false;
                PowerCal.CheckUltimate = false;
                PowerIracema.CheckUltimate = false;
                PowerBrown.CheckUltimate = false;
                PowerDani.CheckUltimate = false;

                Energ -= 60;
            }



        }





    }

    

    

    
}
