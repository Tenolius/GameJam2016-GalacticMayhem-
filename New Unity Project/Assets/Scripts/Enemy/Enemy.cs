using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Vector3 endPoint;
	Vector3 startPoint;
	float startTime;
	float duration;
	float moveSpeed;
	private int damage;
	private bool movingForward;
	private int health;
	private object _lock;


	// Use this for initialization
	void Start () {
		endPoint = new Vector3 (-70,5,0);
		moveSpeed = 5.0f;
		duration = 10.0f;
		startPoint = transform.position;
		startTime = Time.time;
		movingForward = true;
		health = 300;
		damage = 5;
		_lock = new object ();

	}
	
	// Update is called once per frame
	void Update () {

		if (movingForward) {
			//transform.position = Vector3.Lerp (startPoint, endPoint, (Time.time - startTime) / duration);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Collided with something");
		if (other.gameObject.tag == "Turret") {
			Debug.Log ("Collided with Turret");

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
