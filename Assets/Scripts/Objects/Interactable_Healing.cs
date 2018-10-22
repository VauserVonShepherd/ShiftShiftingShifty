using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Healing : MonoBehaviour {

    public void OnTriggerStay(Collider other)
    {
        //if play is in mud
        if (other.GetComponent<PlayerHealth>())
        {
            if (other.transform.position.y < transform.position.y + transform.localScale.y * 0.5f)
            {
                other.GetComponent<Rigidbody>().velocity += Vector3.up * 0.25f + Vector3.right * 
                    other.GetComponent<PlayerBehaviour>().getHSpeed() * Time.deltaTime * 0.1f;
            }

            //if it's moving
             if (other.GetComponent<Rigidbody>().velocity.magnitude > 1)
            {
                other.GetComponent<PlayerHealth>().IncreaseHealth(Time.deltaTime * 0.1f);
            }
        }
    }
}
