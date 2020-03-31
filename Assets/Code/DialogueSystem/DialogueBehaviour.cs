using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class DialogueBehaviour : MonoBehaviour
{
    [SerializeField] private string hostName;
    public string HostName { get { return hostName; } set { hostName = value; } }

    [SerializeField] private PlayerController playerController;
    public PlayerController PlayerController { get { return playerController; } set { playerController = value; } }

    [Header("Dialogue")]
    public DialogueScript[] DialogueScripts;
    private Queue<DialogueScript> dialogueQueue;
    private PlayerHUD playerHUD;

    private void Start()
    {
        LoadDialogueQueue(DialogueScripts);
        playerHUD = FindObjectOfType<PlayerHUD>();
    }
    private void LoadDialogueQueue(DialogueScript[] dialogueScripts)
    {
        dialogueQueue = new Queue<DialogueScript>();
        foreach (DialogueScript item in dialogueScripts)
        {
            dialogueQueue.Enqueue(item);
        }
    }
    public bool TryPlayDialogueInQueue()
    {
        Debug.Log("Dialogue Queue Count: " + dialogueQueue.Count);
        if (dialogueQueue.Count > 0)
        {
            try
            {
                DialogueScript dialogueScript = dialogueQueue.Dequeue();
                DialoguePanel dialoguePanel = DialoguePanelFactory.CreateDialoguePanel(playerController, hostName, dialogueScript);
                dialoguePanel.onDialogueCompleted.AddListener(DialogueComplete);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void PlayDialogue()
    {
        if (TryPlayDialogueInQueue())
        {
            Debug.Log("Successful Dequeue");
        }
        else
        {
            Debug.Log("Dialogue is finished");

        }
    }

    private void DialogueComplete(DialoguePanel dialoguePanel)
    {
        if (dialoguePanel.isLastDialogue)
        {
            dialogueQueue.Enqueue(dialoguePanel.DialogueScript);
        }
        else
        {
            PlayDialogue();
        }
        dialoguePanel.ClosePanel();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController = other.transform.root.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.onUseKeyPressed.AddListener(PlayDialogue);
            OpenInteractionUI("Press E to Talk");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController playerController = other.transform.root.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.onUseKeyPressed.RemoveListener(PlayDialogue);
        }
        playerController = null;
        CloseInteractionUI();
    }
    private void OpenInteractionUI(string message)
    {
        if(playerHUD != null)
        {
            playerHUD.DisplayInteractionUI(message);
        }
        else
        {
            Debug.Log("Player HUD is null");
        }
    }
    private void CloseInteractionUI()
    {
        if (playerHUD != null)
        {
            playerHUD.CloseInteractionUI();
        }
        else
        {
            Debug.Log("Player HUD is null");
        }
    }
}
