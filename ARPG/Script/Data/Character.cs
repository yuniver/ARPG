using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : EntityBase
{
    /// <summary>
    /// 定点数位置，单位为MM
    /// 使用时候注意除1000
    /// </summary>
    public Vector3Int position = Vector3Int.zero;

}
