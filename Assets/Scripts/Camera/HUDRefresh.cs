using UnityEngine;
using System.Collections;

public class HUDRefresh : MonoBehaviour
{
    private HUDControl m_hud;

    private void Start()
    {
        m_hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDControl>();
    }

    private void OnPreRender()
    {
        m_hud.RefreshHighlight();
    }

    private void OnPostRender()
    {
        m_hud.ResetHighlightState();
    }
}
