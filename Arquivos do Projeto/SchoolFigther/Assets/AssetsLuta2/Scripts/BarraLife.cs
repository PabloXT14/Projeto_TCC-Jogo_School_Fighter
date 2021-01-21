using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraLife : MonoBehaviour
{
    public float Life;
    public Image barra;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Life = PlayerLuta.current.LifePlayer;
        barra.fillAmount = Life / 100;
    }



}
