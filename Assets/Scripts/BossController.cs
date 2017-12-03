using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public bool bossAwake = false;
    private Animator anim;

	// Use this for initialization
	void Awake ()
    {
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(bossAwake)
        {
            print ("Boss is awake!");
            //Play Intro animation
            anim.SetBool("bossAwake", true);
            //Disable Character Movement script
        }
    }
}
