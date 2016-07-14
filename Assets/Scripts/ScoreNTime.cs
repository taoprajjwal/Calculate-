using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreNTime : MonoBehaviour {
	public Image Units;
	public Image ScoreTens;
	public Image ScoreUnits;
	public Sprite[] Sprites;

	void Start () {
		UpdateScore (PlayerPrefs.GetInt ("CurrentScore"));
	}
	
	void Update(){
		UpdateTimeDisplay (Time.timeSinceLevelLoad);
	}


	public void UpdateTimeDisplay(float Time){
		if (Time < 10)
			Units.sprite = Sprites [Mathf.FloorToInt (Time)];
		else {
			Units.sprite = Sprites [Mathf.FloorToInt (Time) % 10];
		}
				

	}
		

	public void CheckAnswer(Text ass2){
		if (ass2.text == QuestionHandle.Answer.ToString ()) {
			PlayerPrefs.SetInt ("CurrentScore", PlayerPrefs.GetInt("CurrentScore")+1);
			UpdateScore (PlayerPrefs.GetInt ("CurrentScore"));
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} else {
			LoadGameover ();
		}
	}	

	public void LoadGameover(){
		
		PlayerPrefs.SetInt("CurrentScore",0);
		//LoadOverScene
	
	}

	public void UpdateScore(int n){
		if (n < 10) {
			ScoreUnits.sprite = Sprites [n];
		} else {
			ScoreTens.gameObject.SetActive (true);
			ScoreTens.sprite = Sprites [n / 10];
			ScoreUnits.sprite = Sprites [n % 10];
		}
	}
}	

