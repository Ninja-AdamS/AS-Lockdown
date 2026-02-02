using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UFPPC;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{

    public Camera playerCamera;
    public float interactionDistance = 1f;
    public UniversalFirstPersonPlayerController fpcS;
    public RawImage EnergyDrinkImage; 
    public RawImage BandageImage; 
    public RawImage MoneyImage;
    public bool haveEnergyDrink;
    public bool haveMoney;
    public bool haveBandage;
    public int Playerhealth;
    private bool isDamaging;
    public int Prisonerhealth;
    public AnimController PrisScript;
    public bool isPrsnerDead;
    public bool isPlyrDead;
    public int atckAMT;
    public Image healthBar;
    public BasketballAnimator baskanim;
    public randItem rndItemS;
    

    void Start()
    {
        EnergyDrinkImage.enabled = false;
        BandageImage.enabled = false;
        MoneyImage.enabled = false;
        haveMoney = false;
        haveEnergyDrink = false;
        haveBandage = false;
        Playerhealth = 100;
        Prisonerhealth = 20;
        isPrsnerDead = false;
        atckAMT = 10;
    }

    void Update()
    {
        
        if (Playerhealth <1 && isPlyrDead == false)
        {
            //skip next day once feature is implemented
            Debug.Log("U died");
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                if (hit.collider.CompareTag("Energy"))
                {   
                    haveEnergyDrink = true;
                    ShowEnergyImage();
                    Debug.Log("enery");
                    rndItemS.DestroyItem();
                }

                if (hit.collider.CompareTag("Money"))
                {   
                    haveMoney = true;
                    ShowMoneyImage();
                    Debug.Log("money");
                    rndItemS.DestroyItem();
                }

                if (hit.collider.CompareTag("Bandage"))
                {   
                    haveBandage = true;
                    ShowBandageImage();
                    Debug.Log("bandage");
                    rndItemS.DestroyItem();
                }

                if (hit.collider.CompareTag("PhoneBooth"))
                {   
                    if (Input.GetKeyDown(KeyCode.E) && haveMoney == true)
                    {
                        
                        
                        HideMoneyImage();
                    }
                }
                
                if (hit.collider.CompareTag("Basketball"))
                {
                    Debug.Log("bakeselataball");
                    baskanim.PlayAnimB();
                }
            }
        }
    

        if (Input.GetKeyDown(KeyCode.E) && haveEnergyDrink == true)
        {
            fpcS.UsePop();
            haveEnergyDrink = false;
            HideEnergyImage();
        }

        if (Input.GetKeyDown(KeyCode.E) && haveBandage == true)
        {
            Playerhealth += 25;
            healthBar.fillAmount = Playerhealth / 100f;
            haveBandage = false;
            HideBandageImage();
        }    

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {

                if (hit.collider.CompareTag("NPC"))
                {   
                    Debug.Log("Hit");
                    if (!isDamaging)
                    {
                        StartCoroutine(Damaged());
                    }

                    if (Prisonerhealth <1 && isPrsnerDead == false)
                    {
                        PrisScript.Die();
                        isPrsnerDead = true;
                    }       
                }

                if 
            }       
        }
    }

    System.Collections.IEnumerator Damaged()
    {
        isDamaging = true;
        Prisonerhealth -= atckAMT;
        yield return new WaitForSeconds(1.33f);
        isDamaging = false;
    }

    public void ShowEnergyImage()
    {
        if (EnergyDrinkImage != null)
        {
            EnergyDrinkImage.enabled = true;
        }
    }

    public void HideEnergyImage()
    {
        if (EnergyDrinkImage != null)
        {
            EnergyDrinkImage.enabled = false;
        }
    }

    public void ShowMoneyImage()
    {
        if (MoneyImage != null)
        {
            MoneyImage.enabled = true;
        }
    }

    public void HideMoneyImage()
    {
        if (MoneyImage != null)
        {
            MoneyImage.enabled = false;
        }
    }

    public void ShowBandageImage()
    {
        if (BandageImage != null)
        {
            BandageImage.enabled = true;
        }
    }

    public void HideBandageImage()
    {
        if (BandageImage != null)
        {
            BandageImage.enabled = false;
        }
    }

    public void PlayerAttacked()
    {
        Playerhealth -= 10;
        healthBar.fillAmount = Playerhealth / 100f;
    }
        
}
