using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePointer : MonoBehaviour {

	public float startX = -0.982f;
	public float endX = 1.19f;
	public float updateStep = 0.1f;
	public bool isFront;

	private float start;
	private float end;
	private float update;

	public float getStartPoint() {
		return start;
	}

	public float getEndPoint() {
		return end;
	}

	// Use this for initialization
	void Start () {
		
		start = startX;
		end = endX;
		update = updateStep;
		if (isFront) {
			transform.position = new Vector3 (
				start,
				transform.position.y,
				transform.position.z
			);
		} else {
			transform.position = new Vector3 (
				end,
				transform.position.y,
				transform.position.z
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (
			transform.position.x + update * Time.deltaTime,
			transform.position.y,
			transform.position.z
		);

		if (transform.position.x > end) {
			update = -update;
			transform.position = new Vector3 (
				end,
				transform.position.y,
				transform.position.z
			);
		} else if (transform.position.x < start) {
			update = -update;
			transform.position = new Vector3 (
				start,
				transform.position.y,
				transform.position.z
			);
		}
	}
}
