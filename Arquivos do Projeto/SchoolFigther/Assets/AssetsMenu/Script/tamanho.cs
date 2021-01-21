using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class tamanho : MonoBehaviour
{
    public float A, B, screenWidth, screenHeight;

    // Use this for initialization
    void Start()
    {
        A = transform.localScale.x;
        B = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        transform.localScale = new Vector3((A * screenWidth / screenHeight), transform.localScale.y, transform.localScale.z);
    }
}