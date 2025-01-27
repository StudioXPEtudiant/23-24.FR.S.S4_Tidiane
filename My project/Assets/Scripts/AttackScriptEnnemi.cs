using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class AttackScriptEnnemi : MonoBehaviour
{
    [SerializeField] private float CardDamage;
    [SerializeField] private float CardHealth;	
   
   
    [SerializeField] private Vector2 origin;

    [SerializeField] private Text ShowCardHealth;

    public GameObject CardEnnemiToPlay;
    public UnityEvent makeDamage;
    public bool CanMakeDamage = false;
    public PlayCarteEnnemi playCarteEnnemi;
    public RaycastHit2D hit;
    public string Tag;
    public bool CanShowRaycast = false;
    public float ActualHealth;
	public ListOfEnnemiCard listOfEnnemiCard;
	public PiocheEnnemi piocheEnnemi;    
	public bool CanDestroy;

    void Start()
    {
        ActualHealth = CardHealth;
       // CanShowRaycast = false;
        CanShowRaycast = true;
		CanMakeDamage = false;
    }

    
    void Update()
    {
        if (CanMakeDamage == true)
        {
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.tag == "card")
                {
                    AttackScript attackScript = hit.collider.GetComponent<AttackScript>();
                    if (attackScript != null)
                    {
                       attackScript.ActualHealth -= CardDamage;

                       
                        
                    }
                    CanMakeDamage = false;
                }
            }
        }
		if (CanDestroy == true)
			{
  				//if (ActualHealth < 0)
             	//{
             		Destroy(gameObject);
             //	}
            
             	//if (ActualHealth == 0)
             //	{
               	//Destroy(gameObject);
             	//}
			}          
   
        if (gameObject.tag == "EnnemiCard")
        {
            
            origin = (Vector2)transform.position - new Vector2 (0,1);
                        
                        hit = Physics2D.Raycast(origin, Vector2.down, 3);
                        Debug.DrawRay(origin, Vector2.down * 3, Color.red);
            
        //if (CanShowRaycast == true)
        //{
            
            
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.tag == "card")
                    {
                       // CanMakeDamage = true;
						//Debug.Log("true");
						
                        //CanShowRaycast = false;
                    }
                 //}
            } 
      	}
    }

    private void CanRaycast()
    {
      
    }
   
    
}
