    using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    /*USE THIS IF YOU WANT TO GET A VALUE... (sorry it's a little complex)
     * targetPlayer.playerPersonality[(PersonalityTrait)ButtonNum];
     * 
     * get the PlayerController (in this case: targetPlayer.  variable name may change depending on class)
     * get the dictionary name (which is called: playerPersonality)
     * 
     * inside[], get the index by the "PersonalityTrait" enum
     * you'll need to cast the integer (in this case: ButtonNum) into a "PersonalityTrait" enum
     *          this is done by: [(PersonalityTrait)desiredIndexNum]
     */

    public PlayerController targetPlayer;
    [SerializeField]
    GameObject MainPanel;
    [SerializeField]
    Text QuestionText;
    [SerializeField]
    Text[] ButtonsForEachChoice;

    #region TraitText
    [SerializeField]
    Text Trait1;
    [SerializeField]
    Text Trait2;
    [SerializeField]
    Text Trait3;
    [SerializeField]
    Text Trait4;

    [SerializeField]
    GameObject FinalPanel;

    #endregion


    public enum PersonalityTrait { TRAIT1, TRAIT2, TRAIT3, TRAIT4 };    //the different personality types (add or remove as needed)

    [System.Serializable]
    public struct Choice
    {
        public string displayChoice;      //The choice visible to the player (What's your favorite animal?  A choice would be: "Goats")
        public PersonalityTrait trait;    //which personality type does this choice apply to?
        public int traitWeight;           //how many points are applied to this personality type if the player selects this choice (one is recommended)
    }

    void Start()
    {
        FinalPanel.SetActive(false);
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private List<Choice> options;
    private Transform targetDoor;

    public void CreateNewQuestion(string question, List<Choice> choices, Transform door)
    {
        targetDoor = door;
        QuestionText.text = question;

        //save this list for future use
        options = choices;

        //loop as long as we have enough buttons (4) AND enough choices to fill those buttons (say, the designer only provided 3, we'd only fill 3 buttons)
        for (int x = 0; x < choices.Count && x < ButtonsForEachChoice.Length; x++)
        {
            //set the description for each button
            ButtonsForEachChoice[x].text = choices[x].displayChoice;
        }

        MainPanel.SetActive(true);
    }

    public void UpdatePersonality(int ButtonNum)
    {
        //increment the player's personality by one
        targetPlayer.playerPersonality[(PersonalityTrait)ButtonNum]++;

        //USE THIS IF YOU WANT TO GET A VALUE... (sorry it's a little complex)
        Debug.Log(targetPlayer.playerPersonality[(PersonalityTrait)ButtonNum]);

        //the question has been answered, so close this canvas and deactivate the door
        MainPanel.SetActive(false);
        targetDoor.gameObject.SetActive(false);
    }

    void Update ()
    {

        Trait1.text = targetPlayer.playerPersonality[PersonalityTrait.TRAIT1].ToString();
        Trait2.text = targetPlayer.playerPersonality[PersonalityTrait.TRAIT2].ToString();
        Trait3.text = targetPlayer.playerPersonality[PersonalityTrait.TRAIT3].ToString();
        Trait4.text = targetPlayer.playerPersonality[PersonalityTrait.TRAIT4].ToString();
    }

    public void FinalQuestion ()
    {

        FinalPanel.SetActive(true);

    }

}

