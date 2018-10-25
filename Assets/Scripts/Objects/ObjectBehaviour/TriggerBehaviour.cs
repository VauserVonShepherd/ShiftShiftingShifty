using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBehaviour : MonoBehaviour {
    public UnityEvent enterMethods;
    public UnityEvent exitMethods;

    public void CallEventEnter()
    {
        enterMethods.Invoke();
    }
    
    public void CallEventExit()
    {
        exitMethods.Invoke();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            CallEventEnter();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            CallEventExit();
        }
    }
}
