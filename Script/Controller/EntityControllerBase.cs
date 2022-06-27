using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityControllerBase : MonoBehaviour
{
    private GameObject view;
    private EntityBase data;
    private IAIBase ai;

    public GameObject View { get => view; set => view = value; }
    public EntityBase Data { get => data; set => data = value; }
    internal IAIBase AI { get => ai; set => ai = value; }

    private void Awake()
    {
        Init();
    }
    public virtual void Init() { }
    private void Update()
    {
        AI.Execute(view.GetComponent<ViewManagerBase>(), data);
    }
}
