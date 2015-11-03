using UnityEngine;
using System.Collections;

public class TrailDeath : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public float ProjectileDeathTimer = 5.0f;
    void Explode(ContactPoint[] contacts)
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(gameObject, ProjectileDeathTimer);//Kind of hacky, can modify to use the time property in the trail system.
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<TrailDeath>() != null || coll.gameObject.CompareTag("Player"))
            return; //Basically don't have the projectiles hit each other
        Explode(coll.contacts);
    }
}
