using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public static CameraController instance;

    public GameObject focusObject;

    public bool isFollowing = true;
    public float cameraHeightRelativeToTarget = 2;
    public float cameraDistanceToTarget = 10;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float CameraLerpSpeed = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (PlayerBehaviour.instance)
        {
            player = PlayerBehaviour.instance.gameObject;
            focusObject = player;
        }
    }

    private void Update()
    {
        if (isFollowing)
            LerpCamera();

        if (Input.GetKey(KeyCode.O))
        {
            StartCoroutine(Shake(0.2f, 0.1f));
        }
    }

    private void LerpCamera()
    {
        if (focusObject)
        {
            //Camera position lerp to target x and y, while it's z is maintained by CameraDistanceToTarget
            transform.position = Vector3.Lerp(transform.position, 
                new Vector3(focusObject.transform.position.x, focusObject.transform.position.y + cameraHeightRelativeToTarget, -cameraDistanceToTarget), 
                Time.deltaTime * CameraLerpSpeed);
        }
    }

    public void ShakeForTime(float duration)
    {
        StartCoroutine(Shake(duration,0.1f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        Vector3 originalCamPos = transform.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);

            yield return null;
        }

        transform.position = originalCamPos;
    }

    public void InsertNewCamStat(float height, float distance, float speed)
    {
        CameraLerpSpeed = speed;
        cameraHeightRelativeToTarget = height;
        cameraDistanceToTarget = distance;
    }

    public void SetNewFocus(Transform newFocus)
    {
        focusObject = newFocus.gameObject;
    }
}
