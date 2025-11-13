using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image faceImage;

    public void ShowDialogue(string _name, string _text, Sprite _faceSprite)
    {
        nameText.text = _name;
        dialogueText.text = _text;
        if(faceImage != null)//äÁé ê^Ç™Ç»Ç¢èÍçáÇ‡Ç†ÇÈÇÊÇÀ
        {
            faceImage.sprite = _faceSprite;
        }
    }
}
