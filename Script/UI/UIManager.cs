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
        _panelsCache = new FPContainer<PanelBase>(10);//��໺��10������UI
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
    /// �½�����ջ
    /// </summary>
    /// <param name="panelName">Ŀ����������</param>
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
    /// �˳����棨��ջ��
    /// </summary>
    public void Pop()
    {
        if (_panelStack.Count == 0)
            return;
        var curPanel = _panelStack.Pop();
        curPanel.OnExit(); //�˳�
        if (_panelStack.Count != 0)
        {
            var parentPanel = _panelStack.Peek();
            parentPanel.OnResume(); //�ָ�����
        }
    }
    /// <summary>
    /// ��ȡ������
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
