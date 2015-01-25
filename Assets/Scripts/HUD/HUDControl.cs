using UnityEngine;
using System.Collections;

public class HUDControl : MonoBehaviour
{
	public struct PlayerHUD
	{
		public Transform hudBackground;
		public Transform[] hudPictograms;
	}

	public PlayerInventory[] m_inventories;
	PlayerHUD[] m_playerHUD;
	public Vector2 margin;

	private void Start()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		m_inventories = new PlayerInventory[players.Length];
		m_playerHUD = new PlayerHUD[players.Length];

		for(int i=0; i<players.Length; i++)
		{
			m_inventories[i] = players[i].GetComponent<PlayerInventory>();
			m_playerHUD[i].hudBackground = transform.GetChild(i);
			m_playerHUD[i].hudPictograms = new Transform[players.Length];
			for(int j=0; j<players.Length; j++)
			{
				m_playerHUD[i].hudPictograms[j] = m_playerHUD[i].hudBackground.GetChild(j);
			}
		}
	}

	private void LateUpdate()
	{
		Vector3 minPos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f));
		Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

		m_playerHUD[0].hudBackground.position = new Vector3(minPos.x + margin.x, minPos.y - margin.y);
		m_playerHUD[1].hudBackground.position = new Vector3(maxPos.x - margin.x, minPos.y -	 margin.y);

		for(int i=0; i<m_playerHUD.Length; i++)
		{
			for(int j=0; j<m_playerHUD.Length; j++)
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
}
