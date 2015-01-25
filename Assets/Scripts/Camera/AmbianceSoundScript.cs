using UnityEngine;
using System.Collections;

public class AmbianceSoundScript : MonoBehaviour {

    public AudioClip[] ambianceSounds;
    public AudioClip[] animalsSounds;

    public Vector2 rangeNextAniSounds = new Vector2(30.0f, 60.0f);
    public float rangeNextAmbSound = 45.0f;
    public float nextAniSounds;
    private float nextAmbSound;

    private AudioSource[] audioPlayers;
    // Use this for initialization
	void Start () {
        audioPlayers = GetComponents<AudioSource>();
        nextAmbSound = 0;
        nextAniSounds = 15f;
	}
	
	// Update is called once per frame
	void Update () {
        AmbianceSoundsUpdate();
        AnimalsSoundsUpdate();
	}

    private void AmbianceSoundsUpdate()
    {
        if (nextAmbSound < 0)
        {
            foreach (AudioSource audioPlayer in audioPlayers)
            {
                if (!audioPlayer.isPlaying)
                {
                    audioPlayer.clip = ambianceSounds[Random.Range(0, ambianceSounds.Length)];
                    audioPlayer.pitch = Random.Range(1.0f, 2.0f);
                    audioPlayer.pan = 0;
                    audioPlayer.volume = 1;
                    audioPlayer.Play();
                    nextAmbSound = rangeNextAmbSound;
                    break;
                }
            }
        }
        else
        {
            nextAmbSound -= Time.deltaTime;
        }
    }

    private void AnimalsSoundsUpdate()
    {
        if (nextAniSounds < 0)
        {
            foreach (AudioSource audioPlayer in audioPlayers)
            {
                if (!audioPlayer.isPlaying)
                {
                    audioPlayer.clip = animalsSounds[Random.Range(0, animalsSounds.Length)];
                    audioPlayer.pan = Random.Range(-2.0f, 1.0f);
                    audioPlayer.volume = Random.Range(0.5f, 1.0f);
                    audioPlayer.Play();
                    nextAniSounds = Random.Range(rangeNextAniSounds.x, rangeNextAniSounds.y);
                    break;
                }
            }
        }
        else
        {
            nextAniSounds -= Time.deltaTime;
        }
    }
}
