using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour {

	public Color[] Colors = null;

	public GameObject SelectableCube = null;

	public float Spaceing = 0.3f;

	public int Size = 3;

	public float Scale = 2f;

	public float RandomAmmount = 0.3f;

	public GameObject LevelHandler = null;

    public GameObject Timer = null;

    public bool Started = false;

    public bool RandomRotation = true;

	public enum ClickedState{
		Win,
		Fail,
		Nutral,
	}

	GameObject[] Objects = null;

	// Use this for initialization
	void Start () {

		System.Array.Resize<GameObject> (ref Objects, Size*Size);
	}
	
	// Update is called once per frame
	void Update () {
        if (Started)
        {
            ClickedState Result = CheckCubes();
            if (Result == ClickedState.Win)
            {
                //Debug.Log("Correct");

                ++LevelHandler.GetComponent<LevelHandler>().Level;

                DeleteCubes();
                GenerateCubes();
            }
            else if (Result == ClickedState.Fail)
            {
                //Debug.Log("Incorrect");

                if (LevelHandler.GetComponent<LevelHandler>().Level > 0)
                    --LevelHandler.GetComponent<LevelHandler>().Level;

                DeleteCubes();
                GenerateCubes();
            }
        }
	}

	public void GenerateCubes () {
		Color color = Colors [Random.Range (0, Colors.Length - 1)];
		for (int i = 0; i < Size; ++i) {
			for (int l = 0; l < Size; ++l) {

				Objects [i + Size * l] = (GameObject)Instantiate (SelectableCube, gameObject.transform.position + new Vector3 ((i - Size/2)*(Spaceing + Scale),0,(l - Size/2)*(Spaceing + Scale)), gameObject.transform.rotation);
				Objects [i + Size * l].transform.localScale = new Vector3(Scale, 1, Scale);
				Objects [i + Size * l].GetComponent<Renderer>().material.color = color;
                if (RandomRotation)
                {
                    Objects[i + Size * l].transform.localRotation = Random.rotation;
                }


			}
		}

		int CorrectIndex = Random.Range (0, Objects.Length - 1);
		Objects [CorrectIndex].GetComponent<Selectable> ().correct = true;
		Color newColor = Objects [CorrectIndex].GetComponent<Renderer> ().material.color;
		float rand = Random.Range (RandomAmmount / 2, RandomAmmount);
		if (randomBool()) {
			newColor += new Color(rand, rand, rand);
		} else {
			newColor += new Color(-rand, -rand, -rand);
		}

		Objects [CorrectIndex].GetComponent<Renderer> ().material.color = newColor;

	}

	public void DeleteCubes () {

		for (int i = 0; i < Objects.Length; ++i) {

			Destroy (Objects [i]);
			Objects [i] = null;

		}

	}

	public ClickedState CheckCubes () {
		var result = ClickedState.Nutral;
		for (int i = 0; i < Objects.Length; ++i) {

			if (Objects [i].GetComponent<Selectable> ().clicked) {
				Objects [i].GetComponent<Selectable> ().clicked = false;
				if (Objects [i].GetComponent<Selectable> ().correct) {

					result = ClickedState.Win;
					Objects [i].GetComponent<Selectable> ().correct = false;

				} else {
					result = ClickedState.Fail;
				}

			}

		}
		return result;

	}

	bool randomBool () {

		if (Random.value >= 0.5) {
			return true;
		}
		return false;
	}
}
