using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public PlayerController PlayerController { get { return playerController; } set { playerController = value; } }

    [SerializeField] private DialogueScript dialogueScript;
    public DialogueScript DialogueScript { get { return dialogueScript; } set { dialogueScript = value; } }

    public Text GuestNameText;
    public Text HostNameText;
    public Text DialogueText;
    public Button SubmitButton;
    public bool isLastDialogue;
    public DialogueCompleted onDialogueCompleted;
    // Start is called before the first frame update
    void Start()
    {
        SubmitButton.onClick.AddListener(OnSumbitClicked);
    }

    private void OnDestroy()
    {
        SubmitButton.onClick.RemoveListener(OnSumbitClicked);
    }

    public void InitializePanel(PlayerController playerController, string hostName, DialogueScript dialogueScript)
    {
        this.playerController = playerController;
        this.dialogueScript = dialogueScript;
        GuestNameText.text = playerController.Data.ActorName;
        HostNameText.text = hostName;
        DialogueText.text = dialogueScript.dialogueText;
        this.isLastDialogue = dialogueScript.isFinal;
    }

    public void ClosePanel()
    {
        onDialogueCompleted.RemoveAllListeners();
        Destroy(gameObject);
    }

    private void OnSumbitClicked()
    {
        onDialogueCompleted.Invoke(this);
    }

}
