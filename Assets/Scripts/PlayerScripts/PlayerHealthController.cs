using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int  maxSaglik, gecerliSaglik;

    [SerializeField]
    GameObject yokOlmaEfekti;

    UIController uiController;

    public float yenilmezlikSuresi;

    float yenilmezlikSayaci;

    SpriteRenderer sr;

    PlayerController playerController;


    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        uiController = Object.FindObjectOfType<UIController>();
    }


    private void Start()
    {
        gecerliSaglik = maxSaglik;
    }

    private void Update()
    {
        yenilmezlikSayaci -= Time.deltaTime;

        if(yenilmezlikSayaci <=0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }

    public void HasarAl()
    {
        if(yenilmezlikSayaci <= 0)
        {
            gecerliSaglik--;

            if (gecerliSaglik <= 0)
            {
                gecerliSaglik = 0;
                gameObject.SetActive(false);

                Instantiate(yokOlmaEfekti, transform.position, transform.rotation);
            }
            else
            {
                yenilmezlikSayaci = yenilmezlikSuresi;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

                playerController.GeriTepme();
            }
            uiController.SaglikDurumunuGuncelle();
        }
        
    }

    public void CaniArtir()
    {
        gecerliSaglik++;
        if(gecerliSaglik >= maxSaglik)
        {
            gecerliSaglik = maxSaglik;
        }

        uiController.SaglikDurumunuGuncelle();
    }



}
