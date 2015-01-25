using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public float m_speedX;
	public float m_speedY;

	public int m_playerID;

    public int m_playerLife{get; set;}
	private string m_name;
    private HUDControl m_hud;

	private void Start()
	{
		m_name = "P" + m_playerID.ToString();
		gameObject.layer = LayerMask.NameToLayer(m_name);
        m_playerLife = 2;
        m_hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDControl>();
        m_hud.UpdateLife(m_playerLife);
	}

	private void FixedUpdate()
	{
		Vector2 movement = new Vector2(Input.GetAxis(m_name + " Horizontal"),
		                         	   Input.GetAxis(m_name + " Vertical"));

		movement.x *= m_speedX * Time.fixedDeltaTime;
		movement.y *= m_speedY * Time.fixedDeltaTime;

		rigidbody2D.velocity = movement;

		Vector3 minPos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f));
		Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

		float topScreen = maxPos.y;
		maxPos.y *= (GameMgr.s_instance.m_topWalkableScreenPercentage * 2.0f - 1.0f);
		minPos.y *= (GameMgr.s_instance.m_bottomWalkableScreenPercentage * -2.0f + 1.0f);

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x), 
		                                 Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
		                                 Mathf.Clamp(transform.position.y, minPos.y, maxPos.y)/topScreen);
	}

    public void LoseLife()
    {
        m_playerLife--;
        if(m_playerLife <= 0)
        {
            //Player death
            m_hud.UpdateLife(0);
        }
        else
        {
            m_hud.UpdateLife(m_playerLife);
        }
    }

    public void GainLife()
    {
        m_playerLife++;
        if(m_playerLife > 2)
        {
            m_playerLife = 2;
        }

        m_hud.UpdateLife(m_playerLife);
    }
}
