using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MakeWall : MonoBehaviour {

    public GameObject brick;
    public int x, y, z = 8;
    public Material[] randomMaterial;
    public Material interiorMaterial;
    private Vector3 center;

    private GameObject[] blocks;
    //private float RepairStart = 10.0f;
    //private GameObject[,,] WallParts;
    //private float RepairTimer;
    //private bool IsRepairing = false;
    // Use this for initialization
    public float gap = 0.4f;
    void OnEnable()
    {
        if (randomMaterial.Length != 0 && interiorMaterial != null)
        {
            foreach (BoxCollider g in transform.GetComponentsInChildren<BoxCollider>())
            {
                if (!g.gameObject.CompareTag("Wall"))
                    DestroyImmediate(g.gameObject);
            }
            blocks = new GameObject[x * y * z + 1];
            BoxCollider coll = brick.GetComponent<BoxCollider>();
            for (int i = 0; i < z; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < x; k++)
                    {
                        Vector3 pos = transform.position;
                        pos.z += i * coll.size.z * brick.transform.lossyScale.z + gap * i + gap / 2;
                        pos.y += j * coll.size.y * brick.transform.lossyScale.y + gap * j + gap / 2;
                        pos.x += k * coll.size.x * brick.transform.lossyScale.x + gap * k + gap / 2;
                        GameObject instantiateProjectile = Instantiate(brick, pos, transform.rotation) as GameObject;
                        instantiateProjectile.GetComponent<MeshRenderer>().material = randomMaterial[Random.Range(0, randomMaterial.Length)];
                        instantiateProjectile.transform.parent = transform;
                        blocks[k + j * x + i * y] = instantiateProjectile;
                    }
                }
            }

            Vector3 size = brick.GetComponent<BoxCollider>().size;
            size.Scale(brick.transform.lossyScale);
            size = new Vector3(x * size.x + x * gap, y * size.y + y * gap, z * size.z + z * gap);
            center = transform.position + (size / 2) - (brick.transform.lossyScale / 2);
            GameObject inside = Instantiate(brick, center, transform.rotation) as GameObject;
            inside.GetComponent<MeshRenderer>().material = interiorMaterial;
            inside.transform.localScale = size - new Vector3(gap * 3, gap * 3, gap * 3);
            inside.transform.parent = transform;
            blocks[blocks.Length - 1] = inside;
        }
    }

    void Start()
    {
    }

    void OnDisable()
    {
        foreach (BoxCollider g in transform.GetComponentsInChildren<BoxCollider>())
        {
            if (!g.gameObject.CompareTag("Wall"))
                DestroyImmediate(g.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
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
