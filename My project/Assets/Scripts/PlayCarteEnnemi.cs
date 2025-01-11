using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCarteEnnemi : MonoBehaviour
{
   
    [SerializeField] private GameObject[] SpawnPointEnnemi;

    [SerializeField] private float ListSize = 4;
    
    public List<GameObject> EnnemiHand = new List<GameObject>();
    public List<GameObject> CardPlay = new List<GameObject>();
    public bool[] CanSpawn;
    
    public AttackScriptEnnemi attackScriptEnnemi;

    public int randomCard;
    public GameObject cardToPlay;
    
    public bool CanMove = false;
    
    private bool CanGiveCard = true;
    public bool CanMoveCard = false;
    public int availableSpawn = -1;
    
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
        CanMove = false;
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
       yield return new WaitForSeconds(2);
      // CanMove = true;
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
                 CanMove = true;
                if (!CardPlay.Contains(piocheEnnemi.CardInstantiate))
                               {
                                   if (CardPlay.Count < ListSize)
                                   {
                                       piocheEnnemi.CardInstantiate.transform.position = SpawnPointEnnemi[availableSpawn].transform.position;
                                       CardPlay.Add(piocheEnnemi.CardInstantiate); 
                                       EnnemiHand.RemoveAt(randomCard);
                                       CanSpawn[availableSpawn] = true;
                                       
                                   }
                                                             
                                   }
                          //cardToPlay
          
             }
             
           if (CardPlay.Count > ListSize)
           {
               CanMoveCard = false;
               EnnemiHand.Add(piocheEnnemi.CardInstantiate);
               CardPlay.RemoveAt(randomCard);
               cardToPlay.transform.position = piocheEnnemi.Saved;
               
           }
                       
           
        }
        CanGiveCard = false;
        CanMoveCard = false;
        
    }
}
