using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenArm : MonoBehaviour {
    public Transform armlast;

    public bool FollowPlayer = false;

    public Transform[] movementTargetList = new Transform[0];
    private int currmovementTargetVal = 0;
    
    // Update is called once per frame
    void Update()
    {
        MoveArm();
    }

    public void MoveArm()
    {
        armlast.position = Vector3.MoveTowards(armlast.position, movementTargetList[currmovementTargetVal].position, Time.deltaTime * 7);

        if (Vector3.Magnitude(armlast.position - movementTargetList[currmovementTargetVal].position) < 2)
        {
            ++currmovementTargetVal;
            if (currmovementTargetVal >= movementTargetList.Length)
            {
                currmovementTargetVal = 0;
            }
        }
    }
}
