using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public void PlaxGame(){
		this.GetComponent<AudioSource>().Play();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	public void QuitGame(){
		this.GetComponent<AudioSource>().Play();
		Application.Quit();
	}
}
