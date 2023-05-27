using System;
using System.Collections;
using Ink.Runtime;
using UnityEngine;

[RequireComponent(typeof(DialogueWindow), typeof(DialogueTag))]
public class DialogueController : MonoBehaviour
{
    private DialogueWindow _dialogueWindow;
    private DialogueTag _dialogueTag;
    
    public Story CurrentStory { get; private set; }

    private Coroutine _displayLineCoroutine;

    private void Awake()
    {
        _dialogueWindow = GetComponent<DialogueWindow>();
        _dialogueTag = GetComponent<DialogueTag>();
        
        _dialogueWindow.Init();
        _dialogueTag.Init();
    }

    private void Start()
    {
        _dialogueWindow.SetActive(false);
    }

    private void Update()
    {
        if (_dialogueWindow.IsStatusAnswer == true || 
            _dialogueWindow.IsPlaying == false ||
            _dialogueWindow.CanContinueToNextLine == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//TODO: Сменить управление на мобилку
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        CurrentStory = new Story(inkJSON.text);
        
        _dialogueWindow.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(_dialogueWindow.CooldownNewLetter);
        
        _dialogueWindow.SetActive(false);

        _dialogueWindow.ClearText();
    }

    private void ContinueStory()
    {
        if (CurrentStory.canContinue == false)
        {
            StartCoroutine(ExitDialogueMode());
            return;
        }

        if (_displayLineCoroutine != null)
        {
            StopCoroutine(_displayLineCoroutine);
        }

        _displayLineCoroutine = StartCoroutine(_dialogueWindow.DisplayLineCoroutine(CurrentStory));

        try
        {
            _dialogueTag.HandleTags(CurrentStory.currentTags);
        }
        catch (ArgumentException ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        _dialogueWindow.MakeChoice();

        CurrentStory.ChooseChoiceIndex(choiceIndex);

        ContinueStory();
    }
}
