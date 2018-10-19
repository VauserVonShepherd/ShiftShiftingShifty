using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Healing : MonoBehaviour {

    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() &&
            other.GetComponent<Rigidbody>().velocity.magnitude > 1)
        {
            other.GetComponent<PlayerHealth>().IncreaseHealth(Time.deltaTime * 0.1f);
        }
    }
}
