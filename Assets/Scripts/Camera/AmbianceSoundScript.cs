using UnityEngine;
using System.Collections;

public class AmbianceSoundScript : MonoBehaviour {

    public AudioClip[] ambianceSounds;
    public Vector2 rangeNextSound = new Vector2(10, 30);
    private float nextSound;
    private AudioSource audioPlayer;
    // Use this for initialization
	void Start () {
        audioPlayer = GetComponent<AudioSource>();
        nextSound = Random.Range(rangeNextSound.x, rangeNextSound.y);
	}
	
	// Update is called once per frame
	void Update () {
        if (nextSound < 0)
        {
            audioPlayer.clip = ambianceSounds[Random.Range(0, ambianceSounds.Length)];
            audioPlayer.pitch = Random.Range(1.0f, 2.0f);
            audioPlayer.Play();
        }
        else
        {
            nextSound -= Time.deltaTime;
        }
        Debug.Log(nextSound);
	}
}
