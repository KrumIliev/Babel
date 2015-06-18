using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public GameObject[] elements;
	public float fireDelay = 3f;
	public float nextFire = 1f;
	public float fireVelocity = 10f;

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		if (GameObject.FindObjectOfType<DeadTrigger> ().hasLost) return;

		nextFire -= Time.deltaTime;

		if (nextFire <= 0) {
			nextFire = fireDelay;

			GameObject element = (GameObject) Instantiate(elements[Random.Range(0, elements.Length)], transform.position, transform.rotation);
			element.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (0, fireVelocity);	

			GameObject.FindObjectOfType<ScoreControler>().score++;
		}
	}
}
