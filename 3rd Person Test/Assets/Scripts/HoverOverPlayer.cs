using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class HoverOverPlayer : MonoBehaviour {

    public Transform player;
    private Vector3 targetPosition;
    public float floatHeight = 20.0f;
    public float speed = 20.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= 200.0f)
        {
            targetPosition = player.position + new Vector3(0, floatHeight, 0);
            //transform.LookAt(targetPosition);
            float toTarget = Vector3.Distance(targetPosition, transform.position);
            if (toTarget >= 0.1)
            {
                Rigidbody body = gameObject.GetComponent<Rigidbody>();
                Vector3 targeting = (targetPosition - transform.position);
                if(targeting.magnitude > 1)
                {
                    targeting.Normalize();
                    targeting *= speed;
                }
                body.velocity = targeting;
            }
        }
	}
}
