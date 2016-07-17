using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SCRIPT : MonoBehaviour {
	public Sprite[] Bgimages;
	void Start () {
		
		gameObject.GetComponent<Image> ().sprite = Bgimages [Random.Range (0, 6)];
	}
	
	public void RestartScene(){

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}
}
