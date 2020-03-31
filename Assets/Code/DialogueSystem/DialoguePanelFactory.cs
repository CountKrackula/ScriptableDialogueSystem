using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialoguePanelFactory
{
    public static DialoguePanel CreateDialoguePanel(PlayerController playerController, string hostName, DialogueScript dialogueData)
    {
        DialoguePanel dialoguePanel = GameObject.Instantiate(dialogueData.dialoguePanelPrefab, null);
        dialoguePanel.InitializePanel(playerController, hostName, dialogueData.Copy());
        return dialoguePanel;
    }
}
