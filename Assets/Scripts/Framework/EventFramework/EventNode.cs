using System.Collections.Generic;

public class EventNode
{
    /// <summary>
    /// 监听者分类字典
    /// </summary>
    private Dictionary<int, List<IEventListener>> eventLists = new Dictionary<int, List<IEventListener>>();

    /// <summary>
    /// 添加监听者
    /// </summary>
    /// <param name="code">监听者类别</param>
    /// <param name="_listener">监听者本体</param>
    /// <returns></returns>
    public bool AddListener(EventCode code, IEventListener _listener)
    {
        int id = (int)code;
        if (!eventLists.ContainsKey(id))
        {
            eventLists.Add(id, new List<IEventListener>() { _listener });
            return true;
        }

        if (eventLists[id].Contains(_listener))
        {
            return false;
        }

        eventLists[id].Add(_listener);
        return true;
    }

    /// <summary>
    /// 删除监听者
    /// </summary>
    /// <param name="code">监听者类别</param>
    /// <param name="_listener">监听者本体</param>
    /// <returns></returns>
    public bool DelListener(EventCode code, IEventListener _listener)
    {
        int id = (int)code;
        if (eventLists.ContainsKey(id) && eventLists[id].Contains(_listener))
        {
            eventLists[id].Remove(_listener);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="info">消息内容</param>
    public void SendMessage(EventInfo info)
    {
        foreach (IEventListener listener in eventLists[info.id])
        {
            listener.Event(info.eventDates);
        }
    }
}

/// <summary>
/// 消息内容
/// </summary>
public struct EventInfo
{
    public int id;
    public object[] eventDates;

    public EventInfo(EventCode _code, params object[] _Dates)
    {
        id = (int)_code;
        eventDates = _Dates;
    }
}
/// <summary>
/// 消息代码
/// </summary>
public enum EventCode : int
{
    /// <summary>
    /// 发往逻辑层消息
    /// </summary>
    toLogic = 1,
    /// <summary>
    /// 发往Scene层消息
    /// </summary>
    toScene = 2,
    /// <summary>
    /// 发往Panel层消息
    /// </summary>
    toPanel = 3,
}
