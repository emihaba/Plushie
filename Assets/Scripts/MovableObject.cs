using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour {

    float distance;
    Vector3 objPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDrag () {


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        {
            if(Physics.Raycast(ray, out hit))
            {
                MovableObject obj = hit.collider.GetComponent<MovableObject>();

                if(obj != null)
                {
                    distance = hit.distance;
                    objPos = ray.origin + distance * ray.direction;
                    obj.transform.position = new Vector3(objPos.x, obj.transform.position.y, objPos.z);

                   // obj.transform.position = new Vector3(Mathf.Round(objPos.x), obj.transform.position.y, Mathf.Round(objPos.z));
                    //obj.transform.position = new Vector3(Mathf.Round(obj.transform.position.x),obj.transform.position.y,Mathf.Round(obj.transform.position.z));


                }
            }
        }


    }
}
