using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section_Camera : MonoBehaviour {
    public float newCamLerpSpeed = 5;
    public float newCamDistance = 20;
    public float newCamHeight = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            CameraController.instance.InsertNewCamStat(newCamHeight, newCamDistance, newCamLerpSpeed);
        }
    }
}
