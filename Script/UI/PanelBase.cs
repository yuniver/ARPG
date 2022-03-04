using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelBase : MonoBehaviour
{
    public string Name;
    public abstract void OnEnter();
    public abstract void OnPause();
    public abstract void OnResume();
    public abstract void OnExit();
}
