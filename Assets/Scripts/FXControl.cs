using UnityEngine;
using System.Collections;

public class FXControl : MonoBehaviour
{
    private float m_elapsed = 0.0f;
    public float m_maxTime;

    private void Update()
    {
        m_elapsed += Time.deltaTime;
        if(m_elapsed >= m_maxTime)
        {
            Destroy(gameObject);
        }
    }
}
