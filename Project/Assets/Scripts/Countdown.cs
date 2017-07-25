using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    float timer = 5;

    public GameObject ColorManager = null;
    bool Finnished = false;
    bool Hit3 = false;
    bool Hit2 = false;
    bool Hit1 = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if      (timer <= 0 && !Finnished)
        {
            StopAllCoroutines();
            StartCoroutine(SendTextFade("GO!", new Color(0.3f, 1, 0.3f, 1)));
            RandomizeColor CM = ColorManager.GetComponent<RandomizeColor>();
            CM.GenerateCubes();
            CM.Timer.GetComponent<TimerText>().started = true;
            CM.Started = true;
            Finnished = true;
        }
        else if (timer <= 1 && !Hit1)
        {
            StopAllCoroutines();
            StartCoroutine(SendTextFade("1", new Color(0.6f, 0.7f, 0.3f, 1)));
            Hit1 = true;
        }
        else if (timer <= 2 && !Hit2)
        {
            StopAllCoroutines();
            StartCoroutine(SendTextFade("2", new Color(0.8f, 0.5f, 0.3f, 1)));
            Hit2 = true;
        }
        else if (timer <= 3 && !Hit3)
        {
            StopAllCoroutines();
            StartCoroutine(SendTextFade("3", new Color(1, 0.3f, 0.3f, 1)));
            Hit3 = true;
        }
        else if (!Hit3)
        {
            gameObject.GetComponent<Text>().text = "";
        }
        timer -= Time.deltaTime;
    }

    IEnumerator SendTextFade(string text, Color color)
    {
        Text textComp = gameObject.GetComponent<Text>();
        RectTransform Transform = gameObject.GetComponent<RectTransform>();
        textComp.text = text;
        textComp.color = color;
        for (float i = 1; i > 0; i -= Time.deltaTime)
        {
            transform.localScale = new Vector3(i,i,1);
            textComp.color = new Color(textComp.color.r, textComp.color.g, textComp.color.b, i);
            yield return null;
        }
        
    }

}
