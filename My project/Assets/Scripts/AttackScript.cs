using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackScript : MonoBehaviour
{
	[SerializeField] private float CardDamage;
	[SerializeField] private float CardHealth;
	[SerializeField] private GameObject ButtonTourSuivant;
	//[SerializeField] private Vector2 origin;

	public TourSuivant tourSuivant;
	public UnityEvent <GameObject> makeDamage;
	//public bool CanMakeDamage = false;
	public PlayCarte playCarte;
	public float ActualHealth;
	public bool CanMakeDamage;    
	//public RaycastHit2D hit;
	public string tag;
	
	private bool CanClick;

    void Start()
    {
        ActualHealth = CardHealth;
		ButtonTourSuivant = GameObject.FindWithTag("tourSuivantButton");
		CanClick = true;
    }

    
    void Update()
    {
 
		if (CanMakeDamage == true)
			{

        		if (playCarte.hit.collider != null)
        				{
        					if (playCarte.hit.transform.gameObject.tag == "EnnemiCard")
        						{
									AttackScriptEnnemi attackScriptEnnemi = playCarte.hit.collider.GetComponent<AttackScriptEnnemi>();
								if (attackScriptEnnemi != null)
									{
        								attackScriptEnnemi.ActualHealth -= CardDamage;

									
									}
									CanMakeDamage = false;
        						}
        				}
			}
			if (ActualHealth < 0)
            {
             Destroy(gameObject);
            }

			if (ActualHealth == 0)
            {
             Destroy(gameObject);
            }
    }
 
    
}
