using UnityEngine;
using System.Collections;

public class EndinfScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Invoke("showCredits", 3.0f);
        Invoke("goToMainMenu", 8.0f);
	}
	
    private void showCredits()
    {
        GameObject.Find("ECRAN_CREDITS").renderer.sortingOrder += 2;
    }

    private void goToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
