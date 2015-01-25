using UnityEngine;
using System.Collections;

public class VendorScript : EventBase {

    public Transform outputItem1;
    public Transform outputItem2;
    public Transform outputItem3;

    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);
        if (choice == 0)
        {
            player.GetComponent<PlayerControl>().LoseLife();
            GameObject itemEvent = Resources.Load<GameObject>("Prefabs/Events/ItemEvent");
            Item it = outputItem3.GetComponent<Item>();
            if (!it)
            {
                Debug.LogError("Failed to load items");
            }
            GameObject ie = GameObject.Instantiate(itemEvent, new Vector3(transform.position.x, transform.position.y - (renderer.bounds.size.y / 2), transform.position.z), new Quaternion()) as GameObject;
            (ie.renderer as SpriteRenderer).sprite = (it.renderer as SpriteRenderer).sprite;
            ie.GetComponent<ItemEvent>().m_item = it;
            GameObject fxHit = Resources.Load<GameObject>("Prefabs/FXs/HitFX");
            GameObject.Instantiate(fxHit, transform.position + new Vector3(0.0f, 0.3f), Quaternion.identity);
        }
        if (choice == 1 || choice == 2)
        {
            player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
            player.GetComponent<PlayerInventory>().SetItem(itemIndex, outputItem2.GetComponent<Item>());
        }
        if (choice > 2)
        {
            player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
            player.GetComponent<PlayerInventory>().SetItem(itemIndex, outputItem1.GetComponent<Item>());
        }
        renderer.material.color = Color.gray;
        this.enabled = false;
    }
}
