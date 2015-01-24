using UnityEngine;
using System.Collections;

public class HUDControl : MonoBehaviour
{
	public Vector2 margin;

	private void Update()
	{
		Vector3 minPos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f));
		Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

		Transform[] HUD = {transform.GetChild(0), transform.GetChild(1)};
		HUD[0].position = new Vector3(minPos.x + margin.x, minPos.y - margin.y);
		HUD[1].position = new Vector3(maxPos.x - margin.x, minPos.y - margin.y);
	}
}
