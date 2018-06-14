using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerLevel : MonoBehaviour {

    public AudioMixer masterMixer;
    

    private void Start()
    {
        //FindObjectOfType<SFXManager>().Play("start");
    }

    public void SetSfxLevel(float sfxLvl)
    {

        masterMixer.SetFloat("sfxVolParam", sfxLvl);

    }

    public void SetMusicLevel(float musicLvl)
    {

        masterMixer.SetFloat("musicVolParam", musicLvl);

    }

    public void SetMasterLevel(float masterLvl)
    {

        masterMixer.SetFloat("masterVolParam", masterLvl);

    }

    

}