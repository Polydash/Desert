using UnityEngine;
using System.Collections;

public class PlayerSoundScript : MonoBehaviour {

    public AudioClip[] stepsSounds;
    public AudioClip[] inSounds;
    public AudioClip[] outSounds;
    public float rangeNextStep = 0.25f;

    private bool wasMoving;
    private AudioSource[] audioPlayers;
    private float nextStep;
    private Animator playerAnimator;
	// Use this for initialization
	void Start () {
        audioPlayers = GetComponents<AudioSource>();
        nextStep = 0;
        wasMoving = false;
        playerAnimator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerAnimator.GetBool("moving"))
        {
            if(!wasMoving)
            {
                audioPlayers[1].clip = inSounds[Random.Range(0, inSounds.Length)];
                audioPlayers[1].pitch = Random.Range(1.0f, 2.0f);
                audioPlayers[1].Play();
            }
            if (nextStep < 0)
            {
                audioPlayers[0].clip = stepsSounds[Random.Range(0, stepsSounds.Length)];
                audioPlayers[0].pitch = Random.Range(1.0f, 2.0f);
                audioPlayers[0].Play();
                nextStep = rangeNextStep;
            }
            else
            {   
                nextStep -= Time.deltaTime;
            }
            wasMoving = true;
        }
        else
        {
            if (wasMoving)
            {
                audioPlayers[0].Stop();
                audioPlayers[1].clip = outSounds[Random.Range(0, outSounds.Length)];
                audioPlayers[1].pitch = Random.Range(1.0f, 2.0f);
                audioPlayers[1].Play();
            }
            wasMoving = false;
        }
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
