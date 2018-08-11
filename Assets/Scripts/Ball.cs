using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	/*PRIVATES*/
	private Paddle paddle;
	private bool bStarted = false;
	private AudioSource audioPlay;
	private Vector3 paddleToBallVector;
	private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		// paddleToBallVector = this.transform.position - paddle.transform.position;
		audioPlay = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
		// Vector3 offset = new Vector3(paddleToBallVector.x, paddleToBallVector.y + 0.5f, paddleToBallVector.z);
	}
	



	// Update is called once per frame
	void Update () {
		if (!bStarted) {
			this.transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + 0.5f, 0f);

			if (Input.GetMouseButtonDown(0)) {
				bStarted = true;
				rb.gravityScale = 1;
				rb.velocity = new Vector2(0f, 15f);

			}
		}		
	}

	void OnCollisionEnter2D(Collision2D col) {
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f,0.2f));
		if (bStarted) {
			audioPlay.Play();
			
			rb.velocity += tweak;
		}
	}
}
