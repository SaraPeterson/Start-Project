using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockMonsterScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public Text crystalcount;
    public Text victory;
    private int crystalcountValue = 0;
    public AudioSource musicSource; 
    public AudioClip Background;
    public AudioClip Win;
    public AudioClip Lose;
    public AudioClip CrystalPickUp;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        crystalcount.text = "Crystals Collected: " + crystalcountValue.ToString();
        musicSource.clip = Background;
        musicSource.PlayDelayed(3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Crystal")
        {
            crystalcountValue += 1;
            crystalcount.text = "Crystals Collected: " + crystalcountValue.ToString();
          
           
            if(crystalcountValue >= 7)
            {
                musicSource.clip = Win;
                musicSource.Play();
                victory.text = "You Win! Game created by Sara Peterson";

            }
            Destroy(collision.collider.gameObject);
        }
    }
}
