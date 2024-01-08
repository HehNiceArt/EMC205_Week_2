using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eEqquippedWeapon
{
    AK47,
    DesertEagle,
    RocketLauncher,
    M4A1
}
public class GameManager : MonoBehaviour
{
    [Header("PlayerStats")]
    public float basePlayerDamage;
    public float finalPlayerDamage;
    [Header("Eqquipped Weapon")]
    public eEqquippedWeapon eWeapon;
    [Header("Experience")]
    public float expToAdd;
    public float maxXP;
    public float currentXP;
    public float playerLevel;

    //updates value without playing the game
    private void OnValidate()
    {
        DamageSystem damageSystem = new DamageSystem(); 
        switch (eWeapon)
        {
            case eEqquippedWeapon.AK47:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_AK47;
               // print("AK47: " + basePlayerDamage + " + " + damageSystem.Damage_AK47 + " = " + finalPlayerDamage );
                break;
            case eEqquippedWeapon.DesertEagle:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_DEagle;
                break;
            case eEqquippedWeapon.M4A1:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_M4A1;
                break;
            case eEqquippedWeapon.RocketLauncher:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_RLauncher;
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    DamagePowerUp_WellFed();
        //}

    }

    public void DamagePowerUp_FeedingFrenzy()
    {
        DamageSystem.PowerUp powerUp = new();
        finalPlayerDamage += powerUp.FeedingFrenzy;
        Debug.Log("PowerUp Feeding Frenzy: " + powerUp.FeedingFrenzy + " Final Damage: "+ finalPlayerDamage);
    }

    public void DamagePowerUp_WellFed()
    {
        DamageSystem.PowerUp powerUp = new();
        finalPlayerDamage += finalPlayerDamage * (powerUp.WellFed / 100);
        Debug.Log(powerUp.WellFed + " " + finalPlayerDamage);
    }
    public void DamageReset()
    {
        Debug.Log("Reset damage");
    }
}
