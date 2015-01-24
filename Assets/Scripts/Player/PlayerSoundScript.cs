using UnityEngine;
using System.Collections;

public class PlayerSoundScript : MonoBehaviour {

    public AudioClip[] stepsSounds;
    private AudioSource audioPlayer;
	// Use this for initialization
	void Start () {
        audioPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInChildren<Animator>().GetBool("moving"))
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.clip = stepsSounds[Random.Range(0, stepsSounds.Length)];
                audioPlayer.pitch = Random.Range(1.0f, 2.0f);
                audioPlayer.Play();
            }
        }
	}
}
