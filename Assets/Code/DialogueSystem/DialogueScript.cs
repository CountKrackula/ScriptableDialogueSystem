using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "newDialogueScript", menuName = "Dialogue Script")]
public class DialogueScript : ScriptableObject
{
    public DialoguePanel dialoguePanelPrefab;
    public string dialogueText;
    public bool isFinal;

    public DialogueScript Copy()
    {
        DialogueScript dialogueCopy = ScriptableObject.CreateInstance<DialogueScript>();
        dialogueCopy.dialoguePanelPrefab = dialoguePanelPrefab;
        dialogueCopy.dialogueText = dialogueText;
        dialogueCopy.isFinal = isFinal;
        return dialogueCopy;
    }
}
