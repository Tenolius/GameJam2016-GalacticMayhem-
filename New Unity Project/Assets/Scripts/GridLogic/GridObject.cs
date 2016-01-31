using UnityEngine;
using System.Collections;

public class GridObject : MonoBehaviour {
    public Texture textureDiffuseSelect;
    public Texture textureEmissionSelect;

    public Texture textureDiffuseUnselect;
    public Texture textureEmissionUnselect;

    public Texture textureDiffuseOver;
    public Texture textureEmissionOver;

    public ClickDetection[] clickDetectionPanels;
    public GameObject hCube;

    public Vector3 hCubeCoordinates;

    public int[] planeNum;
    public int[] planeOver;

	// Use this for initialization
	void Start () {
        for(int i=0; i < clickDetectionPanels.Length; i++){
            clickDetectionPanels[i].gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textureDiffuseUnselect);
            clickDetectionPanels[i].gameObject.GetComponent<Renderer>().material.SetTexture("_Emission", textureEmissionUnselect);
        }
        planeNum = new int[2];
        planeOver = new int[2];

        hCubeCoordinates = new Vector3(-10.48861f, -4.75f, -21.68f);
        hCube = Instantiate(Resources.Load("HighlightCube")) as GameObject;
        hCube.transform.position = hCubeCoordinates;
    }
	
	// Update is called once per frame
	void Update () {
        //SwitchColour(planeNum,textureDiffuseSelect,textureEmissionSelect,textureDiffuseUnselect,textureEmissionUnselect);
        //SwitchColour(planeOver,textureEmissionOver,textureEmissionOver,textureDiffuseUnselect,textureEmissionUnselect);
        //MoveHighlightCube();
        //Debug.Log(gridCoordinates);
	}

    public void SwitchColour(int[] plane, Texture currentDiffuse, Texture currentEmission, Texture prevDiffuse, Texture prevEmission){
        /*if (plane.Length == 1){
            clickDetectionPanels[plane[0]].gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", currentDiffuse);
            clickDetectionPanels[plane[0]].gameObject.GetComponent<Renderer>().material.SetTexture("_Emission", currentEmission);
        } else {*/
            clickDetectionPanels[plane[0]].gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", currentDiffuse);
            clickDetectionPanels[plane[0]].gameObject.GetComponent<Renderer>().material.SetTexture("_Emission", currentEmission);
            clickDetectionPanels[plane[1]].gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", prevDiffuse);
            clickDetectionPanels[plane[1]].gameObject.GetComponent<Renderer>().material.SetTexture("_Emission", prevEmission);
        //}
        //Debug.Log("Name: " + clickDetectionPanels[cIndex].name + " id: "+ cIndex + ", previd: " + pIndex);
    }

    public void MoveHighlightCube(){
        hCube.transform.position = hCubeCoordinates;
    }
}
