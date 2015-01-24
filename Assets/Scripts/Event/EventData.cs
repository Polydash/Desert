using UnityEngine;
using System.Collections;

public class EventData : MonoBehaviour
{
	[System.Serializable]
	public struct Choice
	{
		public string text;
		public Item.eItemTag[] m_tagList;
	}

	public Vector2 m_hitbox;
	public Choice[] m_choices; 

	private void OnDrawGizmosSelected()
	{
		float minX = transform.position.x - m_hitbox.x/2.0f;
		float maxX = transform.position.x + m_hitbox.x/2.0f;
		float minY = transform.position.y - m_hitbox.y/2.0f;
		float maxY = transform.position.y + m_hitbox.y/2.0f;
		
		Gizmos.color = Color.red;
		
		Gizmos.DrawLine(new Vector3(minX, minY), new Vector3(minX, maxY));
		Gizmos.DrawLine(new Vector3(minX, minY), new Vector3(maxX, minY));
		Gizmos.DrawLine(new Vector3(maxX, maxY), new Vector3(maxX, minY));
		Gizmos.DrawLine(new Vector3(maxX, maxY), new Vector3(minX, maxY));
	}
}
