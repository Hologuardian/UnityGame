using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject explosionPrefab;
    public float ExplosionStrength = 2000.0f;
    public float ExplosionSize = 5.0f;
    void Explode(ContactPoint[] contacts)
    {
        GameObject explosion = Instantiate(explosionPrefab, contacts[0].point, Quaternion.identity) as GameObject;
        Destroy(explosion, 1.0f);
        
        for (int i = -5; i <= 5; ++i)
        {
            for (int j = -5; j <= 5; ++j)
            {
                for (int k = -5; k <= 5; ++k)
                {
                    RaycastHit hit;
                    
                    Physics.Raycast(transform.position, new Vector3(i, j, k), out hit);
                    Rigidbody body = hit.rigidbody;
                    if (body)
                    {
                        Vector3 direction = body.transform.position - transform.position;
                        direction = direction.normalized;
                        body.AddForce(direction * ExplosionStrength);
                        if(body.gameObject.tag != "Player")
                            Destroy(body.gameObject, 1.0f);
                    }
                }
            }
        }
        
        /*
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, ExplosionSize, Vector3.zero, 0.0f);

        foreach(RaycastHit hit in hits)
        {
            hit.rigidbody.AddExplosionForce(ExplosionStrength, transform.position, ExplosionSize);
        }
        */

        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(gameObject, 2.0f);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<ProjectileHit>() != null)
            return;
        Explode(coll.contacts);
    }
}
