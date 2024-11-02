using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCarteEnnemi : MonoBehaviour
{
    [SerializeField] private GameObject CardToPlayEnnemi;
    [SerializeField] private GameObject[] SpawnPointCardToPlay;
    [SerializeField] private bool[] CanPlayCarteEnnemi;
    
    public bool CanPlayCarte = false;
    
    void Start()
    {
        CanPlayCarteEnnemi = new bool [SpawnPointCardToPlay.Length];

        for (int i = 0; i < CanPlayCarteEnnemi.Length; i++)
        {
            CanPlayCarteEnnemi[i] = false;
        }
    }

    
    void Update()
    {
        if (CardToPlayEnnemi.gameObject.tag == "EnnemiCard")
            {
                if (CanPlayCarte == true)
                {
                    int availableSpawn = -1;
                    
                    for (int i = 0; i < CanPlayCarteEnnemi.Length; i++)
                    {
                        if (!CanPlayCarteEnnemi[i])
                        {
                            availableSpawn = i;
					
                        }
                    }
                } 
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
