using UnityEngine;
using System.Collections;

public class EventExample : EventBase
{
    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log("Event triggered : choice = " + choice.ToString());
    }
}
