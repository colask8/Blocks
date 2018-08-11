using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Brick.breakableCount = 0;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
	
    public void LoadStartScene() {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(0);
    }

    public void LoadScene(string sceneName) {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(sceneName);
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void BrickDestroyed() {
        print(Brick.breakableCount);
        if (Brick.breakableCount <= 0) {
            LoadNextScene();
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
