using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class HoverOverPlayer : MonoBehaviour {

    public Transform player;
    private Vector3 targetPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= 200.0f)
        {
            targetPosition = player.position + new Vector3(0, 20.0f, 0);
            //transform.LookAt(targetPosition);
            float toTarget = Vector3.Distance(targetPosition, transform.position);
            if (toTarget >= 0.1)
            {
                Rigidbody body = gameObject.GetComponent<Rigidbody>();
                Vector3 targeting = (targetPosition - transform.position);
                targeting.Normalize();
                body.velocity = targeting;
            }
        }
	}
}
