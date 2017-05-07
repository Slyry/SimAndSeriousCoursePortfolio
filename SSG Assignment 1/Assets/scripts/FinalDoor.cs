using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalDoor : MonoBehaviour {
    QuestionManager questionManager;
    void Start ()
    {
        questionManager = GameObject.Find("Canvas").GetComponent<QuestionManager>();


    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter door: better start talkin' bub!");
        if (other.tag == "Player")
        {
            questionManager.FinalQuestion();
        }
    }

}

