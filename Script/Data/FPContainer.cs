using System;
using System.Collections;
using System.Collections.Generic;
using Terric.Tool;
using UnityEngine;

namespace Terric.Data
{
    /// <summary>
    /// Frequency priority container
    /// </summary>
    public class FPContainer<T> where T : class
    {
        private int _maxLength;
        private LinkedList<T> _list;
        private int _length = 0;
        public int Length { get => _length; }
        public LinkedList<T> List { get => _list; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="maxLength">容器最大长度</param>
        public FPContainer(int maxLength)
        {
            _maxLength = maxLength;
            _list = new LinkedList<T>();
        }
        /// <summary>
        /// 往容器中添加数据
        /// </summary>
        /// <param name="data">需要添加的数据</param>
        public void Add(T data)
        {
            if (data != null)
            {
                if (_list.Count >= _maxLength)
                {
                    List.RemoveFirst();
                    --_length;
                }
                List.AddLast(data);
                _length++;
            }
        }
        /// <summary>
        /// 调整优先顺序
        /// </summary>
        /// <param name="data">目标数据</param>
        /// <returns></returns>
        public T ReAdd(T data)
        {
            _list.Remove(data);
            _list.AddLast(data);
            return data;
        }
    }
}
