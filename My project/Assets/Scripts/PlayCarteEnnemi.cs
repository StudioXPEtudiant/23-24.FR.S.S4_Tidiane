using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCarteEnnemi : MonoBehaviour
{
   
    [SerializeField] private GameObject[] SpawnPointEnnemi;
    [SerializeField] private bool[] CanSpawn;
    
    public List<GameObject> EnnemiHand = new List<GameObject>();
    public List<GameObject> CardPlay = new List<GameObject>();
    
    private bool CanGiveCard = true;
    private bool CanMoveCard = false;
    private int availableSpawn = -1;
    
    private float TimeBeforePlayCarte = 0.1f;
    
    public PiocheEnnemi piocheEnnemi;
    
    void Start()
    {
       
        
        CanSpawn = new bool [SpawnPointEnnemi.Length];

        for (int i = 0; i < CanSpawn.Length; i++)
        {
            CanSpawn[i] = false;
        }
        CanGiveCard = false;
        CanMoveCard = false;
    }

    
    void Update()
    {
       
    }

    public void FirstTurn()
    {
        
    }
    
   public IEnumerator EnnemiTurn()
    { 
        //Saved = transform.position;
       yield return new WaitForSeconds(3);
        EnnemiHand.Add(piocheEnnemi.CardInstantiate);
        CanGiveCard = true;
      
        if (CanGiveCard)
        {
       
            int randomSpawn = Random.Range(0, SpawnPointEnnemi.Length);
            int randomCard = Random.Range(0, EnnemiHand.Count);
            GameObject cardToPlay = EnnemiHand[randomCard];
            
            for (int i = 0; i < SpawnPointEnnemi.Length; i++)
            {
                if (!CanSpawn[i])
                {
                    availableSpawn = i;
                 
                }
            }
            
             if (availableSpawn != -1)
             {
                 CanMoveCard = true;
                 
                if (!CardPlay.Contains(cardToPlay))
                                {
                                  cardToPlay.transform.position = SpawnPointEnnemi[availableSpawn].transform.position;
                                        CardPlay.Add(cardToPlay);
                                        EnnemiHand.RemoveAt(randomCard);
                                        CanSpawn[availableSpawn] = true;
                                       
                                }
                
            }
             
           if (availableSpawn == -1)
           {
               cardToPlay.transform.position = piocheEnnemi.Saved;
            }
                       
           
        }
        CanGiveCard = false;
        
       
    }
    
    
    
}
