using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 0;
    Text starText;

    // Start is called before the first frame update
    void Start() {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void Update() {
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount) {
        stars += amount;
    }

    public bool HaveEnoughStars(int amount) {
        if (amount <= stars) {
            return true;
        }
        return false;
    }

    public void SpendStars(int amount) {
        if (stars >= amount) {
            stars -= amount;
        }
    }
}
