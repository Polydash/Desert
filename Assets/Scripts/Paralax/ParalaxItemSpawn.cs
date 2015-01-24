using UnityEngine;
using System.Collections;
using System;

public class ParalaxItemSpawn : MonoBehaviour {

    public float nextSpawn = 5.0f;
    public Vector2 spawnRange = new Vector2(5.0f, 15.0f);


    private UnityEngine.GameObject[] ressources;
    private float lastCameraPosition;
	void Start () {
        lastCameraPosition = Camera.main.transform.position.x;
        ressources = Resources.LoadAll<GameObject>("Prefabs/Paralax");
        Debug.Log(ressources.Length);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cameraPosition = Camera.main.transform.position;
        if (nextSpawn < 0)
        {
            var pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 100, 0, 0));
            int rand = UnityEngine.Random.Range(1,4);
            GameObject go = GameObject.Instantiate(
                ressources[UnityEngine.Random.Range(0, ressources.Length)], 
                new Vector3(pos.x,rand-(0.5f*rand),rand*2 + 2),
                new Quaternion()
            ) as GameObject;
            int scaleSize = new System.Random().Next(-1, 2);
            go.transform.localScale = new Vector3((go.transform.localScale.x / rand)*scaleSize, go.transform.localScale.y / rand, go.transform.localScale.z);
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
