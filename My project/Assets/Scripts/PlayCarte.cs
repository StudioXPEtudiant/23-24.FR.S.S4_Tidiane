using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCarte : MonoBehaviour
{
	[SerializeField] private string targetTag; 
	[SerializeField] private bool[] IfCard;	
	[SerializeField] private Vector2 origin;
	
	

	public RaycastHit2D hit;
	public string Tag;
	public AttackScript attackScript;
	public GameObject CardToPlay;
	public bool CanMove;

	private GameObject colision;
	private Vector2 Saved;	
	private bool PosCard;
	private bool CanMoveCard;

    void Start()
    {
      Saved = transform.position;
	  PosCard = true;
	  CanMoveCard = true;
	CanMove = false;
    }

    
    void Update()
    {
	if (CanMoveCard == false)
		{			
			origin = (Vector2)transform.position + new Vector2 (0,1);

			hit = Physics2D.Raycast(origin, Vector2.up, 3);
            Debug.DrawRay(origin, Vector2.up * 3, Color.red);



		//if (hit.collider != null)
			//{
            	//if (hit.transform.gameObject.tag == Tag)
            		//{
            			
               		//}
			//}
		}	
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

			if (collision.gameObject.tag == "EnnemiCard")
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
									CanMove = true;	
									Vector3 cardPos = CardToPlay.transform.position;

									cardPos.x = colision.transform.position.x;
									cardPos.y = colision.transform.position.y;
					
									CardToPlay.transform.position = cardPos;
				
									//PlayerPlayCarte.Add(CardToPlay);									

									//attackScript.CanMakeDamage = true;
	


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
