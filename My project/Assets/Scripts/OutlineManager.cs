using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutlineManager : MonoBehaviour
{
    [SerializeField] private GameObject ActivateOutline;

	private bool CanOutline;	

    void Start()
    {
        CanOutline = true;
    }

    
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
		if(CanOutline == true)
		{
	        ActivateOutline.SetActive(true);
	    	
		}
    }

    private void OnMouseExit()
    {
        ActivateOutline.SetActive(false);
    }
    
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Plateau")
		{
			CanOutline = false;
		}
	}



}
