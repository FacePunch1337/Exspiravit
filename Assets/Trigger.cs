
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


public class Trigger : MonoBehaviour
{
    public bool watch;
    private Player player;
    public GameObject[] objs;
    public GameObject[] souls;
   
    public AudioManager audioManager;
    public Portal portal;





    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
       
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            int index = 0;
            other.TryGetComponent(out Player _player);
            player = _player;



            while (index < souls.Length)
            {
                objs[index].gameObject.SetActive(true);
                souls[index].gameObject.SetActive(true);
                
                if(souls[index].TryGetComponent(out Soul soul)) soul.go = true;
               

                index++;
            }

            if(index == souls.Length && watch)
            {
                player.PlayAnim();
                Invoke("Stop", 9f);
            }







        }

    }

    void Stop()
    {
        int index = 0;
        gameObject.SetActive(false);

        while (index < souls.Length)
        {
            souls[index].gameObject.SetActive(false);
            index++;
        }
        player.StopAnim();
        EnableObject();
        
    }

    public void EnableObject()
    {

        for (int i = 0; i < objs.Length; i++)
        {


            objs[i].gameObject.SetActive(true);


        }

    }


}
