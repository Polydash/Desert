using UnityEngine;
using System.Collections;

public class EventBase : MonoBehaviour
{
	private GameObject[] m_players;
    private PlayerInventory[] m_inventories;
	private EventData m_data;
    private Item m_handItem;

	protected void Start()
	{
		m_players = GameObject.FindGameObjectsWithTag("Player");
		m_data = GetComponent<EventData>();

        m_inventories = new PlayerInventory[m_players.Length];
        for(int i=0; i < m_inventories.Length; i++)
        {
            m_inventories[i] = m_players[i].GetComponent<PlayerInventory>();
        }
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
				if(Input.GetButtonDown(playerName + "X"))
				{
                    int choice = itemMatching(m_inventories[i].GetItem(0));
                    if(choice >= 0)
                    {
                        DoChoice(m_players[i], m_inventories[i].GetItem(0), choice);
                    }
				}
				else if(Input.GetButtonDown(playerName + "A"))
                {
                    int choice = itemMatching(m_inventories[i].GetItem(1));
                    if(choice >= 0)
                    {
                        DoChoice(m_players[i], m_inventories[i].GetItem(1), choice);
                    }
				}
				else if(Input.GetButtonDown(playerName + "B"))
				{
                    int choice = itemMatching(m_inventories[i].GetItem(2));
                    if(choice >= 0)
                    {
                        DoChoice(m_players[i], m_inventories[i].GetItem(2), choice);
                    }
				}
			}
		}
		else
		{
			//TODO(Paul) : Disable highlighting
			renderer.material.color = Color.white;
		}
	}

    private int itemMatching(Item item)
    {
        if(!item)
        {
            return -1;
        }

        for(int i=0; i < m_data.m_choices.Length; i++)
        {
            int result = item.GetTag();
            for(int j=0; j < m_data.m_choices[i].m_tagList.Length; j++)
            {
                result = result & ((int) m_data.m_choices[i].m_tagList[j]);
            }

            if(result > 0)
            {
                return i;
            }
        }

        return -1;
    }

    protected virtual void DoChoice(GameObject player, Item item, int choice)
    {
         Debug.Log("Event triggered : choice = " + choice.ToString());
    }
}
