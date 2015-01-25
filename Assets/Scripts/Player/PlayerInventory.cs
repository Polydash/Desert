using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
	public int m_itemNum;
	private Item[] m_items;

	private void Start()
	{
		m_items = new Item[m_itemNum];
		for(int i=0; i<m_itemNum; i++)
		{
			m_items[i] = null;
		}

        m_items[m_itemNum-1] = Resources.Load<Item>("Prefabs/Items/Hand");
	}

	public void SetItem(int i, Item it)
	{
        if(m_items[i])
        {
            GameObject itemEvent = Resources.Load<GameObject>("Prefabs/Events/ItemEvent");
            Item droppedItem = m_items[i];
            GameObject ie = GameObject.Instantiate(itemEvent, new Vector3(transform.position.x - 1.2f, transform.position.y - 0.5f, transform.position.z), new Quaternion()) as GameObject;
            (ie.renderer as SpriteRenderer).sprite = (droppedItem.renderer as SpriteRenderer).sprite;
            ie.GetComponent<ItemEvent>().m_item = droppedItem;
        }
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
}
