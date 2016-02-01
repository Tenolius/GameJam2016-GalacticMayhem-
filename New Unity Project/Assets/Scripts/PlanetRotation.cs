using UnityEngine;
using System.Collections;

public class PlanetRotation : MonoBehaviour {
    public float RotationSpeed = 2.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RotatePlanet();
	}

    void RotatePlanet(){
        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }
}
