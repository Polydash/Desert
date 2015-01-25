using UnityEngine;
using System.Collections;

public class CartEvent : EventBase
{
	protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);

        Item machette = Resources.Load<Item>("Prefabs/Items/Machete");
        Item pickAxe = Resources.Load<Item>("Prefabs/Items/Pickaxe");

        if(!machette || !pickAxe)
        {
            Debug.LogError("Failed to load items");
        }

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        
        players[0].GetComponent<PlayerInventory>().SetItem(0, machette);
        players[1].GetComponent<PlayerInventory>().SetItem(0, pickAxe);

        renderer.material.color = Color.gray;

        Camera.main.GetComponent<ScrollingScript>().CanScroll = true;
    }
}
