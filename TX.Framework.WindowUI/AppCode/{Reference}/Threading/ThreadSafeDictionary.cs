﻿#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Threading
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct ThreadSafeDictionary<TKey, TItem>
    {
        private static readonly TItem defaultItem;
        private Hashtable implementation;
        private object syncRoot;
        private static object nullObject;

        static ThreadSafeDictionary()
        {
            ThreadSafeDictionary<TKey, TItem>.defaultItem = default(TItem);
            ThreadSafeDictionary<TKey, TItem>.nullObject = new object();
        }

        public static ThreadSafeDictionary<TKey, TItem> Create(object syncRoot)
        {
            ThreadSafeDictionary<TKey, TItem> dictionary = new ThreadSafeDictionary<TKey, TItem>();
            dictionary.Initialize(syncRoot);
            return dictionary;
        }

        public void Initialize(object syncRoot)
        {
            if (this.implementation != null)
            {
                throw new InvalidOperationException("AlreadyInitialized");
            }
            this.syncRoot = syncRoot;
            Hashtable hashtable = new Hashtable();
            Thread.MemoryBarrier();
            this.implementation = hashtable;
        }

        public TItem GetValue(TKey key, Func<TKey, TItem> generator)
        {
            TItem local;
            if (this.TryGetValue(key, out local))
            {
                return local;
            }
            lock (this.syncRoot)
            {
                if (this.TryGetValue(key, out local))
                {
                    return local;
                }
                TItem item = generator(key);
                this.SetValue(key, item);
                return item;
            }
        }

        public TItem GetValue<T>(TKey key, Func<TKey, T, TItem> generator, T argument)
        {
            TItem local;
            if (this.TryGetValue(key, out local))
            {
                return local;
            }
            lock (this.syncRoot)
            {
                if (this.TryGetValue(key, out local))
                {
                    return local;
                }
                TItem item = generator(key, argument);
                this.SetValue(key, item);
                return item;
            }
        }

        public TItem GetValue<T1, T2>(TKey key, Func<TKey, T1, T2, TItem> generator, T1 argument1, T2 argument2)
        {
            TItem local;
            if (this.TryGetValue(key, out local))
            {
                return local;
            }
            lock (this.syncRoot)
            {
                if (!this.TryGetValue(key, out local))
                {
                    local = generator(key, argument1, argument2);
                    this.SetValue(key, local);
                }
                return local;
            }
        }

        public bool TryGetValue(TKey key, out TItem value)
        {
            object obj2 = this.implementation[key];
            if (obj2 == null)
            {
                value = default(TItem);
                return false;
            }
            value = (obj2 == ThreadSafeDictionary<TKey, TItem>.nullObject) ? default(TItem) : ((TItem)obj2);
            return true;
        }

        public void SetValue(TKey key, TItem item)
        {
            lock (this.syncRoot)
            {
                Thread.MemoryBarrier();
                if (item != null)
                {
                    this.implementation[key] = item;
                }
                else
                {
                    this.implementation[key] = ThreadSafeDictionary<TKey, TItem>.nullObject;
                }
            }
        }

        public void Clear()
        {
            lock (this.syncRoot)
            {
                this.implementation.Clear();
                Thread.MemoryBarrier();
            }
        }

        public object SyncRoot
        {
            [DebuggerStepThrough]
            get
            {
                return this.syncRoot;
            }
        }

        public bool IsSynchronized
        {
            [DebuggerStepThrough]
            get
            {
                return true;
            }
        }
    }
}
