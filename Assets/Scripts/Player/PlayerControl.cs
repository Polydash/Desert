using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	private int m_playerID = 0;
	private string m_name;

	private void Start()
	{
		m_playerID = GameMgr.s_instance.GetNextPlayerID();
		m_name = "P" + m_playerID.ToString();
	}

	private void Update()
	{
	}
}
