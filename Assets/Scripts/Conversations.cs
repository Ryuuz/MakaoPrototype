using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversations : MonoBehaviour {
    private DialogueLine[][] conversationsList =
    {
        new DialogueLine[]
        {
            new DialogueLine("Villager1", "Heya!"),
            new DialogueLine("Villager2", "How's it hanging?"),
            new DialogueLine("Villager1", "Pretty good. You?"),
            new DialogueLine("Villager2", "Can't complain.")
        }
    };

    public DialogueLine[] GetConversation(int index)
    {
        return conversationsList[index];
    }
}
