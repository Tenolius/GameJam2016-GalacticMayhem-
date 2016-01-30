using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	Vector3 endPoint;
	Vector3 startPoint;
	float startTime;
	float duration;
	float moveSpeed;

	// Use this for initialization
	void Start () {
		endPoint = new Vector3 (-45,5,0);
		moveSpeed = 10.0f;
		duration = 10.0f;
		startPoint = transform.position;
		startTime = Time.time;

		//transform.position = Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(startPoint, endPoint, (Time.time - startTime) / duration);
		//transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
	}
}
