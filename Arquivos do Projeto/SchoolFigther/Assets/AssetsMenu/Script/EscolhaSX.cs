using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EscolhaSX : MonoBehaviour
{
    public static int sexo;
    public Button masc;
    public Button fem;
    void Start()
    {
        Button btn = masc.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btnF = fem.GetComponent<Button>();
        btnF.onClick.AddListener(TaskOnClickF);
    }

    void TaskOnClick()
    {
       sexo = 0;
    }
    void TaskOnClickF()
    {
        sexo = 1;
    }
}
