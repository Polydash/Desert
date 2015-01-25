using UnityEngine;
using System.Collections;

public class DropItemEvent : EventBase {

    public Transform m_item;
    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);
        GameObject itemEvent = Resources.Load<GameObject>("Prefabs/Events/ItemEvent");
        Item it = m_item.GetComponent<Item>();
        if (!it)
        {
            Debug.LogError("Failed to load items");
        }
        GameObject ie = GameObject.Instantiate(itemEvent, new Vector3(transform.position.x, transform.position.y - (renderer.bounds.size.y / 2), transform.position.z), new Quaternion()) as GameObject;
        (ie.renderer as SpriteRenderer).sprite = (it.renderer as SpriteRenderer).sprite;
        ie.GetComponent<ItemEvent>().m_item = it;
        
        renderer.material.color = Color.gray;

        this.enabled = false;
    }
}
