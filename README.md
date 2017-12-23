# Unity-Framework
Unity核心框架合集（陆续更新），框架讲解文章 http://www.cnblogs.com/SHOR/p/6672185.html

## 2017.12.23更新
* 加入对象池类：使用固定的对象池重用对象，取代单独地分配和释放对象，以此来达到提升性能和优化内存使用的目的。分为三种对象：已使用对象、未使用对象和自动回收对象。

* 加入基于Mono的单例管理类，初始化物体位置和旋转都为默认点。
* 修改ResMgr的用单例类。
* 修改ObjectPool用单例类，ObjectPool在Awake中调用Instance会形成自循环，所以修改了Awake中代码。

## 框架
### UI框架
* 看讲解文章

### 资源管理
* 封装Resource.Load方法，并可以缓存资源

### 消息机制
* EventNode：被监听者，可以给监听者发送消息
  
* IEventListener：监听者实现接口
