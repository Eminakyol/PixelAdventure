using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControlller : MonoBehaviour
{
    public enum tankDurumlari { atesEtme,darbeAlma,hareketEtme };
    public tankDurumlari gecerliDurum;


    [SerializeField]
    Transform tankObje;

    public Animator anim;


    [Header("Hareket")]
    public float hareketHizi;
    public Transform solHedeft, sagHedeft;
    bool yonuSagmi;

    [Header("AtesEtme")]
    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi;
    float mermiAtmaSayac;

    [Header("Darbe")]
    public float darbeSuresi;
    float darbeSayaci;


    private void Start()
    {
        gecerliDurum = tankDurumlari.atesEtme;
    }

    private void Update()
    {
        switch(gecerliDurum)
        {
            case tankDurumlari.atesEtme:
                break;

            case tankDurumlari.darbeAlma:
                if(darbeSayaci >0)
                {
                    darbeSayaci -= Time.deltaTime;

                    if(darbeSayaci <= 0)
                    {
                        gecerliDurum = tankDurumlari.hareketEtme;
                    }
                }

                break;

            case tankDurumlari.hareketEtme:

                if(yonuSagmi)
                {
                    tankObje.position += new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if(tankObje.position.x >sagHedeft.position.x)
                    {
                        tankObje.localScale = Vector3.one;
                        yonuSagmi = false;



                        HareketiDurdur();
                    }
                }else
                {
                    tankObje.position += new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if (tankObje.position.x < solHedeft.position.x)
                    {
                        tankObje.localScale = new Vector3(-1, 1, 1);
                        yonuSagmi = true;

                        HareketiDurdur();
                    }
                }
                break;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            DarbeAl();
        }

    }

    public void DarbeAl()
    {
        gecerliDurum = tankDurumlari.darbeAlma;
        darbeSayaci = darbeSuresi;

        anim.SetTrigger("Vur");
    }

    void HareketiDurdur()
    {
        gecerliDurum = tankDurumlari.atesEtme;
        mermiAtmaSayac = mermiAtmaSuresi;
        anim.SetTrigger("HareketiDurdur");
    }
}
