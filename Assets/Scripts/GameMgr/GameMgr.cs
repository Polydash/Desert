using UnityEngine;
using System.Collections;

public class GameMgr : MonoBehaviour
{
	public static GameMgr s_instance = null;

	[Range(0.0f, 1.0f)]
	public float m_walkableScreenPercentage;

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

	private void OnDrawGizmosSelected()
	{
		Vector3 minPos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f));
		Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
		maxPos.y *= (m_walkableScreenPercentage*2.0f - 1.0f);

		Vector3 source = new Vector3(minPos.x, maxPos.y);
		Vector3 dest = new Vector3(maxPos.x, maxPos.y);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(source, dest);
	}
}
