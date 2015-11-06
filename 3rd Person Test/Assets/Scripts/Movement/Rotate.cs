using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public Vector3 axis;
    public float RPS;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(axis, RPS * Time.deltaTime);
	}
}
