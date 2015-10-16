using UnityEngine;
using System.Collections;

public class Rebuild : MonoBehaviour {
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isRepairing = false;
    public float BakeTime = 1.0f;
    public float LerpAmount = 0.2f;
    private bool hasBaked;
	// Use this for initialization
	void Start ()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (BakeTime >= 0)
        {
            hasBaked = false;
            BakeTime -= Time.deltaTime;
            return;
        }

        if (!hasBaked)
        {
            hasBaked = true;
            originalPosition = gameObject.transform.position;
            originalRotation = gameObject.transform.rotation;
        }

        if (isRepairing && hasBaked)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, LerpAmount);
            gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, LerpAmount);
            if ((originalPosition - transform.position).magnitude <= 0.05f)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                transform.position = originalPosition;
                transform.rotation = originalRotation;
            }
        }
    }
    public bool ShouldRepair()
    {
        if (!hasBaked)
            return false;

        if (transform.position != originalPosition && transform.rotation != originalRotation)
            return true;
        return false;
    }

    public void StartRepair()
    {
        if (!hasBaked)
            return;
        startPosition = transform.position;
        startRotation = transform.rotation;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        isRepairing = true;
    }

    public void StopRepair()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        isRepairing = false;
    }
}
