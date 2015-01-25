using UnityEngine;
using System.Collections;

public class TribeEvent : EventBase
{

    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        switch(choice)
        {
            case 0 :
            case 1 :
                
                player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
                Debug.Log("You win the game.");
                Camera.main.GetComponent<FadeToWithScript>().enabled = true;
                break;
        }

    }

}
