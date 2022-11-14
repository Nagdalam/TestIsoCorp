using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownTrigger : MonoBehaviour
{
    public int rotationDesired;
    public float speedMultiplier;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<WagonMovement>() != null)
            {
                other.GetComponent<WagonMovement>().ChangeRotation(rotationDesired);
                other.GetComponent<WagonMovement>().speedmultiplier = speedMultiplier;
            }
        }
    }
}
