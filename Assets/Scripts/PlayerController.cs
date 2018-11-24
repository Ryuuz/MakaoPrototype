using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float walkSpeed = 300.0f;
    public float turnSpeed = 2.0f;
    private Vector3 direction;
    private Vector2 rotation;
    private Rigidbody physicsBody = null;
    private bool hasMap = false;
    private bool paused = false;

	// Use this for initialization
	void Start () {
        physicsBody = gameObject.GetComponent<Rigidbody>();
        rotation.x = gameObject.transform.rotation.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
        if(hasMap && Input.GetButtonDown("Map"))
        {
            if(paused)
            {
                gameObject.GetComponentInChildren<UIScript>().Hide();
                UnpauseGame();
            }
            else
            {
                PauseGame();
                gameObject.GetComponentInChildren<UIScript>().Show();
            }
        }
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

    public void GiveMap()
    {
        if(hasMap == false)
        {
            hasMap = true;
            PauseGame();
            gameObject.GetComponentInChildren<UIScript>().Show();
        }
    }

    public void ToggleMap()
    {

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
