using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	private void Update()
	{
		Debug.Log(new Vector2(Input.GetAxis("P1 Horizontal"), Input.GetAxis("P1 Vertical")));
	}
}
