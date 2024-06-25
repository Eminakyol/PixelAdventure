using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float hareketHizi;

    [SerializeField]
    float ziplamaGucu;

    bool yerdemi;
    public Transform zeminKontrolNoktasi;
    public LayerMask zeminLayer;
    bool ikiKezZiplayabilirmi;


    public float geriTepmeSuresi, geriTepmeGucu;
    float geriTepmeSayaci;
    bool yonSagmi;

    public float ziplaZiplaGucu;



    Rigidbody2D rb;

    Animator anim;

    public bool hareketEtsinmi;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        hareketEtsinmi = true;
    }

    private void Update()
    {
        if(hareketEtsinmi)
        {
            if (geriTepmeSayaci <= 0)
            {
                HareketEttir();
                Zipla();
                YonuDegistir();
            }
            else
            {
                geriTepmeSayaci -= Time.deltaTime;

                if (yonSagmi)
                {
                    rb.velocity = new Vector2(-geriTepmeGucu, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(geriTepmeGucu, rb.velocity.y);
                }
            }

            anim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
            anim.SetBool("yerdemi", yerdemi);

        } else
        {
            rb.velocity = Vector2.zero;
            anim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
        }


    }

    void HareketEttir()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * hareketHizi;

        rb.velocity = new Vector2(hiz, rb.velocity.y);
    }


    void Zipla()
    {
        yerdemi = Physics2D.OverlapCircle(zeminKontrolNoktasi.position, .2f, zeminLayer);

        if(yerdemi)
        {
            ikiKezZiplayabilirmi = true;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if(yerdemi)
            {
                rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
            } else
            {
                if(ikiKezZiplayabilirmi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
                    ikiKezZiplayabilirmi = false;
                }
                
            }
            
        }

        
    }

    void YonuDegistir()
    {
        Vector2 geciciScale = transform.localScale;

        if(rb.velocity.x > 0)
        {
            yonSagmi = true;
            geciciScale.x = 1f;
        }
        else if(rb.velocity.x < 0)
        {
            yonSagmi = false;
            geciciScale.x = -1f;
        }

        transform.localScale = geciciScale;
    }

    public void GeriTepme()
    {
        geriTepmeSayaci = geriTepmeSuresi;
        rb.velocity = new Vector2(0, rb.velocity.y);

        anim.SetTrigger("hasar");
    }

    public void ZiplaZipla()
    {
        rb.velocity = new Vector2(rb.velocity.x, ziplaZiplaGucu);
    }
}
