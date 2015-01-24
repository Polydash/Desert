using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GroundLoopScript : MonoBehaviour {

    public int direction { get; set; }

    private List<Transform> groundPart;
  
	// Use this for initialization
	void Start () {
	groundPart = new List<Transform>();
			
			for (int i = 0; i < transform.childCount; i++)
			{
                
				Transform child = transform.GetChild(i);
				
				if (child.renderer != null)
				{
					groundPart.Add(child);
				}
			}
            
            groundPart = groundPart.OrderBy(
                    t => t.position.x
                    ).ToList();
            if (direction == -1)
            {
                groundPart.Reverse();

            }
	}
	
	// Update is called once per frame
	void Update () {
        Transform firstChild = groundPart.First();

        if (firstChild != null)
        {
            // Premier test sur la position de l'objet
            // Cela évite d'appeler directement IsVisibleFrom
            // qui est assez lourde à exécuter
            if (direction == 1)
            {
                Vector3 firstChildPos = new Vector3(firstChild.position.x + (firstChild.renderer.bounds.size.x / 2), firstChild.position.y, firstChild.position.x);
                Vector3 firstChildPosPix = Camera.main.WorldToScreenPoint(firstChildPos);
                if (firstChildPosPix.x <= 0)
                {
                    // On récupère le dernier élément de la liste
                    Transform lastChild = groundPart.LastOrDefault();

                    // On calcule ainsi la position à laquelle nous allons replacer notre morceau
                    Vector3 lastPosition = lastChild.transform.position;
                    Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

                    // On place le morceau tout à la fin
                    // Note : ne fonctionne que pour un scorlling horizontal
                    firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);

                    // On met à jour la liste (le premier devient dernier)
                    groundPart.Remove(firstChild);
                    groundPart.Add(firstChild);
                }
            }
            else if(direction == -1)
            {
                Vector3 firstChildPos = new Vector3(firstChild.position.x - (firstChild.renderer.bounds.size.x / 2), firstChild.position.y, firstChild.position.x);
                Vector3 firstChildPosPix = Camera.main.WorldToScreenPoint(firstChildPos);
                if (firstChildPosPix.x > Screen.width)
                {
                    // On récupère le dernier élément de la liste
                    Transform lastChild = groundPart.LastOrDefault();

                    // On calcule ainsi la position à laquelle nous allons replacer notre morceau
                    Vector3 lastPosition = lastChild.transform.position;
                    Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

                    // On place le morceau tout à la fin
                    // Note : ne fonctionne que pour un scorlling horizontal
                    firstChild.position = new Vector3(lastPosition.x - lastSize.x, firstChild.position.y, firstChild.position.z);

                    // On met à jour la liste (le premier devient dernier)
                    groundPart.Remove(firstChild);
                    groundPart.Add(firstChild);
                }
            }
        }
	}
}
