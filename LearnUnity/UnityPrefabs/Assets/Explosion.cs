using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public GameObject[] particalPrefabs;
	public int amountOfParticles = 3;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < amountOfParticles; i++) {
			GameObject particalPrefab = Instantiate (particalPrefabs [Random.Range (0, particalPrefabs.Length)]);
			particalPrefab.transform.position = transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
