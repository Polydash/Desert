﻿using UnityEngine;
using System.Collections;

public class FadeToWithScript : MonoBehaviour
{
    public SpriteRenderer texture;

    private float opacity = 0.0f;

    void Start()
    {
        texture.color = new Color(texture.color.r, texture.color.g, texture.color.b, opacity);
        texture.enabled = true;
        Debug.Log(texture.transform.position);
    }

    void Update()
    {   
        if (opacity < 1.0f)
        {
            opacity += 0.005f;
        }
        else
        {
            Application.LoadLevel("Ending");
        }
    }

    void FixedUpdate()
    {
        texture.color = new Color(texture.color.r, texture.color.g, texture.color.b, opacity);
    }

   
}
