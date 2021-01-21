using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_Energ : MonoBehaviour
{
    public float energia;
    public float energ;
    int time = 0 ;
    public KeyCode gasta;
    public KeyCode ultimate;
    public Image barra;
    public Image barra2;
    public int tempoCarga;
    public int gastoEnergia;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1;
        
        barra.fillAmount = energia / 100;
        barra2.fillAmount = energ / 100;
        
        if ((time >= tempoCarga) && ((energ<101) && (energia<100)))
        {
            energia = energia + 1;
            time = 0;
           

        }
        if ((energia == 100) && (energ<100))
        {
            energia = 0;
            energ = energ + 20;
            

        }
        
        
        if ((energia > gastoEnergia) || (energ>=20))
        {
            if (Input.GetKeyDown(gasta))
            {
                if (((energia- gastoEnergia) <-1) && (energ > 0))
                {
                    energia = (energia+100)- gastoEnergia;
                    energ = energ - 20;
                }
                else
                {
                    energia = energia - gastoEnergia;
                }
            }
        }
        if (energ >= 60)
        {
            if (Input.GetKeyDown(ultimate))
            {
                energ = energ - 60;
            }
        }



    }
    
    
}
