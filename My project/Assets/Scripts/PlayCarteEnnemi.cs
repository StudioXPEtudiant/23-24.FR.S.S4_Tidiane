using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCarteEnnemi : MonoBehaviour
{
   
    [SerializeField] private GameObject[] SpawnPointEnnemi;

    [SerializeField] private float ListSize = 5;
    
    private bool CanGiveCard = true;
    
    public List<GameObject> EnnemiHand = new List<GameObject>();
    public List<GameObject> CardPlay = new List<GameObject>();
   
   // public GameObject[] AGameObject;
    public GameObject[] AssigneGameObject;
    public GameObject[] ReferenceCase;
    public bool[] CanSpawn;
    public AttackScriptEnnemi attackScriptEnnemi;
    public ListOfEnnemiCard listOfEnnemiCard;

    public int randomCard;
    public GameObject cardToPlay;
    
    public bool CanMove = false;
   
    public bool CanMoveCard = false;
    public int availableSpawn = 0;
    public bool CanChangeSpawn;
    public int aleatory;
    public PiocheEnnemi piocheEnnemi;
    
    void Start()
    {
         AssigneGameObject = new GameObject[4];
         ReferenceCase = new GameObject[2];
         CanSpawn = new bool [4];
        
        for (int i = 0; i < CanSpawn.Length; i++)
        {
            CanSpawn[i] = false;
            AssigneGameObject[i] = null;
        }
        CanGiveCard = false;
        CanMoveCard = false;
        CanMove = false;
        CanChangeSpawn = true;

        availableSpawn = 4;
    }

    
    void Update()
    {
       
    }

    public void FirstTurn()
    {
     
    }

    public IEnumerator EnnemiTurn()
    {
        yield return new WaitForSeconds(2);
        EnnemiHand.Add(piocheEnnemi.CardInstantiate);
        CanGiveCard = true;

        if (CanGiveCard)
        {

            int randomSpawn = Random.Range(0, SpawnPointEnnemi.Length);
            int randomCard = Random.Range(0, EnnemiHand.Count);

            aleatory = Random.Range(0, 3);
            

            cardToPlay = piocheEnnemi.CardInstantiate;

            for (int i = 0; i < SpawnPointEnnemi.Length; i++)
            {
               if (!CanSpawn[i])
                {
                    availableSpawn = i;

                }
            }


            if (availableSpawn != -2)
            {
                EnnemiHand.Remove(cardToPlay);
                CanMoveCard = true;
                CanMove = true;
                EnnemiHand.Remove(cardToPlay);
                if (!CardPlay.Contains(piocheEnnemi.CardInstantiate))
                {
                    if (CardPlay.Count < ListSize)
                    {
                        piocheEnnemi.CardInstantiate.transform.position = 
                        SpawnPointEnnemi[availableSpawn].transform.position;
                        
                        if (availableSpawn == 0)
                        {
                            ReferenceCase[1] = cardToPlay;
                        }
                        
                        CardPlay.Add(cardToPlay);

                        AssigneGameObject[availableSpawn] = cardToPlay;
                        
                       CanSpawn[availableSpawn] = true;
                    }

                }
            }
            
            if (CardPlay.Count > ListSize)
            {
                CanMoveCard = false;
                EnnemiHand.Add(cardToPlay);
                CardPlay.RemoveAt(randomCard);
                cardToPlay.transform.position = piocheEnnemi.Saved;
            }
            CanGiveCard = false;
            CanMoveCard = false;
        }
    }
}
