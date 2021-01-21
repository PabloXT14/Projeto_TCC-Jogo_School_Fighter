using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//SERVIRAR PARA CONTROLE DOS ROUNDS E FINAL DA LUTA
public class Controller : MonoBehaviour
{
    public static int lutas;
    public int rounds = 0;
    public GameObject PlayerWin;
    public GameObject PlayerFWin;
    public GameObject caixatexto;
    public int WinPlayer;
    public int WinEnemy;
    public int sexo;
    public bool isChangeRound = true;

    private Animator start;
    public static Controller current;
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

        if( (PlayerPrefs.GetInt("Sexo") != null) && (PlayerPrefs.GetInt("Sexo") != -10) )
        {
            sexo = PlayerPrefs.GetInt("Sexo");
        }
        else
        {
            sexo = EscolhaSX.sexo;
        }

        
        Tutorial = LocalTutorial.GetComponent<Tutorial>().tutorial;
        current = this;
        start = GetComponent<Animator>();
        start.SetInteger("Ct", 2);
        
        if( (PlayerPrefs.GetInt("lutasOrder") != null) && (PlayerPrefs.GetInt("lutasOrder") != -10) )
        {
            if(lutas < PlayerPrefs.GetInt("lutasOrder"))
            {
                lutas = PlayerPrefs.GetInt("lutasOrder");
            }
            
        }
       

    }

    void Update()
    {
        


        //MUDANDO DE ROUND
        if ( ((PlayerLuta.current.LifePlayer<= 0) || (EnemyJoaoVindo.current.LifeEnemy<= 0)) && (WinEnemy < 2) && (WinPlayer < 2) && (EnemyJoaoVindo.current.isJumping == false) && (PlayerLuta.current.isJumping == false) && (canPlay == true) )
        {
            canPlay = false;

            isChangeRound = true;

            if(PlayerLuta.current.LifePlayer <= 0)
            {
                WinEnemy++;
                //SceneManager.LoadScene(6);               
                
            }
            else if(EnemyJoaoVindo.current.LifeEnemy <= 0)
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
            lutas += 1;
            WinPlayer = 0;
        }
        if (WinEnemy == 2)
        {
            start.SetInteger("Win/Lose", 2);
        }

    }

    public void FreezeChacters()
    {
        EnemyJoaoVindo.current.DestrouBody();
        PlayerLuta.current.DestroyBody();
    }

    public void ReativeChacters()
    {
        canPlay = true;
        
        EnemyJoaoVindo.current.ReativeBody();
        PlayerLuta.current.ReativeBody();

    }

    public void finalRound()
    {
        if(lutas == 1)
        {
            SceneManager.LoadScene(6);
        }
        if (lutas == 2)
        {
            SceneManager.LoadScene(8);
        }
        if (lutas == 3)
        {
            SceneManager.LoadScene(40);
        }
        if (lutas == 4)
        {
            SceneManager.LoadScene(48);
        }
        if(lutas == 5)
        {
            SceneManager.LoadScene(56);
        }
        if(lutas == 6)
        {
            SceneManager.LoadScene(57);
        }
        
    }
    public void Restart()
    {
        Tutorial = false;

        if (lutas == 1)
        {
            SceneManager.LoadScene(7);
        }
        if (lutas == 2)
        {
            SceneManager.LoadScene(38);
        }
        if (lutas == 3)
        {
            SceneManager.LoadScene(40);
        }
        if (lutas == 4)
        {
            SceneManager.LoadScene(48);
        }
        if(lutas == 5)
        {
            SceneManager.LoadScene(56);
        }
    }

    IEnumerator End()
    {
        if (sexo == 0)
        {
            PlayerWin.SetActive(true);
        }
        if (sexo == 1)
        {
            PlayerFWin.SetActive(true);
        }
        caixatexto.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        finalRound();
    }

     public void repor()
     {
        //COLOCANDO INIMIGO,PLAYER e CÂMERA NA POSIÇÃO INICIAL

        GameObject.FindGameObjectWithTag("Inimigo").GetComponent<Transform>().position = new Vector3(reporXenemy, reporYenemy, 0);
        GameObject.FindGameObjectWithTag("Inimigo").GetComponent<Transform>().localEulerAngles = new Vector3(0, 180, 0);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = new Vector3(reporXplayer, reporYplayer, 0);//posição player
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, 0);//rotação player

        Cam.current.GetComponent<Transform>().position = new Vector3(reporXcam, reporYcam, -4f);//posição câmera

        //REGENERANDO VIDA
        PlayerLuta.current.LifePlayer = 100;
        EnemyJoaoVindo.current.LifeEnemy = 100;

        //ZERANDO PODER
        BarraEnergy.current.Energ = 0;
        BarraEnergy.current.Energy = 0;

        BarraEnergyEnemy.current.Energ = 0;
        BarraEnergyEnemy.current.Energy = 0;

    } 

    public void Ready()
    {
        EnemyJoaoVindo.current.StopOff();
    }
   

}
