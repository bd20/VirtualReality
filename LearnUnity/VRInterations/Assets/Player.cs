using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 0.5f;
	public Vector3 castlePosition;
	public bool enteredCastle;

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		//Looking at the door
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit)) {
			if (hit.transform.GetComponent<DoorButton> () != null) {
				hit.transform.GetComponent<DoorButton> ().OnLook ();
				MoveToCastle ();
			}
		}

		//Shooting at emermies
		if (GvrViewer.Instance.Triggered || Input.GetKeyDown ("space")) {
			RaycastHit enermyHit;
			if (Physics.Raycast (transform.position, transform.forward, out enermyHit)) {
				if (hit.transform.GetComponent<Enermy> () != null) {
					Destroy (hit.transform.gameObject);
				}
			}
		}

		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * speed);
	}

	private void MoveToCastle() {
		enteredCastle = true;
		targetPosition = castlePosition;
	}
}
