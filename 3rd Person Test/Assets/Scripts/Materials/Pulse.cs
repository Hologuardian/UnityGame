using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {

    // Use this for initialization
    public Material[] pulse;
    Color[] pulseStarts;
    void Start ()
    {
        int i = 0;
        pulseStarts = new Color[pulse.Length];
	    foreach(Material m in pulse)
        {
            pulseStarts[i] = m.GetColor("_EmissionColor");
            i++;
        }
	}

    public float amount = 0.3f;
    //Half Cycle Time
    public float speed = 1.5f;
	// Update is called once per frame
	void Update ()
    {
        float p = Mathf.PingPong(Time.time, amount * speed) / speed;
        for (int i = 0; i < pulseStarts.Length; ++i)
        {
            Color c = pulseStarts[i];
            c.r += p;
            c.g += p;
            c.b += p;
            pulse[i].SetColor("_EmissionColor", c);
            i++;
        }
	}

    void OnDestroy()
    {
        for(int i = 0; i < pulseStarts.Length; ++i)
        {
            pulse[i].SetColor("_EmissionColor", pulseStarts[i]);
        }
    }
}
