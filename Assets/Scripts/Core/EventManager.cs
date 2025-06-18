using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 이벤트 시스템을 관리하는 매니저 클래스입니다.
/// </summary>
public class EventManager : Singleton<EventManager>
{
    private Dictionary<string, Action<object>> eventDictionary = new Dictionary<string, Action<object>>();

    /// <summary>
    /// 이벤트 리스너를 등록합니다.
    /// </summary>
    /// <param name="eventName">이벤트 이름</param>
    /// <param name="listener">이벤트 발생 시 호출될 콜백</param>
    public void StartListening(string eventName, Action<object> listener)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] += listener;
        }
        else
        {
            eventDictionary.Add(eventName, listener);
        }
    }

    /// <summary>
    /// 이벤트 리스너를 해제합니다.
    /// </summary>
    /// <param name="eventName">이벤트 이름</param>
    /// <param name="listener">해제할 콜백</param>
    public void StopListening(string eventName, Action<object> listener)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] -= listener;
        }
    }

    /// <summary>
    /// 이벤트를 발생시킵니다.
    /// </summary>
    /// <param name="eventName">이벤트 이름</param>
    /// <param name="data">이벤트 데이터</param>
    public void TriggerEvent(string eventName, object data)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName]?.Invoke(data);
        }
    }
} 