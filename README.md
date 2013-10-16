TextbookManage
==============

教材管理第5版，与教务系统的申报对接，实现征订计划制订、书商回告、发放计划生成、教材发放、教材结算、报表打印等功能。
与之前版本比较，主要有两点变化：

1  申报数据来源不同，取自教务系统的学生用书与教师用书；

2  发放计划组成不同，由申报与导入共同构成，前者将征订成功的申报按学生学院生成计划，后者按导入的班级发放计划生成。

技术上没太大变化，

1  领域模型驱动，

2  ORM采用实体框架，

3  web 服务用WCF，

4  IOC与AOP用Unity，

5  日志用log4net，

6  Model与DTO映射用AutoMapper，

7  为与教务系统风格保持一致，UI使用Web Forms + Telerik

8  报表使用Reporting Service的本地报表

