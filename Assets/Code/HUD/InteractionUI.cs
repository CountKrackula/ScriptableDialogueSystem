using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    public Text MessageText;

    public void SetMessageText(string messageText)
    {
        MessageText.text = messageText;
    }
}
