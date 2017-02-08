using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {

			GameObject bulletObject = Instantiate (bulletPrefab);
			Bullet bullet = bulletObject.GetComponents<Bullet> ()[0];

			//Get the direction mouse is pointing to.
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 dir = ray.direction;

			bullet.shootingDirection = dir.normalized;
		}
	}
}
