using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_LoadScene : MonoBehaviour
{
    public string sceneToLoad;

    [SerializeField]
    bool instantLoad = false;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerBehaviour>() &&
            other.GetComponent<Rigidbody>().velocity.magnitude == 0)
        {
            SceneTransitionManager.instance.LoadScene(sceneToLoad);
        }else if (other.gameObject.GetComponent<PlayerBehaviour>() && instantLoad)
        {
            SceneTransitionManager.instance.LoadScene(sceneToLoad);
        }
    }
}
