using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class AttackScript : MonoBehaviour
{
	[SerializeField] private float CardDamage;
	[SerializeField] private float CardHealth;
	[SerializeField] private float WeakDamage;
	[SerializeField] private GameObject ButtonTourSuivant;

	[SerializeField] private GameObject CardHealthGameObject;
	[SerializeField] private GameObject CardAttackGameObject;

	[SerializeField] private GameObject ThisCard;
	[SerializeField] private GameObject ElementType;
	[SerializeField] private GameObject Weak;

	public UnityEvent <GameObject> makeDamage;
	public PlayCarte playCarte;
	public float ActualHealth;
	public bool CanMakeDamage; 
	public BarreDeVieManager barreDeVieManager;   
	public string tag;
	
	private bool CanClick;
	private bool CanDamageWithoutWeak;	

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

	    if (playCarte.hit.collider == null)
	    {
		    CanMakeDamage = false;
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
											if(ElementType.tag != playCarte.hit.collider.tag)
												{
													//attackScriptEnnemi.ActualHealth -= CardDamage;
													CanMakeDamage = false;
												}						
										}
											
										
										if (ElementType.tag == "PlantCard" && attackScriptEnnemi.Weak.tag == "PlantCard")
											{
												Debug.Log(attackScriptEnnemi.Weak.tag);
												//Debug.Log(playCarte.hit.collider.CompareTag("PlantCard"));
												if(attackScriptEnnemi != null)
													{
														attackScriptEnnemi.ActualHealth -= CardDamage;
														attackScriptEnnemi.ActualHealth -= WeakDamage;
													}
											}
										if (ElementType.tag == "WaterCard" && attackScriptEnnemi.Weak.tag == "WaterCard")
											{
												if(attackScriptEnnemi != null)
													{
														
														attackScriptEnnemi.ActualHealth -= CardDamage;
														attackScriptEnnemi.ActualHealth -= WeakDamage;
													}
											}
										if (ElementType.tag == "FoudreCard" && attackScriptEnnemi.Weak.tag == "FoudreCard")//
											{
												if(attackScriptEnnemi != null)
													{
													
														attackScriptEnnemi.ActualHealth -= CardDamage;
														attackScriptEnnemi.ActualHealth -= WeakDamage;
													}
											}
										if (ElementType.tag == "FireCard" && attackScriptEnnemi.Weak.tag == "FireCard")
											{
												if(attackScriptEnnemi != null)
													{
														attackScriptEnnemi.ActualHealth -= CardDamage;
														attackScriptEnnemi.ActualHealth -= WeakDamage;
													}//CardDamage *= WeakDamage;
                                                    //attackScriptEnnemi.ActualHealth -= CardDamage;
													// playCarte.hit.collider.tag == "FireCard"
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
