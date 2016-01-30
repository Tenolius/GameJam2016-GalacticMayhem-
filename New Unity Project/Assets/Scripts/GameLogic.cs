using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
    //public GameObject highlightCube;

	// Use this for initialization
	void Start () {
        //Initialize grid highlight cube
        //Instantiate(highlightCube,new Vector3(-10.48861f, 8.014994f, -21.68f),Quaternion.identity);

		//Spawn enemies
		GameObject enemy1 = Instantiate(Resources.Load("Enemy")) as GameObject;
		enemy1.transform.position = new Vector3(22, -7, 13);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
