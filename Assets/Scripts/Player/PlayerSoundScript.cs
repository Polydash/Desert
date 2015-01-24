using UnityEngine;
using System.Collections;

public class PlayerSoundScript : MonoBehaviour {

    public AudioClip[] stepsSounds;
    public float rangeNextStep = 0.25f;

    private AudioSource audioPlayer;
    private float nextStep;
	// Use this for initialization
	void Start () {
        audioPlayer = GetComponent<AudioSource>();
        nextStep = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInChildren<Animator>().GetBool("moving"))
        {
            if (nextStep < 0)
            {
                audioPlayer.clip = stepsSounds[Random.Range(0, stepsSounds.Length)];
                audioPlayer.pitch = Random.Range(1.0f, 2.0f);
                audioPlayer.Play();
                nextStep = rangeNextStep;
            }
            else
            {
                nextStep -= Time.deltaTime;
            }
        }
        else if (audioPlayer.isPlaying)
            audioPlayer.Stop();
	}

    /*void Update()
    {
        if (GetComponentInChildren<Animator>().GetBool("moving"))
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.clip = stepsSounds[Random.Range(0, stepsSounds.Length)];
                audioPlayer.pitch = Random.Range(1.0f, 2.0f);
                audioPlayer.Play();
            }
        }
        else if (audioPlayer.isPlaying)
            audioPlayer.Stop();
    }*/
}
