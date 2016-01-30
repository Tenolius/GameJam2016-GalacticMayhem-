using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// spawn enemies
		GameObject enemy1 = Instantiate(Resources.Load("Enemy")) as GameObject;
		//enemy1.
		enemy1.transform.position = new Vector3(22, -7, 13);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
