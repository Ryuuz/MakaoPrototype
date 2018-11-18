using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float walkSpeed = 10.0f;
    private Vector3 direction;
    private Vector2 rotation;
    private Rigidbody physicsBody = null;

	// Use this for initialization
	void Start () {
        physicsBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 characterRotation = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        rotation.x = rotation.x + characterRotation.x;
        transform.rotation = Quaternion.AngleAxis(rotation.x, Vector3.up);

        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction = transform.TransformDirection(direction) * walkSpeed;
        direction.y = physicsBody.velocity.y;
        physicsBody.velocity = direction;
    }
}
