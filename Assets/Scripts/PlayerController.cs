using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float walkSpeed = 300.0f;
    public float runSpeed = 600.0f;
    public float turnSpeed = 2.0f;
    private Vector3 direction;
    private Vector2 rotation;

    private Rigidbody physicsBody = null;
    private GameObject map = null;

    private bool hasMap = false;
    private bool paused = false;
    private bool grounded = false;
    private float distanceToGround;
    private float movementSpeed;

	// Use this for initialization
	void Start () {
        physicsBody = gameObject.GetComponent<Rigidbody>();
        rotation.x = gameObject.transform.rotation.eulerAngles.y;
        map = gameObject.transform.Find("MapInterface").gameObject;
        distanceToGround = (gameObject.GetComponent<CapsuleCollider>().height / 2.0f) + 0.1f;
        movementSpeed = walkSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if(Physics.Raycast(gameObject.transform.position, -Vector3.up, distanceToGround))
        {
            grounded = true;
        }

        //Respawn
        if (gameObject.transform.position.y < -5.0f)
        {
            gameObject.transform.position = new Vector3(20.0f, 1.5f, 20.0f);
        }

        if (hasMap && Input.GetButtonDown("Map"))
        {
            ToggleMap();
        }

        if(grounded && Input.GetButtonDown("Jump"))
        {
            physicsBody.AddForce(new Vector3(0.0f, 2000.0f, 0.0f));
            grounded = false;
        }

        if(Input.GetButtonDown("Sprint"))
        {
            movementSpeed = runSpeed;
        }
        if(Input.GetButtonUp("Sprint"))
        {
            movementSpeed = walkSpeed;
        }
    }

    private void FixedUpdate()
    {
        Vector2 characterRotation = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        rotation.x += characterRotation.x;
        transform.rotation = Quaternion.AngleAxis(rotation.x * turnSpeed, Vector3.up);

        direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        direction = transform.TransformDirection(direction);
        direction *= Time.deltaTime * movementSpeed;
        direction.y = physicsBody.velocity.y;
        
        physicsBody.velocity = direction;
    }

    public void GiveMap()
    {
        if(hasMap == false)
        {
            hasMap = true;
            PauseGame();
            map.GetComponent<UIScript>().Show();
        }
    }

    public void ToggleMap()
    {
        if (paused)
        {
            map.GetComponent<UIScript>().Hide();
            UnpauseGame();
        }
        else
        {
            PauseGame();
            map.GetComponent<UIScript>().Show();
        }
    }

    private void PauseGame()
    {
        paused = true;
        Time.timeScale = 0.0f;
    }

    private void UnpauseGame()
    {
        paused = false;
        Time.timeScale = 1.0f;
    }
}
