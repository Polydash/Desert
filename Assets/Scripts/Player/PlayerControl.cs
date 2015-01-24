using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
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
		rigidbody2D.velocity = m_movement;
	}
}
