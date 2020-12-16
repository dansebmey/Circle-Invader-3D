﻿using System;

[Serializable]
public class SettingsData
{
    public string lastEnteredHighscoreName;
    public float musicVolume;
    public float sfxVolume;
    
    public SettingsData(GameManager gm)
    {
        lastEnteredHighscoreName = ((RegistryOverlay)gm.OverlayManager.GetOverlay(OverlayManager.OverlayEnum.Registry)).LastEnteredName;
        musicVolume = gm.AudioManager.MusicVolume;
        sfxVolume = gm.AudioManager.SfxVolume;
    }
}