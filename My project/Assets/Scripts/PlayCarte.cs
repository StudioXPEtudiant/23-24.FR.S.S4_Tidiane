using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCarte : MonoBehaviour
{
	[SerializeField] private string targetTag; 
	[SerializeField] private GameObject CardToPlay;
	
	private GameObject colision;

    void Start()
    {
       
    }

    
    void Update()
    {
      
    }

	private void OnMouseDown()
		{
    		Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				
		}

	private void OnMouseDrag()
		{
    		Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			position.z = 0;
			transform.position = position;
		}

	private void OnCollisionEnter2D(Collision2D collision)
		{
			colision = collision.gameObject;
			
		}

	private void OnMouseUp()
		{
			if (colision != null)
				{
					Vector3 cardPos = CardToPlay.transform.position;

					cardPos.x = colision.transform.position.x;
					cardPos.y = colision.transform.position.y;
					
					CardToPlay.transform.position = cardPos;
				
					colision = null;
                }        							
		}
		
}
