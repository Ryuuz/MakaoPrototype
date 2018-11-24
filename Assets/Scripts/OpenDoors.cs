using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {
    public float closedAngle = 0.0f;
    public float openedAngle = 90.0f;
    public float openingSpeed = 5.0f;

    private Quaternion openedDoorLeft = Quaternion.identity;
    private Quaternion openedDoorRight = Quaternion.identity;
    private Quaternion closedDoor = Quaternion.identity;

    private Transform leftTransform;
    private Transform rightTransform;

    private bool closed = true;
    private bool moving = false;

	// Use this for initialization
	void Start () {
        leftTransform = gameObject.transform.Find("Left");
        rightTransform = gameObject.transform.Find("Right");

        openedDoorLeft = Quaternion.Euler(0.0f, openedAngle, 0.0f);
        openedDoorRight = Quaternion.Euler(0.0f, -openedAngle, 0.0f);
        closedDoor = Quaternion.Euler(0.0f, closedAngle, 0.0f);

        closed = true;
        moving = false;
}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator RotateDoors()
    {
        if(!moving)
        {
            moving = true;

            if(closed)
            {
                while (Quaternion.Angle(leftTransform.localRotation, openedDoorLeft) > 2.0f)
                {
                    leftTransform.localRotation = Quaternion.Slerp(leftTransform.localRotation, openedDoorLeft, openingSpeed * Time.deltaTime);
                    rightTransform.localRotation = Quaternion.Slerp(rightTransform.localRotation, openedDoorRight, openingSpeed * Time.deltaTime);
                    yield return null;
                }
            }
            else
            {
                while (Quaternion.Angle(leftTransform.localRotation, closedDoor) > 2.0f)
                {
                    leftTransform.localRotation = Quaternion.Slerp(leftTransform.localRotation, closedDoor, openingSpeed * Time.deltaTime);
                    rightTransform.localRotation = Quaternion.Slerp(rightTransform.localRotation, closedDoor, openingSpeed * Time.deltaTime);
                    yield return null;
                }
            }

            yield return null;
            closed = !closed;
            moving = false;
        }
    }
}
