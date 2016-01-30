using UnityEngine;
using System.Collections;

public class ClickDetection : MonoBehaviour {
    private int planeLength;
    private string planeChars;

    public GridObject gridObjectScript;
    //public GameObject highlightCube;

    void OnMouseDown(){
        SendPlaneNum();
        //Instantiate(highlightCube, new Vector3(-10.48861f, 8.014994f, -21.68f), Quaternion.identity);
        //Debug.Log("x: "+ gameObject.transform.position.x + ", y: " + gameObject.transform.position.y + ", z: "+ gameObject.transform.position.z);
        gridObjectScript.hCubeCoordinates = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y +3, gameObject.transform.position.z);
    }

    void OnMouseOver(){
        Debug.Log("Mouse Over: " + gameObject.transform.position);
    }

    void SendPlaneNum(){
        string planeName = gameObject.name;
        string idString;
        if (planeName.Length == 6){
            idString = planeName.Substring(planeName.Length - 1);
        } else{
            idString = planeName.Substring(planeName.Length - 2);
        }

        int planeId = int.Parse(idString);
        ChangeGridColour(planeId);
    }

    void ChangeGridColour(int num){
        int planeLength = gridObjectScript.planeNum.Length;

        if(planeLength == 0){
            gridObjectScript.planeNum[0] = num;
        }
        if(planeLength == 1){
            gridObjectScript.planeNum[1] = num;
        }
        else{
            int prevGrid = gridObjectScript.planeNum[0];
            gridObjectScript.planeNum[0] = num;
            gridObjectScript.planeNum[1] = prevGrid;
        }
    }
}
