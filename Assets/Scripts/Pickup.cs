using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform playerHand; // Pozice, kde bude item držen
    private GameObject currentItem; // Aktuální item, který hráè zvedá
    private bool isHoldingItem = false; // Kontrola, zda hráè drží item

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingItem)
            {
                DropItem();
            }
            else
            {
                TryPickupItem();
            }
        }
    }

    void TryPickupItem()
    {
        // Kontrola kolizí pomocí SphereCast
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f); // Polomìr detekce
        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("PickupItem"))
            {
                PickupItem(collider.gameObject);
                break;
            }
        }
    }

    void PickupItem(GameObject item)
    {
        currentItem = item;
        isHoldingItem = true;

        // Deaktivace fyziky a pøipojení k hráèi
        Rigidbody itemRb = currentItem.GetComponent<Rigidbody>();
        if (itemRb != null)
        {
            itemRb.isKinematic = true;
        }
        currentItem.GetComponent<Collider>().enabled = false;

        // Pøesunutí itemu do ruky
        currentItem.transform.SetParent(playerHand);
        currentItem.transform.localPosition = Vector3.zero;
        currentItem.transform.localRotation = Quaternion.identity;
    }

    void DropItem()
    {
        if (currentItem == null) return;

        // Reaktivace fyziky a odpojení od hráèe
        Rigidbody itemRb = currentItem.GetComponent<Rigidbody>();
        if (itemRb != null)
        {
            itemRb.isKinematic = false;
        }
        currentItem.GetComponent<Collider>().enabled = true;

        // Odstranìní parentingu a odhození itemu
        currentItem.transform.SetParent(null);
        currentItem = null;
        isHoldingItem = false;
    }
}
