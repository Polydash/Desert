using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MenuScript : MonoBehaviour {

    private List<ButtonScript> buttons;
    private int selectedButton;
    private int lastDirection;
	void Start () {
        buttons = new List<ButtonScript>(GetComponentsInChildren<ButtonScript>());
        buttons = buttons.OrderBy(t => t.transform.position.y).ToList();
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

	}

    // Update is called once per frame
    void Update()
    {
        int directionY = Mathf.RoundToInt(Input.GetAxis("P1 Vertical"));
        Debug.Log(directionY);
        if (directionY != lastDirection)
        {
            buttons[selectedButton].Selected = false;
            selectedButton = (selectedButton + directionY) % (buttons.Count);
            if (selectedButton == -1)
                selectedButton = buttons.Count - 1;
            buttons[selectedButton].Selected = true;
            lastDirection = directionY;
        }
        if (Input.GetButtonUp("P1 A"))
        {
            
        }
	}
}
