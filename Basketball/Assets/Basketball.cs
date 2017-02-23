﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour {

	public bool hitSomething = false;
	public bool gotRightTarget = false;

	public int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider collider) {
		if (hitSomething == false) {
			if (collider.tag == "BasketballTarget") {
				hitSomething = true;
				gotRightTarget = true;
				score++;
			} else if (collider.tag == "Floor") {
				hitSomething = true;
				gotRightTarget = false;
			}
		}
	}
}
