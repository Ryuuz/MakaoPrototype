using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour {
    CanvasGroup canvasGroup;

    // Use this for initialization
    void Start () {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        Hide();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hide()
    {
        canvasGroup.alpha = 0.0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    public void Show()
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }
}
