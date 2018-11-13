﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour {
    public float SpeedDebuffVal = 15;

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.GetComponent<PlayerBehaviour>())
    //    {
    //        other.GetComponent<PlayerState>().stuckedPosition = other.transform.position;
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.GetComponent<PlayerBehaviour>())
    //    {
    //        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
    //        other.GetComponent<PlayerState>().Stuck(2,2,1);
    //        player.speedModifier = SpeedDebuffVal;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.GetComponent<PlayerBehaviour>())
    //    {
    //        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();

    //        //player.GetComponent<Rigidbody>().angularDrag = 0.05f;
    //        //other.GetComponent<PlayerState>().stuckedPosition = Vector3.zero;
    //    }
    //}

    private void OnCollisionStay(Collision other)
    {
        if (other.collider.transform.parent && other.collider.transform.parent.GetComponent<PlayerBehaviour>())
        {
            other.collider.transform.parent.GetComponent<PlayerState>().stuckedPosition = other.collider.transform.position;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.transform.parent && other.collider.transform.parent.GetComponent<PlayerBehaviour>())
        {
            PlayerBehaviour player = other.collider.transform.parent.GetComponent<PlayerBehaviour>();
            other.collider.transform.parent.GetComponent<PlayerState>().stuckedPosition = other.collider.transform.position;
            other.collider.transform.parent.GetComponent<PlayerState>().Stuck(2, 2, 1);
            player.speedModifier = SpeedDebuffVal;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.transform.parent && other.collider.transform.parent.GetComponent<PlayerBehaviour>())
        {
            PlayerBehaviour player = other.collider.transform.parent.GetComponent<PlayerBehaviour>();
        }
    }
}
