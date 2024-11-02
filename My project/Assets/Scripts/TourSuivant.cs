using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourSuivant : MonoBehaviour
{
	public Pioche pioche;
	public PiocheEnnemi piocheEnnemi;	

    void Start()
    {
     
    }

    
    void Update()
    {
        
    }

    public void NextTour()
    {
	    pioche.CanGiveCard = true;

    }

	public void NextTourEnnemi()
	{
		piocheEnnemi.CanGiveCard = true;
	}
    
 
}
