using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour {
    public Camera playerCam;
	
	// Update is called once per frame
	void LateUpdate () {
        transform.LookAt(transform.position + playerCam.transform.rotation * Vector3.forward, playerCam.transform.rotation * Vector3.forward);
    }
}
