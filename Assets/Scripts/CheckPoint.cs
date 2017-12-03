using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private BossController bossController;
    private CharacterMovement characterMovement;

	// Use this for initialization
	void Awake ()
    {
        bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
        characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            //Change the camera behavior
            //Wake up the boss
            bossController.bossAwake = true;
            

            Collider c = GetComponent<Collider>();
            c.isTrigger = false;

            //Disable Character Movement
            characterMovement.enabled = false;
        }
    }
}
