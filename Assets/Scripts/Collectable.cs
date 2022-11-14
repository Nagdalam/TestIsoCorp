using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreToAdd;
    public GameObject popUp;

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
            Debug.Log("Picked object");
                GameManager.Instance.UpdateScore(scoreToAdd);
                GameObject newPopup = Instantiate(popUp, this.transform.position, Quaternion.Euler(0,-90,0));
                if (Mathf.Sign(scoreToAdd) == 1)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.goodSound);
                    Debug.Log("Good " + gameObject.name);
                    newPopup.GetComponent<TextMesh>().text = ("+ " + scoreToAdd.ToString());
                    newPopup.GetComponent<TextMesh>().color = Color.green;
                }
                else
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.badSound);
                    Debug.Log("Bad " + gameObject.name);
                    newPopup.GetComponent<TextMesh>().text = (scoreToAdd.ToString());
                    newPopup.GetComponent<TextMesh>().color = Color.red;
                }
                Destroy(gameObject);
            }
        }
    }
}
