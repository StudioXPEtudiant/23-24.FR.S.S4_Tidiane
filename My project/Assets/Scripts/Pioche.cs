using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pioche : MonoBehaviour
{
	public GameObject[] SpawnPoint;
	[SerializeField] private bool[] CanSpawn;
	[SerializeField] private GameObject[] CardLvl1;

	private GameObject SpawnCard;	
    public bool CanGiveCard = true;


    void Start()
    {
     	
		CanSpawn = new bool [SpawnPoint.Length];

		for (int i = 0; i < CanSpawn.Length; i++)
			{
				CanSpawn[i] = false;
			}

		CanGiveCard = true;
    }

    
    void Update()
    {
       
    }

	public void TakeCard()
{
		if (CanGiveCard)
			{
				
				int randomSpawn = Random.Range(0, SpawnPoint.Length);
				int availableSpawn = -1;
					
				for (int i = 0; i < SpawnPoint.Length; i++)
					{
						if (!CanSpawn[i])
							{
								availableSpawn = i;
					
							}
					}

				if (availableSpawn != -1)
					{
						int randomCard = Random.Range(0, CardLvl1.Length);
				 		 Instantiate(CardLvl1[randomCard], SpawnPoint[availableSpawn].transform.position, Quaternion.identity);
						CanSpawn[availableSpawn] = true;
					}	
				
			}
		CanGiveCard = false;
}



    //public void CardGiver()
    //{
       // if (CanGiveCard == true)
       // {	
           // AleatoryCard = Random.Range(1, 6);
			//if (SpawnPoint.Length == 0) return;

          // int randomSpawn = Random.Range(0, SpawnPoint.Length);
			//GameObject SpawnRandomPoint = SpawnPoint[randomSpawn];

 //	if (AleatoryCard == 1)
           // {

               // Instantiate(Card1, SpawnPoint[randomSpawn].transform.position, Quaternion.identity);
            //    ActualCard += 1;
              
           // }

          //  if (AleatoryCard == 2)
          //  {
              // Instantiate(Card2, SpawnPoint[randomSpawn].transform.position, Quaternion.identity);
              //  ActualCard += 1;
                
                   
          //  }

           // if (AleatoryCard == 3)
           // {
               // Instantiate(Card3, SpawnPoint[randomSpawn].transform.position, Quaternion.identity);
             //   ActualCard += 1;
              
   
           // }

           // if (AleatoryCard == 4)
           // {
              // Instantiate(Card4, SpawnPoint[randomSpawn].transform.position, Quaternion.identity);
             //   ActualCard += 1;
                
    
           // }

            //if (AleatoryCard == 5)
           // {
                //Instantiate(Card5, SpawnPoint[randomSpawn].transform.position, Quaternion.identity);
              //  ActualCard += 1;
                
    
           // }

         // if (AleatoryCard == 6)
           // {
                //Instantiate(Card6, SpawnPoint[randomSpawn].transform.position, Quaternion.identity);
                //ActualCard += 1;
               
    
           // }
 

    //}

 	//}

}







