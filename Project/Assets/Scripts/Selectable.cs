using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

	public float speedMultiplier = 5f;
	public bool clicked = false;
	Vector3 target = new Vector3(1,1,1);

	// Use this for initialization
	void Start () {
		
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

		target = new Vector3 (1.1f, 1.1f, 1.1f);

	}

	void OnMouseExit () {

		target = new Vector3 (1f, 1f, 1f);

	}

	void OnMouseDown () {

		clicked = true;

	}
}
