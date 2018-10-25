using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBehaviour : MonoBehaviour {
    public UnityEvent methods;
    
    public void CallEvent()
    {
        methods.Invoke();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            CallEvent();
        }
    }
}
