using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pioche : MonoBehaviour
{
	public GameObject[] SpawnPoint;
	[SerializeField] private bool[] CanSpawn;
	public GameObject[] CardLvl1;
	[SerializeField] private GameObject[] CardToSpawn;
	[SerializeField] private int availableSpawn = -1;
	[SerializeField] private List<GameObject> PlayerPiocheSpawn = new List<GameObject>();
	[SerializeField] private bool CanSpawnMaxCard;
	
	public GameObject SpawnCard;	
    public bool CanGiveCard = true;
    public ListOfPlayerCard listOfPlayerCard;
	public bool Spawn;
	public Button pioche;
	public bool ifAllTrue;
	public bool CanMakeDamage;
	
    void Start()
    {
	    CardToSpawn = new GameObject[SpawnPoint.Length];
	    CanSpawnMaxCard = true;
	    
		CanSpawn = new bool [SpawnPoint.Length];
		ifAllTrue = true;

		for (int i = 0; i < CanSpawn.Length; i++)
			{
				CanSpawn[i] = false;
			}

		CanGiveCard = true;
		Spawn = false;
		CanMakeDamage = false;
    }

    
    void Update()
    {
	    libererSpawn();
    }

	public void TakeCard()
{
		if (CanGiveCard)
			{
				
				int randomSpawn = Random.Range(0, SpawnPoint.Length);
				
				
				for (int i = 0; i < SpawnPoint.Length; i++)
					{
						if (!CanSpawn[i])
							{
								availableSpawn = i;
					
							}
					}

				if (availableSpawn != -1)
				{
						if (CanSpawnMaxCard)
						{	
							int randomCard = Random.Range(0, CardLvl1.Length);
				 			SpawnCard = Instantiate(CardLvl1[randomCard], SpawnPoint[availableSpawn].transform.position, Quaternion.identity);
							PlayerPiocheSpawn.Add(CardLvl1[randomCard]);//randomCardrandomCard
							CardToSpawn[availableSpawn] = CardLvl1[randomCard];
							CanSpawn[availableSpawn] = true;
							Spawn = true;
							CanMakeDamage = true;
							listOfPlayerCard.CanDamage = true;
						
						}
					}	
			}
		CanGiveCard = false;
		pioche.interactable = false;
}

	public void libererSpawn()
	{
		if (availableSpawn == 0)
		{
			for(int i = 0; i < CanSpawn.Length; i++)
			{
				CanSpawn[i] = false;
			}
					      
		}
	}

	private void Spawn2()
	{
		
	}
	
	
	
}







