using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListOfEnnemiCard : MonoBehaviour
{
    [SerializeField] private float ListSize = 5;
	[SerializeField] private Button TourSuivant;

    public List<GameObject> EnnemiPlayCarte = new List<GameObject>();	
    public List<GameObject> EnnemiHand = new List<GameObject>();
    public PiocheEnnemi piocheEnnemi;
    public Pioche pioche;
	public PlayCarteEnnemi playCarteEnnemi;
    public ListOfPlayerCard listOfPlayerCard;
	public bool CanDamage;
	
	public BarreDeVieManager barreDeVieManager;


	void Start()
    {
        CanDamage = false;
    }

   
    void Update()
    {
        if (piocheEnnemi.Spawn == true)
        {
            if (EnnemiHand.Count <= ListSize)
            {
                EnnemiHand.Add(piocheEnnemi.CardInstantiate);
                piocheEnnemi.Spawn = false;
            }
        }
        
        GameObject[] tag = GameObject.FindGameObjectsWithTag("EnnemiCard");

              if (playCarteEnnemi.CanMove == true )
              	{
                  	EnnemiPlayCarte.Add(playCarteEnnemi.cardToPlay);
                  	EnnemiHand.Remove(piocheEnnemi.CardInstantiate);
                  	playCarteEnnemi.CanMove = false;
				  	ListCardEnnemi();
                 }

       foreach (GameObject obj in EnnemiPlayCarte)
       {
        AttackScriptEnnemi attackScriptEnnemi = obj.GetComponent<AttackScriptEnnemi>();
            	if (obj != null && obj.tag == "EnnemiCard")
            	{
					if(attackScriptEnnemi.ActualHealth == 0)
					{
						EnnemiPlayCarte.Remove(attackScriptEnnemi.CardEnnemiToPlay);
						playCarteEnnemi.CardPlay.Remove(attackScriptEnnemi.CardEnnemiToPlay);

			
						attackScriptEnnemi.CanDestroy = true;
                	}
					
		            if (playCarteEnnemi.ReferenceCase[1] == null) 
					 {//0
						playCarteEnnemi.CanSpawn[0] = false;
					 }
		            
		            if (playCarteEnnemi.AssigneGameObject[1] == null)
		            {
			            playCarteEnnemi.CanSpawn[1] = false;
			            
		            }
		            
		            if (playCarteEnnemi.AssigneGameObject[2] == null)
		            {//1
			            playCarteEnnemi.CanSpawn[2] = false;
		            }

		            if (playCarteEnnemi.AssigneGameObject[3] == null)
		            {//2
			            playCarteEnnemi.CanSpawn[3] = false;
		            }
		            
					if (attackScriptEnnemi.ActualHealth <= 0)
					{
						EnnemiPlayCarte.Remove(attackScriptEnnemi.CardEnnemiToPlay);
						playCarteEnnemi.CardPlay.Remove(attackScriptEnnemi.CardEnnemiToPlay);
	
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
						if(attackScriptEnnemi.hit.collider == null)
							{
									barreDeVieManager.CanActualiseHealthBarPlayer = true;
								barreDeVieManager.ActualiseHealthBarPlayer();
								attackScriptEnnemi.CanMakeDamage = false;
							}

                		attackScriptEnnemi.CanMakeDamage = true;
				
						StartCoroutine(PlayerCanPlay());
						TourSuivant.interactable = true;
         	  		}
        	}
    }
    
    public IEnumerator PlayerCanPlay()
    {
        yield return new WaitForSeconds(4);
	
        pioche.CanGiveCard = true;

    }
    
    
}
