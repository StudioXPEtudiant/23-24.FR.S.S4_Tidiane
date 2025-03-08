using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListOfPlayerCard : MonoBehaviour
{
    [SerializeField] private GameObject[] CarteToPlay;
    [SerializeField] private float ListSize = 4;
    [SerializeField] private bool CanGiveCardEnnemi;
	[SerializeField] private Button TourSuivant;    

    public List<GameObject> PlayerPlayCarte = new List<GameObject>();	
    public List<GameObject> PlayerHand = new List<GameObject>();
    public Pioche pioche;
	public PiocheEnnemi piocheEnnemi;
    public BarreDeVieManager barreDeVieManager;
    
    public bool CanDamage;
    
    void Start()
    {
        CanGiveCardEnnemi = false;
        CanDamage = false;
    }

   
    void Update()
    {
        if (pioche.Spawn == true)
        {
            if (PlayerHand.Count < ListSize)
            {
                PlayerHand.Add(pioche.SpawnCard);
                
                pioche.Spawn = false;

              
            }
        }

       GameObject[] tag = GameObject.FindGameObjectsWithTag("card");
               foreach (GameObject obj in tag)
               {
                   PlayCarte playCarte = obj.GetComponent<PlayCarte>();  
                   if (playCarte.CanMove == true )
                   {
                       PlayerPlayCarte.Add(playCarte.CardToPlay);
						PlayerHand.Remove(pioche.SpawnCard);
                       playCarte.CanMove = false;
                        CanGiveCardEnnemi = true;
                          
                        foreach (GameObject Obj in PlayerPlayCarte)
                          {
                              CanDamage = true;
                          }                                         
                   }
                
               }
    }

    public void CanMakeDamage()
    {
        
    }
    
    public void ListCard()
    {        
            foreach (GameObject obj in PlayerPlayCarte)
            {        
                    if (obj != null && obj.tag == "card")
                    {
                     PlayCarte playCarte = obj.GetComponent<PlayCarte>();
					 AttackScript attackScript = obj.GetComponent<AttackScript>();
						
                               		if (playCarte.hit.collider == null)
                               		{
                                   		barreDeVieManager.CanActualiseHealthBarEnnemi = true;
                               		}
							
		              	   obj.GetComponent<AttackScript>().CanMakeDamage = true;
                           StartCoroutine(EnnemiCanPlay());
                           CanGiveCardEnnemi = false;
                           CanDamage = false;

							TourSuivant.interactable = false;
                    }				    
            }

            foreach (GameObject obj in PlayerHand)
            { 
                    if (obj != null && obj.tag == "card")
                    {
                        PlayCarte playCarte = obj.GetComponent<PlayCarte>();
                            
                        
                        if (pioche.CanMakeDamage == true)
                        {
                           
                            CanDamage = true;
                            obj.GetComponent<AttackScript>().CanMakeDamage = true;
 
                            StartCoroutine(EnnemiCanPlay());
                            CanGiveCardEnnemi = false;
                            pioche.CanMakeDamage = false;

							TourSuivant.interactable = false;
                        }
                    }   
            }           
    }
 

public IEnumerator EnnemiCanPlay()
{
    if (CanDamage == true)
    {
        yield return new WaitForSeconds(2);
        	
        piocheEnnemi.CanGiveCard = true;
        CanDamage = false;
    }
	
}


}


