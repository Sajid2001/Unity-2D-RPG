using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MessageManager : MonoBehaviour
{
   public Message message;
    public UnityEvent messageEvent;

   public void OnSignalRaised()
    {
        messageEvent.Invoke();
    }
    private void OnEnable()
    {
        message.RegisterMessage(this);
    }
    private void OnDisable()
    {
        message.DeRegisterMessage(this);
    }
}
