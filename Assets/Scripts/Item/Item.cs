﻿using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	public enum eItemTag : int
	{
		HEALING = 0x00000001 << 0,
		FOOD = 0x00000001 << 1,
		WEAPON = 0x00000001 << 2,
		SEED = 0x00000001 << 3,
		LIQUID = 0x00000001 << 4,
		VALUABLE = 0x00000001 << 5,
		CURRENCY = 0x00000001 << 6,
		MASK = 0x00000001 << 7,
		ARTEFACT = 0x00000001 << 8,
		CONTAINER = 0x00000001 << 9,
		TOOL = 0x00000001 << 10
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