using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestScript : MonoBehaviour {

	public float speed = 20;
    public float Shots = 1.0f;
    public Rigidbody projectile;
    public string FireKey = "Fire1";
    public bool Automatic = false;
    public bool AutoHeatReduction = false;
    public float AutoDelay = 0.5f;
    private float AutoTimer = 0.0f;
    public float Spread = 0.1f;
    public bool IsAI = false;
    public Transform targeting;
    public Slider heatSlider;
    private float heat;
    private bool overheat = false;
    public float HeatPerShot = 0.1f;
    public float HeatPerSecond = 0.5f;
    public Collider[] ignore = new Collider[1];

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update () {
        if (heatSlider != null)
        {
            heatSlider.value = heat;
            if (heat >= 1)
            {
                heatSlider.gameObject.transform.FindChild("Background").GetComponent<Image>().color = Color.yellow;
                overheat = true;
                heat = 1;
            }
            if (heat <= 0)
            {
                heatSlider.gameObject.transform.FindChild("Background").GetComponent<Image>().color = Color.white;
                overheat = false;
                heat = 0;
            }
        }
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
                heat -= Time.deltaTime * HeatPerSecond;
                if (Input.GetButtonDown(FireKey) && !overheat)
                {
                    Shoot();
                }
            }
            else
            {
                if (AutoHeatReduction)
                {
                    heat -= Time.deltaTime * HeatPerSecond;
                }

                AutoTimer += Time.deltaTime;
                if (Input.GetButton(FireKey) && !overheat)
                {
                    if(AutoTimer >= AutoDelay)
                    {
                        AutoTimer = 0;
                        Shoot();
                    }
                }
                else if(!AutoHeatReduction)
                {
                    heat -= Time.deltaTime * HeatPerSecond;
                }
            }
        }
    }

    public void Shoot()
    {
        for (int i = 0; i < Shots; ++i)
        {
            heat += HeatPerShot;
            //Debug.Log(transform.rotation.x + " " + transform.rotation.y + "" + transform.rotation.z + " " + transform.rotation.w);
            RaycastHit hit;
            Physics.Raycast(targeting.position, targeting.forward, out hit);
            if (hit.collider != null && hit.point != Vector3.zero)
            {
                transform.LookAt(hit.point);
                //Debug.Log(hit.point);
            }
            else
            {
                transform.LookAt(transform.position + transform.parent.transform.TransformDirection(Vector3.forward));
            }
            Rigidbody instantiateProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            if(IsAI)
            {
                instantiateProjectile.gameObject.tag = "AIProjectile";
            }
            Vector3 sped = Random.insideUnitSphere * (speed * Spread);
            //Debug.Log("Spread Vector: " + sped + " Speed: " + speed);
            instantiateProjectile.velocity = transform.TransformDirection(0 + sped.x, 0 + sped.y, speed);
            if(ignore != null)
            {
                foreach(Collider c in ignore)
                {

                    Physics.IgnoreCollision(instantiateProjectile.GetComponent<Collider>(), c);
                }
            }
            Destroy(instantiateProjectile.gameObject, 10.0f);
            
        }
    }
}
