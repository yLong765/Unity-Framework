# Unity-Framework
Unity核心框架合集（陆续更新与维护），框架讲解[文章](http://www.cnblogs.com/SHOR/p/6672185.html)

## 2017.12.23更新
* 加入对象池类，分为三种对象：已使用对象、未使用对象和自动回收对象
* 加入基于Mono的单例管理类，初始化物体位置和旋转都为默认点
* 修改ResMgr脚本，使用单例管理类
* 修改ObjectPool用单例类，ObjectPool在Awake中调用Instance会形成自循环，所以修改了Awake中代码

## 2018.8.28更新
* 重写MonoSingleton，修复Editor模式调用时产生多实例的问题
* 可用 Create 方法初始化

## 框架
### UI框架
* 看讲解文章

### 资源管理
* ResMgr：封装Resource.Load方法，并可以缓存资源

### 消息机制
* EventNode：被监听者，可以给监听者发送消息
* IEventListener：监听者实现接口

### 对象池
* ObjectPool：使用固定的对象池重用对象，取代单独地分配和释放对象，以此来达到提升性能和优化内存使用的目的

### 单例管理
* MonoSingletonMgr：基于mono的单例管理
* SingletonMgr：基于C#的单例管理
