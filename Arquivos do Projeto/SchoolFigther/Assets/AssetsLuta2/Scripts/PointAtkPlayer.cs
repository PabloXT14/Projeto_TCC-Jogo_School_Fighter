using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtkPlayer : MonoBehaviour
{
    private int AtVeterano;
    public bool isAtk;

    public static PointAtkPlayer current;

    void Start()
    {
        current = this;
        AtVeterano = EscolhaVet.vet;
        
    }
    private void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Inimigo")
        {
            isAtk = true;
            PlayerLuta.current.AudioPunch.Play();

            if (AtVeterano == 0)
            {
                EnemyJoaoVindo.current.TakeDamage(0.9f);
                if (PlayerLuta.current.noOfClicks < 3)
                {
                    //EMPURRA EM UMA DISTÂNCIA PEQUENA
                    colider.gameObject.transform.Translate(-Vector2.right * 1.2f);
                }
                else
                {
                    //EMPURRA EM UMA DISTÂNCIA GRANDE AO COMPLETAR O COMBO
                    colider.gameObject.transform.Translate(-Vector2.right * 3f);
                }

            }
            if (AtVeterano == 1)
            {
                EnemyJoaoVindo.current.TakeDamage(2.1f);

                if (PlayerLuta.current.noOfClicks < 3)
                {
                    //EMPURRA EM UMA DISTÂNCIA PEQUENA
                    colider.gameObject.transform.Translate(-Vector2.right * 1.2f);
                }
                else
                {
                    //EMPURRA EM UMA DISTÂNCIA GRANDE AO COMPLETAR O COMBO
                    colider.gameObject.transform.Translate(-Vector2.right * 3f);
                }
            }
            if (AtVeterano == 2)
            {
                EnemyJoaoVindo.current.TakeDamage(1.4f);

                if (PlayerLuta.current.noOfClicks < 3)
                {
                    //EMPURRA EM UMA DISTÂNCIA PEQUENA
                    colider.gameObject.transform.Translate(-Vector2.right * 1.2f);
                }
                else
                {
                    //EMPURRA EM UMA DISTÂNCIA GRANDE AO COMPLETAR O COMBO
                    colider.gameObject.transform.Translate(-Vector2.right * 3f);
                }

            }
            else
            {
                isAtk = false;
            }
        }

    }

}
