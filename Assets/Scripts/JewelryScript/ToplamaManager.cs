using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaManager : MonoBehaviour
{
    [SerializeField]
    bool mucevhermi, kirazmi;

    [SerializeField]
    GameObject toplamaEfekti;

    bool toplandimi;


    LevelManager  LevelManager;
    UIController uiController;
    PlayerHealthController playerHealthController;

    private void Awake()
    {
        LevelManager = Object.FindObjectOfType<LevelManager>();
        uiController = Object.FindObjectOfType<UIController>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !toplandimi)
        {
            if (mucevhermi)
            {
                LevelManager.toplananMucevherSayisi++;

                toplandimi = true;
                Destroy(gameObject);

                uiController.MucevherSayisiniGuncelle();

                Instantiate(toplamaEfekti, transform.position, transform.rotation);
            }

            if(kirazmi)
            {
                if(playerHealthController.gecerliSaglik != playerHealthController.maxSaglik)
                {
                    
                    toplandimi = true;
                    Destroy(gameObject);
                    playerHealthController.CaniArtir();
                    Instantiate(toplamaEfekti, transform.position, transform.rotation);
                }
            }

            
        }
    }
}
