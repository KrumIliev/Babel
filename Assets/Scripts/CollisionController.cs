using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

	void OnCollisionEnter2D () {
		if (Camera.main.transform.position.y < transform.position.y) {
			Camera.main.GetComponent<CameraMover>().cannonY = transform.position.y - Camera.main.transform.position.y;
			Camera.main.GetComponent<CameraMover>().targerY = transform.position.y;
		}
	}
}
