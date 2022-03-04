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
        /// ���캯��
        /// </summary>
        /// <param name="maxLength">������󳤶�</param>
        public FPContainer(int maxLength)
        {
            _maxLength = maxLength;
            _list = new LinkedList<T>();
        }
        /// <summary>
        /// ���������������
        /// </summary>
        /// <param name="data">��Ҫ��ӵ�����</param>
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
        /// ��������˳��
        /// </summary>
        /// <param name="data">Ŀ������</param>
        /// <returns></returns>
        public T ReAdd(T data)
        {
            _list.Remove(data);
            _list.AddLast(data);
            return data;
        }
    }
}
