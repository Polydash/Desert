using UnityEngine;
using System.Collections;

public class ItemEvent : EventBase
{
    public Item m_item;

	protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);

        if(!m_item)
        {
            Debug.LogError("Item to be picked has not been set !");
        }
        else
        {
            if(item)
            {
                player.GetComponent<PlayerInventory>().SetItem(itemIndex, m_item);
            }
        }

        Destroy(gameObject);
    }
}
