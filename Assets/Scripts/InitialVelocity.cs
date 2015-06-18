using UnityEngine;
using System.Collections;

public class InitialVelocity : MonoBehaviour {

	public Vector3 initVelocity;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = initVelocity;;
	}
}
