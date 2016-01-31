using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject spawnLocation1;
	public GameObject spawnLocation2;
	public GameObject spawnLocation3;
	public GameObject spawnLocation4;

	public Vector3 position1;
	public Vector3 position2;
	public Vector3 position3;
	public Vector3 position4;


	public float spawnTime = 5.0f;
	public GameObject enemy;


	// Use this for initialization
	void Start () {
		position1 = spawnLocation1.gameObject.transform.position;
		position2 = spawnLocation2.gameObject.transform.position;
		position3 = spawnLocation3.gameObject.transform.position;
		position4 = spawnLocation4.gameObject.transform.position;

		float y = 4.2f;
		position1 [1] = y;
		position2 [1] = y;
		position3 [1] = y;
		position4 [1] = y;

		position1 [2] = 9.0f;
		position2 [2] = -6.0f;
		position3 [2] = -21.0f;
		position4 [2] = -38.0f;

		float min = 5.0f;
		float max = 10.0f;
		float spawnTime1 = Random.Range (min, max);
		float spawnTime2 = Random.Range (min, max);
		float spawnTime3 = Random.Range (min, max);
		float spawnTime4 = Random.Range (min, max);


		InvokeRepeating ("SpawnPosition1", spawnTime1, spawnTime1);
		InvokeRepeating ("SpawnPosition2", spawnTime2, spawnTime2);
		InvokeRepeating ("SpawnPosition3", spawnTime3, spawnTime3);
		InvokeRepeating ("SpawnPosition4", spawnTime1, spawnTime4);



	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void SpawnPosition1() {
		Instantiate (enemy, position1, enemy.gameObject.transform.rotation);
	}

	void SpawnPosition2() {
		Instantiate (enemy, position2, enemy.gameObject.transform.rotation);
	}

	void SpawnPosition3() {
		Instantiate (enemy, position3, enemy.gameObject.transform.rotation);
	}

	void SpawnPosition4() {
		Instantiate (enemy, position4, enemy.gameObject.transform.rotation);
	}
}
