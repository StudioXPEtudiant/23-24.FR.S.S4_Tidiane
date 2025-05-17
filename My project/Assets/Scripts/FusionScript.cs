using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FusionScript : MonoBehaviour
{
    [SerializeField] private GameObject FirstCardClick;
    private int FirstCardMaxClick;
    
    [SerializeField] private GameObject SecondCardClick;

    [SerializeField] private GameObject SpawnCardViolette;

    private PlayCarte playCarteFirstCardClick;
    private PlayCarte playCarteSecondCardClick;
    
    void Start()
    {
        FirstCardMaxClick = 0;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
           
           if (hit)
           {
                if (FirstCardMaxClick == 0)
                {
                    FirstCardClick = hit.collider.gameObject;
                    playCarteFirstCardClick = FirstCardClick.GetComponent<PlayCarte>();
                }
          
                if (FirstCardMaxClick == 1)
                {
                    SecondCardClick = hit.collider.gameObject;
                    playCarteSecondCardClick = SecondCardClick.GetComponent<PlayCarte>();
                }

                if (FirstCardMaxClick == 2)
                {
                    SecondCardClick = hit.collider.gameObject;
                    playCarteSecondCardClick = SecondCardClick.GetComponent<PlayCarte>();
                }

                if (playCarteFirstCardClick.CanMoveCard == false)
                {
                    if (FirstCardClick.CompareTag("card"))
                    {
                        foreach (Transform elementType in FirstCardClick.transform)
                        {
                            if (elementType.CompareTag("WaterCard") && FirstCardMaxClick == 0)
                            {
                                FirstCardMaxClick = 1;
                                StartCoroutine(WaitBeforeResetFusion());
                            }

                            if (elementType.CompareTag("FireCard") && FirstCardMaxClick == 0)
                            {
                                FirstCardMaxClick = 2;
                                StartCoroutine(WaitBeforeResetFusion());
                            }

                        }
                    }
                }

                if (playCarteSecondCardClick.CanMoveCard == false)
                {
                    if (SecondCardClick.CompareTag("card"))
                    {
                        foreach (Transform elementType in SecondCardClick.transform)
                        {
                            if (elementType.CompareTag("FireCard") && FirstCardMaxClick == 1)
                            {
                               StopCoroutine(WaitBeforeResetFusion());
                                Instantiate(SpawnCardViolette, FirstCardClick.transform.position, Quaternion.identity);
                            Destroy(FirstCardClick);
                            Destroy(SecondCardClick);
                            FirstCardMaxClick = 0;
                            
                            }
                            if (elementType.CompareTag("WaterCard") && FirstCardMaxClick == 2)
                            {
                                StopCoroutine(WaitBeforeResetFusion());
                                Instantiate(SpawnCardViolette, FirstCardClick.transform.position, Quaternion.identity);
                            Destroy(FirstCardClick);
                            Destroy(SecondCardClick);
                            FirstCardMaxClick = 0;
                            
                            }
                        
                        }
                    } 
                }
                
           }
        }
    }

    private IEnumerator WaitBeforeResetFusion()
    {
        yield return new WaitForSeconds(2);
        FirstCardMaxClick = 0;
    }
}
