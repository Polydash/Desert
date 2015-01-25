using UnityEngine;
using System.Collections;

public class RescueEvent : EventBase
{
	protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);

        Item flask = Resources.Load<Item>("Prefabs/Items/Flask");
        if(!flask)
        {
            Debug.LogError("Failed to load item");
        }

        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        inventory.ConsumeItem(itemIndex);
        inventory.SetItem(itemIndex, flask);

        Destroy(gameObject);
    }
}
