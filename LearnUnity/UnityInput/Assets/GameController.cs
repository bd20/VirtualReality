using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] gameCameras;

	private int gameCameraIndex = 0;

	// Use this for initialization
	void Start () {
		FocusOnCamera (gameCameraIndex);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Input.GetMouseButtonDown (0));
		if (Input.GetMouseButtonDown (0)) {
			ChangeCamera (1);
		}
	}

	void FocusOnCamera (int index) {
		for (int i = 0; i < gameCameras.Length; i++) {
			gameCameras [i].SetActive (i == index);
		}
	}

	void ChangeCamera (int direction) {
		gameCameraIndex += direction;

		if (gameCameraIndex >= gameCameras.Length) {
			gameCameraIndex = 0;
		}

		FocusOnCamera (gameCameraIndex);
	}
}
