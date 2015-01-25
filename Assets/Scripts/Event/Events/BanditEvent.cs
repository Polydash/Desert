using UnityEngine;
using System.Collections;

public class BanditEvent : EventBase
{

    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);
        if (choice == 0 || choice == 1)
        {
            player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);

        }
        if (choice >1)
        {
            player.GetComponent<PlayerControl>().LoseLife();
        }
        Destroy(gameObject);
    }
}
