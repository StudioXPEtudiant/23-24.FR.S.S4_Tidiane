using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCarte : MonoBehaviour
{
	[SerializeField] private string targetTag; 
	[SerializeField] private GameObject CardToPlay;
	
	private GameObject colision;
	private Vector2 Saved;	
	private bool PosCard;
	private bool CanMoveCard;

    void Start()
    {
      Saved = transform.position;
	  PosCard = true;
	  CanMoveCard = true;
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
			if (CardToPlay.gameObject.tag == "card")
				{
					if (CanMoveCard == true)
						{
    						Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
							position.z = 0;
							transform.position = position;
						}
				}
		}

	private void OnCollisionEnter2D(Collision2D collision)
		{
			colision = collision.gameObject;

			if (collision.gameObject.tag == "card")
				{
					colision = null;
				}
		}

	private void OnMouseUp()
		{
			if (CardToPlay.gameObject.tag == "card")
				{
					if (colision != null)
						{
							if (CanMoveCard == true)
								{
									Vector3 cardPos = CardToPlay.transform.position;

									cardPos.x = colision.transform.position.x;
									cardPos.y = colision.transform.position.y;
					
									CardToPlay.transform.position = cardPos;
				
									colision = null;
									PosCard = false;
									CanMoveCard = false;
								}
               			}        

			if (PosCard == true)
				{
					CardToPlay.transform.position = Saved;	
				}								
		}
	}
}
