using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamVersus : MonoBehaviour
{
    private GameObject player;
    public float Speed;//velocidade de acompanhamento da camera

    //VARIÁVEIS LIMITES DA CÂMERA
    public bool maxMin;
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;

    public static CamVersus current;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        current = this;
    }

    
    void Update()
    {
      //if ((player != null) && (ControlVersus.current.canPlay == true) && (PlayerVersus1.current.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic) && /*(PlayerVesus2.current.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic) && */(PlayerVersus1.current.enabled) && (PlayerVersus2.current.enabled)  )
      //{
  
            /*Atribuindo posição do eixo x do player a camera para seguir*//*OBS: o valor somado/subtraindo ao eixo x do player faz com que a camera foque um pouco afrente da posição do player*/
            Vector3 newPos = new Vector3(player.transform.position.x + 7.5f, transform.position.y, transform.position.z);

            /*Deixando movimento da camera mais suave*/
            transform.position = Vector3.Lerp(transform.position, newPos, Speed * Time.deltaTime);

            /*Limitando visão da camera */
            if (maxMin)
            {
                transform.position = new Vector3(Mathf.Clamp(newPos.x, xMin, xMax), Mathf.Clamp(newPos.y, yMin, yMax), -4/*player.transform.position.z*/);
            }
            
           
      //}


    }


}
