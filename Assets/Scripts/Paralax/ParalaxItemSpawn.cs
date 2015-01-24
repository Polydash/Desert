using UnityEngine;
using System.Collections;
using System;

public class ParalaxItemSpawn : MonoBehaviour {

    public float nextSpawn = 5.0f;
    public Vector2 spawnRange = new Vector2(5.0f, 15.0f);
    public Vector3 spawnLignePosY = new Vector3(0.6f, 0.9f, 1.2f);

    private UnityEngine.GameObject[] ressources;
    private float lastCameraPosition;
    private GameObject parent;
	void Start () {
        lastCameraPosition = Camera.main.transform.position.x;
        ressources = Resources.LoadAll<GameObject>("Prefabs/Paralax");
        parent = GameObject.Find("Paralax");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cameraPosition = Camera.main.transform.position;
        if (nextSpawn < 0)
        {
            var pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 100, 0, 0));
            int rand = UnityEngine.Random.Range(1,4);
            float ligneY = spawnLignePosY.x;
            if (rand == 2)
                ligneY = spawnLignePosY.y;
            if (rand == 3)
                ligneY = spawnLignePosY.z;

            GameObject go = GameObject.Instantiate(
                ressources[UnityEngine.Random.Range(0, ressources.Length)], 
                new Vector3(pos.x,ligneY,rand*2 + 2),
                new Quaternion()
            ) as GameObject;
            int scaleSize = ((int)UnityEngine.Random.Range(0, 2)) * 2 - 1;
            go.transform.localScale = new Vector3((go.transform.localScale.x / rand)*scaleSize, go.transform.localScale.y / rand, go.transform.localScale.z);
            go.transform.parent = parent.transform;
            nextSpawn = UnityEngine.Random.Range(spawnRange.x, spawnRange.y);
        }
        else
        {
            float cameraPositionX = cameraPosition.x;
            nextSpawn = nextSpawn - (cameraPositionX - lastCameraPosition);
            lastCameraPosition = cameraPositionX;
        }
	}
}
