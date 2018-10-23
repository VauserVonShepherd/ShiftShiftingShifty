using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour_Cooldown : MonoBehaviour {
    [SerializeField]    
    protected float Cooldown;

    protected float currCooldown = 0;

	// Update is called once per frame
	void Update () {
        if(currCooldown > 0)
        {
            currCooldown -= Time.deltaTime;
        }
        else {
            CallEvent();
        }
	}

    public virtual void CallEvent()
    {

    }
}
