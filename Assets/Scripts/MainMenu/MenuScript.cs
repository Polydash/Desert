using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MenuScript : MonoBehaviour {

    private List<ButtonScript> buttons;
    private int selectedButton;
    private int lastDirection;
    private bool isItemSelected;
    private AudioSource audioPlayer;
    private AudioClip changeSelection;
    private AudioClip selection;
	void Start () {
        audioPlayer = GetComponent<AudioSource>();
        changeSelection = Resources.Load<AudioClip>("Sound/Menu/Bouton_A_02");
        selection = Resources.Load<AudioClip>("Sound/Menu/Bouton_C_03");
        buttons = new List<ButtonScript>(GetComponentsInChildren<ButtonScript>());
        if (buttons.Count > 0)
        {
            buttons[0].Selected = true;
            selectedButton = 0;
        }
        for (int i = 1; i < buttons.Count; i++)
        {
            buttons[i].Selected = false;
        }
        lastDirection = 0;
        isItemSelected = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (!isItemSelected)
        {
            int directionY = - Mathf.RoundToInt(Input.GetAxis("P1 Vertical"));
            if (directionY != lastDirection)
            {
                buttons[selectedButton].Selected = false;
                selectedButton = (selectedButton + directionY) % (buttons.Count);
                if (selectedButton == -1)
                    selectedButton = buttons.Count - 1;
                buttons[selectedButton].Selected = true;
                audioPlayer.clip = changeSelection;
                audioPlayer.Play();
                lastDirection = directionY;
            }
        }

        if (Input.GetButtonUp("P1 A") || Input.GetButtonUp("P1 X") || Input.GetButtonUp("P1 B"))
        {
            audioPlayer.clip = selection;
            audioPlayer.Play();
            isItemSelected = true;
            if (selectedButton == 2)
            {
                Application.Quit();
            }
            if (selectedButton == 1)
            {
                ShowCredits();
            }
            if (selectedButton == 0)
            {
                Application.LoadLevel("Controls");
            }
        }
        
	}

    private void ShowCredits()
    {
        GameObject credits = GameObject.Find("Credits");
        if (credits.transform.position.z == 12)
        {
            credits.transform.position = new Vector3(credits.transform.position.x, credits.transform.position.y, -1);
        }
        else 
        {
            credits.transform.position = new Vector3(credits.transform.position.x, credits.transform.position.y, 12);
            isItemSelected = false;
        }
        

    }

}
