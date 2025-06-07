using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FusionScript : MonoBehaviour
{
    [SerializeField] private GameObject FirstCardClick = null;
    private int FirstCardMaxClick;
    
    [SerializeField] private GameObject SecondCardClick = null;
    private int SecondCardMaxClick;
    
    [SerializeField] private GameObject SpawnCardViolette;
    [SerializeField] private GameObject SpawnCarteBlanche;
    
    private PlayCarte playCarteFirstCardClick;
    private PlayCarte playCarteSecondCardClick;
    
    private string firstCardClickName = "";
    private string SecondCardClickName = "";
    
    void Start()
    {
        FirstCardMaxClick = 0;
        SecondCardMaxClick = 0;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

           if (hit && hit.collider.CompareTag("card"))
           {
               GameObject clickedCard = hit.collider.gameObject;
               PlayCarte playCarte = clickedCard.GetComponent<PlayCarte>();

               if (playCarte.CanMoveCard == false)
               {
                   string elementTag = ElementType(clickedCard);

                   if (FirstCardClick == null)
                   {
                       FirstCardClick = clickedCard;
                       firstCardClickName = elementTag;
                       StartCoroutine(WaitBeforeResetFusion());
                   }
                   else if(SecondCardClick == null && clickedCard != FirstCardClick)
                   {
                       SecondCardClick = clickedCard;
                       SecondCardClickName = elementTag;
                       
                       StopCoroutine(WaitBeforeResetFusion());
                       
                       Fusion();
                   }
               }
           }
        }
    }

   string ElementType(GameObject card)
    {
        foreach (Transform elementType in card.transform)
        {
            if (elementType.CompareTag("FireCard")) return "FireCard";
            if (elementType.CompareTag("WaterCard")) return "WaterCard";
            if (elementType.CompareTag("PlantCard")) return "PlantCard";
            if (elementType.CompareTag("FoudreCard")) return "FoudreCard"; 
        }

        return "";
    }

   private void Fusion()
   {
       if (firstCardClickName == "" || SecondCardClickName == "") return;

       if ((firstCardClickName == "WaterCard" && SecondCardClickName == "FireCard") || (firstCardClickName == "FireCard" && SecondCardClickName == "WaterCard"))
       {
           Instantiate(SpawnCarteBlanche, FirstCardClick.transform.position, Quaternion.identity);
           Destroy(FirstCardClick);
           Destroy(SecondCardClick);
           
           FirstCardClick = null;
           SecondCardClick = null;
           
           firstCardClickName = "";
           SecondCardClickName= "";
       }
       else if ((firstCardClickName == "PlantCard" && SecondCardClickName == "FoudreCard") || (firstCardClickName == "FoudreCard" && SecondCardClickName == "PlantCard"))
       {
           Instantiate(SpawnCardViolette, FirstCardClick.transform.position, Quaternion.identity);
          Destroy(FirstCardClick);
          Destroy(SecondCardClick);
           
           FirstCardClick = null;
           SecondCardClick = null;
           
           firstCardClickName = "";
           SecondCardClickName= "";
       }
       else
       {
           FirstCardClick = null;
           SecondCardClick = null;
           
           firstCardClickName = "";
           SecondCardClickName= "";
       }
   }

    private IEnumerator WaitBeforeResetFusion()
    {
        yield return new WaitForSeconds(2);
        
        FirstCardClick = null;
        SecondCardClick = null;
           
        firstCardClickName = "";
        SecondCardClickName= "";
    }
}
