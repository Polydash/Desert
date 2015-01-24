using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float seuilDeScroll = 0.66f;

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
        }
        else
        {
            bool move = true;
            float distance = 0;
            foreach (GameObject ob in players)
            {
                var screenPos = camera.WorldToScreenPoint(ob.transform.position);
                if (direction == 1)
                {
                    if (screenPos.x < seuilDeScroll * screenWidth)
                    {
                        move = false;
                    }
                    else
                    {
                        float newDist =  screenPos.x - (seuilDeScroll * screenWidth);
                        if (newDist < distance || distance == 0)
                        {
                            distance = newDist;
                        }
                    }
                }
                else if (direction == -1)
                {
                    if (screenPos.x > (1 - seuilDeScroll) * screenWidth)
                    {

                        move = false;
                    }
                    else
                    {
                        float newDist = ((1-seuilDeScroll) * screenWidth) - screenPos.x ;
                        if (newDist < distance || distance == 0)
                        {
                            distance = newDist;
                        }
                    }
                }
            }
            if (move == true)
            {
                movement = new Vector2(direction * distance, 0);
            }
            else
            {
                movement = new Vector2(0, 0);
            }
        }
        Camera.main.transform.Translate(new Vector3(movement.x,movement.y, 0.0f));
        //transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, transform.position.z);
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
