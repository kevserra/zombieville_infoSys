using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Weapon2D weapon2D = collision.gameObject.GetComponent<Weapon2D>();
        if (weapon2D)
        {
            AudioManager.Instance.PlaySFX("AmmoPUp");
            weapon2D.AddAmmo(weapon2D.ammoPickup);
            Destroy(gameObject);
        }
    }
}
