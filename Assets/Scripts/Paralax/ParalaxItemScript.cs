using UnityEngine;
using System.Collections;

public class ParalaxItemScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 posPixel = Camera.main.WorldToScreenPoint(transform.position);
        if (Camera.main.GetComponent<ScrollingScript>().Direction == 1)
        {
            if (posPixel.x + renderer.bounds.max.x <= -Screen.width/2)
            {
                Destroy(gameObject);
            }
        }
        else if (Camera.main.GetComponent<ScrollingScript>().Direction == -1)
        {
            if (posPixel.x - renderer.bounds.size.x >= Screen.width*1.5)
            {
                Destroy(gameObject);
            }
        }
	}
}
