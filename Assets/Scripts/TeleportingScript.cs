using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingScript : MonoBehaviour {
    public GameObject teleportPoint;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(teleportPoint)
            {
                transform.position = teleportPoint.transform.position;
                teleportPoint = teleportPoint.GetComponent<NextPoint>().next;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
