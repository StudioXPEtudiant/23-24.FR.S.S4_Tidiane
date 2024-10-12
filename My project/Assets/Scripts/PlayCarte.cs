using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCarte : MonoBehaviour
{

	[SerializeField] private GameObject CardToPlay;
	[SerializeField] private GameObject[] PositionCarteSurLePlateau;
	
	
    void Start()
    {
     
    }

    
    void Update()
    {
        
    }

    void OnMouseDown()
    {
		if (CardToPlay.tag == "card")
			{
		     
    		}	
	}
}
//if (Input.GetButtonDown("Fire1"))
			//{
				//Vector3 mousePos = Input.mousePosition;
				//{
						
					//}			
			//}   