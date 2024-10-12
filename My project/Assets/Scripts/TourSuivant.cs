using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourSuivant : MonoBehaviour
{
	public Pioche pioche;
    void Start()
    {
     
    }

    
    void Update()
    {
        
    }

    public void NextTour()
    {
	    pioche.CanGiveCard = true;
	    Debug.Log("true");
    }
    
 
}
