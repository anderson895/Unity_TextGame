using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Text questionText;
    public Text outcomeText;
    public GameObject panel;
    public Text endingText;

    private int currentStage = 1;

    private string[,] questionsAndChoices = new string[,]
    {
        {"The main character pressure on the academics is because he is having a hard time catching up on the lesson.", "Study", "Socialize", "Gaming"},
        {"The Main Character is taking school works.", "Study", "Socialize", "Gaming"},
        {"The Main character is having a quiz.", "Study", "Socialize", "Gaming"},
        {"The main will take a final exam.", "Study", "Socialize", "Gaming"}
    };

    private string[,] outcomes = new string[,]
    {
        // Outcomes for the 1st question
        {"GAIN INTELLIGENCE BUT NO RELAX", "WILL GAIN SOCIAL SKILLS AND NOT BE PRESSURED", "NOT BE PRESSURED BUT IT CAN DECREASE THE IQ"},

        // Outcomes for the 2nd question
        {"YOU GOT THE HIGHEST SCORE", "THE MAIN CHARACTER WILL GAIN BUT YOU GOT AVERAGE SCORE", "THE MAIN CHARACTER WILL BARELY PASS"},

        // Outcomes for the 3rd question
        {"YOU WILL PASSED", "IF YOU PICK SOCIALIZE AGAIN YOU WILL FAIL", "YOU WILL FAIL BUT YOU WILL LEARN A VALUABLE LESSON"},

        // Outcomes for the 4th question
        {"YOU WILL GET A PERFECT SCORE", "YOU WILL GET A GOOD SCORE THAT A FRIEND HELPED YOU REVIEW EXAM", "YOU WILL GET DECENT GRADES"}
    };

    private string[] chosenOptions; // Array to store the chosen options for each stage

    void Start()
    {
        outcomeText.gameObject.SetActive(false);
        panel.SetActive(false);
        chosenOptions = new string[questionsAndChoices.GetLength(0)];

        ShowQuestion();
    }

    public void OnButtonClick(int choice)
    {
        if (currentStage <= questionsAndChoices.GetLength(0))
        {
            string chosenOption = questionsAndChoices[currentStage - 1, choice];
            Debug.Log("Stage " + currentStage + " - Chosen Option: " + chosenOption);

            outcomeText.text = outcomes[currentStage - 1, choice - 1];
            outcomeText.gameObject.SetActive(true);

            chosenOptions[currentStage - 1] = chosenOption; // Store the chosen option for the current stage

            Invoke("MoveToNextStage", 2f);
        }
    }

    private void MoveToNextStage()
    {
        currentStage++;
        outcomeText.gameObject.SetActive(false);

        if (currentStage <= questionsAndChoices.GetLength(0))
        {
            ShowQuestion();
        }
        else
        {
            ShowFinalOutcome();
        }
    }

    private void ShowQuestion()
    {
        questionText.text = questionsAndChoices[currentStage - 1, 0];
    }

    private void ShowFinalOutcome()
    {
        panel.SetActive(true);
        string finalOutcome = GetFinalOutcomeFromChoices();
        endingText.text = finalOutcome;
    }
    private string GetFinalOutcomeFromChoices()
    {
        if (chosenOptions[0] == "Gaming" && chosenOptions[1] == "Gaming" && chosenOptions[2] == "Gaming" && chosenOptions[3] == "Gaming")
        {
            return "THE MAIN CHARACTER DECIDE TO QUIT COLLEGE AND BECOME PRO PLAYER AND BECOME SUCCESS ON THE INDUSTRY BECAUSE OF GAMING PASSION";
        }
        else if (chosenOptions[0] == "Gaming" && chosenOptions[1] == "Gaming" && chosenOptions[2] == "Study" && chosenOptions[3] == "Study")
        {
            return "YOU WILL BECOME A PRO SMART PLAYER BY IMPLEMENTING YOUR STUDIES";
        }
        else if (chosenOptions[0] == "Gaming" && chosenOptions[1] == "Gaming" && chosenOptions[2] == "Socialize" && chosenOptions[3] == "Socialize")
        {
            return "By the power of socializing and gaming you tried become a youtuber and collab with famous people like pewdiepie, jack, and mark";
        }
        else if (chosenOptions[0] == "Gaming" && chosenOptions[1] == "Gaming" && chosenOptions[2] == "Gaming" && chosenOptions[3] == "Socialize")
        {
            return "You will gain great skills on gaming but you will have bad communication with your teammate";
        }
        else if (chosenOptions[0] == "Gaming" && chosenOptions[1] == "Gaming" && chosenOptions[2] == "Gaming" && chosenOptions[3] == "Study")
        {
            return "You will be good at gaming but you will be bad at academics";
        }
        else if (chosenOptions[0] == "Study" && chosenOptions[1] == "Study" && chosenOptions[2] == "Study" && chosenOptions[3] == "Study")
        {
            return "The main character will gain award summa cum laude and become the highest position on their job";
        }
        else if (chosenOptions[0] == "Study" && chosenOptions[1] == "Study" && chosenOptions[2] == "Gaming" && chosenOptions[3] == "Gaming")
        {
            return "You will become a pro smart player by implementing your studies";
        }
        else if (chosenOptions[0] == "Study" && chosenOptions[1] == "Study" && chosenOptions[2] == "Socialize" && chosenOptions[3] == "Socialize")
        {
            return "You will graduate and manage to balance the bonds with your friends and family";
        }
        else if (chosenOptions[0] == "Study" && chosenOptions[1] == "Study" && chosenOptions[2] == "Study" && chosenOptions[3] == "Socialize")
        {
            return "You will finish your studies and become cum laude, but the disadvantage is you don't have soft skills to communicate with others";
        }
        else if (chosenOptions[0] == "Study" && chosenOptions[1] == "Study" && chosenOptions[2] == "Study" && chosenOptions[3] == "Gaming")
        {
            return "You will prioritize study more than a hobby. You will abandon your love for games and become a diligent person";
        }
        else if (chosenOptions[0] == "Socialize" && chosenOptions[1] == "Socialize" && chosenOptions[2] == "Socialize" && chosenOptions[3] == "Socialize")
        {
            return "The main character will gain networking skills and negotiation skills to improve the business, and also cherish the memories of their friends";
        }
        else if (chosenOptions[0] == "Socialize" && chosenOptions[1] == "Socialize" && chosenOptions[2] == "Gaming" && chosenOptions[3] == "Gaming")
        {
            return "By the power of socializing and gaming, you tried to become a YouTuber and collaborate with famous people like PewDiePie, Jack, and Mark";
        }
        else if (chosenOptions[0] == "Socialize" && chosenOptions[1] == "Socialize" && chosenOptions[2] == "Socialize" && chosenOptions[3] == "Study")
        {
            return "You will gain many friends.";
        }
        else if (chosenOptions[0] == "Socialize" && chosenOptions[1] == "Socialize" && chosenOptions[2] == "Socialize" && chosenOptions[3] == "Gaming")
        {
            return "You will have good communication but you will be bad at playing games.";
        }
        else if (chosenOptions[0] == "Socialize" && chosenOptions[1] == "Socialize" && chosenOptions[2] == "Study" && chosenOptions[3] == "Study")
        {
            return "You will graduate and manage to balance the bonds with your friends and family";
        }
        else
        {
            return "OTHER OUTCOME";
        }
    }

}
