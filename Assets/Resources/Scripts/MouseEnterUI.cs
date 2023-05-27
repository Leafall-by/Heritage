using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseEnterUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image _image;

    private Coroutine _coroutineAlpha;

    private const float MINIMUM = 0.2f;
    private const float MAXIMUM = 1f;
    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_coroutineAlpha != null)
        {
            StopCoroutine(_coroutineAlpha);
        }
        
        _coroutineAlpha = StartCoroutine(SetAlpha(true));
    }

    private IEnumerator SetAlpha(bool active)
    {
        Color color = _image.color;

        if (active)
        {
            for (; color.a > MINIMUM; color.a -= .01f)
            {
                _image.color = color;
                yield return new WaitForSeconds(.01f);
            }
        }
        else
        {
            for (; color.a <= MAXIMUM; color.a += .01f)
            {
                _image.color = color;
                yield return new WaitForSeconds(.01f);
            }
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_coroutineAlpha != null)
        {
            StopCoroutine(_coroutineAlpha);
        }
        
        _coroutineAlpha = StartCoroutine(SetAlpha(false));
    }
}
