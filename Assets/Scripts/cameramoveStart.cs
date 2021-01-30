using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramoveStart : MonoBehaviour
{

    public Animator anim;



    public void movecam()
    {

        anim.Play("MoveCam");
    }
}