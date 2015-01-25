using UnityEngine;
using System.Collections;

public class YourteEvent : EventBase {

    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);
        player.GetComponent<PlayerControl>().GainLife();
        renderer.material.color = Color.gray;
        this.enabled = false;
    }
}
