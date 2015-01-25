using UnityEngine;
using System.Collections;

public class FadeToGameScript : MonoBehaviour {

    public GUITexture texture;

    private float opacity = 1.0f;

    void Start()
    {
        texture.color = new Color(texture.color.r, texture.color.g, texture.color.b, opacity);
        texture.enabled = true;
    }

    void Update()
    {
        if (opacity > 0.0f)
        {
            opacity -= 0.008f;
        }
        else
        {
            texture.enabled = false;
            this.enabled = false;
        }
    }

    void FixedUpdate()
    {
        texture.color = new Color(texture.color.r, texture.color.g, texture.color.b, opacity);
    }
}
