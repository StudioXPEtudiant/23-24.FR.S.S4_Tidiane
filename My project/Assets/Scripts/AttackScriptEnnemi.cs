using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class AttackScriptEnnemi : MonoBehaviour
{
    public float CardDamage;
    public float CardHealth;	
    [SerializeField] private float WeakDamage;
    [SerializeField] private float cardStartDamage;
    [SerializeField] private float MaxWeakDamage;
    
    [SerializeField] private GameObject CardHealthGameObjectEnnemi;
    [SerializeField] private GameObject CardAttackGameObjectEnnemi;
    [SerializeField] private TMP_Text CardHealthTextEnnemi;
    [SerializeField] private TMP_Text CardAttackTextEnnemi;
   
    [SerializeField] private Vector2 origin;

    [SerializeField] private Text ShowCardHealth;

    [SerializeField] private GameObject ElementType;
    public GameObject Weak;

    public GameObject CardEnnemiToPlay;
    public UnityEvent makeDamage;
    public bool CanMakeDamage = false;
    public PlayCarteEnnemi playCarteEnnemi;
    public RaycastHit2D hit;
    public string Tag;
    public bool CanShowRaycast = false;
    public float ActualHealth;
	public ListOfEnnemiCard listOfEnnemiCard;
	public PiocheEnnemi piocheEnnemi;    
	public bool CanDestroy;
    public int SpawnCardPosition;
   // public bool canLibererSpawn;
    
    void Start()
    {
        ActualHealth = CardHealth;
        CanShowRaycast = true;
		CanMakeDamage = false;

        cardStartDamage = CardDamage;
        MaxWeakDamage = 0;
        
        piocheEnnemi = GameObject.FindGameObjectWithTag("EnnemiPioche").GetComponent<PiocheEnnemi>();
    }

    
    void Update()
    {
	    if (CardEnnemiToPlay.tag == "EnnemiCard")
	    {
		     TMP_Text CardHealthTextEnnemi = CardHealthGameObjectEnnemi.GetComponent<TMP_Text>();
		     TMP_Text CardAttackTextEnnemi = CardAttackGameObjectEnnemi.GetComponent<TMP_Text>();
            		     
		     CardHealthTextEnnemi.text = ActualHealth.ToString();
		     CardAttackTextEnnemi.text = CardDamage.ToString();   
	    }

        if (hit.collider == null)
        {
            CardDamage = cardStartDamage;
        }
        
        if (CanMakeDamage)
        {
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.tag == "card")
                {
                    AttackScript attackScript = hit.collider.GetComponent<AttackScript>();
                    if (attackScript != null)
                    {
                        if(ElementType.tag != attackScript.Weak.tag)
                        {
                             attackScript.ActualHealth -= CardDamage;
                             MaxWeakDamage = 0;
                        } 
                    }
                    CanMakeDamage = false;
                    
                    if(ElementType.tag == "PlantCard" && attackScript.Weak.tag == "PlantCard")
                    {
                        if (CardEnnemiToPlay.tag == "EnnemiCard")
                        {
                             attackScript.ActualHealth -= CardDamage;
                             attackScript.ActualHealth -= WeakDamage;
                             
                             if (MaxWeakDamage == 0)
                             {
                                  attackScript.CardDamage--;
                                  CardDamage++;
                                  MaxWeakDamage = 1;
                             }
                            
                        }
                       
                    }

                    if(ElementType.tag == "WaterCard" && attackScript.Weak.tag == "WaterCard")
                    {
                        if (CardEnnemiToPlay.tag == "EnnemiCard")
                        {
                            attackScript.ActualHealth -= CardDamage;
                            attackScript.ActualHealth -= WeakDamage;

                            if (MaxWeakDamage == 0)
                            {
                                attackScript.CardDamage--;
                                CardDamage++;
                                MaxWeakDamage = 1;
                            }
                        }
                    }

                    if(ElementType.tag == "FoudreCard" && attackScript.Weak.tag == "FoudreCard")
                    {
                        if (CardEnnemiToPlay.tag == "EnnemiCard")
                        {
                            attackScript.ActualHealth -= CardDamage;
                            attackScript.ActualHealth -= WeakDamage;

                            if (MaxWeakDamage == 0)
                            {
                                attackScript.CardDamage--;
                                CardDamage++;
                                MaxWeakDamage = 1;
                            }
                        }
                    }

                    if(ElementType.tag == "FireCard" && attackScript.Weak.tag == "FireCard")
                    {
                        if (CardEnnemiToPlay.tag == "EnnemiCard")
                        {
                            attackScript.ActualHealth -= CardDamage;
                            attackScript.ActualHealth -= WeakDamage;

                            if (MaxWeakDamage == 0)
                            {
                                attackScript.CardDamage--;
                                CardDamage++;
                                MaxWeakDamage = 1;
                            }
                        }
                    }

                   

                    if (ElementType.tag == "NegativeEffect" && attackScript.Weak.tag == "NegativeEffect")
                    {
                        if (attackScript != null)
                        {
                            if (CardEnnemiToPlay.tag == "EnnemiCard")
                            {
                                attackScript.ActualHealth -= CardDamage;
                                attackScript.ActualHealth -= WeakDamage;
                            }
                            CanMakeDamage = false;

                        }
                    }

                    if (ElementType.tag == "PositiveEffect" && attackScript.Weak.tag == "PositiveEffect")
                    {
                        if(attackScript != null)
                        {
                            if (CardEnnemiToPlay.tag == "EnnemiCard")
                            {
                                attackScript.ActualHealth -= CardDamage;
                                attackScript.ActualHealth -= WeakDamage;
                            }
                            CanMakeDamage = false;
                    
                        }
                                            
                    }
                }
            }

            //if(hit.collider.tag == "Plateau")
            //{
               // CanMakeDamage = false;
           // }
  				 if (hit.collider == null)
                    {
                        CanMakeDamage = false;
                    } 
        }

    

		if (CanDestroy == true)
			{
             		Destroy(gameObject);
			}          
   
        if (gameObject.tag == "EnnemiCard")
        {
            origin = (Vector2)transform.position - new Vector2 (0,1);
                        
            hit = Physics2D.Raycast(origin, Vector2.down, 3);
            Debug.DrawRay(origin, Vector2.down * 3, Color.red);
      	}
    }

    public void LibererSpawnEnnemi()
    {
        int freeSpawnEnnemi = SpawnCardPosition;
        
        piocheEnnemi.ActualSpawn.Add(freeSpawnEnnemi);
        piocheEnnemi.CanSpawn[freeSpawnEnnemi] = false;
        piocheEnnemi.ActualSpawnPosition = freeSpawnEnnemi;

    }
    
}
