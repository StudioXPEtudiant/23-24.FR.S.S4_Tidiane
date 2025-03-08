using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreDeVieManager : MonoBehaviour
{
	[SerializeField] private float HealthBarLifePlayer;
	[SerializeField] private float HealthBarLifeEnnemi;
	
	[SerializeField] private Slider PlayerHealthBar;
	[SerializeField] private Slider EnnemiHealthBar;

	[SerializeField] private float HealthBarDamageEnnemi;
	[SerializeField] private float HealthBarDamagePlayer;	

	public bool CanActualiseHealthBarEnnemi;
	public bool CanActualiseHealthBarPlayer;		

    void Start()
    {
	    CanActualiseHealthBarEnnemi = false;
		CanActualiseHealthBarPlayer = false;

	if(PlayerHealthBar != null)
		{
			PlayerHealthBar.maxValue = HealthBarLifePlayer;
	    	PlayerHealthBar.value = HealthBarLifePlayer;
	    }

		if(EnnemiHealthBar != null)
			{
	    		EnnemiHealthBar.maxValue = HealthBarLifeEnnemi;
	    		EnnemiHealthBar.value = HealthBarLifeEnnemi;
	    	}
    }

    
    void Update()
    {
	   
    }

    public void ActualiseHealthBarPlayer()
    {
	    if (CanActualiseHealthBarPlayer == true)
		{
	   		HealthBarLifePlayer -= HealthBarDamagePlayer;
			PlayerHealthBar.value = HealthBarLifePlayer;
			CanActualiseHealthBarPlayer = false;
		}
    }

    public void ActualiseHealthBarEnnemi()
    {
	    if (CanActualiseHealthBarEnnemi == true)
	    {
		    HealthBarLifeEnnemi -= HealthBarDamageEnnemi;
		    EnnemiHealthBar.value = HealthBarLifeEnnemi;
		    CanActualiseHealthBarEnnemi = false;
	    }
    }
    
}
