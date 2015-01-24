using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float seuilDeScroll = 0.66f;
    public int Direction { get { return direction; } } 
    private int direction = 0;
    
    private int screenWidth;
    private GameObject[] players;
    private Vector2 movement = new Vector2(0,0);

	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
        screenWidth = Screen.width;
	}

    void LateUpdate()
    {
        if (direction == 0)
        {
            int posPlayers = 0;
            foreach (GameObject ob in players)
            {
                var screenPos = camera.WorldToScreenPoint(ob.transform.position);
                if (screenPos.x > seuilDeScroll * screenWidth)
                {
                    posPlayers++;
                }
                else if (screenPos.x < (1 - seuilDeScroll) * screenWidth)
                {
                    posPlayers--;
                }
            }
            if (posPlayers == (players.Length))
                direction = 1;
            else if (posPlayers == (players.Length * -1))
                direction = -1;
            if (direction != 0)
            {
                GroundLoopScript groundScript = GameObject.Find("Grounds").GetComponent<GroundLoopScript>();
                if (groundScript != null)
                {
                    groundScript.direction = direction;
                    groundScript.enabled = true;
                }
            }
        }
        else
        {
            bool move = true;
            float distance = float.MaxValue;
            foreach (GameObject ob in players)
            {
                var screenPos = camera.WorldToScreenPoint(ob.transform.position);
                if (direction == 1)
                {
                    if (screenPos.x <= seuilDeScroll * screenWidth)
                    {
                        move = false;
                    }
                    else
                    {
                        float newDist =  screenPos.x - (seuilDeScroll * screenWidth);
                        if (newDist < distance)
                        {
                            distance = newDist;
                        }
                    }
                }
                else if (direction == -1)
                {
                    if (screenPos.x >= (1 - seuilDeScroll) * screenWidth)
                    {
                        move = false;
                    }
                    else
                    {
                        float newDist = ((1-seuilDeScroll) * screenWidth) - screenPos.x ;
                        if (newDist < distance)
                        {
                            distance = newDist;
                        }
                    }
                }
            }
            if (move == true)
            {
                var posCam = camera.WorldToScreenPoint(camera.transform.position);
                var mv = camera.ScreenToWorldPoint(new Vector3(posCam.x + (direction*distance), 0.0f, 0.0f));
                movement = new Vector2(mv.x, 0.0f);
                
            }
            else
            {
                movement = new Vector2(transform.position.x, transform.position.y);
            }
            float paralaxSpeed = (movement.x - transform.position.x);
            transform.position = new Vector3(movement.x, transform.position.y, transform.position.z);
            if (move)
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Paralax"))
                {
                    obj.transform.position = new Vector3(obj.transform.position.x + paralaxSpeed * (obj.transform.position.z / 10), obj.transform.position.y, obj.transform.position.z);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 minPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * seuilDeScroll, 0.0f));
        Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * seuilDeScroll, Screen.height));

        Vector3 source = new Vector3(minPos.x, minPos.y);
        Vector3 dest = new Vector3(maxPos.x, maxPos.y);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(source, dest);
    }
}
