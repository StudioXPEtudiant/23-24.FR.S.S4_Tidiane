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

    void Start()
    {
        CanGiveCardEnnemi = false;
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
                   }

               }

            
                
    }

    public void ListCard()
    { 
        
            foreach (GameObject obj in PlayerPlayCarte)
            {
                if (obj != null && obj.tag == "card")
                {
                    obj.GetComponent<AttackScript>().CanMakeDamage = true;
                    if (CanGiveCardEnnemi == true)
                    {
                        StartCoroutine(EnnemiCanPlay());
                        CanGiveCardEnnemi = false;
                    }
                }
            }
    }

public IEnumerator EnnemiCanPlay()
{
	yield return new WaitForSeconds(2);
	
	piocheEnnemi.CanGiveCard = true;
}



}


