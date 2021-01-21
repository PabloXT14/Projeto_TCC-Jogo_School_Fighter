using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdlePlayer : MonoBehaviour
{
    public int sx;
    public GameObject Press;
    public GameObject PlayerFem;
    public GameObject PlayerMasc;
    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        sx = EscolhaSX.sexo;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (sx == 0)
        {
            PlayerFem.SetActive(false);
        }
        if (sx == 1)
        {
            PlayerMasc.SetActive(false);
        }
    }

}
