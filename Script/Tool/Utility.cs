using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Terric.Tool
{
    public static class Utility
    {
        public static string Localization(this string text, params string[] args)
        {
            return string.Format(LoadManager.Instance.localizationTextTable[text][(int)GlobalManager.Instance.Currlanguage], args);
        }
        //
        public static PanelBase GetValue(this List<PanelBase> list, string key)
        {
            for (int i = 0; i < list.Count; i++)
            {
                PanelBase panel = list[i];
                if (panel.Name == key)
                    return panel;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PanelBase GetValue(this FPContainer<PanelBase> _list, string key)
        {
            foreach (PanelBase panel in _list.List)
            {
                if (panel.Name == key)
                    return _list.ReAdd(panel);
            }
            return null;
        }
    }
}