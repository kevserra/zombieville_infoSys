using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBin : MonoBehaviour
{
   
  //Destroys blood particle system that clones and sits in the scene until destroyed***
    void Update()
    {
        Destroy(gameObject, 0.5f);
    }
}
