using UnityEngine;
using System.Collections;

public class ParticleCollision : MonoBehaviour
{
    public float ExplosionStrength = 5;
    void OnParticleCollision(GameObject other)
    {
        Rigidbody body = other.GetComponent<Rigidbody>();
        if (body)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction = direction.normalized;
            body.AddForce(direction * ExplosionStrength);
        }
    }
}
