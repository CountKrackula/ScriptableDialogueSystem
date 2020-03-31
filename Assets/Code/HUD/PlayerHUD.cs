using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private InteractionUI interactionUI;
    public InteractionUI InteractionUI { get { return interactionUI; } set { interactionUI = value; } }
    // Start is called before the first frame update
    void Start()
    {
        if (interactionUI == null)
        {
            interactionUI = GetComponentInChildren<InteractionUI>();
        }
    }

    public void DisplayInteractionUI(string message)
    {
        interactionUI.SetMessageText(message);
        interactionUI.gameObject.SetActive(true);
    }
    public void CloseInteractionUI()
    {
        interactionUI.gameObject.SetActive(false);
    }
}
