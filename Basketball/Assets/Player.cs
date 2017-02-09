using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Basketball basketball;
	public Vector3 basketballOffset;
	public float basketballDistance = 1f;
	public float minShootingForce = 400f;
	public float maxShootingForce = 1000f;

	private bool holdingBasketball;
	private bool calculatingShoot;
	private float shootingTimer = 0f;

	// Use this for initialization
	void Start () {
		holdingBasketball = true;
	}

	public void PickBasketball() {
		shootingTimer = 0f;
		holdingBasketball = true;
		calculatingShoot = false;
		basketball.hitSomething = false;
		basketball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		basketball.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (holdingBasketball) {
			basketball.transform.position = this.transform.position + this.transform.forward * basketballDistance + basketballOffset;
			basketball.GetComponent<Rigidbody> ().useGravity = false;


			if (calculatingShoot) {
				shootingTimer += Time.deltaTime;
			}


			if (GvrViewer.Instance.Triggered || Input.GetKeyDown("space")) {
				if (calculatingShoot == false) {
					calculatingShoot = !calculatingShoot;
				} else if (holdingBasketball) {
					holdingBasketball = false;
					basketball.GetComponent<Rigidbody> ().useGravity = true;
					float calculatedScale = Mathf.Min (shootingTimer, 1f);
					float calculatedForce = minShootingForce + (maxShootingForce - minShootingForce) * calculatedScale;
					basketball.GetComponent<Rigidbody> ().AddForce (this.transform.forward * calculatedForce);
				}
			}
		
		}
	}
}
