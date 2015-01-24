using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public float m_speedX;
	public float m_speedY;

	public int m_playerID{get; set;}

	private string m_name;
	private Vector2 m_movement;

	private void Start()
	{
		m_playerID = GameMgr.s_instance.GetNextPlayerID();
		m_name = "P" + m_playerID.ToString();
	}

	private void Update()
	{
		m_movement = new Vector2(Input.GetAxis(m_name + " Horizontal"),
		                         Input.GetAxis(m_name + " Vertical"));
	}

	private void FixedUpdate()
	{
		m_movement = new Vector2(m_movement.x*m_speedX, m_movement.y*m_speedY);
		rigidbody2D.velocity = m_movement*Time.fixedDeltaTime;

		Vector3 minPos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f));
		Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x), 
		                                 Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
		                                 transform.position.z);
	}
}
