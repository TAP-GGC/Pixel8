using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class DrawWithMouse : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 prevPosition;

    public float minDist;


    public String red;
    public String green;
    public String blue;
    


    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        prevPosition = transform.position;   
        
    }

    // Update is called once per frame
    void Update()
    {
        colorCheck();
        if(Input.GetMouseButton(0)){
            
            Vector3 currPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            currPosition.z = 0f;

            if(Vector3.Distance(currPosition,prevPosition) > minDist){

                if(prevPosition == transform.position){
                    line.SetPosition(0,currPosition);
                }
                else{
                    line.positionCount++;
                    line.SetPosition(line.positionCount-1, currPosition);
                }
                
                prevPosition =currPosition;
            }
        }

        
    }

    public void colorCheck(){

        if (IsBinaryString(red) && IsBinaryString(green) && IsBinaryString(blue)){

        int numred = Convert.ToInt32(red, 2);
        int numgreen = Convert.ToInt32(green, 2);
        int numblue = Convert.ToInt32(blue, 2);

        float redValue = numred / 255f;
        float greenValue = numgreen / 255f;
        float blueValue = numblue / 255f;

        line.startColor = new Color(redValue, greenValue, blueValue, line.startColor.a);
        line.endColor = new Color(redValue, greenValue, blueValue, line.endColor.a);
        }

        else{

            Debug.LogError("Invalid binary string! Use only '1's and '0's.");
        }
    }
    public bool IsBinaryString(string value){
        return Regex.IsMatch(value, "^[01]+$");
    }
}