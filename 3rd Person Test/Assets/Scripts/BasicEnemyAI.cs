using UnityEngine;
using System.Collections;

public class BasicEnemyAI : MonoBehaviour
{
    public Transform player;
    public float distance;
    private Vector3 direction;
	// Use this for initialization
	void Start ()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(player != null && GetComponent<Renderer>().enabled)
        {
            distance = Vector3.Distance(player.position, transform.position);
            direction = player.position - transform.position;
            direction.Normalize();
            if(distance <= 120)
            {
                transform.LookAt(player);
            }
            if(distance <= 60)
            {
                GetComponentInChildren<TestScript>().Shoot();
            }
        }
	}
}
