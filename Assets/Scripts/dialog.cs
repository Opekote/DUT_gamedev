using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    public GameObject panel;
    public Text TextDialog;
    public string[] message;
    public bool StartDialog = false;
    int x;
    public int id;


    void Start()
    {
        switch(id)
        {
            case 1:
            message[0] = "Hi, i just invented a new method of healing";
            message[1] = "You can try it";
            message[2] = "Goodbye!";
            break;
            case 2:
            message[0] = "We are under attack!";
            message[1] = "to fight";
            message[2] = "press buttons I,O,P ";
            break;

        }
        x = 1;
        
        panel.SetActive(false);
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        {
            panel.SetActive(true);
            TextDialog.text = message[0];
            StartDialog = true;
        }
    }

   public void OnTriggerExit2D(Collider2D collision)
   {
    panel.SetActive(false);
    StartDialog = false;
   }

    void Update()
    {
        if (StartDialog == true)
        {
            if(Input.GetKeyDown(KeyCode.V))
            {
                switch(x)
                {
                case 1:
                TextDialog.text = message[1];
                x = 2;
                break; 
                 case 2:
                TextDialog.text = message[2];
                x = 3;
                break;
                case 3:
                Destroy(gameObject);
                break;
                }  
            }
        }
    }
}
