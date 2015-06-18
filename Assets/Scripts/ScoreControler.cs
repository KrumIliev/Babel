using UnityEngine;
using System.Collections;

public class ScoreControler : MonoBehaviour {

	public int score = 0;

	void OnGUI() {
		GUI.color = Color.black;
		GUI.Label (new Rect (0, 0, 100, 50), "Score: " + score);
	}
}
