using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject menuPause;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                //Ativa o menuPaused
                menuPause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                //Desativa o menuPaused
                menuPause.SetActive(false);
            }

        }



    }
}
