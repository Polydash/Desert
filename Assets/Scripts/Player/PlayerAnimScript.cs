using UnityEngine;
using System.Collections;

public class PlayerAnimScript : MonoBehaviour {

    public float seuil = 0.01f;
    private bool right = true;
    private PlayerControl playerScript;
	// Use this for initialization
	void Start () {
        playerScript = GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("P" + playerScript.m_playerID + " A") || Input.GetButton("P" + playerScript.m_playerID + " B"))
        {
            GetComponentInChildren<Animator>().SetBool("moving", false);
            GetComponentInChildren<Animator>().SetBool("using", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("using", false);
        }
        if (Mathf.Abs(rigidbody2D.velocity.x) > seuil || Mathf.Abs(rigidbody2D.velocity.y) > seuil)
            {
                if (rigidbody2D.velocity.x < 0 && right)
                {
                    Vector3 scale = GetComponentInChildren<Transform>().localScale;
                    GetComponentInChildren<Transform>().localScale = new Vector3(-scale.x, scale.y, scale.z);
                    right = false;
                }
                else if (rigidbody2D.velocity.x > 0 && !right)
                {
                    Vector3 scale = GetComponentInChildren<Transform>().localScale;
                    GetComponentInChildren<Transform>().localScale = new Vector3(-scale.x, scale.y, scale.z);
                    right = true;
                }
                GetComponentInChildren<Animator>().SetBool("using", false);
                GetComponentInChildren<Animator>().SetBool("moving", true);

            }
            else
            {
                GetComponentInChildren<Animator>().SetBool("moving", false);
            }
        
	}
}
