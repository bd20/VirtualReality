using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public TextMesh frontScoreText;
	public TextMesh backScoreText;
	public Basketball basketball;
	public Player player;
	public GameObject shootingTarget;

	private int previousScore;


	private float basketballTimer = 0f;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (previousScore != basketball.score) {
			float distance = calculateDistance ();

			Debug.Log (distance);

			if (distance < 190f) {
				basketball.score += 1;
			} else {
				basketball.score += 2;
			}
		}

		frontScoreText.text = "" + basketball.score;
		backScoreText.text = "" + basketball.score;

		if (basketball.hitSomething && basketballTimer == 0f) {
			basketballTimer = 1f;
		}

		//Debug.Log (basketballTimer);
		//Debug.Log (basketball.hitSomething);

		if (basketballTimer > 0f) {
			basketballTimer -= Time.deltaTime;
			if (basketballTimer <= 0f) {
				player.PickBasketball ();
				basketballTimer = 0f;
			}
		}

		previousScore = basketball.score;
	}

	float calculateDistance() {
		float dx = basketball.transform.position.x - player.transform.position.x;
		Debug.Log ("dx" + dx);
		float dz = basketball.transform.position.z - player.transform.position.z;
		Debug.Log ("dz" + dz);
		return dx * dx + dz * dz;
	}
}
