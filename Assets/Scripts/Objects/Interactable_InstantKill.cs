using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_InstantKill : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
