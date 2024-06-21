using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finished_game_menu_controller : MonoBehaviour
{
    public bool game_is_finished = false;
    private bool menu_active = false;
    public bool is_new_record = false;
    public float final_time;
    public GameObject game_is_finished_menu;
    public TMPro.TMP_Text your_time;
    public TMPro.TMP_Text new_record;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    
    // Update is called once per frame
    void Update()
    {
        if(game_is_finished == true && menu_active == false)
        {
            menu_active = true;
            game_finished();
            Time.timeScale = 0f;
        }
    }
    void game_finished()
    {
        if (is_new_record == true)
        {
            new_record.enabled = true;
        }
        your_time.text += final_time.ToString("F2") + " sec"; 
        game_is_finished_menu.SetActive(true);
    }
    public void on_return_button()
    {
        game_is_finished = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Race_setup_menu");
    }
}
