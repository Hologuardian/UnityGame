using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	public float speed = 20;
    public float Shots = 1.0f;
    public Rigidbody projectile;
    public string FireKey = "Fire1";
    public bool Automatic = false;
    public float AutoDelay = 5.0f;
    private float AutoTimer = 0.0f;
    public float Spread = 0.1f;
    public bool IsAI = false;

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update () {
        //This is dusgusting and shouldn't be here
        if (!IsAI)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            //Above is dusgusting and shouldn't be here
            if (!Automatic)
            {
                if (Input.GetButtonDown(FireKey))
                {
                    Shoot();
                }
            }
            else
            {
                AutoTimer += Time.deltaTime;
                if (Input.GetButton(FireKey) && AutoTimer >= AutoDelay)
                {
                    AutoTimer = 0;
                    Shoot();
                }
            }
        }
    }

    public void Shoot()
    {
        for (int i = 0; i < Shots; ++i)
        {
            //Debug.Log(transform.rotation.x + " " + transform.rotation.y + "" + transform.rotation.z + " " + transform.rotation.w);
            Rigidbody instantiateProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            Vector3 sped = Random.insideUnitSphere * (speed * Spread);
            Debug.Log("Spread Vector: " + sped + " Speed: " + speed);
            instantiateProjectile.velocity = transform.TransformDirection(0 + sped.x, 0 + sped.y, speed);
            Destroy(instantiateProjectile.gameObject, 30.0f);
        }
    }
}
