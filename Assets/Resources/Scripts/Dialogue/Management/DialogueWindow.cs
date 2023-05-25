using System.Collections;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DialogueChoice))]
public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayName;
    [SerializeField] private TextMeshProUGUI _displayText;
    
    [SerializeField] private GameObject _dialogueWindow;
    
    [SerializeField, Range(0f, 1f)] private float _cooldownNewLetter;
    [SerializeField] private Image _image;

    private DialogueChoice _dialogueChoice;
    
    public bool IsStatusAnswer { get; private set; }
    public bool IsPlaying { get; private set; }
    public bool CanContinueToNextLine { get; private set; }

    public float CooldownNewLetter => _cooldownNewLetter;
    
    public void Init()
    {
        IsStatusAnswer = false;
        CanContinueToNextLine = false;
        
        _dialogueChoice = GetComponent<DialogueChoice>();

        _dialogueChoice.Init();
    }

    public void SetActive(bool active)
    {
        IsPlaying = active;
        _dialogueWindow.SetActive(active);
    }

    public void SetSpriteImage(Sprite sprite)
    {
        Debug.Log(sprite.ToString());
        _image.sprite = sprite;
    }

    #region Management Text

    public void SetText(string text)
    {
        _displayText.text = text;
    }

    public void Add(string text)
    {
        _displayText.text += text;
    }

    public void ClearText()
    {
        SetText("");
    }

    public void SetName(string characterName)
    {
        _displayName.text = characterName;
    }
    
    #endregion

    public void MakeChoice()
    {
        if (CanContinueToNextLine == false)
        {
            return;
        }

        IsStatusAnswer = false;
    }

    public IEnumerator DisplayLineCoroutine(Story story)
    {
        string line = story.Continue();
        
        ClearText();

        CanContinueToNextLine = false;

        _dialogueChoice.HideChoices();

        bool isAddingRichText = false;

        yield return new WaitForSeconds(.001f);

        foreach (char letter in line)
        {
            if (Input.GetMouseButtonDown(0)) // TODO: Заменить на мобильное управление
            {
                SetText(line);
                break;
            }

            isAddingRichText = letter == '<' || isAddingRichText;

            if (letter == '>')
            {
                isAddingRichText = false;
            }
            
            Add(letter.ToString());

            if (isAddingRichText == false)
            {
                yield return new WaitForSeconds(_cooldownNewLetter);
            }
        }

        CanContinueToNextLine = true;

        IsStatusAnswer = _dialogueChoice.DisplayChoices(story);
    }
}
