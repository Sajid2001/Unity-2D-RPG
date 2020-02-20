using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Message : ScriptableObject
{
    public List<MessageManager> listeners = new List<MessageManager>();
    public void Raise()
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }
    public void RegisterMessage(MessageManager manager)
    {
        listeners.Add(manager);
    }
    public void DeRegisterMessage(MessageManager manager)
    {
        listeners.Remove(manager);
    }
}
