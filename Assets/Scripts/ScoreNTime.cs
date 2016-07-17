using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreNTime : MonoBehaviour {
	public Image Units;
	public Image ScoreTens;
	public Image ScoreUnits;
	public Sprite[] Sprites;
	public GameObject GameOverCam;
	public GameObject Canvas;
	public GameObject MainCam;
	public Text CurrentScore;
	public Text HighScore;
	public bool EndGameScene=false;
	void Start () {
		UpdateScore (PlayerPrefs.GetInt ("CurrentScore"));
	}
	
	void Update(){
		

		if(EndGameScene==false){
			UpdateTimeDisplay (Time.timeSinceLevelLoad);

		if (Time.timeSinceLevelLoad>4){
			int s = 5 + (PlayerPrefs.GetInt ("CurrentScore")/10);
			if (Time.timeSinceLevelLoad > s) {
				LoadGameover ();
			}
		}
	}
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
		EndGameScene = true;
		GameOverScore ();
		Canvas.SetActive (false);
		GameOverCam.SetActive (true);
		MainCam.SetActive (false);
	
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

public void GameOverScore(){
		int s;
		s= PlayerPrefs.GetInt ("CurrentScore");
		CurrentScore.text = s.ToString ();

		if(s > PlayerPrefs.GetInt("ḦighScore")){

			PlayerPrefs.SetInt ("HighScore", s);
				
		}

				HighScore.text=PlayerPrefs.GetInt("HighScore").ToString();
		PlayerPrefs.SetInt("CurrentScore",0);

	}



}	

