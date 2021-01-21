using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrderScenes : MonoBehaviour
{
    public int Entercontroller;
    public int FinalFight;

    void Start()
    {
        SceneManager.LoadScene(31);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Entercontroller == 7)
        {
            SceneManager.LoadScene(7);
        }
        if (FinalFight == 1)
        {
            SceneManager.LoadScene(7);
        }
        if (Entercontroller == 15)
        {
            SceneManager.LoadScene(7);
        }
    }
}
