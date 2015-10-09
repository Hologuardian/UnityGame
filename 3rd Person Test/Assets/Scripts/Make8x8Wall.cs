using UnityEngine;
using System.Collections;

public class Make8x8Wall : MonoBehaviour {

    public BoxCollider brick;
    public int x, y, z;
    // Use this for initialization
    void Start () {
	    for(int i = 0; i < z; ++i)
        {
            for(int j = 0; j < y; ++j)
            {
                for (int k = 0; k < x; ++k)
                {
                    Vector3 pos = transform.position;
                    pos.z += i * brick.size.z;
                    pos.y += j * brick.size.y;
                    pos.x += k * brick.size.x;
                    print(pos + " || " + brick.bounds.size);
                    BoxCollider instantiateProjectile = Instantiate (brick, pos, transform.rotation) as BoxCollider;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
