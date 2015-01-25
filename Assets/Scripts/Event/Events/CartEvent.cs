using UnityEngine;
using System.Collections;

public class CartEvent : EventBase
{
    private AudioSource eventSoundPlayer;
    private AudioClip inv_pickaxe;

	protected override void DoChoice(GameObject player, Item item, int itemIndex, int choice)
    {
        Debug.Log(m_data.m_choices[choice].text);

        eventSoundPlayer = GameObject.Find("EventSoundPlayer").GetComponent<AudioSource>();
        Item machette = Resources.Load<Item>("Prefabs/Items/Machete");
        AudioClip inv_machette = Resources.Load<AudioClip>("Sound/Event/Inventaire_machette");
        Item pickAxe = Resources.Load<Item>("Prefabs/Items/Pickaxe");
        inv_pickaxe = Resources.Load<AudioClip>("Sound/Event/Inventaire_pioche_01");

        if(!machette || !pickAxe)
        {
            Debug.LogError("Failed to load items");
        }

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        
        players[0].GetComponent<PlayerInventory>().SetItem(0, machette);
        eventSoundPlayer.clip = inv_machette;
        eventSoundPlayer.volume = 0.2f;
        eventSoundPlayer.Play();

        players[1].GetComponent<PlayerInventory>().SetItem(0, pickAxe);
        Invoke("playPickAxeSound", 0.6f);

        renderer.material.color = Color.gray;

        Camera.main.GetComponent<ScrollingScript>().CanScroll = true;
    }

    private void playPickAxeSound()
    {
        if (eventSoundPlayer != null && inv_pickaxe != null)
        {
            eventSoundPlayer.clip = inv_pickaxe;
            eventSoundPlayer.volume = 0.2f;
            eventSoundPlayer.Play();
        }
    }
}
