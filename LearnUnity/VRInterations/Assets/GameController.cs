using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public TextMesh infoText; 
	public Player player;
	public Transform enermiesContainer;

	private float restartTimer = 3f;

	// Use this for initialization
	void Start () {
		infoText.text = "Find the button\nand enter the castld!";

	}
	
	// Update is called once per frame
	void Update () {
		if (player.enteredCastle) {
			int enermiesRemaining = enermiesContainer.GetComponentsInChildren<Enermy> ().Length;

			if (enermiesRemaining > 0) {

				infoText.text = "Destroy all enermies.";
				infoText.text += "\nEnermies remaining: " + enermiesRemaining;
			} else {
				infoText.text = "You win!";
				restartTimer -= Time.deltaTime;
				if (restartTimer <= 0) {
					SceneManager.LoadScene (SceneManager.GetActiveScene().name);
				}
			}
		}
	}
}
