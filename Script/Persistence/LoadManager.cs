using System;
using System.Collections;
using System.Collections.Generic;
using Terric.Tool;
using UnityEngine;

public class LoadManager : Singleton<LoadManager>
{
    public Dictionary<string, List<string>> localizationTextTable = new Dictionary<string, List<string>>();

    public T Load<T>(string path)
    {
        AssetBundle.LoadFromFile(path);
        throw new NotImplementedException();
    }
}
