using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour {

    public float Timer = 120;
    public bool started = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Timer <= 0.1)
        {
            Debug.Log("Fail!");
            gameObject.GetComponent<Text>().text = "Time Left: 00:00";
            Application.Quit();
        }
        else if(started)
        {
            Timer -= Time.deltaTime;
        }
        int Min = Mathf.RoundToInt(Mathf.Floor(Timer / 60));
        int Sec = Mathf.RoundToInt(Timer % 60);
        if (Sec == 60)
        {
            Sec = 0;
            Min += 1;
        }

        gameObject.GetComponent<Text>().text = "Time Left: " + Min.ToString("00") + ":" + Sec.ToString("00");
    }
}
