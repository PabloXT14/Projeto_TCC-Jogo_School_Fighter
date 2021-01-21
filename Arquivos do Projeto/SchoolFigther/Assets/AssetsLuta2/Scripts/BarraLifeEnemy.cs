using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraLifeEnemy : MonoBehaviour
{
    public float Life;
    public Image barra;

    public static BarraLifeEnemy current;

    
    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        Life = EnemyJoaoVindo.current.LifeEnemy;
        barra.fillAmount = Life / 100;
       

    }



}
