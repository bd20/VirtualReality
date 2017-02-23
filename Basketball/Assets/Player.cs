using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Basketball basketball;
	public Vector3 basketballOffset;

	public float basketballDistance = 1f;
	public float minShootingForce = 400f;
	public float maxShootingForce = 1000f;
	public float relativeTorqueX = 200f;

	public ForcePointer forcePointer;

	private bool holdingBasketball;

	private Vector3 previousForwardDirection;

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		holdingBasketball = true;
		targetPosition = transform.position;
	}

	public void PickBasketball() {
		holdingBasketball = true;
		basketball.hitSomething = false;
		basketball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		basketball.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
	}

	void Update () {
		RaycastHit hit;

		//When holding the basketball
		if (holdingBasketball) {
			basketball.transform.position = this.transform.position + this.transform.forward * basketballDistance + basketballOffset;
			//basketball.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
			basketball.GetComponent<Rigidbody> ().useGravity = false;
		}

		//When triggering
		if (GvrViewer.Instance.Triggered || Input.GetKeyDown("space")) {
			bool castSomething = (Physics.Raycast (transform.position, transform.forward, out hit));
			if (castSomething && hit.transform.name == "Floor") {
				targetPosition = new Vector3 (
					hit.point.x,
					transform.position.y,
					hit.point.z
				);
			}
			else if (holdingBasketball) {
				holdingBasketball = false;
				basketball.GetComponent<Rigidbody> ().useGravity = true;
				float calculatedScale = (forcePointer.transform.position.x - forcePointer.startX) 
					/ (forcePointer.endX - forcePointer.startX);
				float calculatedForce = minShootingForce + (maxShootingForce - minShootingForce) * calculatedScale;
				basketball.GetComponent<Rigidbody> ().AddForce (this.transform.forward * calculatedForce);
				basketball.GetComponent<Rigidbody> ().AddRelativeTorque (new Vector3 (relativeTorqueX, 0f, 0f));
			}
		}

		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime);
	}
}
