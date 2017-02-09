using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public Vector3 loweredPosition;
	public float speed = 3f;
	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * speed);
	}

	public void LowerDoor() {
		targetPosition = loweredPosition;
	}
}
