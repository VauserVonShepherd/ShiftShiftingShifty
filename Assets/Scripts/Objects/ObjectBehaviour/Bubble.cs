﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
    [SerializeField]
    private float maxHorizontal = 1;

    [SerializeField]
    private float timeBeforeDestroy = 1;

    private Vector3 startingPos;

    private bool isRight = true;

    private void Awake()
    {
        startingPos = transform.position;
    }

    private void Start()
    {
        StartCoroutine(DestroyInTime());
    }

    private void Update()
    {
        Vector3 targetLocation = new Vector3(startingPos.x, transform.position.y, 0);

        transform.position = Vector3.Lerp(transform.position,
            targetLocation + new Vector3(isRight? maxHorizontal : -maxHorizontal, 0),
            Time.deltaTime);


        if(Vector3.Magnitude(targetLocation + new Vector3(isRight ? maxHorizontal : -maxHorizontal, 0) - transform.position) < 0.2f)
        {
            isRight = !isRight;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerBehaviour>().JumpModifier = 400;
            other.GetComponent<PlayerHealth>().IncreaseMaxHealth((1f- other.GetComponent<PlayerHealth>().health) + 1);
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyInTime()
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        while (transform.localScale.x > 0)
        {
            yield return new WaitForSeconds(0.05f);
            transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        }

        Destroy(gameObject);
        yield return null;
    }
}
