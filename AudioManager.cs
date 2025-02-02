using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Music")]
    public AudioSource _titleMusic;
    public AudioSource _gameMusic;
    public AudioSource _endingMusic;
    private bool _titleMusicPlaying = false;
    private bool _gameMusicPlaying = false;
    

    [Header("Clips")]
    public AudioSource _jump;
    public AudioSource _landing;
    public AudioSource _melting;
    public AudioSource _boxfall;

    [Header("Squeaks")]
    public AudioSource _squeakSource;
    public AudioClip[] _squeaks;

    public void StartTitleMusic()
    {
        if (!_titleMusicPlaying)
        {
            _titleMusic.Play();
            _gameMusic.Stop();
            _titleMusic.volume = 0.5f;
            _gameMusicPlaying = false;
            _titleMusicPlaying = true;
        }
    }
    public void StartGameMusic()
    {
        if (!_gameMusicPlaying)
        {
            _gameMusic.Play();
            _titleMusic.Stop();
            _gameMusic.volume = 0.5f;
            _titleMusicPlaying = false;
            _gameMusicPlaying = true;
        }
    }

}
