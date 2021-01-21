using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour
{
    public Text CronometroText;
    private float tempoAtual;

    void Start()
    {
        tempoAtual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtual += Time.deltaTime;
        CronometroText.text = tempoAtual.ToString("F2");
    }
}
