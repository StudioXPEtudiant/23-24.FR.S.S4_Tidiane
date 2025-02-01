using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfPlayerCard : MonoBehaviour
{
    [SerializeField] private GameObject[] CarteToPlay;
    [SerializeField] private float ListSize = 4;
    [SerializeField] private bool CanGiveCardEnnemi;
    
    public List<GameObject> PlayerPlayCarte = new List<GameObject>();	
    public List<GameObject> PlayerHand = new List<GameObject>();
    public Pioche pioche;
	public PiocheEnnemi piocheEnnemi;

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

                       // foreach (GameObject objet in PlayerHand)
                        //{
                           // CanDamage = true;
                       // }
                                          
                   }
                
               }

           // CanGiveCardEnnemi = true;
                
    }

    public void CanMakeDamage()
    {
        
    }
    
    public void ListCard()
    {
        
        
            foreach (GameObject obj in PlayerPlayCarte)
            {
                if (CanDamage == true)
                {
                    if (obj != null && obj.tag == "card")
                    {
                     PlayCarte playCarte = obj.GetComponent<PlayCarte>();
                    
                           obj.GetComponent<AttackScript>().CanMakeDamage = true;
                           StartCoroutine(EnnemiCanPlay());
                           CanGiveCardEnnemi = false;
                           CanDamage = false;
                    }
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
                            Debug.Log("3");
                            StartCoroutine(EnnemiCanPlay());
                            CanGiveCardEnnemi = false;
                            pioche.CanMakeDamage = false;
                        }
                    }   
            }
                
                //}
           // }
            
    }
 

public IEnumerator EnnemiCanPlay()
{
    //if (CanDamage == true)
    //{
        yield return new WaitForSeconds(2);
        	
        piocheEnnemi.CanGiveCard = true;
   // }
	
}


}


