using UnityEngine;
using System.Collections;

public class EventMeat : EventBase
{
	protected override void DoChoiceA(GameObject player){ Debug.Log("A"); }
	protected override void DoChoiceB(GameObject player){ Debug.Log("B"); }
	protected override void DoChoiceX(GameObject player){ Debug.Log("X"); }
	protected override void DoChoiceY(GameObject player){ Debug.Log("Y"); }
}
