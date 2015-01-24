using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public float m_speedX;
	public float m_speedY;

	public int m_playerID{get; set;}

	private string m_name;

	private void Start()
	{
		m_playerID = GameMgr.s_instance.GetNextPlayerID();
		m_name = "P" + m_playerID.ToString();
		gameObject.layer = LayerMask.NameToLayer(m_name);
	}

	private void FixedUpdate()
	{
		Vector2 movement = new Vector2(Input.GetAxis(m_name + " Horizontal"),
		                         	   Input.GetAxis(m_name + " Vertical"));

		movement.x *= m_speedX * Time.fixedDeltaTime;
		movement.y *= m_speedY * Time.fixedDeltaTime;

		rigidbody2D.velocity = movement;

		Vector3 minPos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f));
		Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

		float topScreen = maxPos.y;
		maxPos.y *= (GameMgr.s_instance.m_walkableScreenPercentage * 2.0f - 1.0f);

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x), 
		                                 Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
		                                 Mathf.Clamp(transform.position.y, minPos.y, maxPos.y)/topScreen);
	}
}
