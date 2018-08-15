using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearWalls : MonoBehaviour {


    float currentAngle;

	void Start () {

	}
	
	void Update () {
        
        float currentRotation = transform.rotation.eulerAngles.y;


        if (currentRotation > 91.0f && currentRotation <= 135.0f)
        {
            currentAngle = 1 - (currentRotation - 90.0f) / (135.0f - 90.0f);
            transform.localScale = new Vector3(currentAngle, currentAngle, currentAngle);
        }

        if(currentRotation <= 91.0f || currentRotation >= 359.0f)
        {
            transform.localScale = Vector3.one;
        }

        if(currentRotation < 359.0f && currentRotation >= 315.0f)
        {
            currentAngle = (currentRotation - 315.0f) / (359.0f - 315.0f);
            transform.localScale = new Vector3(currentAngle, currentAngle, currentAngle);
        }

        if(currentRotation > 135.0f && currentRotation < 315.0f)
        {
            transform.localScale = new Vector3(float.Epsilon, float.Epsilon, float.Epsilon);
        }

        if(gameObject.tag == ("Corner Wall") && currentRotation + 91.0f > 90.0f && currentRotation + 91.0f <= 135.0f)
        {
            currentAngle = 1 - (currentRotation + 90.1f - 90.0f) / (135.0f - 90.0f);
            transform.localScale = new Vector3(currentAngle, currentAngle, currentAngle);
        }

        if (gameObject.tag == ("Corner Wall") && currentRotation + 91.0f > 135.0f && currentRotation + 91.0f < 315.0f)
        {
            transform.localScale = new Vector3(float.Epsilon, float.Epsilon, float.Epsilon);
        }

    }
}
