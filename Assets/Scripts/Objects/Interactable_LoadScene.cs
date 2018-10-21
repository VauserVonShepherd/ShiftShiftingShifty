using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_LoadScene : MonoBehaviour
{
    public string sceneToLoad;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerBehaviour>() &&
            other.GetComponent<Rigidbody>().velocity.magnitude == 0)
        {
            SceneTransitionManager.instance.LoadScene(sceneToLoad);
        }
    }
}
