using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOff : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().drag = 2;
            other.GetComponent<Rigidbody>().angularDrag = 4;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<PlayerState>().UnStuck();
        }
    }
}
