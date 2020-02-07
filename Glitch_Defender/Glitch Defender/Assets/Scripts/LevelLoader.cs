using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float splashToStartTime = 3f;
    int currentSceneIndex;
    

    private void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene();
    }

    public void RestartScene() {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void LoadScene() {
        if (currentSceneIndex == 0) {
            StartCoroutine(WaitAndLoadScene(1));
        }
    }

    IEnumerator WaitAndLoadScene(int index) {
        yield return new WaitForSeconds(splashToStartTime);
        SceneManager.LoadScene(index);
    }

    public void LoadYouLose() {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitGame() {
        Application.Quit();
    }


}
