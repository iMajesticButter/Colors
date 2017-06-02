using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour {
	public GameObject colorManager = null;
	public int MaxLevels = 50;
	public int Level = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Level >= MaxLevels) {
			Debug.Log ("win");
			Application.Quit ();
		}
		gameObject.GetComponent<Text> ().text = "Level: "+Level+"/"+MaxLevels;
	}
}
