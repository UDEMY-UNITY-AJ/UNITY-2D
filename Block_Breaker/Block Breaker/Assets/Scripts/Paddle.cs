using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16;
    float mousePosInUnits;
    [SerializeField]  float min_x = 1f;
    [SerializeField]  float max_x = 15f;

    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        mousePos = new Vector2(0, 0.25f);
    }

    // Update is called once per frame
    void Update() {
        mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        mousePos.x = Mathf.Clamp(mousePosInUnits, min_x, max_x);
        transform.position = mousePos;
    }
}
