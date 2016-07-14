using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerHandle : MonoBehaviour {
	public GameObject[] Buttons;
	private int[] Answers=new int [4];


	void Start () {
	 	Answers[0] = QuestionHandle.Answer;
		Answers[1] = Answers[0]+ Random.Range (-3, -2);
		Answers[2] = Answers[0] + Random.Range (5, 11);
		Answers[3] = Answers[0] + Random.Range (1, 3);

		int shft = Random.Range (0, 4);
		for (int i = 0; i <= 3; i++) {
			Text Answerfield = Buttons [i].GetComponent<Text> ();
			Answerfield.text = Answers [RandomOptions(i,shft)].ToString ();
		}

	}

	public int RandomOptions(int n,int shift){
		int s = n + shift;
		if (s <= 3) {

			return s;
		} else {
			return s - 4;
		}
	}
}
