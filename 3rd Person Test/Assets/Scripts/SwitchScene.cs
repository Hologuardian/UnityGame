using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {

    public string Scene;
    public string CurrentScene;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Switch()
    {
        Application.LoadLevel(Scene);
    }
}
