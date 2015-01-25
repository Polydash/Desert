using UnityEngine;
using System.Collections;

public class DescriptionSpawn : MonoBehaviour
{
    private float m_elapsed = 0.0f;
    private Vector3 m_target;
    private float m_fade = 0.0f;

    public float m_maxTime;
    public float m_distance;

    [Range(0.0f, 1.0f)]
    public float m_speed;

    public float m_fadeSpeed;
	
    private void Start()
    {
        m_target = transform.position;
        m_target += new Vector3(0.0f, m_distance);
    }

	private void Update()
    {
        m_elapsed += Time.deltaTime;
	    if(m_elapsed > m_maxTime)
        {
            m_fade -= m_fadeSpeed * Time.deltaTime;
            if(m_fade <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Color c = renderer.material.color;
                renderer.material.color = new Color(c.r, c.g, c.b, m_fade);
            }
        }
        else
        {
            m_fade += m_fadeSpeed * Time.deltaTime;
            if(m_fade >= 1.0f)
            {
                m_fade = 1.0f;
            }
            Color c = renderer.material.color;
            renderer.material.color = new Color(c.r, c.g, c.b, m_fade);
        }

        Vector3 distance = m_target - transform.position; 
        transform.position += m_speed * distance;
	}
}
