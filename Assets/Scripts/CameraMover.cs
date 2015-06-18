using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	public GameObject leftCannon;
	public GameObject rightCannon;

	public float targerY = 0;
	public float cannonY = -3;
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.y = Mathf.Lerp (transform.position.y, targerY, 1f * Time.deltaTime);
		transform.position = position;
	}
}
