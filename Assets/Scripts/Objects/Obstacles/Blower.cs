using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : BaseBehaviour_Cooldown {
    [SerializeField]
    private Transform startTransform;
    [SerializeField]
    private float BlowStrength = 4;

    private List<GameObject> objectsInRange = new List<GameObject>();

    public override void CallEvent()
    {
        base.CallEvent();

        currCooldown = Cooldown;
        Blow();
    }

    private void FixedUpdate()
    {
        GetComponent<Renderer>().material.color = new Color(
            GetComponent<Renderer>().material.color.r,
            GetComponent<Renderer>().material.color.b,
            GetComponent<Renderer>().material.color.g,
            (Cooldown - currCooldown) / Cooldown);

        print((Cooldown - currCooldown) / Cooldown );
    }

    public void Blow()
    {
        List<GameObject> tempList = new List<GameObject>();

        foreach(GameObject obj in objectsInRange)
        {
            if (obj)
            {
                tempList.Add(obj);
            }
        }
        objectsInRange = tempList;

        foreach(GameObject obj in objectsInRange){
           obj.GetComponent<Rigidbody>().velocity = transform.right * BlowStrength / Vector3.Magnitude(startTransform.position - obj.transform.position);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            objectsInRange.Add(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (objectsInRange.Contains(other.gameObject))
        {
            objectsInRange.Remove(other.gameObject);
        }
    }
}
