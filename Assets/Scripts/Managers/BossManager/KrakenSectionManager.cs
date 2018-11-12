using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenSectionManager : TriggerBehaviour {
    public int ArmBroken = 0;

    public GameObject wallObject;
    public Rigidbody KrakenObj;

    public BasicAI[] nextJointToActivate;

    private void Start()
    {
        foreach (BasicAI ai in nextJointToActivate)
        {
            ai.enabled = false;
        }
    }

    public void ActivateNextSection()
    {
        foreach(BasicAI ai in nextJointToActivate)
        {
            ai.enabled = true;
        }
    }

    public void BreakArm()
    {
        ++ArmBroken;

        //If both arms are broken then open up wall
        if(ArmBroken >= 2)
        {
            wallObject.SetActive(false);
            DropKraken();
            ActivateNextSection();
        }
    }

    public void DropKraken()
    {
        if (KrakenObj)
        {
            KrakenObj.useGravity = true;
            KrakenObj.isKinematic = false;
            CameraController.instance.ShakeForTime(4);
        }
    }
}
