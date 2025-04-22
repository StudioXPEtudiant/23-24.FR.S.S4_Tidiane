using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Pioche : MonoBehaviour
{
	[Header("SpawnVariables")]
	
	[SerializeField] private GameObject[] CardToSpawn;
	[SerializeField] private int availableSpawn = -1;
	[SerializeField] private bool CanSpawnMaxCard;
	[SerializeField] private List<GameObject> TryCardLvl1;
	    
	public List<int> availableSpawn2;
	public List<GameObject> PlayerPiocheSpawn = new List<GameObject>();
	public GameObject[] SpawnPoint;
	public bool[] CanSpawn;
	public GameObject SpawnCard;
	public bool Spawn;
	public int CurrentSpawnPosition = 0;
		
	[Header("PiocheVariables")]
	
	[SerializeField] private int randomCard2;
	public GameObject[] CardLvl1;
	public bool CanGiveCard = true;
	public ListOfPlayerCard listOfPlayerCard;
	public Button pioche;
	
	[Header("Damage")]
	
	public bool CanMakeDamage;
	

	
	void Start()
	{
		CardToSpawn = new GameObject[SpawnPoint.Length];
		CanSpawnMaxCard = false;

		CanSpawn = new bool [SpawnPoint.Length];

		for (int i = 0; i < CanSpawn.Length; i++)
		{
			CanSpawn[i] = false;
		}

		for (int i = 0; i < SpawnPoint.Length; i++)
		{
			availableSpawn2.Add(i);
		}

		CurrentSpawnPosition = availableSpawn2[8];
		CanGiveCard = true;
		Spawn = false;
		CanMakeDamage = false;
	}


	void Update()
	{
		
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
				int Spawn2 = CurrentSpawnPosition;
				randomCard2 = Random.Range(0, TryCardLvl1.Count);

					CanSpawnMaxCard = false;
					
					listOfPlayerCard.TourSuivant.interactable = true;

					if (!PlayerPiocheSpawn.Contains(CardLvl1[randomCard2]))
					{
						CanSpawnMaxCard = true;
					}
					else
					{
						CanSpawnMaxCard = false;
					}
					
					if (CanSpawnMaxCard)
					{
						SpawnCard = Instantiate(TryCardLvl1[randomCard2],
							SpawnPoint[Spawn2].transform.position, Quaternion.identity);
						SpawnCard.GetComponent<PlayCarte>().SpawnPosition = Spawn2;
						PlayerPiocheSpawn.Add(SpawnCard); 
						CardToSpawn[Spawn2] = CardLvl1[randomCard2];
						CanSpawn[Spawn2] = true;
						availableSpawn2.Remove(Spawn2);
						CurrentSpawnPosition--;
						Spawn = true;
						CanMakeDamage = true;
						listOfPlayerCard.CanDamage = true;
						CanSpawnMaxCard = false;
						listOfPlayerCard.TourSuivant.interactable = true;
						TryCardLvl1.RemoveAt(randomCard2);
						listOfPlayerCard.TourSuivant.interactable = true;
					}
			}


			CanGiveCard = false;
		}
		pioche.interactable = false;
	}
}

	







