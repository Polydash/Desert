using UnityEngine;
using System.Collections;

public class WaterEvent : EventBase {

    public Transform outputItem;
    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);
        if (choice == 0)
        {
            player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
            player.GetComponent<PlayerInventory>().SetItem(itemIndex,outputItem.GetComponent<Item>());
        }
        if (choice == 1)
        {
            player.GetComponent<PlayerControl>().GainLife();
        }

        renderer.material.color = Color.gray;

        this.enabled = false;
    }
}
