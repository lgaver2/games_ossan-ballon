using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class result_d : MonoBehaviour
{
    public List<TextMeshProUGUI> txts;
    public GameObject panel;
    public GameObject start_button;
    float total_time;
    string final_time;
    bool play=false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(play) total_time += Time.deltaTime;
    }
    public void deat(float point)
    {
        Time.timeScale = 0;
        txts[0].text = "Points: "+point.ToString("F0");
        txts[1].text = "Bird Attack: " + PlayerPrefs.GetInt("bird").ToString("F0");
        txts[2].text = "Coins: " + PlayerPrefs.GetInt("coin").ToString("F0");
        change_time();
        txts[3].text = "Time: " + final_time;
        panel.SetActive(true);
    }

    void change_time()
    {
        if (total_time >= 60) final_time = (total_time / 60).ToString("F2") + "min";
        else if(total_time >= 60) final_time = (total_time / 3600).ToString("F2") + "h";
        else final_time = (total_time).ToString("F2") + "s";
    }


    public void close()
    {
        panel.SetActive(false);
        start_button.SetActive(true);
    }
    public void restart_res()
    {
        total_time = 0;
        play = true;
    }
}
