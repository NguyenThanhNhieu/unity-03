using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private CharacterMovement characterMovement;

	// Use this for initialization
	void Awake ()
    {
        characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void EnableCharacterMovement()
    {
        print("Enable Character Movement!");
        characterMovement.enabled = true;
    }
}
