using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        if(Vector3.Magnitude(transform.position - PlayerBehaviour.instance.transform.position) < CameraController.instance.cameraDistanceToTarget)
        {
            //shake camera if impact too big
            StartCoroutine(CameraController.instance.Shake(0.2f, 
                collision.relativeVelocity.magnitude * 0.01f));

        }

        if (collision.collider.tag == "Disable")
        {
            GetComponent<Rigidbody>().velocity = -Vector3.forward * 15;
            Destroy(gameObject, 5);
        }
    }
}
