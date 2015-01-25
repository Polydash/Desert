using UnityEngine;
using System.Collections;

public class IguaneEvent : EventBase
{

    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);
        if (choice == 0 || choice == 1 || choice == 2)
        {
            player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
            GameObject fxHit = Resources.Load<GameObject>("Prefabs/FXs/HitFX");
            GameObject.Instantiate(fxHit, transform.position + new Vector3(0.0f, 0.3f), Quaternion.identity);

        }
        if (choice > 2)
        {
            player.GetComponent<PlayerControl>().LoseLife();
        }
        Destroy(gameObject);
    }
}
