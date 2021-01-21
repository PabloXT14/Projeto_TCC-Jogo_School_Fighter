using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGame : MonoBehaviour
{
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);  
    }

   
}