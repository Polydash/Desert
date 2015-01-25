using UnityEngine;
using System.Collections;

public class BramblesEvent : EventBase
{
    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);
        player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);

        Destroy(gameObject);
    }
}
