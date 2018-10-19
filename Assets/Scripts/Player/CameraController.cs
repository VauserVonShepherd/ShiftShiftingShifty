using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject focusObject;

    public bool isFollowing = true;
    public float cameraDistanceToTarget = 10;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float CameraLerpSpeed = 1;

    private void Start()
    {
        focusObject = player;
    }

    private void Update()
    {
        if (isFollowing)
            LerpCamera();
    }

    private void LerpCamera()
    {
        if (focusObject)
        {
            //Camera position lerp to target x and y, while it's z is maintained by CameraDistanceToTarget
            transform.position = Vector3.Lerp(transform.position, 
                new Vector3(focusObject.transform.position.x, focusObject.transform.position.y, -cameraDistanceToTarget), 
                Time.deltaTime * CameraLerpSpeed);
        }
    }
}
