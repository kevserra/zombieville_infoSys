using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2D : MonoBehaviour
{
    public Transform shootPoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineR;

    public int currentMag, maxMagSize = 15, currentAmmo, maxAmmoSize = 100;
    public int ammoPickup = 15;

    private void Start()
    {
        currentMag = 5;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentMag > 0)
            {
                StartCoroutine(Shoot());
                currentMag--;
            }          
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            AudioManager.Instance.PlaySFX("Reload");
            Reload();
        }
    }

    IEnumerator Shoot()
    {
        AudioManager.Instance.PlaySFX("Laser");
        RaycastHit2D hitInfo = Physics2D.Raycast(shootPoint.position, shootPoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                AudioManager.Instance.PlayZ("Grunt");
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineR.SetPosition(0, shootPoint.position);
            lineR.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineR.SetPosition(0, shootPoint.position);
            lineR.SetPosition(1, shootPoint.position + shootPoint.right * 100);
        }

        lineR.enabled = true;
        yield return 0;
        lineR.enabled = false;    
    }

    public void Reload()
    {
        int reloadAmt = maxMagSize - currentMag; //how many bullets to refill clip
        reloadAmt = (currentAmmo - reloadAmt) >= 0 ? reloadAmt : currentAmmo;
        currentMag += reloadAmt;
        currentAmmo -= reloadAmt;
    }

    public void AddAmmo(int ammoAmt)
    {
        currentAmmo += ammoAmt;
        if (currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }


    
}
