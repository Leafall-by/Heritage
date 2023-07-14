using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour, IPointerClickHandler
{
    public int dropChance;

    public Sprite BlackCardSprite;
    public Sprite BaseSprite;
    
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;

    [HideInInspector] public UnityEvent<Card> OnClick;
    
    [HideInInspector] public Animator animator;

    public void Init()
    {
        animator = GetComponent<Animator>();
    }
    
    public void HideCard()
    {
        name.enabled = false;
        description.enabled = false;
        gameObject.GetComponent<Image>().sprite = BlackCardSprite;
        
    }
    
    public void ShowCard()
    {
        name.enabled = true;
        description.enabled = true;
        gameObject.GetComponent<Image>().sprite = BaseSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
        OnClick?.Invoke(this);
    }
    
    abstract public void Use();

}
