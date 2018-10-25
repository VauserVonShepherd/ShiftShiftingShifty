using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour {
    public Transform platform;

    public bool isActive = false;

    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private float baseRotation = 30;

    [SerializeField]
    private float timeBeforeStart = 5;
    [SerializeField]
    private float timeBeforeStop = 5;

    public TriggerBehaviour[] sectionCheckpoints = new TriggerBehaviour[0];
    private int currCheckpoint = 0;

    // Update is called once per frame
    void Update () {
        if (isActive)
        {
            //platform.Translate((-Vector3.up * Vspeed + Vector3.right* Hspeed) * Time.deltaTime);

            platform.Translate((sectionCheckpoints[currCheckpoint].transform.position - platform.position).normalized * speed * Time.deltaTime);

            if (Vector3.Magnitude(PlayerBehaviour.instance.transform.position - platform.position) > 20)
            {
                PlayerHealth.instance.TakeInstantDamage(100);
            }

            if (Vector3.Magnitude(sectionCheckpoints[currCheckpoint].transform.position - platform.position) < 1)
            {
                ++currCheckpoint;
                if(currCheckpoint >= sectionCheckpoints.Length)
                {
                    isActive = false;
                }
            }
        }
	}
    
    public void StartTheElevator()
    {
        StartCoroutine(startElevatorIn());
    }
    
    public void RotatePlatformTrigger(float speed)
    {
        StartCoroutine(RotatePlatform(speed));
    }

    public void setElevatorPace(int paceVal)
    {
        switch (paceVal) {
            case 1:
                speed = 3;
                break;

            case 2:
                speed = 6;
                break;

            case 3:
                speed = 9;
                break;
        }
    }

    //Pivot the platform for difficulty
    IEnumerator RotatePlatform(float speed)
    {
        float moveSpeed = speed;
        while (platform.rotation.y < 180)
        {
            platform.rotation = Quaternion.Slerp(platform.rotation, Quaternion.Euler(0, 0, -baseRotation), moveSpeed * Time.time);
            yield return null;
        }
        platform.rotation = Quaternion.Euler(0, 180, 0);
        yield return null;
    }

    private IEnumerator startElevatorIn()
    {
        yield return new WaitForSeconds(timeBeforeStart);
        isActive = true;
        StartCoroutine(stopElevatorIn());

        StartCoroutine(RotatePlatform(0.01f));
    }
    
    private IEnumerator stopElevatorIn()
    {
        yield return new WaitForSeconds(timeBeforeStop);
        isActive = false;
    }
}
