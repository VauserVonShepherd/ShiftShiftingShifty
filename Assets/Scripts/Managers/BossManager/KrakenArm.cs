using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenArm : MonoBehaviour {
    public Transform armlast;
    
    public Transform[] movementTargetList = new Transform[0];

    [SerializeField]
    private List<KrakenArmJoint> armJointList = new List<KrakenArmJoint>();

    private int currmovementTargetVal = 0;
    [SerializeField]
    private int chaseRange = 7;
    [SerializeField]
    private int chaseSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        MoveArm();
    }

    public void MoveArm()
    {
        if (Vector3.Magnitude(armlast.position - movementTargetList[currmovementTargetVal].position) < 2)
        {
            ++currmovementTargetVal;
            if (currmovementTargetVal >= movementTargetList.Length)
            {
                currmovementTargetVal = 0;
            }
        }
        
        if(Vector3.Magnitude(armlast.position - PlayerBehaviour.instance.transform.position) < 5 && chaseRange > 0)
        {
            armlast.position = Vector3.MoveTowards(armlast.position, PlayerBehaviour.instance.transform.position, Time.deltaTime * 3);
        }
        else
        {
            armlast.position = Vector3.MoveTowards(armlast.position, movementTargetList[currmovementTargetVal].position, Time.deltaTime * chaseSpeed);
        }
    }

    //Reorganize the arm when joint is destroyed
    public void ReorganizeArm()
    {
        //Check if the current joint is still connected to the base
        bool isConnected = true;

        List<KrakenArmJoint> armStillConnected = new List<KrakenArmJoint>();
        
        for (int i = 0; i < armJointList.Count; i++)
        {
            if(armJointList[i].health <= 0)
            {
                isConnected = false;
            }

            //If the joint is no longer connected, the gravity will be on and the collider will be a trigger
            if (!isConnected)
            {
                armJointList[i].GetComponent<Rigidbody>().useGravity = true;
                armJointList[i].GetComponent<Collider>().isTrigger = true;
            }
            else
            {
                //If it is connected then update the last joint to the latest joint
                armlast = armJointList[i].transform;
                armStillConnected.Add(armJointList[i]);
            }
        }//end for loop

        armJointList = armStillConnected;

        //if the total joint is less than 3
        if(armJointList.Count < 3)
        {
            DisableAllJoint();
            CameraController.instance.ShakeForTime(2);
        }
        else{

            CameraController.instance.ShakeForTime(0.5f);
        }
    }

    void DisableAllJoint()
    {
        this.enabled = false;

        foreach (KrakenArmJoint joint in armJointList)
        {
            joint.GetComponent<Rigidbody>().useGravity = true;
            joint.GetComponent<Collider>().isTrigger = true;
        }
     transform.parent.GetComponent<KrakenSectionManager>().BreakArm();
    }
}
