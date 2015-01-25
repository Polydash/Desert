using UnityEngine;
using System.Collections;

public class HUDControl : MonoBehaviour
{
	public struct PlayerHUD
	{
		public Transform hudBackground;
		public Transform[] hudPictograms;
        public bool[] highlight;
	}

    public Transform[] m_lifeHUD;
	public PlayerInventory[] m_inventories;
	PlayerHUD[] m_playerHUD;
	public Vector2 margin;
    public Sprite[] m_P1State;
    public Sprite[] m_P2State;

	private void Start()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		m_inventories = new PlayerInventory[players.Length];
		m_playerHUD = new PlayerHUD[players.Length];
        m_lifeHUD = new Transform[players.Length];

		for(int index=0; index<players.Length; index++)
		{
            int i=players[index].GetComponent<PlayerControl>().m_playerID-1;

			m_inventories[i] = players[index].GetComponent<PlayerInventory>();
			m_playerHUD[i].hudBackground = transform.GetChild(i);
			m_playerHUD[i].hudPictograms = new Transform[m_inventories[i].m_itemNum];
			m_playerHUD[i].highlight = new bool[m_inventories[i].m_itemNum];
            for(int j=0; j < m_inventories[i].m_itemNum; j++)
			{
				m_playerHUD[i].hudPictograms[j] = m_playerHUD[i].hudBackground.GetChild(j);
                m_playerHUD[i].highlight[j] = false;
			}
            m_lifeHUD[i] = m_playerHUD[i].hudBackground.GetChild(m_inventories[i].m_itemNum);
		}

        UpdateLife(0, 2);
        UpdateLife(1, 2);
	}

	private void LateUpdate()
	{
		Vector3 minPos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f));
		Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        m_playerHUD[0].hudBackground.position = new Vector3(minPos.x + margin.x, minPos.y - margin.y);
        m_playerHUD[1].hudBackground.position = new Vector3(maxPos.x - margin.x, minPos.y - margin.y);

		for(int i=0; i<m_playerHUD.Length; i++)
		{
			for(int j=0; j<m_inventories[i].m_itemNum; j++)
			{
				Item item = m_inventories[i].GetItem(j);
				SpriteRenderer pictoRenderer = m_playerHUD[i].hudPictograms[j].GetComponent<SpriteRenderer>();

				if(item != null)
				{
					pictoRenderer.sprite = item.m_pictogram;
					pictoRenderer.enabled = true;
				}
				else
				{
					pictoRenderer.enabled = false;
				}
			}
		}
	}

    public void UpdateLife(int playerID, int lifePoints)
    {
        if(playerID == 0)
        {
            m_lifeHUD[playerID].GetComponent<SpriteRenderer>().sprite = m_P1State[lifePoints];
        }
        else
        {
            m_lifeHUD[playerID].GetComponent<SpriteRenderer>().sprite = m_P2State[lifePoints];
        }
    }

    public void Highlight(int player, int item)
    {
        m_playerHUD[player].highlight[item] = true;
    }

    public void RefreshHighlight()
    { 
        for(int i=0; i<m_playerHUD.Length; i++)
	    {
            for(int j=0; j<m_inventories[i].m_itemNum; j++)
			{
                SpriteRenderer spriteRenderer = m_playerHUD[i].hudPictograms[j].GetComponent<SpriteRenderer>();
                if(spriteRenderer.material.color == Color.gray && m_playerHUD[i].highlight[j])
                {
                    spriteRenderer.material.color = Color.white;
                }
                else if(spriteRenderer.material.color == Color.white && !m_playerHUD[i].highlight[j])
                {
                    spriteRenderer.material.color = Color.gray;
                }
            }
        }
    }

    public void ResetHighlightState()
    {
        for(int i=0; i<m_playerHUD.Length; i++)
	    {
            for(int j=0; j<m_inventories[i].m_itemNum; j++)
			{
                m_playerHUD[i].highlight[j] = false;
            }
        }
    }
}
