using UnityEngine;
using System.Collections;

public class BramblesEvent : EventBase
{
    protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        switch(choice)
        {
            case 0 :
                AudioSource eventSoundPlayer = GameObject.Find("EventSoundPlayer").GetComponent<AudioSource>();
                AudioClip obj_machette = Resources.Load<AudioClip>("Sound/Event/objet_machette");
                eventSoundPlayer.clip = obj_machette;
                player.GetComponent<PlayerInventory>().ConsumeItem(itemIndex);
                eventSoundPlayer.volume = 0.2f;
                eventSoundPlayer.Play();
                Destroy(gameObject);
                break;

            case 1 :
                player.GetComponent<PlayerControl>().LoseLife();
                Destroy(gameObject);
                break;
        }
    }
}
