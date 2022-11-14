
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WagonMovement : MonoBehaviour
{
    [SerializeField] Transform[] pointsToPass;
    [SerializeField] Transform objectToMove;

    private float interpolateAmount;
    public float speedmultiplier = 1;
    private int lastPointPassed = 0;
    bool shouldMove = true;

    private bool rotationChange;
    private float rotationInterpolateAmount;
    private int desiredRotation;

    int score = 0;

    public BoxCollider hitbox;
    public BoxCollider hitboxRight;
    public BoxCollider hitboxLeft;
  
    // Update is called once per frame
    void FixedUpdate()
    {
        interpolateAmount = (interpolateAmount + Time.deltaTime * speedmultiplier) % 1f;
        if (shouldMove)
        {
            objectToMove.position = Vector3.Lerp(pointsToPass[lastPointPassed].position, pointsToPass[lastPointPassed + 1].position, interpolateAmount);
        }
        if (rotationChange)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0,desiredRotation), rotationInterpolateAmount);
            if (rotationInterpolateAmount < 1)
                rotationInterpolateAmount = (rotationInterpolateAmount + Time.deltaTime);
            else
                rotationChange = false;
        }
        if (Vector3.Distance(objectToMove.position, pointsToPass[lastPointPassed + 1].position) < .75)
        {
            if (lastPointPassed < pointsToPass.Length - 2)
            {
                interpolateAmount = 0;
                lastPointPassed++;

            }
            else
            {
                if (shouldMove == true)
                {
                   
                    shouldMove = false;
                    SoundManager.Instance.PlaySound(SoundManager.Instance.endSound);
                    GameManager.Instance.ShowEndUI();
                }

            }
        }

    }

    public void ChangeRotation(int rotationSent)
    {
        rotationChange = true;
        rotationInterpolateAmount = 0;
        desiredRotation = rotationSent;
    }

    

    public void OffSetTrigger(int offset)
    {
        if(offset > 0)
        {
            hitboxLeft.enabled = false;
            hitboxRight.enabled = true;
        }
        else if(offset < 0)
        {
            hitboxLeft.enabled = true;
            hitboxRight.enabled = false;
        }
        else
        { 
            hitboxLeft.enabled = false;
            hitboxRight.enabled = false;
        }
    }
}
