using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{

    public static SaveData current;

    void Start()
    {
        
    }

    
    void Update()
    {
        current = this;
    }

    
    public void Save()
    {
        PlayerPrefs.SetString("Nome", Conversa.NomePRo);
        PlayerPrefs.SetInt("Sexo", Player.sx);
        PlayerPrefs.SetInt("Cutscene", Player.Cut);
        PlayerPrefs.SetInt("Veterano", Player.Vt);
        PlayerPrefs.SetInt("lutasOrder", Player.lutasOrder);
        
    }

    public void Load()
    {

        Conversa.NomePRo =  PlayerPrefs.GetString("Nome");
        Player.sx = PlayerPrefs.GetInt("Sexo");
        Player.Cut = PlayerPrefs.GetInt("Cutscene");
        Player.Vt = PlayerPrefs.GetInt("Veterano");
        Player.lutasOrder = PlayerPrefs.GetInt("lutasOrder");

        Debug.Log(PlayerPrefs.GetString("Nome"));
        Debug.Log(PlayerPrefs.GetInt("lutasOrder"));


        if (PlayerPrefs.GetInt("lutasOrder") != null)
        {


            if (PlayerPrefs.GetInt("lutasOrder") < 3)
            {
                SceneManager.LoadScene(21);
            }
            else
            {
                SceneManager.LoadScene(53);

            }

        }
        else
        {
            SceneManager.LoadScene(0);
        }
        

    }

}
