using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	private void OnTriggerEnter2D(Collider2D collision)
	{
	print("Trigger" + collision.ToString());
	levelManager.LoadScene("Lose_Screen");
	}

	private void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
	print("Collision");
	}
}
