using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {
    public GameObject[] npcs;
    public int dialogueNumber = 0;
    public Text dialogueOwner;
    public Text dialogueText;

    private List<DialogueLine> sentences;
    private bool talking = false;
    private SphereCollider colliderRadius;

	// Use this for initialization
	void Start () {
        sentences = new List<DialogueLine>();
        GetDialogue();
        talking = false;
        colliderRadius = gameObject.GetComponent<SphereCollider>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(CheckForNPCs())
            {
                talking = true;
                other.transform.Find("DialogueBox").GetComponent<UIScript>().Show();
                StartCoroutine(RunDialogue());
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            talking = false;
            other.transform.Find("DialogueBox").GetComponent<UIScript>().Hide();
        }
    }

    private void GetDialogue()
    {
        DialogueLine[] tempDialogue = gameObject.GetComponent<Conversations>().GetConversation(dialogueNumber);

        foreach(DialogueLine line in tempDialogue){
            sentences.Add(line);
        }
    }

    public IEnumerator RunDialogue()
    {
        int index = 0;
        while (talking && index < sentences.Count)
        {
            dialogueOwner.text = sentences[index].name;
            dialogueText.text = sentences[index].text;

            index++;
            yield return new WaitForSeconds(1.0f);
        }

        yield return null;
    }

    private bool CheckForNPCs()
    {
        bool present = true;

        foreach(GameObject npc in npcs)
        {
            if(Vector3.Distance(gameObject.transform.position, npc.transform.position) > colliderRadius.radius)
            {
                present = false;
            }
        }

        return present;
    }
}
