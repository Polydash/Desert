using UnityEngine;
using System.Collections;

public class EventMeat : EventBase
{
	protected override void DoChoiceA(GameObject player){ Debug.Log("P" + player.GetComponent<PlayerControl>().m_playerID + " A"); }
	protected override void DoChoiceB(GameObject player){ Debug.Log("P" + player.GetComponent<PlayerControl>().m_playerID + " B"); }
	protected override void DoChoiceX(GameObject player){ Debug.Log("P" + player.GetComponent<PlayerControl>().m_playerID + " X"); }
	protected override void DoChoiceY(GameObject player){ Debug.Log("P" + player.GetComponent<PlayerControl>().m_playerID + " Y"); }
}
