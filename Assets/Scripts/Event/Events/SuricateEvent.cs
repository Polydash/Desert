using UnityEngine;
using System.Collections;

public class SuricateEvent : EventBase
{
	protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        switch(choice)
        {
            case 0 :
                GameObject itemEvent = Resources.Load<GameObject>("Prefabs/Events/ItemEvent");
                GameObject meat = Resources.Load<GameObject>("Prefabs/Items/Raw Meat");
                Item it = meat.GetComponent<Item>();
                if(!it)
                {
                    Debug.LogError("Failed to load items");
                }
                player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
                GameObject ie = GameObject.Instantiate(itemEvent, new Vector3(transform.position.x, transform.position.y - (renderer.bounds.size.y / 2), transform.position.z), new Quaternion()) as GameObject;
                (ie.renderer as SpriteRenderer).sprite = (it.renderer as SpriteRenderer).sprite;
                ie.GetComponent<ItemEvent>().m_item = it;
                break;
        }

        Destroy(gameObject);
    }
}
