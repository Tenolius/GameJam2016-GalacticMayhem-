using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Vector3 endPoint;
	Vector3 startPoint;
	float startTime;
	float duration;
	float moveSpeed;
	private int damage = 5;
	private bool movingForward;
	private int health;
	private object _lock;


	// Use this for initialization
	void Start () {
		endPoint = new Vector3 (-70,5,0);
		moveSpeed = 10.0f;
		duration = 10.0f;
		startPoint = transform.position;
		startTime = Time.time;
		movingForward = true;
		health = 100;
		_lock = new object ();

		//transform.position = Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (movingForward) {
			//transform.position = Vector3.Lerp (startPoint, endPoint, (Time.time - startTime) / duration);
			transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Turret") {
			movingForward = false;
		}

	}


	public int getDamage() {
		return damage;
	}

	public void resumeMovement() {
		movingForward = true;
	}

	public void hit(int damage) {
		lock (_lock) {
			health -= damage;
			Debug.Log (health);
			if (health <= 0) {
				Destroy (gameObject);
			}
		}
	}


}
