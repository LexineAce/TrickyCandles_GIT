using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //player movement
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    Vector2 movement;

    //flame count
    private int count;
    public Text winText;
    public Text restartText;

    //spawns more flames
    private int xPos;
    private int yPos;
    public GameObject theFlamey;
    private int flameyCount;

    //music
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource winSource;
    public AudioClip musicBG;
    public AudioClip musicSFX;
    public AudioClip musicWin;

    void Start()
    {
        musicSource.clip = musicBG;
        musicSource.PlayDelayed(2.5f);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetAxisRaw("Horizontal") < 0)
            {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            winText.text = "";
            SetCountText();
            sfxSource.clip = musicSFX;
            sfxSource.Play();
        }
    }

    void SetCountText()
    {
        //SetCountText.text = "Count: " + count.ToString ();
        if (count >= 10)
        {
            winText.text = "You Win!";
            restartText.text = "Press 'R' To Restart Or 'ESC' To Exit.";
            Destroy(GameObject.FindWithTag("Timer"));
            //musicSource.Stop();
            winSource.clip = musicWin;
            winSource.Play();

        }
        else if (count >= 5)
        {
            StartCoroutine(flameyDrop());
        }
    }

    IEnumerator flameyDrop()
    {
        while (flameyCount < 5)
        {
            xPos = Random.Range(-6, 6);
            yPos = Random.Range(-1, 3);
            Instantiate(theFlamey, new Vector2(xPos, yPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            flameyCount += 1;
        }
    }
}
