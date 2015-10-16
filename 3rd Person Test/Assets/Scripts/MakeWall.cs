using UnityEngine;
using System.Collections;

public class MakeWall : MonoBehaviour {

    public GameObject brick;
    public int x, y, z = 8;
    //private float RepairStart = 10.0f;
    //private GameObject[,,] WallParts;
    //private float RepairTimer;
    //private bool IsRepairing = false;
    // Use this for initialization
    void Start () {
        //RepairTimer = RepairStart;
        //WallParts = new GameObject[x,y,z];

        for (int i = 0; i < z; i++)
        {
            for(int j = 0; j < y; j++)
            {
                for (int k = 0; k < x; k++)
                {
                    Vector3 pos = transform.position;
                    BoxCollider coll = brick.GetComponent<BoxCollider>();
                    pos.z += i * coll.size.z;
                    pos.y += j * coll.size.y;
                    pos.x += k * coll.size.x;
                    GameObject instantiateProjectile = Instantiate (brick, pos, transform.rotation) as GameObject;
                    //WallParts[k,j,i] = instantiateProjectile.gameObject;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
     //   IsRepairing = false;
	    //foreach(GameObject obj in WallParts)
     //   {
     //       Rebuild cube = obj.GetComponent<Rebuild>();
     //       if (cube.ShouldRepair())
     //           IsRepairing = true;
     //   }
     //   if(IsRepairing)
     //   {
     //       if(RepairTimer > 0)
     //           RepairTimer -= Time.deltaTime;

     //       if(RepairTimer <= 0)
     //       {
     //           foreach (GameObject obj in WallParts)
     //           {
     //               Rebuild cube = obj.GetComponent<Rebuild>();
     //               cube.StartRepair();
     //           }
     //       }
     //   }
     //   else
     //   {
     //       foreach (GameObject obj in WallParts)
     //       {
     //           Rebuild cube = obj.GetComponent<Rebuild>();
     //           cube.StopRepair();
     //       }
     //       RepairTimer = RepairStart;
     //   }
	}
}
