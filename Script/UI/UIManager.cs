using System;
using System.Collections;
using System.Collections.Generic;
using Terric.Tool;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private Dictionary<string, string> _panelPaths = null;
    private FPContainer<PanelBase> _panelsCache = null;
    private Stack<PanelBase> _panelStack = null;

    public UIManager() => Init();

    private void Init()
    {
        _panelPaths = getPath();
    }

    private Dictionary<string, string> getPath()
    {
        TextAsset panels = LoadManager.Instance.Load<TextAsset>("UIPanels");
        var retVal = new Dictionary<string, string>();

        return retVal;
    }

    public void Push(string panelName)
    {
        if (_panelStack == null)
            _panelStack = new Stack<PanelBase>();

        PanelBase panel = GetPanel(panelName);
        _panelStack.Push();

    }

    private PanelBase GetPanel(string panelName)
    {
        if (_panelPaths == null)
        {
            _panelPaths = new Dictionary<string, string>();

        }

        if (!_panelsCache.GetValue(panelName))
        {
            _panelsCache.Add(LoadManager.Instance.Load<PanelBase>(panelName));
        }

        return _panelsCache[panelName];
    }

}
