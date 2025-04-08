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
	public List<GameObject> PlayerPiocheSpawn = new List<GameObject>();
	[SerializeField] private bool CanSpawnMaxCard;

	public GameObject SpawnCard;
	public bool CanGiveCard = true;
	public ListOfPlayerCard listOfPlayerCard;
	public bool Spawn;
	public Button pioche;
	public bool ifAllTrue;
	public bool CanMakeDamage;

	public float MaxTentative = -1;

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
//<<<<<<< HEAD
				int randomCard = Random.Range(0, CardLvl1.Length);

				if (PlayerPiocheSpawn.Contains(CardLvl1[randomCard]))
				{
					CanSpawnMaxCard = false;


					for (int i = 0; i > MaxTentative; i++)
					{
						int randomCardTry2 = Random.Range(0, CardLvl1.Length);

						if (!PlayerPiocheSpawn.Contains(CardLvl1[randomCardTry2]))
						{
							SpawnCard = Instantiate(CardLvl1[randomCardTry2],
								SpawnPoint[availableSpawn].transform.position, Quaternion.identity);
							PlayerPiocheSpawn.Add(SpawnCard); //randomCardrandomCard
							CardToSpawn[availableSpawn] = CardLvl1[randomCardTry2];
							CanSpawn[availableSpawn] = true;
							Spawn = true;
							CanMakeDamage = true;
							listOfPlayerCard.CanDamage = true;
							CanSpawnMaxCard = false;

							listOfPlayerCard.TourSuivant.interactable = true;

							break;
						}

						if (i == PlayerPiocheSpawn.Count)
						{
							break;
						}

//=======
						//if (CanSpawnMaxCard)
						//{
							//int randomCard = Random.Range(0, CardLvl1.Length);
							//SpawnCard = Instantiate(CardLvl1[randomCard], SpawnPoint[availableSpawn].transform.position,
								//Quaternion.identity);
							//PlayerPiocheSpawn.Add(CardLvl1[randomCard]); //randomCardrandomCard
							//CardToSpawn[availableSpawn] = CardLvl1[randomCard];
							//CanSpawn[availableSpawn] = true;
							//Spawn = true;
							//CanMakeDamage = true;
							//listOfPlayerCard.CanDamage = true;
//>>>>>>> a359217ff5e36a225241d3501cffa123ad0801a0

						}
					}

					if (!PlayerPiocheSpawn.Contains(CardLvl1[randomCard]))
					{
						CanSpawnMaxCard = true;
					}

					if (CanSpawnMaxCard)
					{
						SpawnCard = Instantiate(CardLvl1[randomCard],
							SpawnPoint[availableSpawn].transform.position, Quaternion.identity);
						PlayerPiocheSpawn.Add(SpawnCard); //randomCardrandomCard
						CardToSpawn[availableSpawn] = CardLvl1[randomCard];
						CanSpawn[availableSpawn] = true;
						Spawn = true;
						CanMakeDamage = true;
						listOfPlayerCard.CanDamage = true;
						CanSpawnMaxCard = false;
						listOfPlayerCard.TourSuivant.interactable = true;
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

	







