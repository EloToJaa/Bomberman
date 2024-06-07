using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PlayerInfoPanel : MonoBehaviour
{
    [SerializeField] PowerupStatsViewer_SO powerupStatsViewer_SO;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private RectTransform infoContainer;
    [SerializeField] private GameObject player;

    private GameObject infoTemplate;

    private void Awake()
    {
        infoTemplate = infoContainer.GetChild(0).gameObject;
        infoTemplate.SetActive(false);
        titleText.text = player.name;
    }




}
