using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PiocheEnnemi : MonoBehaviour
{
	[Header("SpawnVariables")]
	
    [SerializeField] private GameObject[] SpawnPointEnnemi;
    public bool[] CanSpawn;
    public bool Spawn;
    public List<int> ActualSpawn;
    public int ActualSpawnPosition;
	private int availableSpawn = -1;
    
	
	[Header("GameObjectVariable")] 
     
    [SerializeField] private List<GameObject> EnnemiCardLvl1;
     public GameObject[] CardLvl1;
     public GameObject CardInstantiate;
     private int NumberOfCard = 0;
     
	[Header("Other")]
     
    public bool CanGiveCard = true;
	public Vector2 Saved;        
	public PlayCarteEnnemi playCarteEnnemi;

	

    void Start()
    {	        
        CanSpawn = new bool [SpawnPointEnnemi.Length];

            for (int i = 0; i < CanSpawn.Length; i++)
            {
                CanSpawn[i] = false;
            }

            for (int i = 0; i < SpawnPointEnnemi.Length; i++)
            {
	           ActualSpawn.Add(i); 
            }
            
	    ActualSpawnPosition = ActualSpawn[8];
		CanGiveCard = false;
		Spawn = false;
    }

    
    void Update()
    {
       if (CanGiveCard == true)
       {
       
	     
	      
	       CanGiveCard = false;
       }

    //   LibererSpawnPiocheEnnemi();
    }

    public void SpawnEnnemiCard()
    {
	      int randomSpawn = Random.Range(0, SpawnPointEnnemi.Length);
        
        	       for (int i = 0; i < SpawnPointEnnemi.Length; i++)
        	       { 
        		       if (!CanSpawn[i]) 
        		       {
        			       availableSpawn = i;
        		       }
        	       }
        
        		                        
        	       if (availableSpawn != -1)
        	       {
        		       int randomCard = Random.Range(0, CardLvl1.Length);
        		       int randomCard2 = Random.Range(0, EnnemiCardLvl1.Count);
        		       int SpawnPosition = ActualSpawnPosition;
        		       
        		       CardInstantiate = Instantiate(EnnemiCardLvl1[randomCard2], SpawnPointEnnemi[SpawnPosition].transform.position,//CardLvl1[randomCard]
                                       Quaternion.identity);
		               CardInstantiate.GetComponent<AttackScriptEnnemi>().SpawnCardPosition = SpawnPosition;
		               playCarteEnnemi.FirstTurn();
        		       EnnemiCardLvl1.RemoveAt(randomCard2);
        		       playCarteEnnemi.EnnemiHand.Add(CardInstantiate);
        		       CardInstantiate.tag = "EnnemiCard";
        		       Saved = CardInstantiate.transform.position;
        		       CanSpawn[SpawnPosition] = true;
        		       ActualSpawn.Remove(SpawnPosition);
        		       ActualSpawnPosition--;
        		       Spawn = true;
        		       StartCoroutine(playCarteEnnemi.EnnemiTurn());
	               }
	}
    
    //public void LibererSpawnPiocheEnnemi()
       // {
	       // if (availableSpawn == 0)
	        //{
		       // for(int i = 0; i < CanSpawn.Length; i++)
		      //  {
			      //  CanSpawn[i] = false;
		       // }
	        //}
         
       // }



}
