using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDestruction : MonoBehaviour
{
    public float lifeSpan = 2.0f;
	
    
    // Use this for initialization
	void Start ()
    {
        Destroy(gameObject, lifeSpan);
	}
}
