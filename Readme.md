

返水计算程序分为四个部分:
1.Commission.Unit  
	分布式计算程序，可以随意增加服务器数量
	自动从Commission.Server上下载程序运行
	检测版本是否与当前计算库的版本一致

2.Commission.Server
	管理服务器程序，计算的开始由该程序发起
	1) 向Redis中的任务队列中发送计算任务。
	2) 从Redis中读到任务处理的状态
	3) 提供计算库Commission.Computer的下载服务,
		并更新计算程序库的版本号到Redis中

3.Commission.Interfaces
	返水计算接口

4.Commission.Computer
	计算的算法库

