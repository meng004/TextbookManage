/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2013-4-20 22:38:02                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Approval_Declaration') and o.name = 'FK_DeclarationApproval_inherits_Approval')
alter table Textbook.Approval_Declaration
   drop constraint FK_DeclarationApproval_inherits_Approval
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Approval_Declaration') and o.name = 'FK_DeclarationDeclarationApproval')
alter table Textbook.Approval_Declaration
   drop constraint FK_DeclarationDeclarationApproval
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Approval_Feedback') and o.name = 'FK_Approval_Feedback_Approval')
alter table Textbook.Approval_Feedback
   drop constraint FK_Approval_Feedback_Approval
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Approval_Feedback') and o.name = 'FK_Approval_Feedback_Feedback')
alter table Textbook.Approval_Feedback
   drop constraint FK_Approval_Feedback_Feedback
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.BooksellerStaff') and o.name = 'FK_BooksellerStaff_Bookseller')
alter table Textbook.BooksellerStaff
   drop constraint FK_BooksellerStaff_Bookseller
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Declaration') and o.name = 'FK_TextbookDeclaration')
alter table Textbook.Declaration
   drop constraint FK_TextbookDeclaration
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Inventory') and o.name = 'FK_StorageInventory')
alter table Textbook.Inventory
   drop constraint FK_StorageInventory
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Inventory') and o.name = 'FK_TextbookInventory')
alter table Textbook.Inventory
   drop constraint FK_TextbookInventory
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.ReleaseRecord') and o.name = 'FK_StockRecordReleaseRecord')
alter table Textbook.ReleaseRecord
   drop constraint FK_StockRecordReleaseRecord
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.ReleaseRecord_Student') and o.name = 'FK_ReleaseRecord_Student_ReleaseRecord')
alter table Textbook.ReleaseRecord_Student
   drop constraint FK_ReleaseRecord_Student_ReleaseRecord
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.ReleaseRecord_Teacher') and o.name = 'FK_ReleaseRecord_Teacher_ReleaseRecord')
alter table Textbook.ReleaseRecord_Teacher
   drop constraint FK_ReleaseRecord_Teacher_ReleaseRecord
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.StockRecord') and o.name = 'FK_InventoryStockRecord')
alter table Textbook.StockRecord
   drop constraint FK_InventoryStockRecord
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Storage') and o.name = 'FK_BookSellerStorage')
alter table Textbook.Storage
   drop constraint FK_BookSellerStorage
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Subscription') and o.name = 'FK_BookSellerSubscription')
alter table Textbook.Subscription
   drop constraint FK_BookSellerSubscription
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Subscription') and o.name = 'FK_FeedbackSubscription')
alter table Textbook.Subscription
   drop constraint FK_FeedbackSubscription
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Subscription') and o.name = 'FK_TextbookSubscription')
alter table Textbook.Subscription
   drop constraint FK_TextbookSubscription
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.SubscriptionDeclaration') and o.name = 'FK_SubscriptionDeclaration_Declaration')
alter table Textbook.SubscriptionDeclaration
   drop constraint FK_SubscriptionDeclaration_Declaration
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.SubscriptionDeclaration') and o.name = 'FK_SubscriptionDeclaration_Subscription')
alter table Textbook.SubscriptionDeclaration
   drop constraint FK_SubscriptionDeclaration_Subscription
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Approval')
            and   type = 'U')
   drop table Textbook.Approval
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Approval_Declaration')
            and   name  = 'IX_FK_DeclarationDeclarationApproval'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Approval_Declaration.IX_FK_DeclarationDeclarationApproval
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Approval_Declaration')
            and   type = 'U')
   drop table Textbook.Approval_Declaration
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Approval_Feedback')
            and   name  = 'IX_FK_ApprovalFeedback'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Approval_Feedback.IX_FK_ApprovalFeedback
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Approval_Feedback')
            and   type = 'U')
   drop table Textbook.Approval_Feedback
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Bookseller')
            and   type = 'U')
   drop table Textbook.Bookseller
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.BooksellerStaff')
            and   type = 'U')
   drop table Textbook.BooksellerStaff
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Declaration')
            and   name  = 'IX_TermRecipient'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Declaration.IX_TermRecipient
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Declaration')
            and   name  = 'IX_TeachingTask'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Declaration.IX_TeachingTask
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Declaration')
            and   name  = 'IX_FK_TextbookDeclaration'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Declaration.IX_FK_TextbookDeclaration
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Declaration')
            and   type = 'U')
   drop table Textbook.Declaration
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Feedback')
            and   type = 'U')
   drop table Textbook.Feedback
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Inventory')
            and   name  = 'IX_FK_TextbookInventory'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Inventory.IX_FK_TextbookInventory
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Inventory')
            and   name  = 'IX_FK_StorageInventory'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Inventory.IX_FK_StorageInventory
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Inventory')
            and   type = 'U')
   drop table Textbook.Inventory
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.ReleaseRecord')
            and   name  = 'IX_FK_StockRecordReleaseRecord'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.ReleaseRecord.IX_FK_StockRecordReleaseRecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.ReleaseRecord')
            and   type = 'U')
   drop table Textbook.ReleaseRecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.ReleaseRecord_Student')
            and   type = 'U')
   drop table Textbook.ReleaseRecord_Student
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.ReleaseRecord_Teacher')
            and   type = 'U')
   drop table Textbook.ReleaseRecord_Teacher
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.StockRecord')
            and   name  = 'IX_FK_InventoryStockRecord'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.StockRecord.IX_FK_InventoryStockRecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.StockRecord')
            and   type = 'U')
   drop table Textbook.StockRecord
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Storage')
            and   name  = 'IX_FK_BookSellerStorage'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Storage.IX_FK_BookSellerStorage
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Storage')
            and   type = 'U')
   drop table Textbook.Storage
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Subscription')
            and   name  = 'IX_FK_TextbookSubscription'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Subscription.IX_FK_TextbookSubscription
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Subscription')
            and   name  = 'IX_FK_FeedbackSubscription'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Subscription.IX_FK_FeedbackSubscription
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Subscription')
            and   name  = 'IX_FK_TermSubscription'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Subscription.IX_FK_TermSubscription
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.Subscription')
            and   name  = 'IX_FK_BookSellerSubscription'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.Subscription.IX_FK_BookSellerSubscription
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Subscription')
            and   type = 'U')
   drop table Textbook.Subscription
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.SubscriptionDeclaration')
            and   name  = 'IX_FK_Subscription'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.SubscriptionDeclaration.IX_FK_Subscription
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.SubscriptionDeclaration')
            and   name  = 'IX_FK_SubscriptionDeclaration_Declaration'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.SubscriptionDeclaration.IX_FK_SubscriptionDeclaration_Declaration
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.SubscriptionDeclaration')
            and   type = 'U')
   drop table Textbook.SubscriptionDeclaration
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Textbook')
            and   type = 'U')
   drop table Textbook.Textbook
go

if exists(select 1 from systypes where name='Datetimes')
   drop type Datetimes
go

if exists(select 1 from systypes where name='GUID')
   drop type GUID
go

if exists(select 1 from systypes where name='Names')
   drop type Names
go

if exists(select 1 from systypes where name='Numbers')
   drop type Numbers
go

if exists(select 1 from systypes where name='Quality')
   execute sp_unbindrule Quality
go

if exists(select 1 from systypes where name='Quality')
   drop type Quality
go

if exists(select 1 from systypes where name='Remarks')
   drop type Remarks
go

if exists(select 1 from systypes where name='TrueOrFalse')
   execute sp_unbindrule TrueOrFalse
go

if exists(select 1 from systypes where name='TrueOrFalse')
   drop type TrueOrFalse
go

if exists(select 1 from systypes where name='number2')
   execute sp_unbindrule number2
go

if exists(select 1 from systypes where name='number2')
   drop type number2
go

if exists(select 1 from systypes where name='sex')
   execute sp_unbindrule sex
go

if exists(select 1 from systypes where name='sex')
   drop type sex
go

drop schema Textbook
go

if exists (select 1
   from  sysobjects where type = 'D'
   and name = 'D_0'
   )
   drop default D_0
go

if exists (select 1
   from  sysobjects where type = 'D'
   and name = 'D_1'
   )
   drop default D_1
go

if exists (select 1
   from  sysobjects where type = 'D'
   and name = 'D_getdate()'
   )
   drop default "D_getdate()"
go

if exists (select 1
   from  sysobjects where type = 'D'
   and name = 'D_newid()'
   )
   drop default "D_newid()"
go

if exists (select 1
   from  sysobjects where type = 'D'
   and name = 'D_无'
   )
   drop default D_无
go

if exists (select 1
   from  sysobjects where type = 'D'
   and name = 'Default_0.00'
   )
   drop default "Default_0.00"
go

if exists (select 1 from sysobjects where id=object_id('R_Quality') and type='R')
   drop rule  R_Quality
go

if exists (select 1 from sysobjects where id=object_id('R_TrueOrFalse') and type='R')
   drop rule  R_TrueOrFalse
go

if exists (select 1 from sysobjects where id=object_id('R_number2') and type='R')
   drop rule  R_number2
go

if exists (select 1 from sysobjects where id=object_id('R_sex') and type='R')
   drop rule  R_sex
go

create rule R_Quality as
      @column >= 0
go

create rule R_TrueOrFalse as
      @column in (0,1)
go

create rule R_number2 as
      @column >= 0
go

create rule R_sex as
      @column in (1,2,0,9)
go

/*==============================================================*/
/* Default: D_0                                                 */
/*==============================================================*/
create default D_0
    as 0
go

/*==============================================================*/
/* Default: D_1                                                 */
/*==============================================================*/
create default D_1
    as 1
go

/*==============================================================*/
/* Default: "D_getdate()"                                       */
/*==============================================================*/
create default "D_getdate()"
    as getdate()
go

/*==============================================================*/
/* Default: "D_newid()"                                         */
/*==============================================================*/
create default "D_newid()"
    as newid()
go

/*==============================================================*/
/* Default: D_无                                                 */
/*==============================================================*/
create default D_无
    as '无'
go

/*==============================================================*/
/* Default: "Default_0.00"                                      */
/*==============================================================*/
create default "Default_0.00"
    as 0.00
go

/*==============================================================*/
/* User: Textbook                                               */
/*==============================================================*/
create schema Textbook
go

/*==============================================================*/
/* Domain: Datetimes                                            */
/*==============================================================*/
create type Datetimes
   from datetime2
go

execute sp_bindefault N'"D_getdate()"', N'Datetimes'
go

/*==============================================================*/
/* Domain: GUID                                                 */
/*==============================================================*/
create type GUID
   from uniqueidentifier
go

execute sp_bindefault N'"D_newid()"', N'GUID'
go

/*==============================================================*/
/* Domain: Names                                                */
/*==============================================================*/
create type Names
   from nvarchar(200)
go

/*==============================================================*/
/* Domain: Numbers                                              */
/*==============================================================*/
create type Numbers
   from nvarchar(20)
go

/*==============================================================*/
/* Domain: Quality                                              */
/*==============================================================*/
create type Quality
   from int
go

execute sp_bindrule R_Quality, Quality
go

execute sp_bindefault N'D_0', N'Quality'
go

/*==============================================================*/
/* Domain: Remarks                                              */
/*==============================================================*/
create type Remarks
   from nvarchar(2000)
go

/*==============================================================*/
/* Domain: TrueOrFalse                                          */
/*==============================================================*/
create type TrueOrFalse
   from bit
go

execute sp_bindrule R_TrueOrFalse, TrueOrFalse
go

execute sp_bindefault N'D_0', N'TrueOrFalse'
go

/*==============================================================*/
/* Domain: number2                                              */
/*==============================================================*/
create type number2
   from decimal(10,2)
go

execute sp_bindrule R_number2, number2
go

execute sp_bindefault N'"Default_0.00"', N'number2'
go

/*==============================================================*/
/* Domain: sex                                                  */
/*==============================================================*/
create type sex
   from int
go

execute sp_bindrule R_sex, sex
go

execute sp_bindefault N'D_1', N'sex'
go

/*==============================================================*/
/* Table: Approval                                              */
/*==============================================================*/
create table Textbook.Approval (
   ApprovalID           int                  identity(1,1),
   Division             Names                not null,
   Auditor              Names                not null,
   ApprovalDate         Datetimes            not null,
   Suggestion           TrueOrFalse          not null,
   Remark               Remarks              null,
   ApprovalTarget       Quality              not null,
   constraint PK_Approvals primary key (ApprovalID)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Textbook.Approval')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ApprovalTarget')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'Textbook', 'table', 'Approval', 'column', 'ApprovalTarget'

end


execute sp_addextendedproperty 'MS_Description', 
   '类型，如：用书申报的审核，回告的审核等',
   'user', 'Textbook', 'table', 'Approval', 'column', 'ApprovalTarget'
go

/*==============================================================*/
/* Table: Approval_Declaration                                  */
/*==============================================================*/
create table Textbook.Approval_Declaration (
   ApprovalID           int                  not null,
   Declaration_ID       int                  not null,
   constraint PK_Approvals_DeclarationApproval primary key (ApprovalID)
)
go

/*==============================================================*/
/* Index: IX_FK_DeclarationDeclarationApproval                  */
/*==============================================================*/
create index IX_FK_DeclarationDeclarationApproval on Textbook.Approval_Declaration (
Declaration_ID ASC
)
go

/*==============================================================*/
/* Table: Approval_Feedback                                     */
/*==============================================================*/
create table Textbook.Approval_Feedback (
   ApprovalID           int                  not null,
   Feedback_ID          int                  not null default 0
      constraint CKC_FEEDBACK_ID_APPROVAL check (Feedback_ID >= 0),
   constraint PK_APPROVAL_FEEDBACK primary key (ApprovalID)
)
go

/*==============================================================*/
/* Index: IX_FK_ApprovalFeedback                                */
/*==============================================================*/
create index IX_FK_ApprovalFeedback on Textbook.Approval_Feedback (
Feedback_ID ASC
)
go

/*==============================================================*/
/* Table: Bookseller                                            */
/*==============================================================*/
create table Textbook.Bookseller (
   BooksellerID         int                  identity(1,1),
   Name                 Names                not null,
   Contact              Names                null,
   Telephone            Numbers              null,
   constraint PK_BookSellers primary key (BooksellerID)
)
go

/*==============================================================*/
/* Table: BooksellerStaff                                       */
/*==============================================================*/
create table Textbook.BooksellerStaff (
   BooksellerStaffID    int                  identity(1,1),
   Bookseller_ID        int                  not null,
   StaffName            Names                not null,
   Sex                  sex                  not null,
   constraint PK_BOOKSELLERSTAFF primary key nonclustered (BooksellerStaffID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Textbook.BooksellerStaff') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'Textbook', 'table', 'BooksellerStaff' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '书商所属的员工', 
   'user', 'Textbook', 'table', 'BooksellerStaff'
go

/*==============================================================*/
/* Table: Declaration                                           */
/*==============================================================*/
create table Textbook.Declaration (
   DeclarationID        int                  identity(1,1),
   Textbook_ID          int                  not null,
   TeachingTask_Num     Numbers              not null,
   Teacher_ID           GUID                 not null,
   Term                 Numbers              not null,
   RecipientType        Quality              not null,
   DeclarationCount     Quality              not null,
   DeclarationDate      Datetimes            not null,
   Mobile               Numbers              not null,
   Telephone            Numbers              not null,
   ApprovalState        Quality              not null,
   HadViewFeedback      TrueOrFalse          not null,
   constraint PK_Declarations primary key (DeclarationID)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Textbook.Declaration')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RecipientType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'Textbook', 'table', 'Declaration', 'column', 'RecipientType'

end


execute sp_addextendedproperty 'MS_Description', 
   '如：教师用书，学生用书',
   'user', 'Textbook', 'table', 'Declaration', 'column', 'RecipientType'
go

/*==============================================================*/
/* Index: IX_FK_TextbookDeclaration                             */
/*==============================================================*/
create index IX_FK_TextbookDeclaration on Textbook.Declaration (
Textbook_ID ASC
)
go

/*==============================================================*/
/* Index: IX_TeachingTask                                       */
/*==============================================================*/
create index IX_TeachingTask on Textbook.Declaration (
TeachingTask_Num ASC
)
go

/*==============================================================*/
/* Index: IX_TermRecipient                                      */
/*==============================================================*/
create index IX_TermRecipient on Textbook.Declaration (
Term ASC,
RecipientType ASC
)
go

/*==============================================================*/
/* Table: Feedback                                              */
/*==============================================================*/
create table Textbook.Feedback (
   FeedbackID           int                  identity(1,1),
   Person               Names                not null,
   FeedbackDate         Datetimes            not null,
   FeedbackState        TrueOrFalse          not null,
   Remark               Remarks              null,
   constraint PK_Feedbacks primary key (FeedbackID)
)
go

/*==============================================================*/
/* Table: Inventory                                             */
/*==============================================================*/
create table Textbook.Inventory (
   InventoryID          int                  identity(1,1),
   Storage_ID           Quality              not null,
   Textbook_ID          Quality              not null,
   ShelfNumber          Numbers              null,
   InventoryCount       Quality              not null,
   constraint PK_Inventories primary key (InventoryID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Textbook.Inventory') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'Textbook', 'table', 'Inventory' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '仓库所存放的教材信息，包括库存数量', 
   'user', 'Textbook', 'table', 'Inventory'
go

/*==============================================================*/
/* Index: IX_FK_StorageInventory                                */
/*==============================================================*/
create index IX_FK_StorageInventory on Textbook.Inventory (
Storage_ID ASC
)
go

/*==============================================================*/
/* Index: IX_FK_TextbookInventory                               */
/*==============================================================*/
create index IX_FK_TextbookInventory on Textbook.Inventory (
Textbook_ID ASC
)
go

/*==============================================================*/
/* Table: ReleaseRecord                                         */
/*==============================================================*/
create table Textbook.ReleaseRecord (
   ReleaseRecordID      GUID                 not null,
   StockRecord_ID       int                  not null,
   Textbook_ID          int                  not null,
   Name                 Names                not null,
   Isbn                 Numbers              not null,
   Author               Names                not null,
   Press                Names                not null,
   PressAddress         Names                not null,
   Edition              Quality              not null,
   PrintCount           Quality              not null,
   PublishDate          Datetimes            not null,
   Price                number2              not null,
   Discount             number2              null,
   DiscountPrice        number2              null,
   TextbookType         Names                not null,
   IsSelfCompile        TrueOrFalse          not null,
   PageCount            Quality              not null,
   School_ID            GUID                 not null,
   SchoolName           Names                not null,
   Term                 Numbers              not null,
   ReleaseDate          Datetimes            not null,
   ReleaseCount         Quality              not null,
   Telephone            Numbers              null,
   Bookseller_ID        Quality              not null,
   BooksellerName       Names                not null,
   RecipientType        Quality              not null,
   constraint PK_ReleaseRecords primary key (ReleaseRecordID)
)
go

/*==============================================================*/
/* Index: IX_FK_StockRecordReleaseRecord                        */
/*==============================================================*/
create index IX_FK_StockRecordReleaseRecord on Textbook.ReleaseRecord (
StockRecord_ID ASC
)
go

/*==============================================================*/
/* Table: ReleaseRecord_Student                                 */
/*==============================================================*/
create table Textbook.ReleaseRecord_Student (
   ReleaseRecordID      GUID                 not null,
   Class_ID             GUID                 not null,
   ClassName            Names                not null,
   Student_ID           GUID                 not null,
   StudentNum           Numbers              not null,
   StudentName          Names                not null,
   Gender               sex                  not null,
   constraint PK_ReleaseRecords_StudentRelease primary key (ReleaseRecordID)
)
go

/*==============================================================*/
/* Table: ReleaseRecord_Teacher                                 */
/*==============================================================*/
create table Textbook.ReleaseRecord_Teacher (
   ReleaseRecordID      GUID                 not null,
   Department_ID        GUID                 not null,
   DepartmentName       Names                not null,
   Teacher_ID           GUID                 not null,
   TeacherName          Names                not null,
   Gender               sex                  not null,
   IDCardType           Quality              null,
   IDCardNum            Numbers              null,
   Barcode              Numbers              null,
   constraint PK_ReleaseRecords_TeacherRelease primary key (ReleaseRecordID)
)
go

/*==============================================================*/
/* Table: StockRecord                                           */
/*==============================================================*/
create table Textbook.StockRecord (
   StockRecordID        int                  identity(1,1),
   Inventory_ID         int                  not null,
   StockCount           Quality              not null,
   StockDate            Datetimes            not null,
   Operator             Names                not null,
   StockType            TrueOrFalse          not null,
   constraint PK_StockRecords primary key (StockRecordID)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Textbook.StockRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StockType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'Textbook', 'table', 'StockRecord', 'column', 'StockType'

end


execute sp_addextendedproperty 'MS_Description', 
   '入库，或出库',
   'user', 'Textbook', 'table', 'StockRecord', 'column', 'StockType'
go

/*==============================================================*/
/* Index: IX_FK_InventoryStockRecord                            */
/*==============================================================*/
create index IX_FK_InventoryStockRecord on Textbook.StockRecord (
Inventory_ID ASC
)
go

/*==============================================================*/
/* Table: Storage                                               */
/*==============================================================*/
create table Textbook.Storage (
   StorageID            int                  identity(1,1),
   Bookseller_ID        Quality              not null,
   Name                 Names                not null,
   Address              Names                null,
   constraint PK_Storages primary key (StorageID)
)
go

/*==============================================================*/
/* Index: IX_FK_BookSellerStorage                               */
/*==============================================================*/
create index IX_FK_BookSellerStorage on Textbook.Storage (
Bookseller_ID ASC
)
go

/*==============================================================*/
/* Table: Subscription                                          */
/*==============================================================*/
create table Textbook.Subscription (
   SubscriptionID       int                  identity(1,1),
   Bookseller_ID        Quality              not null,
   Textbook_ID          Quality              not null,
   Feedback_ID          Quality              not null,
   Term                 Numbers              not null,
   PlanCount            Quality              not null,
   SpareCount           Quality              not null,
   SubscriptionDate     Datetimes            not null,
   constraint PK_Subscriptions primary key (SubscriptionID)
)
go

/*==============================================================*/
/* Index: IX_FK_BookSellerSubscription                          */
/*==============================================================*/
create index IX_FK_BookSellerSubscription on Textbook.Subscription (
Bookseller_ID ASC
)
go

/*==============================================================*/
/* Index: IX_FK_TermSubscription                                */
/*==============================================================*/
create index IX_FK_TermSubscription on Textbook.Subscription (
Term ASC
)
go

/*==============================================================*/
/* Index: IX_FK_FeedbackSubscription                            */
/*==============================================================*/
create index IX_FK_FeedbackSubscription on Textbook.Subscription (
Feedback_ID ASC
)
go

/*==============================================================*/
/* Index: IX_FK_TextbookSubscription                            */
/*==============================================================*/
create index IX_FK_TextbookSubscription on Textbook.Subscription (
Textbook_ID ASC
)
go

/*==============================================================*/
/* Table: SubscriptionDeclaration                               */
/*==============================================================*/
create table Textbook.SubscriptionDeclaration (
   Subscription_ID      int                  not null,
   Declaration_ID       int                  not null,
   constraint PK_SubscriptionDeclaration primary key nonclustered (Subscription_ID, Declaration_ID)
)
go

/*==============================================================*/
/* Index: IX_FK_SubscriptionDeclaration_Declaration             */
/*==============================================================*/
create index IX_FK_SubscriptionDeclaration_Declaration on Textbook.SubscriptionDeclaration (
Declaration_ID ASC
)
go

/*==============================================================*/
/* Index: IX_FK_Subscription                                    */
/*==============================================================*/
create index IX_FK_Subscription on Textbook.SubscriptionDeclaration (
Subscription_ID ASC
)
go

/*==============================================================*/
/* Table: Textbook                                              */
/*==============================================================*/
create table Textbook.Textbook (
   TextbookID           int                  identity(1,1),
   Name                 Names                not null,
   Isbn                 Numbers              not null,
   Author               Names                not null,
   Press                Names                not null,
   PressAddress         Names                not null,
   Edition              Quality              not null,
   PrintCount           Quality              not null,
   PublishDate          Datetimes            not null,
   Price                number2              not null,
   TextbookType         Names                not null,
   IsSelfCompile        TrueOrFalse          not null,
   PageCount            Quality              not null,
   Discount             number2              null,
   DiscountPrice        number2              null,
   constraint PK_Textbooks primary key (TextbookID)
)
go

alter table Textbook.Approval_Declaration
   add constraint FK_DeclarationApproval_inherits_Approval foreign key (ApprovalID)
      references Textbook.Approval (ApprovalID)
         on delete cascade
go

alter table Textbook.Approval_Declaration
   add constraint FK_DeclarationDeclarationApproval foreign key (Declaration_ID)
      references Textbook.Declaration (DeclarationID)
go

alter table Textbook.Approval_Feedback
   add constraint FK_Approval_Feedback_Approval foreign key (ApprovalID)
      references Textbook.Approval (ApprovalID)
go

alter table Textbook.Approval_Feedback
   add constraint FK_Approval_Feedback_Feedback foreign key (Feedback_ID)
      references Textbook.Feedback (FeedbackID)
go

alter table Textbook.BooksellerStaff
   add constraint FK_BooksellerStaff_Bookseller foreign key (Bookseller_ID)
      references Textbook.Bookseller (BooksellerID)
go

alter table Textbook.Declaration
   add constraint FK_TextbookDeclaration foreign key (Textbook_ID)
      references Textbook.Textbook (TextbookID)
go

alter table Textbook.Inventory
   add constraint FK_StorageInventory foreign key (Storage_ID)
      references Textbook.Storage (StorageID)
go

alter table Textbook.Inventory
   add constraint FK_TextbookInventory foreign key (Textbook_ID)
      references Textbook.Textbook (TextbookID)
go

alter table Textbook.ReleaseRecord
   add constraint FK_StockRecordReleaseRecord foreign key (StockRecord_ID)
      references Textbook.StockRecord (StockRecordID)
go

alter table Textbook.ReleaseRecord_Student
   add constraint FK_ReleaseRecord_Student_ReleaseRecord foreign key (ReleaseRecordID)
      references Textbook.ReleaseRecord (ReleaseRecordID)
go

alter table Textbook.ReleaseRecord_Teacher
   add constraint FK_ReleaseRecord_Teacher_ReleaseRecord foreign key (ReleaseRecordID)
      references Textbook.ReleaseRecord (ReleaseRecordID)
go

alter table Textbook.StockRecord
   add constraint FK_InventoryStockRecord foreign key (Inventory_ID)
      references Textbook.Inventory (InventoryID)
go

alter table Textbook.Storage
   add constraint FK_BookSellerStorage foreign key (Bookseller_ID)
      references Textbook.Bookseller (BooksellerID)
go

alter table Textbook.Subscription
   add constraint FK_BookSellerSubscription foreign key (Bookseller_ID)
      references Textbook.Bookseller (BooksellerID)
go

alter table Textbook.Subscription
   add constraint FK_FeedbackSubscription foreign key (Feedback_ID)
      references Textbook.Feedback (FeedbackID)
go

alter table Textbook.Subscription
   add constraint FK_TextbookSubscription foreign key (Textbook_ID)
      references Textbook.Textbook (TextbookID)
go

alter table Textbook.SubscriptionDeclaration
   add constraint FK_SubscriptionDeclaration_Declaration foreign key (Declaration_ID)
      references Textbook.Declaration (DeclarationID)
go

alter table Textbook.SubscriptionDeclaration
   add constraint FK_SubscriptionDeclaration_Subscription foreign key (Subscription_ID)
      references Textbook.Subscription (SubscriptionID)
go

