using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReativatingCharacters : MonoBehaviour
{
    public void ReativeBody()
    {
        

        EnemyJoaoVindo.current.ReativeBody();
        PlayerLuta.current.ReativeBody();

        
        gameObject.SetActive(false);
    }
}
