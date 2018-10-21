using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section_ToggleEvent : MonoBehaviour {
    public bool willActivate = true;

    public List<GameObject> eventToActivate;

    //Hit player
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            //Activate or deactivate object
            foreach(GameObject eventObj in eventToActivate)
            {
                eventObj.SetActive(willActivate);
            }
        }
    }
}
