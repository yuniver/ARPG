using System;
using System.Collections;
using System.Collections.Generic;
using Terric.Data;
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
        _panelPaths = getPathTable();
        _panelsCache = new FPContainer<PanelBase>(10);//最多缓存10个常用UI
    }

    private Dictionary<string, string> getPathTable()
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
        _panelStack.Push(panel);

    }

    private PanelBase GetPanel(string panelName)
    {
        if (_panelPaths == null)
        {
            _panelPaths = getPathTable();

        }

        var retVal = _panelsCache.GetValue(panelName);

        if (retVal == null)
        {
            retVal = LoadManager.Instance.Load<PanelBase>(_panelPaths[panelName]);
            _panelsCache.Add(retVal);
        }

        return retVal;
    }

}
