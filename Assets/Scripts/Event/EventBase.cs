﻿using UnityEngine;
using System.Collections;

public abstract class EventBase : MonoBehaviour
{
	private GameObject[] m_players;
	public Rect m_hitbox;

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

	protected void Start()
	{
		m_players = GameObject.FindGameObjectsWithTag("Player");

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

	protected void Update()
	{
		bool shown = false;

		for(int i=0; i<m_players.Length; i++)
		{
			float posX = m_players[i].transform.position.x;
			float posY = m_players[i].transform.position.y;
			if(posX > m_hitbox.x - m_hitbox.width/2.0f && posX < m_hitbox.x + m_hitbox.width/2.0f &&
			   posY > m_hitbox.y - m_hitbox.height/2.0f && posY < m_hitbox.y + m_hitbox.height/2.0f)
			{
				//TODO(Paul) : Show menu
				renderer.material.color = Color.red;
				shown = true;
			}
			else
			{
				//TODO(Paul) : Hide menu
				renderer.material.color = Color.white;
				shown = false;
			}
		}

		if(shown)
		{
			for(int i=0; i<m_players.Length; i++)
			{
				string playerName = "P" + (i+1).ToString() + " ";
				if(Input.GetButtonDown(playerName + "A"))
				{
					DoChoiceA(m_players[i]);
				}
				else if(Input.GetButtonDown(playerName + "B"))
				{
					DoChoiceB(m_players[i]);
				}
				else if(Input.GetButtonDown(playerName + "X"))
				{
					DoChoiceX(m_players[i]);
				}
				else if(Input.GetButtonDown(playerName + "Y"))
				{
					DoChoiceY(m_players[i]);
				}
			}
		}
	}

	protected virtual void DoChoiceA(GameObject player){}
	protected virtual void DoChoiceB(GameObject player){}
	protected virtual void DoChoiceX(GameObject player){}
	protected virtual void DoChoiceY(GameObject player){}
}
