using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

	public float speedMultiplier = 5f;
	public bool clicked = false;
	public bool correct = false;
	Vector3 target = new Vector3(1,1,1);
	Vector3 OriginalScale;

	// Use this for initialization
	void Start () {
		OriginalScale = gameObject.transform.localScale;
		target = OriginalScale;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.localScale = new Vector3 (
			Mathf.Lerp (gameObject.transform.localScale.x, target.x, Time.deltaTime*speedMultiplier),
			Mathf.Lerp (gameObject.transform.localScale.y, target.y, Time.deltaTime*speedMultiplier),
			Mathf.Lerp (gameObject.transform.localScale.z, target.z, Time.deltaTime*speedMultiplier)
		);
	}

	void OnMouseEnter () {

		target = OriginalScale + new Vector3 (0.1f, 0.1f, 0.1f);

	}

	void OnMouseExit () {

		target = OriginalScale;

	}

	void OnMouseDown () {

		clicked = true;

	}
}
