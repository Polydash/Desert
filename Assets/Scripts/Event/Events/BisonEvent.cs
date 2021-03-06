﻿using UnityEngine;
using System.Collections;

public class BisonEvent : EventBase {

    public Transform outputItem1;
    public Transform outputItem2;

    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);
        if (choice == 0)
        {
            GameObject itemEvent = Resources.Load<GameObject>("Prefabs/Events/ItemEvent");
            Item it = outputItem1.GetComponent<Item>();
            if (!it)
            {
                Debug.LogError("Failed to load items");
            }
            GameObject ie = GameObject.Instantiate(itemEvent, new Vector3(transform.position.x, transform.position.y - (renderer.bounds.size.y / 2), transform.position.z), new Quaternion()) as GameObject;
            (ie.renderer as SpriteRenderer).sprite = (it.renderer as SpriteRenderer).sprite;
            ie.GetComponent<ItemEvent>().m_item = it;
        }
        if (choice == 1)
        {
            player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
            player.GetComponent<PlayerInventory>().SetItem(itemIndex, outputItem2.GetComponent<Item>());
        }
        renderer.material.color = Color.gray;
        this.enabled = false;
    }
}
