using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMusic : MonoBehaviour
{
    public int Scene;

    void Start()
    {
        // 0 = menu
        // 1 = antes da primeira luta
        // 2 = luta
        // 3 = map


        if (Scene == 4)
        {
            GameObject.FindGameObjectWithTag("MenuMusic").SetActive(false);
        }
        if (Scene == 1) 
        {
            GameObject.FindGameObjectWithTag("Musica").SetActive(true);
        }


        if (Scene == 2) 
        {            
            GameObject.FindGameObjectWithTag("Musica").SetActive(false);
            GameObject.FindGameObjectWithTag("MusicLuta").SetActive(true);
        }
        if (Scene == 3)
        {            
            GameObject.FindGameObjectWithTag("MusicLuta").SetActive(false);
            GameObject.FindGameObjectWithTag("Musica").SetActive(true);
        }

    }
    



}
