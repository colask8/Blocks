using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	private int timesHit;
	public static int breakableCount = 0; 
	private int maxHits;
	private Vector3 startPosition;
	private bool upDirection = true;


	public GameObject smoke;
	public float floatOffset = 0f;
	public float floatingSpeed = 0f;
	public AudioClip crackSound;
	public Sprite[] hitSprites;


	LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit=0;
		startPosition = this.transform.position;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		maxHits = hitSprites.Length + 1;
		if (isBreakable()) breakableCount++;

		ParticleSystem.MainModule main = smoke.GetComponent<ParticleSystem>().main;
		main.startColor = this.gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
		if (floatOffset > 0) {
			floatBrick();
		}
	}

	public bool isBreakable() {
		return this.gameObject.tag == "Breakable";
	}
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}

		void floatBrick() {
		Vector3 offset = new Vector3 (this.transform.position.x, startPosition.y + (upDirection ?  floatOffset : (-1) * floatOffset), startPosition.z);
		// print ("offset" + offset.y);
		if (offset == this.transform.position) {
			upDirection = !upDirection;
		}
		// Vector3 cu
		// float speed = Time.deltaTime * floatingSpeed;
		float directionAndSpeed =  (upDirection ? 1 : (-1)) * Time.deltaTime * floatingSpeed;
		this.transform.position = new Vector3(
			this.transform.position.x,
			Mathf.Clamp(this.transform.position.y + directionAndSpeed , startPosition.y - floatOffset, startPosition.y + floatOffset),
			this.transform.position.z
		);
	}

	void HandleHits() {
		timesHit++;
		if (maxHits <= timesHit) {
			breakableCount--;
			Object.Destroy(this.gameObject);
			Object.Instantiate(smoke, this.transform.position, Quaternion.identity);
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		AudioSource.PlayClipAtPoint (crackSound, transform.position);
		if (isBreakable()) {
			HandleHits();
		}
	}
}
