using UnityEngine;
using System.Collections;

public class AutelEvent : EventBase {

    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);
        player.GetComponent<PlayerControl>().GainLife();
        
        player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);

        GetComponent<Animator>().SetBool("used", true);
        
        this.enabled = false;
    }
	
}
