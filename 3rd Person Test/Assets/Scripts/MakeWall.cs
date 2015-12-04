using UnityEngine;
using System.Collections;

public class MakeWall : MonoBehaviour {

    public GameObject brick;
    public int x, y, z = 8;
    public Material[] randomMaterial;
    private Vector3 center;
    private Vector3 size;
    //private float RepairStart = 10.0f;
    //private GameObject[,,] WallParts;
    //private float RepairTimer;
    //private bool IsRepairing = false;
    // Use this for initialization
    void Start () {
        //RepairTimer = RepairStart;
        //WallParts = new GameObject[x,y,z];
        BoxCollider coll = brick.GetComponent<BoxCollider>();
        for (int i = 0; i < z; i++)
        {
            for(int j = 0; j < y; j++)
            {
                for (int k = 0; k < x; k++)
                {
                    Vector3 pos = transform.position;
                    pos.z += i * coll.size.z * brick.transform.lossyScale.z;
                    pos.y += j * coll.size.y * brick.transform.lossyScale.y;
                    pos.x += k * coll.size.x * brick.transform.lossyScale.x;
                    GameObject instantiateProjectile = Instantiate (brick, pos, transform.rotation) as GameObject;
                    instantiateProjectile.GetComponent<MeshRenderer>().material = randomMaterial[Random.Range(0, randomMaterial.Length)];
                    /*float val = Random.value;
                    if(val < 0.8f)
                    {
                        instantiateProjectile.GetComponent<MeshRenderer>().material = randomMaterial[0];
                    }
                    else if (val < 0.9f)
                    {
                        instantiateProjectile.GetComponent<MeshRenderer>().material = randomMaterial[1];
                    }
                    else
                    {
                        instantiateProjectile.GetComponent<MeshRenderer>().material = randomMaterial[2];
                    }*/
                    //WallParts[k,j,i] = instantiateProjectile.gameObject;
                }
            }
        }
	}

    void OnDrawGizmos()
    {
        Vector3 size = brick.GetComponent<BoxCollider>().size;
        size.Scale(brick.transform.lossyScale);
        size = new Vector3(x * size.x, y * size.y, z * size.z);
        center = transform.position + (size / 2) - (brick.transform.lossyScale / 2);
        Gizmos.DrawCube(center, size);
        Gizmos.DrawWireCube(center, size);
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
