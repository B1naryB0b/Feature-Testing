using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	void Start () {
        Invoke("NextScene", 4f);
	}
	
    void NextScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(Mathf.Max(SceneManager.sceneCountInBuildSettings) - 1);
    }

}
