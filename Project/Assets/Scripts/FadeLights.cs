using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLights : MonoBehaviour {

	public Color[] Colors = null;
	public float FadeSpeedMultiplier = 1.5f;
	int index = 0;
	Vector3 target = new Vector3(1,1,1);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		target = new Vector3 (Colors [index].r, Colors [index].g, Colors [index].b);
		gameObject.GetComponent<Light> ().color = new Color (
			Mathf.Lerp(gameObject.GetComponent<Light> ().color.r, target.x, Time.deltaTime*this.FadeSpeedMultiplier),
			Mathf.Lerp(gameObject.GetComponent<Light> ().color.g, target.y, Time.deltaTime*this.FadeSpeedMultiplier),
			Mathf.Lerp(gameObject.GetComponent<Light> ().color.b, target.z, Time.deltaTime*this.FadeSpeedMultiplier)
		);

		if (Vector3.Distance (new Vector3(gameObject.GetComponent<Light> ().color.r, gameObject.GetComponent<Light> ().color.g, gameObject.GetComponent<Light> ().color.b), target) <= 0.1) {

			if (index + 1 > Colors.Length - 1) {

				index = 0;

			} else {
				++index;
			}

		}

	}
}
