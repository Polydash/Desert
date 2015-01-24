using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
	public int m_itemNum = 2;
	private Item[] m_items;

	private void Start()
	{
		m_items = new Item[m_itemNum];
		for(int i=0; i<m_itemNum; i++)
		{
			m_items = null;
		}
	}

	public void SetItem(int i, Item it)
	{
		m_items[i] = it;
	}

	public Item GetItem(int i)
	{
		return m_items[i];
	}

	public void ConsumeItem(int i)
	{
		m_items[i] = null;
	}

	public void ReplaceItem(int i, Item it)
	{
		//TODO(Paul) : Instantiate Event for previous Item
		m_items[i] = it;
	}
}
