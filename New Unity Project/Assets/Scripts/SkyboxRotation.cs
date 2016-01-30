using UnityEngine;
using System.Collections;

public class SkyboxRotation : MonoBehaviour {

    //public Skybox nebulaSky;
    public bool isRotating;
    public float speed;

    // Use this for initialization
	void Start () {
        speed = 0;
        isRotating = true;
        //nebulaSky = GetComponent<Skybox> ();
	}
	
	// Update is called once per frame
	void Update () {
        if(isRotating) {
            speed += 0.25f * Time.deltaTime;
            speed %= 360;
            //nebulaSky.material.SetFloat("_Rotation", speed);
            RenderSettings.skybox.SetFloat("_Rotation", speed);
        }
	}
}
