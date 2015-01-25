using UnityEngine;
using System.Collections;

public class TreeEvent : EventBase {

    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        GameObject itemEvent = Resources.Load<GameObject>("Prefabs/Events/ItemEvent");
        Item baton = Resources.Load<Item>("Prefabs/Items/Spear");
        if (!baton)
        {
            Debug.LogError("Failed to load items");
        }

        //itemEvent.m_item = baton;
        GameObject ie = GameObject.Instantiate(itemEvent, new Vector3(transform.position.x, transform.position.y - (renderer.bounds.size.y / 2), transform.position.z), new Quaternion()) as GameObject;
        (ie.renderer as SpriteRenderer).sprite = (baton.renderer as SpriteRenderer).sprite;
        ie.GetComponent<ItemEvent>().m_item = baton;
        
        renderer.material.color = Color.gray;

        this.enabled = false;
    }
}
