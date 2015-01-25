using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour
{
    void Update()
    {
	    if(Input.GetButtonDown("P1 A") || Input.GetButtonDown("P1 X") || Input.GetButtonDown("P1 B"))
        {
            Application.LoadLevel("Prototype");
        }
    }
}
