using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Terric.Tool;


public enum Language
{
    CHS = 0,
    CHT = 1,
    ENG = 2,
    JPN = 3,
    KOR = 4
}

public class GlobalManager : MonoSingleton<GlobalManager>
{
    public BuildingData Buildings { get => buildings; set => buildings = value; }
    public CharacterData Characters { get => characters; set => characters = value; }
    public MapData Maps { get => maps; set => maps = value; }
    public PlayerData Player { get => player; set => player = value; }
    public SystemConfigData Config { get => config; set => config = value; }
    public GalleryData Gallery { get => gallery; set => gallery = value; }
    public DialogData Dialog { get => dialog; set => dialog = value; }

    private CharacterData characters;
    private BuildingData buildings;
    private MapData maps;
    private GalleryData gallery;
    private DialogData dialog;

    private PlayerData player;
    private SystemConfigData config;
}
