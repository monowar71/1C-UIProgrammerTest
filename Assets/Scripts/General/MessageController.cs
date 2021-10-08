using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : ASingleton_MBLazy<MessageController>
{
    [System.Serializable]
    class Message
    {
        public string type;
        public GameObject messageObject;
        public Text text;
        
    }
    [SerializeField] private List<Message> messages = new List<Message>();

    public void ShowMessage(string type, string text = null)
    {
        var curMessage = messages.Find(message => message.type == type) ?? messages.First();
        curMessage.messageObject.SetActive(true);
        
        if (!string.IsNullOrEmpty(text) && curMessage.text != null)
        {
            curMessage.text.text = text;
        }
    }

    public void HideMessage(string name)
    {
        var curMessage = messages.Find(message => message.type == name);
        curMessage.messageObject.SetActive(false);
    }

    public void HideAllMessage()
    {
        messages.ForEach(message => message.messageObject.SetActive(false));
    }
}
