using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAnimalScript : MonoBehaviour {
    public GameObject stoneGate = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(stoneGate.GetComponent<OpenDoors>().RotateDoors());
        }

        Destroy(gameObject, 2.0f);
    }
}
