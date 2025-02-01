using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class AttackScript : MonoBehaviour
{
	[SerializeField] private float CardDamage;
	[SerializeField] private float CardHealth;
	[SerializeField] private GameObject ButtonTourSuivant;

	[SerializeField] private GameObject CardHealthGameObject;
	[SerializeField] private GameObject CardAttackGameObject;

	[SerializeField] private GameObject ThisCard;
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
	
	[SerializeField] private TMP_Text CardHealthText;
	[SerializeField] private TMP_Text CardAttackText;
	
    void Start()
    {
        ActualHealth = CardHealth;
		ButtonTourSuivant = GameObject.FindWithTag("tourSuivantButton");
		CanClick = true;
		CanMakeDamage = false;
    }

    
    void Update()
    {
	    if (ThisCard.tag == "card")
	    {
		    TMP_Text CardHealthText = CardHealthGameObject.GetComponent<TMP_Text>();
		    TMP_Text CardAttackText = CardAttackGameObject.GetComponent<TMP_Text>();
            		     
		    CardHealthText.text = ActualHealth.ToString();
		    CardAttackText.text = CardDamage.ToString();    
	    }
		     
	    
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
										Debug.Log("true");
										CanMakeDamage = false;
									}
									
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
