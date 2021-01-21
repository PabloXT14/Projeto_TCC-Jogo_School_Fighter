using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour{



    void Start()
    { 
        StartCoroutine(Delay());
    }

   
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5.1f);
        SceneManager.LoadScene(5);
    }

}
