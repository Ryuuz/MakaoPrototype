using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float walkSpeed = 300.0f;
    public float turnSpeed = 0.5f;
    private Vector3 direction;
    private Vector2 rotation;
    private Rigidbody physicsBody = null;
    private bool hasMap = false;
    private bool paused = false;

	// Use this for initialization
	void Start () {
        physicsBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate()
    {
        Vector2 characterRotation = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        rotation.x += characterRotation.x;
        transform.rotation = Quaternion.AngleAxis(rotation.x * turnSpeed, Vector3.up);

        direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        direction = transform.TransformDirection(direction);
        direction *= Time.deltaTime * walkSpeed;
        direction.y = physicsBody.velocity.y;
        
        physicsBody.velocity = direction;
    }
}
