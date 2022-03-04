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
    private Language _currlanguage = Language.CHS;
    public Language Currlanguage { get => _currlanguage; set => _currlanguage = value; }
}
