using UnityEngine;
using System.Collections;

public class EventBase : MonoBehaviour
{
	private GameObject[] m_players;
	private EventData m_data; 

	protected void Start()
	{
		m_players = GameObject.FindGameObjectsWithTag("Player");
		m_data = GetComponent<EventData>();
	}

	protected void Update()
	{
		bool shown = false;

		for(int i=0; i<m_players.Length; i++)
		{
			float posX = m_players[i].transform.position.x;
			float posY = m_players[i].transform.position.y;
			if(posX > transform.position.x - m_data.m_hitbox.x/2.0f && posX < transform.position.x + m_data.m_hitbox.x/2.0f &&
			   posY > transform.position.y - m_data.m_hitbox.y/2.0f && posY < transform.position.y + m_data.m_hitbox.y/2.0f)
			{
				shown = true;
			}
		}

		if(shown)
		{
			//TODO(Paul) : Highlight options
			renderer.material.color = Color.red;

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
		else
		{
			//TODO(Paul) : Disable highlighting
			renderer.material.color = Color.white;
		}
	}

	protected virtual void DoChoiceA(GameObject player){}
	protected virtual void DoChoiceB(GameObject player){}
	protected virtual void DoChoiceX(GameObject player){}
	protected virtual void DoChoiceY(GameObject player){}
}
