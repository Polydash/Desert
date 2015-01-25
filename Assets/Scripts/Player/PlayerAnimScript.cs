using UnityEngine;
using System.Collections;

public class PlayerAnimScript : MonoBehaviour {

    public float seuil = 0.01f;
    private bool right = true;
    private PlayerControl playerScript;
    private GameObject obj;
	// Use this for initialization
	void Start () {
        playerScript = GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("P" + playerScript.m_playerID + " A") || Input.GetButton("P" + playerScript.m_playerID + " B") || Input.GetButton("P" + playerScript.m_playerID + " X"))
        {
            GetComponentInChildren<Animator>().SetBool("moving", false);
            GetComponentInChildren<Animator>().SetBool("using", true);
            int btPressed = 0;
            if (Input.GetButton("P" + playerScript.m_playerID + " A"))
            {
                btPressed = 1;
            }
            if (Input.GetButton("P" + playerScript.m_playerID + " B"))
            {
                btPressed = 2;
            }
            if (!obj)
            {
                if (btPressed == 0 || btPressed == 1)
                {
                    Item it = GetComponent<PlayerInventory>().GetItem(btPressed);
                    if (it)
                    {
                        obj = new GameObject("Item");
                        Vector3 scale = GetComponentInChildren<Transform>().localScale;
                        obj.transform.position = new Vector3(transform.position.x + (0.6f * scale.x), transform.position.y + 0.3f, transform.position.z);
                        
                        obj.transform.localScale = new Vector3(0.7f, 0.7f, obj.transform.localScale.z);
                        obj.AddComponent("SpriteRenderer");
                        (obj.renderer as SpriteRenderer).sprite = it.m_pictogram;
                    }
                }
            }

        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("using", false);
            Destroy(obj);
            obj = null;
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
                if (obj)
                {
                    Destroy(obj);
                    obj = null;
                }
            }
            else
            {
                GetComponentInChildren<Animator>().SetBool("moving", false);
            }
        
	}
}
