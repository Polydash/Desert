using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	public string m_name;
	public enum eItemTag : int
	{
		WEAPON = 0x00000001 << 0,
		HEALING = 0x00000001 << 1,
		HURTING = 0x00000001 << 2
	}

	public eItemTag[] m_tagList;
	protected int m_tag;

	protected void Start()
	{
		for(int i=0; i<m_tagList.Length; i++)
		{
			m_tag = m_tag | (int) m_tagList[i];
		}
	}
}
