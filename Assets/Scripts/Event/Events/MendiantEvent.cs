using UnityEngine;
using System.Collections;

public class MendiantEvent : EventBase
{
	protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        switch(choice)
        {
            case 0 :
            case 1 :
            case 2 :
            case 3 :
            case 4 :
                { 
                    GameObject itemEvent = Resources.Load<GameObject>("Prefabs/Events/ItemEvent");
                    GameObject artifact = Resources.Load<GameObject>("Prefabs/Items/Artifact");
                    Item it = artifact.GetComponent<Item>();
                    if(!it)
                    {
                        Debug.LogError("Failed to load items");
                    }
                    player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
                    GameObject ie = GameObject.Instantiate(itemEvent, new Vector3(transform.position.x, transform.position.y - (renderer.bounds.size.y / 2), transform.position.z), new Quaternion()) as GameObject;
                    (ie.renderer as SpriteRenderer).sprite = (it.renderer as SpriteRenderer).sprite;
                    ie.GetComponent<ItemEvent>().m_item = it;
                    renderer.material.color = Color.gray;
                    this.enabled = false;
                }
                break;

            case 5 :
            case 6 :
                {
                    GameObject itemEvent = Resources.Load<GameObject>("Prefabs/Events/ItemEvent");
                    GameObject gold = Resources.Load<GameObject>("Prefabs/Items/Gold");
                    Item it = gold.GetComponent<Item>();
                    if(!it)
                    {
                        Debug.LogError("Failed to load items");
                    }

                    if(item.GetTag() != (int) Item.eItemTag.HAND)
                    {
                        player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
                    }
                
                    GameObject ie = GameObject.Instantiate(itemEvent, new Vector3(transform.position.x, transform.position.y - (renderer.bounds.size.y / 2), transform.position.z), new Quaternion()) as GameObject;
                    (ie.renderer as SpriteRenderer).sprite = (it.renderer as SpriteRenderer).sprite;
                    ie.GetComponent<ItemEvent>().m_item = it;
                   
                    Destroy(gameObject);
                }
                break;
        }
    }
}
