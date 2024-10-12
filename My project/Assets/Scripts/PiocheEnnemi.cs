using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiocheEnnemi : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPointEnnemi;
    [SerializeField] private bool[] CanSpawn;
    [SerializeField] private GameObject[] CardLvl1;

    private bool CanGiveCard = true;
    private int NumberOfCard = 0;

    void Start()
    {
        StartCoroutine(SpawnCarteEnnemi());
        
        CanSpawn = new bool [SpawnPointEnnemi.Length];

            for (int i = 0; i < CanSpawn.Length; i++)
            {
                CanSpawn[i] = false;
            }
    }

    
    void Update()
    {
       
    }
    

    private IEnumerator SpawnCarteEnnemi()
    {
        
        while (NumberOfCard < 2)
        {


           

            if (CanGiveCard)
            {

                int randomSpawn = Random.Range(0, SpawnPointEnnemi.Length);
                int availableSpawn = -1;

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
                    Instantiate(CardLvl1[randomCard], SpawnPointEnnemi[availableSpawn].transform.position,
                        Quaternion.identity);
                    CanSpawn[availableSpawn] = true;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }


}
