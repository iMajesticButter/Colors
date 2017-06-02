using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour {

	public Color[] Colors = null;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = Colors[Random.Range(0, Colors.Length - 1)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
