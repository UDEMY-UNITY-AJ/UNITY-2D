using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddleToBallVector;
    Vector2 paddlePos;

    Rigidbody2D myRigidbody2D;

    bool hasStarted;

    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position;
        paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (hasStarted == false) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(2f, 15f);
        }
    }

    private void LockBallToPaddle() {
        paddlePos.x = paddle1.transform.position.x;
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f,
            randomFactor), UnityEngine.Random.Range(0f, randomFactor));

        if (hasStarted) {
            GetComponent<AudioSource>().PlayOneShot(ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}
