using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerEquipmentManager pM;
    public string itemName;
    public GameObject itemContainer;
    public Transform weaponHold;
    public int itemID;

    int previousID;
    bool isCreated;
    bool destroyPrev;
    public static PlayerEquipmentManager Instance {  get; private set; }
    private void Start()
    {
    pM = GetComponent<PlayerEquipmentManager>();
    }
    private void Update()
    {
        WeaponsCheck();
        WeaponsModelUpdate();
        if(previousID != itemID)
        {
            previousID = itemID;
            isCreated = true;
            destroyPrev = true;
        }
    }
    public void WeaponsCheck()
    {
        itemName = pM.ItemsList[itemID].itemName;
        itemContainer = pM.ItemsList[itemID].itemContainer;
    }
    public void WeaponsModelUpdate()
    {
        if(isCreated)
        {
            GameObject weapon = Instantiate(itemContainer, weaponHold.transform);
            weapon.transform.SetParent(weaponHold.transform);
            isCreated = false;
            if(destroyPrev)
            {
                var prevWeapon = itemContainer.transform.GetChild(0);
                Destroy(prevWeapon);
                destroyPrev = false;
            }
        }
    }

}
