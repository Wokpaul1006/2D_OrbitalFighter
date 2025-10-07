using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMN : MonoBehaviour
{
    [SerializeField] AudioSource mainTheme;
    public void OnMuteTheme()
    {
        mainTheme.volume = 0;
    }

    public void OnPlayTheme()
    {
        mainTheme.volume = 1;
    }
}
