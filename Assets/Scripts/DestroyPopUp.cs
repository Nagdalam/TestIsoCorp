using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPopUp : MonoBehaviour
{
    void Start()
    {
    }
   public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
