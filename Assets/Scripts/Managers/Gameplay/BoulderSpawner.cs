using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawner : MonoBehaviour {
    public float CD = 5;
    private float currentCD;

    public GameObject boulderPrefab;

    public int amountPerSpawn = 3;

	// Update is called once per frame
	void Update () {
        currentCD -= Time.deltaTime;

        if(currentCD <= 0)
        {
            for(int i = 0; i < amountPerSpawn; i++)
            {
                GameObject boulder = GameObject.Instantiate(boulderPrefab, transform.position + Vector3.up * i * 2, Quaternion.identity);
            }
            currentCD = CD;
        }
	}
}
