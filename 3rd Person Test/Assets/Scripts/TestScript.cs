using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	public float speed = 20;
    public float Shots = 1.0f;
    public Rigidbody projectile;

	// Use this for initialization
	void Start ()
    {
        Screen.lockCursor = true;
    }
    
    // Update is called once per frame
    void Update () {
        //This is dusgusting and shouldn't be here
        if (Input.GetKey(KeyCode.Escape))
            Screen.lockCursor = false;
        //Above is dusgusting and shouldn't be here
        if (Input.GetButtonDown("Fire1")){
			for(int i = 0; i < Shots; ++i)
            {
                //Debug.Log(transform.rotation.x + " " + transform.rotation.y + "" + transform.rotation.z + " " + transform.rotation.w);
                Rigidbody instantiateProjectile = Instantiate(projectile, transform.position + Random.insideUnitSphere / 3, transform.rotation) as Rigidbody;
                instantiateProjectile.velocity = transform.TransformDirection(0, 0, speed) + Random.insideUnitSphere * speed / 10;
                Destroy(instantiateProjectile.gameObject, 30.0f);
            }
		}
	}
}
