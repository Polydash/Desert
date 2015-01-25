using UnityEngine;
using System.Collections;

public class RescueEvent : EventBase
{
	protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);
        AudioSource eventSoundPlayer = GameObject.Find("EventSoundPlayer").GetComponent<AudioSource>();
        AudioClip obj_machette = Resources.Load<AudioClip>("Sound/Event/Objet_pioche");
        eventSoundPlayer.clip = obj_machette;
        Item flask = Resources.Load<Item>("Prefabs/Items/Flask");
        if(!flask)
        {
            Debug.LogError("Failed to load item");
        }

        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        inventory.ConsumeItem(itemIndex);
        inventory.SetItem(itemIndex, flask);
        eventSoundPlayer.volume = 0.2f;
        eventSoundPlayer.Play();

        GameObject fxHit = Resources.Load<GameObject>("Prefabs/FXs/HitFX");
        GameObject.Instantiate(fxHit, transform.position + new Vector3(0.0f, 0.3f), Quaternion.identity);

        Destroy(gameObject);
    }
}
