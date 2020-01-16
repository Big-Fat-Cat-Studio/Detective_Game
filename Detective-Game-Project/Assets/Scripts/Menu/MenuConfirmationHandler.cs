using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuConfirmationHandler : MonoBehaviour
{
    public UnityEvent ExecuteConfirm;
    public UnityEvent ExecuteDecline;

    public GameObject DialoguePrefab;

    [Tooltip("Dialogue header text.")]          public string headerText;
    [Tooltip("Dialogue body text.")]            public string bodyText;
    [Tooltip("Dialogue confirm button text.")]  public string confirmText;
    [Tooltip("Dialogue decline button text;")]  public string declineText;

    private void OnEnable()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShowDialogue();
            });
    }

    private void OnDisable()
    {
        gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void ShowDialogue()
    {
        // Grab current EventSystem
        EventSystem eV = EventSystem.current;

        // Instantiate Dialogue
        GameObject dialogue = Instantiate(DialoguePrefab);
        dialogue.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        Text dialogueTitle      = GameObject.FindGameObjectWithTag("DialogueTitle").GetComponent<Text>();
        Text dialogueBody       = GameObject.FindGameObjectWithTag("DialogueBody").GetComponent<Text>();
        Text dialogueConfirm    = GameObject.FindGameObjectWithTag("DialogueConfirm").GetComponent<Text>();
        Text dialogueCancel     = GameObject.FindGameObjectWithTag("DialogueCancel").GetComponent<Text>();

        // Assign Title/Body/Actions
        dialogueTitle.text      = headerText;
        dialogueBody.text       = bodyText;
        dialogueConfirm.text    = confirmText;
        dialogueCancel.text     = declineText;

        // Set focus on the decline button
        eV.SetSelectedGameObject(GameObject.FindGameObjectWithTag("DialogueCancelButton"));
        dialogueCancel.GetComponentInParent<Button>().OnSelect(null);

        // Assign Listeners
        GameObject.FindGameObjectWithTag("DialogueConfirmButton").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(dialogue);
            ExecuteConfirm.Invoke();
        });

        GameObject.FindGameObjectWithTag("DialogueCancelButton").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(dialogue);
            eV.SetSelectedGameObject(gameObject);
            gameObject.GetComponent<Button>().OnSelect(null);
            ExecuteDecline.Invoke();
        });

        // On press 

    }
}
