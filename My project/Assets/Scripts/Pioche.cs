using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pioche : MonoBehaviour
{
	public GameObject[] SpawnPoint;
	[SerializeField] private bool[] CanSpawn;
	[SerializeField] private GameObject[] CardLvl1;

	public GameObject SpawnCard;	
    public bool CanGiveCard = true;
    public ListOfPlayerCard listOfPlayerCard;
	public bool Spawn;

    void Start()
    {
     	
		CanSpawn = new bool [SpawnPoint.Length];

		for (int i = 0; i < CanSpawn.Length; i++)
			{
				CanSpawn[i] = false;
			}

		CanGiveCard = true;
		Spawn = false;
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
				 	SpawnCard = Instantiate(CardLvl1[randomCard], SpawnPoint[availableSpawn].transform.position, Quaternion.identity);
						CanSpawn[availableSpawn] = true;
						Spawn = true;
					
					}	
			}
		CanGiveCard = false;
		
}

	public void libererSpawn(GameObject card)
	{
		
		
		GameObject[] tag = GameObject.FindGameObjectsWithTag("card");
		foreach (GameObject obj in tag)
		{
			PlayCarte playCarte = obj.GetComponent<PlayCarte>();  
			if(playCarte.CanMove == true)
			{
				for (int i = 0; i < SpawnPoint.Length; i++)
				{
					if (SpawnPoint[i].transform.position == card.transform.position)
					{
						CanSpawn[i] = false;

					}
				}
				Debug.Log("true");
			}
		}
		
	}

	private void Spawn2()
	{
		
	}
	
	
	
}







