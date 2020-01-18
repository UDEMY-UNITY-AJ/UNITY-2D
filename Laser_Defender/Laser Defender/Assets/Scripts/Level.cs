using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadStartScene() {
        SceneManager.LoadScene(0);
    }

    public void LoadGame() {
        SceneManager.LoadScene(1);
    }

    public void LoadGameOverScene() {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
