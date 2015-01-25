using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public Sprite normalTexture;
    public Sprite highLightedTexture;
    public bool Selected = false;
    private SpriteRenderer spriteRenderer;

    private bool wasSelected = false;
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        wasSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Selected && !wasSelected)
        {
            spriteRenderer.sprite = highLightedTexture;
            wasSelected = true;
        }
        else if (!Selected && wasSelected)
        {
            spriteRenderer.sprite = normalTexture;
            wasSelected = false;
        }
	}
}
