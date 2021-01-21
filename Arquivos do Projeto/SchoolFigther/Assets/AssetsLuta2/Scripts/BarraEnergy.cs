using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraEnergy : MonoBehaviour
{
    public float Energy;
    public float Energ;//barra pequenininha
    private int timeCarga = 14;
    public int gastoEnergy;


    int timer; 

    public Image BarraG;
    public Image BarraP;
    private int AtVeterano;

    public static BarraEnergy current;//variavel que vai ajudar a no instanciamento, para adicionar ou remover vida através de outros scripts
    // Start is called before the first frame update
   
    
    void Start()
    {
        current = this;
        AtVeterano = EscolhaVet.vet;
        if (AtVeterano == 0)
        {
            timeCarga -= 2;
        }
        if (AtVeterano == 1)
        {
            timeCarga -= 2;
        }
        if (AtVeterano == 2)
        {
            timeCarga -= 2;
        }
    }

    // Update is called once per frame
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
                if (/*(Input.GetKeyDown(KeyCode.Q) &&*/ PlayerLuta.CheckEnergia == true)
                {
                    PlayerLuta.CheckEnergia = false;
                    if (((Energy - gastoEnergy) < -1) && (Energ > 0))
                    {
                        //Energy = (Energy + 100)-gastoEnergy;
                        Energ -= 20;
                    }
                    else
                    {
                        Energy -= gastoEnergy;
                    }

                }
            }


            //ULTIMATE
            if ((Energ >= 60) && (PlayerLuta.CheckUltimate == true) && (Controller.lutas >= 6))
            {
                PlayerLuta.CheckUltimate = false;
                // if(Input.GetKeyDown(KeyCode.E))
                // {
                Energ -= 60;
                // }
            }



        }



    }

  
}
