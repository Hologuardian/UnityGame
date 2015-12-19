using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SwitchScene))]
public class PlayerDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.gameObject.GetComponent<SwitchScene>().Switch();
        }
	}

    void OnDestroy()
    {
        gameObject.gameObject.GetComponent<SwitchScene>().Switch();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
