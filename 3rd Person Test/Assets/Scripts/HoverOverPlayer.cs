using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class HoverOverPlayer : MonoBehaviour {

    public Transform player;
    private Vector3 targetPosition;
    public float floatHeight = 20.0f;
    public float speed = 20.0f;
    private Vector3 randomSphere;
	// Use this for initialization
	void Start ()
    {
        randomSphere = Random.insideUnitSphere;
    }

    public float sphereSize = 5.0f;
    public float sprintMod = 4.0f;
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= 200.0f)
        {

            targetPosition = player.position + new Vector3(0, floatHeight, 0) + randomSphere * sphereSize;
            //transform.LookAt(targetPosition);
            float toTarget = Vector3.Distance(targetPosition, transform.position);
            if (toTarget >= 0.25F)
            {
                Rigidbody body = gameObject.GetComponent<Rigidbody>();
                Vector3 targeting = (targetPosition - transform.position);
                targeting.Normalize();
                if(toTarget >= sphereSize)
                    targeting *= speed * sprintMod;
                else
                    targeting *= speed;
                body.velocity = targeting;
            }
            else
            {
                randomSphere = Random.insideUnitSphere;
            }
        }
	}
}
