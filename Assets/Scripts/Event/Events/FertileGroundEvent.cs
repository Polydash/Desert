using UnityEngine;
using System.Collections;

public class FertileGroundEvent : EventBase
{
    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
        renderer.material.color = Color.gray;
        this.enabled = false;
    }
}
