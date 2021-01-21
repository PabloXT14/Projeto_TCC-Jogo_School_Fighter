using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMartha : MonoBehaviour
{
    private Animator anim;



    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        

            if ((EnemyJoaoVindo.current.anim.GetBool("isWalking") == true) && (!EnemyJoaoVindo.current.isDead))
            {
                //ANDANDO
                anim.SetBool("isWalking", true);
                anim.SetBool("isJumping", false);
                anim.SetBool("isAtk", false);
            }

            if(!EnemyJoaoVindo.current.enabled)
            {
                anim.SetTrigger("isFullDamage");
            }

            if ((EnemyJoaoVindo.current.anim.GetBool("isJumping") == true) && (!EnemyJoaoVindo.current.isDead))
            {
                //PULANDO
                anim.SetBool("isJumping", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAtk", false);
            }

            if (((EnemyJoaoVindo.current.anim.GetBool("isPower") == true) || (EnemyJoaoVindo.current.anim.GetBool("isUltimate") == true)) && (!EnemyJoaoVindo.current.isDead))
            {
                //SOLTANDO PODER
                anim.SetBool("isAtk", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isJumping", false);
            }


        
        

       
        if( (EnemyJoaoVindo.current.anim.GetBool("isDead") == true) || (EnemyJoaoVindo.current.isDead == true) )
        {
            //PARADO
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isAtk", false);

        }
        


    }
}
