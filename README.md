# Unity-Framework
Unity核心框架合集（陆续更新），框架讲解文章 http://www.cnblogs.com/SHOR/p/6672185.html

## 框架
### UI框架
* 看讲解文章

### 资源管理
* 封装Resource.Load方法，并可以缓存资源

### 消息机制
* EventNode：被监听者，可以给监听者发送消息
  
* IEventListener：监听者实现接口

## 预告
### 对象池
* 使用固定的对象池重用对象，取代单独地分配和释放对象，以此来达到提升性能和优化内存使用的目的
  
* 资源管理框架的缓存删除，用对象池全权处理

### 单例管理
* 继承于MonoBehavior的单例
  
* 非继承于MonoBehavior的单例
