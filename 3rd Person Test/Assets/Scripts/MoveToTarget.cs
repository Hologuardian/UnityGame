using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour {

    public float speed = 5.0f;
    public float TargetTimer = 1.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        GameObject obj = GameObject.FindGameObjectWithTag("Target");
        if (TargetTimer >= 0 && obj != null)
        {
            TargetTimer -= Time.deltaTime;
            return;
        }

        Vector3 dir = (obj.transform.position - transform.position);
        dir.Normalize();
        gameObject.GetComponent<Rigidbody>().velocity = dir * speed;

    }
}
