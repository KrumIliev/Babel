using UnityEngine;
using System.Collections;

public class MouseControler : MonoBehaviour {

	public LineRenderer dragLine;
	
	Rigidbody2D grabbedObject = null;

	float velocityRatio = 4f;
	bool useMouse = true;

	void Start () {
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android) {
			useMouse = false;
		} else {
			useMouse = true;
		}
	}

	void Update () {
		if (!useMouse) {
			if (Input.touchCount > 0) {
				Touch touch = Input.touches [0];

				if (touch.phase == TouchPhase.Began) grabObject(Camera.main.ScreenToWorldPoint(touch.position));

				if (touch.phase == TouchPhase.Ended) releceObject();
			}

		} else {
			if (Input.GetMouseButtonDown (0)) grabObject(Camera.main.ScreenToWorldPoint(Input.mousePosition));

			if(Input.GetMouseButtonUp(0)) releceObject();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) Application.Quit ();
	}

	private void grabObject (Vector3 worldPosition) {
		Vector2 screenPosition = new Vector2(worldPosition.x, worldPosition.y);
		Vector2 dir = Vector2.zero;
		
		RaycastHit2D hit = Physics2D.Raycast(screenPosition, dir);
		if(hit.collider != null && hit.collider.GetComponent<Rigidbody2D>() != null) {
			grabbedObject = hit.collider.GetComponent<Rigidbody2D>();
			grabbedObject.gravityScale = 0;
			dragLine.enabled = true;
		}
	}
	
	private void releceObject () {
		if (grabbedObject != null) {
			grabbedObject.gravityScale = 1;
			grabbedObject = null;
			dragLine.enabled = false;
		}
	}

	void FixedUpdate () {
		if(grabbedObject != null) {
			Vector2 mouseWorldPos2D;
			if (useMouse) {
				mouseWorldPos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			} else {
				mouseWorldPos2D = Camera.main.ScreenToWorldPoint(Input.touches [0].position);
			}
			grabbedObject.velocity = (mouseWorldPos2D - grabbedObject.position) * velocityRatio;
		}
	}
	
	void LateUpdate() {
		if(grabbedObject != null) {
			Vector3 mouseWorldPos3D;
			if (useMouse) {
				mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			} else {
				mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.touches [0].position);
			}
			dragLine.SetPosition(0, new Vector3(grabbedObject.position.x, grabbedObject.position.y, -1));
			dragLine.SetPosition(1, new Vector3(mouseWorldPos3D.x, mouseWorldPos3D.y, -1));
		}
	}
}
