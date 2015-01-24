using UnityEngine;
using System.Collections;

public class AmbianceSoundScript : MonoBehaviour {

    public AudioClip[] ambianceSounds;
    public float rangeNextSound = 45.0f;
    private float nextSound;
    private AudioSource[] audioPlayers;
    // Use this for initialization
	void Start () {
        audioPlayers = GetComponents<AudioSource>();
        nextSound = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (nextSound < 0)
        {
            foreach (AudioSource audioPlayer in audioPlayers)
            {
                if (!audioPlayer.isPlaying)
                {
                    audioPlayer.clip = ambianceSounds[Random.Range(0, ambianceSounds.Length)];
                    audioPlayer.pitch = Random.Range(1.0f, 2.0f);
                    audioPlayer.Play();
                    nextSound = rangeNextSound;
                    break;
                }
            }
        }
        else
        {
            nextSound -= Time.deltaTime;
        }
	}
}
