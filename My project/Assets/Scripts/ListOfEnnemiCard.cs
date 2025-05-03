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
	public AttackScriptEnnemi attackScriptEnnemi;

	private float MaxHealthBarDamage;
	
	void Start()
    {
        CanDamage = false;
        MaxHealthBarDamage = 0;
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

              if (playCarteEnnemi.CanMove)
              	{
                  	EnnemiPlayCarte.Add(playCarteEnnemi.cardToPlay);
                  	EnnemiHand.Remove(piocheEnnemi.CardInstantiate);
                  	playCarteEnnemi.CanMove = false;
				  	ListCardEnnemi();
				    StartCoroutine(WaitBeforeDamage());
				    MaxHealthBarDamage = 0;
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
        	//foreach (GameObject obj in EnnemiPlayCarte)
        	//{
				// attackScriptEnnemi = obj.GetComponent<AttackScriptEnnemi>();
            		//if (obj != null && obj.tag == "EnnemiCard")
		           // {
			           
					//}
        	//}
    }
    
    public IEnumerator PlayerCanPlay()
    {
        yield return new WaitForSeconds(0);
        pioche.pioche.interactable = true;
		pioche.CanGiveCard = true;
		listOfPlayerCard.TourSuivant.interactable = false;
    }
    
    private IEnumerator WaitBeforeDamage()
    {
	    yield return new WaitForSeconds(2);
	    
	   if (MaxHealthBarDamage == 0)
	   {
			foreach (GameObject obj in EnnemiPlayCarte)
			{
				attackScriptEnnemi = obj.GetComponent<AttackScriptEnnemi>();
		     
				attackScriptEnnemi.CanMakeDamage = true;
				
				if(attackScriptEnnemi.hit.collider != null && attackScriptEnnemi.hit.collider.tag == "Plateau")//== null
				{
			    
				       Debug.Log(attackScriptEnnemi.gameObject.name);
				       barreDeVieManager.CanActualiseHealthBarPlayer = true;
				       barreDeVieManager.ActualiseHealthBarPlayer();
				       attackScriptEnnemi.CanMakeDamage = false;
				       MaxHealthBarDamage = 1;
				       Debug.Log(attackScriptEnnemi.hit.collider.name);
			    }
			 
		    }
	   }
	   
	   StartCoroutine(PlayerCanPlay());
	   
    }
    
}
