using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGameStartScne : MonoBehaviour {


	public void GameLoad(){
		PlayerPrefs.SetInt ("CurrentScore", 0);
		SceneManager.LoadScene ("MainS");

	}

}
