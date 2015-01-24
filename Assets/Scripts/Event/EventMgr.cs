using UnityEngine;
using System.Collections;

public class EventMgr : MonoBehaviour
{
	private Transform[] m_events;
	private Transform m_currentEvent;

	private void Start()
	{
		m_events = Resources.LoadAll<Transform>("Prefabs/Events");
		NextEvent();
	}

	private void Update()
	{
		if(!m_currentEvent.renderer.isVisible && m_currentEvent.transform.position.x < Camera.main.transform.position.x)
		{
			Destroy(m_currentEvent.gameObject);
			NextEvent();
		}
	}

	private void NextEvent()
	{
		Transform m_eventPrefab = m_events[(int) Random.Range(0, m_events.Length)];

		Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
		Vector3 pos = new Vector3(maxPos.x, transform.position.y);

		m_currentEvent = GameObject.Instantiate(m_eventPrefab, pos, Quaternion.identity) as Transform;
	}
}
