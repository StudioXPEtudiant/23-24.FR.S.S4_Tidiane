using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCarte : MonoBehaviour
{
	[SerializeField] private string targetTag; 
	[SerializeField] private GameObject CardToPlay;
	

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

	 void OnCollisionEnter2D(Collision2D collision)
		{
			//if (collision.gameObject.CompareTag("targetTag"))
				//{
					Debug.Log("w");
				//}
		}
}
//CardToPlay.