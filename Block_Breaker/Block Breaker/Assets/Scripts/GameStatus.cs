using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{

    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 1;

    [SerializeField] int currentScore = 0;
    [SerializeField] Text score;

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        score.text = currentScore.ToString();
    }

    public void AddToScore() {
        currentScore += pointsPerBlockDestroyed;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = currentScore.ToString();
        Time.timeScale = gameSpeed;
    }

    public void Reset() {
        Destroy(gameObject);
    }
}
