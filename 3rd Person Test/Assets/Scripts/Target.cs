using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + transform.TransformDirection(Vector3.forward * 5.0f), transform.TransformDirection(Vector3.forward), out hit);
            Debug.Log(hit.point);
            GameObject tar = GameObject.FindGameObjectWithTag("Target");
            if(tar != null)
                Destroy(tar);
            GameObject obj = Instantiate(new GameObject(), hit.point, transform.rotation) as GameObject;
            obj.tag = "Target";
        }
	}
}
