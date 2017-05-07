using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : MonoBehaviour
{
    QuestionManager questionManager;   //the panel to display the questions and choices

    [SerializeField] string question;           //The question
    public List<QuestionManager.Choice> options = new List<QuestionManager.Choice>();  //the list of choices the player can choose from

    void Start()
    {
        questionManager = GameObject.Find("Canvas").GetComponent<QuestionManager>();
        Debug.Log(questionManager);
        if(questionManager == null)
        {
            throw new System.Exception("There is no Canvas in the scene OR there is no \"QuestionManager\" script attached!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter door: better start talkin' bub!");
        if(other.tag == "Player")
        {
            questionManager.CreateNewQuestion(question, options, this.transform);
        }
    }
}
