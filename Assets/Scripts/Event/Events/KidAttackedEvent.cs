using UnityEngine;
using System.Collections;

public class KidAttackedEvent : EventBase
{
    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        switch(choice)
        {
            case 0 :
                player.GetComponent<PlayerControl>().LoseLife();
                renderer.material.color = Color.grey;
                transform.GetChild(0).renderer.enabled = false;
                this.enabled = false;
                break;

            case 1 :
                player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
                renderer.material.color = Color.grey;
                transform.GetChild(0).renderer.enabled = false;
                this.enabled = false;
                break;
        }
    }
}
