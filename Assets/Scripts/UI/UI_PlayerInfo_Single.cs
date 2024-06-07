using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UI_PlayerInfo_Single : MonoBehaviour
{
    [SerializeField] private RectTransform barContainer;

    private Image image;
    private GameObject barTemplate;

    private void Awake()
    {
        image = GetComponent<Image>();
        barTemplate = barContainer.GetChild(0).gameObject;
        barTemplate.SetActive(false);
    }


}
