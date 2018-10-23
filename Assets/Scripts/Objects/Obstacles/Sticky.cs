using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            other.GetComponent<PlayerState>().stuckedPosition = other.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
            other.GetComponent<PlayerState>().Stuck(2,2,1);
            player.speedModifier = 15;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();

            //player.GetComponent<Rigidbody>().angularDrag = 0.05f;
            //other.GetComponent<PlayerState>().stuckedPosition = Vector3.zero;
        }
    }
}
