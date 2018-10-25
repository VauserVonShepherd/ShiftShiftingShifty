using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour {
    public Transform platform;

    public bool isActive = false;

    [SerializeField]
    private float timeBeforeElevatorStart = 5;
    [SerializeField]
    private float timeBeforeElevatorStop = 5;

    // Update is called once per frame
    void Update () {
        if (isActive)
        {
            platform.Translate((-Vector3.up + Vector3.right) * Time.deltaTime);
        }
	}

    //Pivot the platform for difficulty
    private void RotatePlatform()
    {

    }

    public void StartTheElevator()
    {
        StartCoroutine(startElevatorIn());
    }

    private IEnumerator startElevatorIn()
    {
        yield return new WaitForSeconds(timeBeforeElevatorStart);
        isActive = true;
        StartCoroutine(stopElevatorIn());
    }
    
    private IEnumerator stopElevatorIn()
    {
        yield return new WaitForSeconds(timeBeforeElevatorStop);
        isActive = false;
    }
}
