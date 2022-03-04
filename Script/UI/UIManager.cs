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
    private GameObject _canvas;
    public UIManager() => Init();

    private void Init()
    {
        _panelPaths = getPathTable();
        _panelsCache = new FPContainer<PanelBase>(10);//最多缓存10个常用UI
        _canvas = GameObject.Find("UICanvas");
        _panelStack = new Stack<PanelBase>();
    }

    private Dictionary<string, string> getPathTable()
    {
        TextAsset panels = LoadManager.Instance.Load<TextAsset>("UIPanels");
        var retVal = new Dictionary<string, string>();

        throw new NotImplementedException();
    }
    /// <summary>
    /// 新界面入栈
    /// </summary>
    /// <param name="panelName">目标界面的名字</param>
    public void Push(string panelName)
    {
        if (_panelStack.Count > 0)
        {
            var parentUI = _panelStack.Peek();
            parentUI.OnPause();
        }

        PanelBase panel = getPanel(panelName);
        panel.OnEnter();
        _panelStack.Push(panel);
    }
    /// <summary>
    /// 退出界面（出栈）
    /// </summary>
    public void Pop()
    {
        if (_panelStack.Count == 0)
            return;
        var curPanel = _panelStack.Pop();
        curPanel.OnExit(); //退出
        if (_panelStack.Count != 0)
        {
            var parentPanel = _panelStack.Peek();
            parentPanel.OnResume(); //恢复父级
        }
    }
    /// <summary>
    /// 获取面板对象
    /// </summary>
    /// <param name="panelName"></param>
    /// <returns></returns>
    private PanelBase getPanel(string panelName)
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
