using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	public float speed = 20;
	public Rigidbody projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Debug.Log(transform.rotation.x + " " + transform.rotation.y + "" + transform.rotation.z + " " + transform.rotation.w);
			Rigidbody instantiateProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			instantiateProjectile.velocity = transform.TransformDirection(0, 0, speed);
			Destroy(instantiateProjectile.gameObject, 30.0f);
		}
	}
}
