using UnityEngine;
using System.Collections;

public class ClickDetection : MonoBehaviour {
    private int planeLength;
    private string planeChars;

    public GridObject gridObjectScript;
    //public GameObject highlightCube;

    void OnMouseDown(){
        SendPlaneNum(gridObjectScript.planeNum);
        //Instantiate(highlightCube, new Vector3(-10.48861f, 8.014994f, -21.68f), Quaternion.identity);
        //Debug.Log("x: "+ gameObject.transform.position.x + ", y: " + gameObject.transform.position.y + ", z: "+ gameObject.transform.position.z);
        gridObjectScript.SwitchColour(gridObjectScript.planeNum, gridObjectScript.textureDiffuseSelect, gridObjectScript.textureEmissionSelect, gridObjectScript.textureDiffuseUnselect, gridObjectScript.textureEmissionUnselect);
        //gridObjectScript.MoveHighlightCube();
        gridObjectScript.hCube.transform.position = gameObject.transform.position;
        gridObjectScript.hCubeCoordinates = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y +3, gameObject.transform.position.z);
    }

    void OnMouseOver(){
        //SendPlaneNum(gridObjectScript.planeOver);
        Debug.Log("Mouse Over: " + gameObject.transform.position);
        gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", gridObjectScript.textureDiffuseOver);
        gameObject.GetComponent<Renderer>().material.SetTexture("_Emission", gridObjectScript.textureEmissionOver);
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", gridObjectScript.textureDiffuseUnselect);
        gameObject.GetComponent<Renderer>().material.SetTexture("_Emission", gridObjectScript.textureEmissionUnselect);
    }

    void SendPlaneNum(int[] planes){
        string name = gameObject.name;
        string idString;
        if (name.Length == 6){
            idString = name.Substring(name.Length - 1);
        } else{
            idString = name.Substring(name.Length - 2);
        }

        int planeId = int.Parse(idString);
        ChangeGridColour(planeId,planes);
    }

    void ChangeGridColour(int num,int[] planeGrid){
        int planeLength = planeGrid.Length;

        if(planeLength == 0){
            planeGrid[0] = num;
        }
        if(planeLength == 1){
            planeGrid[1] = num;
        }
        else{
            int prevGrid = planeGrid[0];
            planeGrid[0] = num;
            planeGrid[1] = prevGrid;
        }
    }
}
