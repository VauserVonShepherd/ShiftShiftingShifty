using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour {
    public Transform platform;

    public bool isActive = false;

    [SerializeField]
    private float Hspeed = 2;
    [SerializeField]
    private float Vspeed = 2;

    [SerializeField]
    private float baseRotation = 30;

    [SerializeField]
    private float timeBeforeStart = 5;
    [SerializeField]
    private float timeBeforeStop = 5;

    // Update is called once per frame
    void Update () {
        if (isActive)
        {
            platform.Translate((-Vector3.up * Vspeed + Vector3.right* Hspeed) * Time.deltaTime);

            if(Vector3.Magnitude(PlayerBehaviour.instance.transform.position - platform.position) > 20)
            {
                PlayerHealth.instance.TakeInstantDamage(100);
            }
        }
	}
    
    public void StartTheElevator()
    {
        StartCoroutine(startElevatorIn());
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
