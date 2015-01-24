using UnityEngine;
using System.Collections;

public class PlayerSoundScript : MonoBehaviour {

    public AudioClip[] stepsSounds;
    private AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        Debug.Log(stepsSounds);
        Debug.Log(stepsSounds.Length);
        Debug.Log(stepsSounds[0]);
        Debug.Log(audio);
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInChildren<Animator>().GetBool("moving"))
        {
            if (!audio.isPlaying)
            {
                audio.clip = stepsSounds[Random.Range(0,stepsSounds.Length)];
                audio.Play();
            }
        }
	}
}
