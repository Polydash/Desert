using UnityEngine;
using System.Collections;

public class GameMgr : MonoBehaviour
{
	public static GameMgr s_instance = null;

	private int m_playerID = 0;

	private void Awake()
	{
		if(s_instance)
		{
			Debug.LogError("Multiple instances of GameMgr");
		}

		s_instance = this;
	}

	public int GetNextPlayerID()
	{
		return ++m_playerID;
	}
}
