using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class Options : MonoBehaviour
{
   
    public Slider sensitivitySlider;
    public Slider moveSpeedSlider;
    public Slider musicSlider;
    public Slider soundSlider;
    public Toggle musicCheckBox;
    public Toggle soundCheckBox;
   private AudioManager audioManager;
    public FPcam fpCam;





    public float sensitivitySliderValue;
    public float moveSpeedSliderValue;
    public float musicSliderValue;
    public float soundSliderValue;
    public bool musicCheckBoxValue;
    public bool soundCheckBoxValue;
  
  
    void Start()
    {

        audioManager = GetComponentInParent<AudioManager>();

    }
    void SensitivityCheck()
    {
        sensitivitySliderValue = sensitivitySlider.value * 100;
    }

    void MoveSpeed()
    {

        moveSpeedSliderValue = moveSpeedSlider.value * 100;
        
    }
    void MusicChek()
    {

        musicSliderValue = musicCheckBox.isOn ? musicSlider.value : 0f;


    }
    void SoundChek()
    {

        soundSliderValue = soundCheckBox.isOn ? soundSlider.value : 0f;
        

    }
   
   

    void Update()
    {
        MoveSpeed();
        MusicChek();
        SoundChek();
        SensitivityCheck();


    }
}
