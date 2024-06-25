using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EziciKutuController : MonoBehaviour
{
    [SerializeField]
    GameObject yokOlmaEfekti;

    [SerializeField]
    GameObject toplamaEfekti;
    [SerializeField]
    bool kirazmi;

    bool toplandimi;

    PlayerController playerController;
    ToplamaManager toplamaManager;
    PlayerHealthController playerHealthController;


    public float kirazinCikmaSansi;

    public GameObject kirazObje;


    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        toplamaManager = Object.FindObjectOfType<ToplamaManager>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kurbaga"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(yokOlmaEfekti, transform.position, transform.rotation);

            playerController.ZiplaZipla();

            float cikmaAraligi = Random.Range(0f, 100f);

            if(cikmaAraligi <= kirazinCikmaSansi)
            {
                Instantiate(kirazObje, other.transform.position, other.transform.rotation);
                
            }
        }

        if (other.CompareTag("Player") && !toplandimi)
        {
            if (kirazmi)
            {
                if (playerHealthController.gecerliSaglik != playerHealthController.maxSaglik)
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
