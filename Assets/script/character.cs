using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class character : MonoBehaviour
{
    public GameObject b_gen;
    public GameObject panel;
    public GameObject panel2;
    public GameObject bal;
    public GameObject res;
    public GameObject birdg;
    public GameObject coing;
    public List<TextMeshProUGUI> txts;
    public List<AudioClip> se;
    AudioSource aud;
    Rigidbody2D rigid;
    float point;
    float level_time;
    int level=1;
    bool jumping = true;
    bool once=true;
    bool play = false;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
        panel.SetActive(false);
        panel2.SetActive(false);
        PlayerPrefs.SetInt("bird", 0);
        PlayerPrefs.SetInt("coin", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            if (Input.GetMouseButtonDown(0) && jumping)
            {
                this.rigid.velocity = Vector2.zero;
                this.rigid.AddForce(transform.up * 200);
                aud.PlayOneShot(se[0]);
            }
            point += Time.deltaTime * level;
            txts[0].text = point.ToString("F0");

            if (level_time >= 30)
            {
                if (level < 5) { level += 1; aud.PlayOneShot(se[4]); panel2.SetActive(true);Invoke("panel_close", 1f); }
                level_time = 0;
                b_gen.GetComponent<bird_generator>().lvl(level);
            }
            level_time += Time.deltaTime;

            if (transform.position.y <= -5 || transform.position.y >= 6 && once) chara_death();
            if (transform.position.y >= 4.5f)
            {
                panel.SetActive(true);
                txts[1].text = "PULL DOWN";
            }
            else if (transform.position.y <= -3.5f)
            {
                panel.SetActive(true);
                txts[1].text = "PULL UP";
            }
            else panel.SetActive(false);

            if (transform.position.y <= -10) death();
        }
    }

    void panel_close() { panel2.SetActive(false); }

    public void char_point()
    {
        point += 100*level;
        txts[0].text = point.ToString("F0");
        aud.PlayOneShot(se[1]);
    }
    public void char_point_minus()
    {
        point -= 50*level;
        txts[0].text = point.ToString("F0");
        aud.PlayOneShot(se[2]);
    }
    public void chara_death()
    {
        if (once)
        {
            aud.PlayOneShot(se[3]);
            bal.SetActive(false);
            jumping = false;
            once = false;
        }
        
    }
    void death()
    {
        aud.PlayOneShot(se[5]);
        GameObject c = GameObject.FindWithTag("coin");
        Destroy(c);
        GameObject[] b = GameObject.FindGameObjectsWithTag("bird");
        foreach (GameObject bi in b) GameObject.Destroy(bi);
        res.GetComponent<result_d>().deat(point);
        birdg.GetComponent<bird_generator>().d_bird();
        coing.GetComponent<coin_genrator>().d_coin();
        rigid.gravityScale = 0;

        bal.SetActive(true);
        transform.position = new Vector3(0, 1, 0);
    }

    public void reset_chara()
    {
        transform.position = new Vector3(0, 1, 0);
        rigid.gravityScale = 1;
        rigid.velocity = Vector2.zero;
        panel.SetActive(false);
        PlayerPrefs.SetInt("bird", 0);
        PlayerPrefs.SetInt("coin", 0);
        level = 1;
        level_time = 0;
        point = 0;
        jumping = true;
        once = true;
        aud.PlayOneShot(se[6]);
        play = true;
    }
}
