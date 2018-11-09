using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenSectionManager : TriggerBehaviour {
    public int ArmBroken = 0;

    public GameObject wallObject;

    public void BreakArm()
    {
        ++ArmBroken;

        //If both arms are broken then open up wall
        if(ArmBroken >= 2)
        {
            wallObject.SetActive(false);
        }
    }
}
