using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	public Sprite m_pictogram;

	public enum eItemTag : int
	{
		HEALING = 	0x00000001 << 0,
		FOOD = 		0x00000001 << 1,
		WEAPON = 	0x00000001 << 2,
		SEED = 		0x00000001 << 3,
		LIQUID = 	0x00000001 << 4,
		VALUABLE = 	0x00000001 << 5,
		CURRENCY = 	0x00000001 << 6,
		MASK = 		0x00000001 << 7,
		ARTEFACT = 	0x00000001 << 8,
		CONTAINER = 0x00000001 << 9,
		TOOL = 		0x00000001 << 10,
		BRAMBLES = 	0x00000001 << 11,
		PRISONER = 	0x00000001 << 12,
		HAND = 		0x00000001 << 13,
        RAW_MEAT =  0x00000001 << 14,
        MEAT = 0x00000001 << 15
	}

	public eItemTag[] m_tagList;
    private int m_tag;

    public int GetTag()
    {
        if(m_tag == 0 && m_tagList.Length > 0)
        {
            for(int i=0; i<m_tagList.Length; i++)
		    {
			    m_tag = m_tag | (int) m_tagList[i];
		    }
        }

        return m_tag;
    }
}
