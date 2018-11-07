using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
    [SerializeField]
    private float maxHorizontal = 1;

    private Vector3 startingPos;

    private bool isRight = true;

    private void Awake()
    {
        startingPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            startingPos + new Vector3(isRight? maxHorizontal : -maxHorizontal, 0),
            Time.deltaTime);

        if(Vector3.Magnitude(startingPos + new Vector3(isRight ? maxHorizontal : -maxHorizontal, 0) - transform.position) < 0.2f)
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
        }
    }
}
