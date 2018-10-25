using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour {
    private Vector3 touchPosition = Vector3.zero;

    private void Update()
    {
        if(Vector3.Magnitude(touchPosition - PlayerBehaviour.instance.transform.position) > 1)
        {
            touchPosition = Vector3.zero;
            PlayerBehaviour.instance.transform.parent = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            other.transform.parent = transform.parent;
            touchPosition = other.transform.position;
        }
    }
}
