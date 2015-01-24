using UnityEngine;
using System.Collections;

public class EventBase : MonoBehaviour
{
	public enum eButton
	{
		A,
		B,
		X,
		Y
	}
	
	[System.Serializable]
	public struct Choice
	{
		public eButton button;
		public string text;
		public Item.eItemTag[] m_tagList;
	}

	public Choice[] m_choices; 

	private void Start()
	{
		if(m_choices.Length > 4)
		{
			Debug.LogError("Too many choices on event");
			return;
		}

		bool[] buttons = {false, false, false, false};
		for(int i=0; i<buttons.Length; i++)
		{
			if(buttons[(int) m_choices[i].button])
			{
				Debug.LogError("Two choices are mapped on the same button");
			}
			buttons[(int) m_choices[i].button] = true;
		}
	}

	private void Update()
	{
		//Map input
	} 
}
