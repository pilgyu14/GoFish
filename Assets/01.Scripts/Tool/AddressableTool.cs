using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System; 

public static class AddressableTool 
{

    /// <summary>
    /// ��巹���� ���� �������� 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"></param>
    /// <param name="name"></param>
    public static async void GetAddressableAssetAsync<T>(Action<T> action, string name)
    {
        var handle = Addressables.LoadAssetAsync<T>(name);
        await handle.Task;
        action.Invoke(handle.Result);
    }

    /// <summary>
    /// ��巹���� ���� �������� (��ųʸ���)
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="actioin"></param>
    /// <param name="key"></param>
    /// <param name="name"></param>
    public static async void GetAddressableAssetDicAsync<K, T>(Action<K, T> actioin, K key, string name)
    {
        var handle = Addressables.LoadAssetAsync<T>(name);
        await handle.Task;
        actioin.Invoke(key, handle.Result);
    }
}
