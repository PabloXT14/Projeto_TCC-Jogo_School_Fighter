using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//SERVIRAR PARA CONTROLE DOS ROUNDS E FINAL DA LUTA
public class ControlVersus : MonoBehaviour
{
    public int rounds = 0;
    public GameObject PlayerWin;
    public GameObject PlayerFWin;
    public GameObject caixatexto;
    public int WinPlayer;
    public int WinEnemy;
    public bool isChangeRound = true;

    private Animator start;
    public static ControlVersus current;
    private bool Tutorial;
    public GameObject LocalTutorial;
    public GameObject Enemy;

    public bool canPlay = false;


    //VARIÁVEIS DE REPOR POSIÇÕES
    public float reporXplayer;
    public float reporYplayer;

    public float reporXenemy;
    public float reporYenemy;

    public float reporXcam;
    public float reporYcam;



    void Start()
    {
        rounds = 1;

        
        Tutorial = LocalTutorial.GetComponent<Tutorial>().tutorial;
        current = this;
        start = GetComponent<Animator>();
        start.SetInteger("Ct", 2);
       

    }

    void Update()
    {
        


        //MUDANDO DE ROUND
        if ( ((Player2Versus.current.LifePlayer<= 0) || (PlayerVersus.current.LifePlayer2<= 0)) && (WinEnemy < 2) && (WinPlayer < 2) && (PlayerVersus.current.isJumping == false) && (Player2Versus.current.isJumping == false) && (canPlay == true) )
        {
            canPlay = false;

            isChangeRound = true;

            if(Player2Versus.current.LifePlayer <= 0)
            {
                WinEnemy++;
                //SceneManager.LoadScene(6);               
                
            }
            else if(PlayerVersus.current.LifePlayer2 <= 0)
            {

                WinPlayer++;
                //SceneManager.LoadScene(6);

            }

            rounds++;           


        }

        
            
        

        //ATIVANDO ANIMAÇÃO DOS ROUNDS
        if ((WinEnemy != 2) && (WinPlayer != 2))
        {
            if ((rounds == 1) && (isChangeRound)  )
            {
                isChangeRound = false;
                start.SetInteger("Round", 1);             

            }
            else if ((rounds == 2) && (isChangeRound))
            {
                isChangeRound = false;
                start.SetInteger("Round", 2);
                

            }
            else if ((rounds == 3) && (isChangeRound))
            {
                isChangeRound = false;
                start.SetInteger("Round", 3);
                
            }

            

        }

        if (WinPlayer == 2)
        {
            start.SetInteger("Win/Lose", 1);
            WinPlayer = 0;
        }
        if (WinEnemy == 2)
        {
            start.SetInteger("Win/Lose", 2);
        }

    }

    public void FreezeChacters()
    {
        PlayerVersus.current.DestroyBody();
        Player2Versus.current.DestroyBody();
    }

    public void ReativeChacters()
    {
        canPlay = true;

        PlayerVersus.current.ReativeBody();
        Player2Versus.current.ReativeBody();

    }

    public void finalRound()
    {
        
        
    }
    public void Restart()
    {
        Tutorial = false;

    }

    IEnumerator End()
    {
 
        caixatexto.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        finalRound();
    }

     public void repor()
     {
        //COLOCANDO INIMIGO,PLAYER e CÂMERA NA POSIÇÃO INICIAL

        GameObject.FindGameObjectWithTag("Versus").GetComponent<Transform>().position = new Vector3(reporXenemy, reporYenemy, 0);
        GameObject.FindGameObjectWithTag("Versus").GetComponent<Transform>().localEulerAngles = new Vector3(0, 180, 0);

        GameObject.FindGameObjectWithTag("Versus2").GetComponent<Transform>().position = new Vector3(reporXplayer, reporYplayer, 0);//posição player
        GameObject.FindGameObjectWithTag("Versus2").GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, 0);//rotação player

        Cam.current.GetComponent<Transform>().position = new Vector3(reporXcam, reporYcam, -4f);//posição câmera

        //REGENERANDO VIDA
        Player2Versus.current.LifePlayer = 100;
        PlayerVersus.current.LifePlayer2 = 100;

        //ZERANDO PODER
        BarraEnergy.current.Energ = 0;
        BarraEnergy.current.Energy = 0;

        BarraEnergyEnemy.current.Energ = 0;
        BarraEnergyEnemy.current.Energy = 0;

    } 

   

}
