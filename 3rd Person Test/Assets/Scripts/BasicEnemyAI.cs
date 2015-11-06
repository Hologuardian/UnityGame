using UnityEngine;
using System.Collections;

public class BasicEnemyAI : MonoBehaviour
{
    public Transform player;
    public float distance;
    public float AutoDelay = 0.1f;
    private float AutoTimer = 0.0f;
    // Use this for initialization
    void Start ()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        AutoTimer += Time.deltaTime;
        if (player != null && GetComponent<Renderer>().enabled)
        {
            distance = Vector3.Distance(player.position, transform.position);
            if(distance <= 120)
            {
                transform.LookAt(player);
            }
            if(distance <= 60 && AutoTimer >= AutoDelay)
            {
                AutoTimer = 0;
                TestScript shooting = GetComponentInChildren<TestScript>();
                if(shooting != null)
                {
                    shooting.Shoot();
                }
            }
        }
	}
}
