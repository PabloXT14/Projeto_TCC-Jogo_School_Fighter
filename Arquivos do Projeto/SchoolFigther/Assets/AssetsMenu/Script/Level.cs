using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour{

   
    public void LoadScene(string name)
    {
        
        SceneManager.LoadScene(name);

        /*DELETANDO SAVE*/
        PlayerPrefs.SetString("Nome", "-10");
        PlayerPrefs.SetInt("Sexo", -10);
        PlayerPrefs.SetInt("Cutscene", -10);
        PlayerPrefs.SetInt("Veterano", -10);
        PlayerPrefs.SetInt("lutasOrder", -10);

    }

   
}
