using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{
    public Weapon2D weapon2D;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateAmmoText();
    }

    private void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        text.text = $"{weapon2D.currentMag} / {weapon2D.maxMagSize} | {weapon2D.currentAmmo} / {weapon2D.maxAmmoSize}";
    }

}
