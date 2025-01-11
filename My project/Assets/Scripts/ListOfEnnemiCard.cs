using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfEnnemiCard : MonoBehaviour
{
    [SerializeField] private float ListSize = 4;
    public List<GameObject> EnnemiPlayCarte = new List<GameObject>();	
    public List<GameObject> EnnemiHand = new List<GameObject>();
    public PiocheEnnemi piocheEnnemi;
    public Pioche pioche;
	public PlayCarteEnnemi playCarteEnnemi;
    public ListOfPlayerCard listOfPlayerCard;

	void Start()
    {
        
    }

   
    void Update()
    {
        if (piocheEnnemi.Spawn == true)
        {
            if (EnnemiHand.Count < ListSize)
            {
                EnnemiHand.Add(piocheEnnemi.CardInstantiate);
                piocheEnnemi.Spawn = false;
            }
        }
        
        GameObject[] tag = GameObject.FindGameObjectsWithTag("EnnemiCard");
       
        //foreach (GameObject obj in tag)
        //{
           // PlayCarteEnnemi playCarteEnnemi = obj.GetComponent<PlayCarteEnnemi>();  
           //if (playCarteEnnemi != null)
                  //{
                       if (playCarteEnnemi.CanMove == true )
                                  {
                                      EnnemiPlayCarte.Add(piocheEnnemi.CardInstantiate);
                                      EnnemiHand.Remove(piocheEnnemi.CardInstantiate);
                                      playCarteEnnemi.CanMove = false;
										ListCardEnnemi();
                                  }
                  //}  
          

       // }
       foreach (GameObject obj in EnnemiPlayCarte)
       {
        AttackScriptEnnemi attackScriptEnnemi = obj.GetComponent<AttackScriptEnnemi>();
            	if (obj != null && obj.tag == "EnnemiCard")
            	{
                					
					if(attackScriptEnnemi.ActualHealth == 0)
					{
						Debug.Log("true");
						EnnemiPlayCarte.Remove(piocheEnnemi.CardInstantiate);
						playCarteEnnemi.CardPlay.Remove(piocheEnnemi.CardInstantiate);

						if(playCarteEnnemi.CardPlay.Remove(piocheEnnemi.CardInstantiate));
						{
							playCarteEnnemi.CanSpawn[playCarteEnnemi.availableSpawn] = false;
						}

						attackScriptEnnemi.CanDestroy = true;
                	}	

					if(attackScriptEnnemi.ActualHealth <= 0)
					{
						Debug.Log("false");
						EnnemiPlayCarte.Remove(piocheEnnemi.CardInstantiate);
						playCarteEnnemi.CardPlay.Remove(piocheEnnemi.CardInstantiate);

						if(playCarteEnnemi.CardPlay.Remove(piocheEnnemi.CardInstantiate));
						{
							playCarteEnnemi.CanSpawn[playCarteEnnemi.availableSpawn] = false;
						}

						attackScriptEnnemi.CanDestroy = true;
                	}	
				}
		}
    }

    private void ListCardEnnemi()
    {
        foreach (GameObject obj in EnnemiPlayCarte)
        {
			AttackScriptEnnemi attackScriptEnnemi = obj.GetComponent<AttackScriptEnnemi>();
            	if (obj != null && obj.tag == "EnnemiCard")
            	{
                		attackScriptEnnemi.CanMakeDamage = true;
				
						StartCoroutine(PlayerCanPlay());
         	   }
        }
    }
    
    public IEnumerator PlayerCanPlay()
    {
        yield return new WaitForSeconds(4);
	
        pioche.CanGiveCard = true;
       // pioche.CanGiveCard = false;
    }
    
    
}
