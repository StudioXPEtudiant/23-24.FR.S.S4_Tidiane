using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Pioche : MonoBehaviour
{
	public GameObject[] SpawnPoint;
	[SerializeField] private bool[] CanSpawn;
	public GameObject[] CardLvl1;
	[SerializeField] private GameObject[] CardToSpawn;
	[SerializeField] private int availableSpawn = -1;
	public List<GameObject> PlayerPiocheSpawn = new List<GameObject>();
	[SerializeField] private bool CanSpawnMaxCard;
	[SerializeField] private List<GameObject> TryCardLvl1;
	
	public GameObject SpawnCard;
	public bool CanGiveCard = true;
	public ListOfPlayerCard listOfPlayerCard;
	public bool Spawn;
	public Button pioche;
	public bool ifAllTrue;
	public bool CanMakeDamage;

	[SerializeField] private int randomCard2;
	public float MaxTentative = -1;

	void Start()
	{
		CardToSpawn = new GameObject[SpawnPoint.Length];
		CanSpawnMaxCard = false;

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
//<<<<<<< HEAD
				int randomCard = Random.Range(0, CardLvl1.Length);
				//int 
				randomCard2 = Random.Range(0, TryCardLvl1.Count);
			//	if (PlayerPiocheSpawn.Contains(CardLvl1[randomCard]))
				//{
					CanSpawnMaxCard = false;


					//for (int i = 0; i > MaxTentative; i++)//
				//	{
						int randomCardTry2 = Random.Range(0, CardLvl1.Length);

						//if (!PlayerPiocheSpawn.Contains(CardLvl1[randomCardTry2]))
						//{
							//SpawnCard = Instantiate (CardLvl1[randomCard2], //randomCardTry2
							//	SpawnPoint[availableSpawn].transform.position, Quaternion.identity);
							//PlayerPiocheSpawn.Add(SpawnCard); //randomCardrandomCard
							//CardToSpawn[availableSpawn] = CardLvl1[randomCard2];//randomCardTry2
							//CanSpawn[availableSpawn] = true;
							//Spawn = true;
							//CanMakeDamage = true;
							//listOfPlayerCard.CanDamage = true;
							//CanSpawnMaxCard = false;
							//TryCardLvl1.RemoveAt(randomCard2);
				
							listOfPlayerCard.TourSuivant.interactable = true;
							
							//break;
					//}
						//if (i == PlayerPiocheSpawn.Count)
						//{
						//	break;
						//}


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
						SpawnCard = Instantiate(TryCardLvl1[randomCard2], //CardLvl1[randomCard2],//randomCard
							SpawnPoint[availableSpawn].transform.position, Quaternion.identity);
						PlayerPiocheSpawn.Add(SpawnCard); //randomCardrandomCard
						CardToSpawn[availableSpawn] = CardLvl1[randomCard2];//randomCard
						CanSpawn[availableSpawn] = true;
						Spawn = true;
						CanMakeDamage = true;
						listOfPlayerCard.CanDamage = true;
						CanSpawnMaxCard = false;
						listOfPlayerCard.TourSuivant.interactable = true;
						//CardLvl1[randomCard] = null;
						TryCardLvl1.RemoveAt(randomCard2);
						listOfPlayerCard.TourSuivant.interactable = true;
					}
				}


			CanGiveCard = false;
		}
		pioche.interactable = false;
	}
	

	public void libererSpawn()
		{
			if (availableSpawn == 0)
			{
				for (int i = 0; i < CanSpawn.Length; i++)
				{
					CanSpawn[i] = false;
				}

			}
		}

		private void Spawn2()
		{

		}
}

	







