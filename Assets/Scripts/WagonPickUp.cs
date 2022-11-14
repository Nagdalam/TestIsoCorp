using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTilt(int tilt)
    {
        gameObject.transform.localRotation = Quaternion.Euler(tilt, 0, 0);
    }
}
