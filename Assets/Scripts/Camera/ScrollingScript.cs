﻿using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {

    public int direction = 1;
    public float seuilDeScroll = 0.66f;
    public Vector2 scrollSpeed = new Vector2(1,0);


    private int screenWidth;
    private GameObject[] players;
    private Vector2 movement = new Vector2(0,0);

	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
        screenWidth = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
        bool move = true;
        foreach (GameObject ob in players)
        {
            if (ob.transform.position.x < seuilDeScroll * screenWidth)
            {
                move = false;
            }
        }
        if (move == true)
        {
            movement = new Vector2(direction * scrollSpeed.x, scrollSpeed.y);
        }
        else
        {
            movement = new Vector2(0, 0);
        }
	}

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, transform.position.z);
    }
}
