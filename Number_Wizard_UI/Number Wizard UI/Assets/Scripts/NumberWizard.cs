using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

    [SerializeField] int max;
    [SerializeField]  int min;
    [SerializeField] Text guessText;
    int guess;

    // Use this for initialization
    void Start() {
        StartGame();
    }

    void StartGame() {
        NextGuess();
        max += 1;
    }


    public void OnPressHigher() {
        min = guess;
        NextGuess();
    }

    public void OnPressLower() {
        max = guess;
        NextGuess();
    }

    
    void NextGuess() {
        guess = (max + min) / 2;
        guessText.text = guess.ToString();
    }
}
