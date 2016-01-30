using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	private int health = 200;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			Debug.Log ("Enemy attacking turret");
		}
	}


	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			Enemy script = other.GetComponent<Enemy> ();
			int damage = script.getDamage ();

			if (health <= 0) {
				Destroy (gameObject);
				script.resumeMovement ();
			} else {
				health -= damage;
			}
		}
	}

	void OnParticleCollision(GameObject other) {
		if (other.tag == "Enemy") {
			Debug.Log ("Shot enemy");
		}
	}






}
