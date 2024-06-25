using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Image can1_Img, can2_Img, can3_Img;


    [SerializeField]
    Sprite doluCan, yarimCan ,bosCan;

    

    [SerializeField]
    TMP_Text mucevherTxt;

    PlayerHealthController playerHealthController;

    LevelManager levelManager;

    public GameObject fadeScreen;


    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        levelManager = Object.FindObjectOfType<LevelManager>();
    }

    public void SaglikDurumunuGuncelle()
    {
        switch(playerHealthController.gecerliSaglik)
        {
            case 6:
                can1_Img.sprite = doluCan;
                can2_Img.sprite = doluCan;
                can3_Img.sprite = doluCan;
                break;

            case 5:
                can1_Img.sprite = doluCan;
                can2_Img.sprite = doluCan;
                can3_Img.sprite = yarimCan;
                break;

            case 4:
                can1_Img.sprite = doluCan;
                can2_Img.sprite = doluCan;
                can3_Img.sprite = bosCan;
                break;
            case 3:
                can1_Img.sprite = doluCan;
                can2_Img.sprite = yarimCan;
                can3_Img.sprite = bosCan;
                break;

            case 2:
                can1_Img.sprite = doluCan;
                can2_Img.sprite = bosCan;
                can3_Img.sprite = bosCan;
                break;

            case 1:
                can1_Img.sprite = yarimCan;
                can2_Img.sprite = bosCan;
                can3_Img.sprite = bosCan;
                break;


            case 0:
                can1_Img.sprite = bosCan;
                can2_Img.sprite = bosCan;
                can3_Img.sprite = bosCan;
                break;

        }

    }

    public void MucevherSayisiniGuncelle()
    {
        mucevherTxt.text = levelManager.toplananMucevherSayisi.ToString();
    }

    public void FadeEkraniAc()
    {
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }


}
