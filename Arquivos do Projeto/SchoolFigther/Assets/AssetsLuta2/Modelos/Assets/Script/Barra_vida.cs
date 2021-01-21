using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Barra_vida : MonoBehaviour
{
    public float vida;
    public KeyCode baixa;
    public Image barra;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barra.fillAmount = vida / 100;
        if (Input.GetKey(baixa))
        {
            vida = vida - 1;
        }
    }
}
