using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionRounds : MonoBehaviour
{
    public bool finishTransition = false;
    

    
    void Start()
    {
        
    }

// Update is called once per frame
    void Update()
    {
        
        finishTransition = false;
        //Debug.Log(finishTransition);
        
    }

    //ENCERRANDO ANIMAÇÃO DE TRANSIÇÃO DE ROUNDS
    public void FinishTransition()
    {
        //FINALIZAR TUTORIAL
        if ((Controller.current.WinEnemy == 2) || (Controller.current.WinPlayer == 2))
        {
            SceneManager.LoadScene(6);
        }
        else
        {
           

            finishTransition = true;
            gameObject.SetActive(false);
        }

        

        
        
    }

}
