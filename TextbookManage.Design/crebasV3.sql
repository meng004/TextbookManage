/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2012/12/4 星期二 10:54:13                       */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.ApprovalDeclaration') and o.name = 'FK_DeclarationApprovalDeclaration')
alter table Textbook.ApprovalDeclaration
   drop constraint FK_DeclarationApprovalDeclaration
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.BooksellerStaff') and o.name = 'FK_BooksellerStaff_Reference_Bookseller')
alter table Textbook.BooksellerStaff
   drop constraint FK_BooksellerStaff_Reference_Bookseller
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Declaration') and o.name = 'FK_DeclarationTextbook')
alter table Textbook.Declaration
   drop constraint FK_DeclarationTextbook
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Declaration') and o.name = 'FK_RecipientTypeDeclaration')
alter table Textbook.Declaration
   drop constraint FK_RecipientTypeDeclaration
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Declaration') and o.name = 'FK_SubscriptionPlanDeclaration')
alter table Textbook.Declaration
   drop constraint FK_SubscriptionPlanDeclaration
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Declaration') and o.name = 'FK_TeacherDeclaration')
alter table Textbook.Declaration
   drop constraint FK_TeacherDeclaration
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Declaration') and o.name = 'FK_TeachingTaskDeclaration')
alter table Textbook.Declaration
   drop constraint FK_TeachingTaskDeclaration
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Feedback') and o.name = 'FK_FeedbackSubscriptionPlan')
alter table Textbook.Feedback
   drop constraint FK_FeedbackSubscriptionPlan
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.SubscriptionPlan') and o.name = 'FK_BooksellerSubscriptionPlan')
alter table Textbook.SubscriptionPlan
   drop constraint FK_BooksellerSubscriptionPlan
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.SubscriptionPlan') and o.name = 'FK_SubscriptionPlanTextbook')
alter table Textbook.SubscriptionPlan
   drop constraint FK_SubscriptionPlanTextbook
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.SubscriptionPlan') and o.name = 'FK_TermSubscriptionPlan')
alter table Textbook.SubscriptionPlan
   drop constraint FK_TermSubscriptionPlan
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.ApprovalDeclaration')
            and   type = 'U')
   drop table Textbook.ApprovalDeclaration
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
            from  sysobjects
           where  id = object_id('Textbook.RecipientType')
            and   type = 'U')
   drop table Textbook.RecipientType
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.StudentReleaseDetail')
            and   name  = 'Idx_StudentReleaseDetail_StudentId'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.StudentReleaseDetail.Idx_StudentReleaseDetail_StudentId
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Textbook.StudentReleaseDetail')
            and   name  = 'Idx_StudentReleaseDetail_Num'
            and   indid > 0
            and   indid < 255)
   drop index Textbook.StudentReleaseDetail.Idx_StudentReleaseDetail_Num
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.StudentReleaseDetail')
            and   type = 'U')
   drop table Textbook.StudentReleaseDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.SubscriptionPlan')
            and   type = 'U')
   drop table Textbook.SubscriptionPlan
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
   and name = 'D_男'
   )
   drop default D_男
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
      @column >= 1
go

create rule R_TrueOrFalse as
      @column in (0,1)
go

create rule R_number2 as
      @column >= 0
go

create rule R_sex as
      @column in ('男','女','未知','未说明')
go


drop schema Textbook
go

/*==============================================================*/
/* User: Textbook                                               */
/*==============================================================*/
create schema Textbook
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
/* Default: D_男                                                 */
/*==============================================================*/
create default D_男
    as '男'
go

/*==============================================================*/
/* Default: "Default_0.00"                                      */
/*==============================================================*/
create default "Default_0.00"
    as 0.00
go



/*==============================================================*/
/* Domain: Datetimes                                            */
/*==============================================================*/
create type Datetimes
   from datetime2
go

execute sp_bindefault '"D_getdate()"', 'Datetimes'
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

execute sp_bindefault 'D_1', 'Quality'
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

execute sp_bindefault 'D_0', 'TrueOrFalse'
go

/*==============================================================*/
/* Domain: number2                                              */
/*==============================================================*/
create type number2
   from decimal(10,2)
go

execute sp_bindrule R_number2, number2
go

execute sp_bindefault '"Default_0.00"', 'number2'
go

/*==============================================================*/
/* Domain: sex                                                  */
/*==============================================================*/
create type sex
   from varchar(10)
go

execute sp_bindrule R_sex, sex
go

execute sp_bindefault 'D_男', 'sex'
go

/*==============================================================*/
/* Table: ApprovalDeclaration                                   */
/*==============================================================*/
create table Textbook.ApprovalDeclaration (
   ApprovalDeclarationID uniqueidentifier      not null default newid(),
   ApprovalDivision     Names                 not null,
   ApprovalPerson       Names                 not null,
   ApprovalDate         Datetimes             not null,
   ApprovalSuggestion   TrueOrFalse           not null,
   Remark               Remarks               null,
   Declaration_DeclarationID uniqueidentifier      not null,
   constraint PK_ApprovalDeclaration primary key nonclustered (ApprovalDeclarationID)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Bookseller                                            */
/*==============================================================*/
create table Textbook.Bookseller (
   BookSellerID         uniqueidentifier      not null default newid(),
   Num                  int                   identity(1, 1),
   Name                 Names                 not null,
   Contact              Names                 not null,
   Telephone            Numbers               not null,
   constraint PK_Bookseller primary key nonclustered (BookSellerID)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: BooksellerStaff                                       */
/*==============================================================*/
create table Textbook.BooksellerStaff (
   BooksellerStaffID    uniqueidentifier      not null default newid(),
   BookSellerID         uniqueidentifier      not null,
   StaffNum             int                   identity(1,1),
   StaffName            Names                 not null,
   Sex                  Numbers               not null,
   constraint PK_BooksellerStaff primary key nonclustered (BooksellerStaffID)
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
   DeclarationID        uniqueidentifier      not null default newid(),
   Num                  bigint                identity(1, 1),
   RecipientType_RecipientTypeID int                   not null,
   DeclarationCount     Quality               not null,
   DeclarationDate      Datetimes             not null,
   HomeTelphone         Numbers               not null,
   Mobile               Numbers               not null,
   IsLookedFeedback     TrueOrFalse           not null,
   SubscriptionPlan_SubscriptionPlanID uniqueidentifier      null,
   Textbook_TextbookID  uniqueidentifier      not null,
   TeachingClassNum     char(9)               not null,
   Declarant_TeacherID  uniqueidentifier      not null default newid(),
   ApprovalState        int                   not null
      constraint CKC_ApprovalState_Declaration check (ApprovalState >= 0),
   constraint PK_Declaration primary key nonclustered (DeclarationID)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_bindefault 'D_0', 'Textbook.Declaration.ApprovalState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Textbook.Declaration')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Declarant_TeacherID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'Textbook', 'table', 'Declaration', 'column', 'Declarant_TeacherID'

end


execute sp_addextendedproperty 'MS_Description', 
   '职工ID',
   'user', 'Textbook', 'table', 'Declaration', 'column', 'Declarant_TeacherID'
go

/*==============================================================*/
/* Table: Feedback                                              */
/*==============================================================*/
create table Textbook.Feedback (
   FeedbackPerson       Names                not null,
   FeedBackDate         Datetimes            not null,
   FeedBackState        TrueOrFalse          not null,
   Remark               Remarks              not null,
   SubscriptionPlan_SubscriptionPlanID uniqueidentifier     not null,
   constraint PK_Feedback primary key nonclustered (SubscriptionPlan_SubscriptionPlanID)
         on "PRIMARY"
)
on "PRIMARY"
go


/*===================ON=========================================*/
/* Table: RecipientType                                         */
/*==============================================================*/
create table Textbook.RecipientType (
   RecipientTypeID      int                   identity(1, 1),
   Name                 Names                 not null,
   constraint PK_RecipientType primary key nonclustered (RecipientTypeID)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: StudentReleaseDetail                                  */
/*==============================================================*/
create table Textbook.StudentReleaseDetail (
   StudentReleaseDetailID uniqueidentifier      not null default newid(),
   Num                  bigint                identity(1,1),
   Term                 Numbers               not null,
   CourseID             uniqueidentifier      not null,
   CourseName           Names                 not null,
   SchoolID             uniqueidentifier      not null,
   SchoolName           Names                 not null,
   ProfessionalClassID  uniqueidentifier      not null,
   ProfessionalClassName Names                 not null,
   StudentID            uniqueidentifier      not null,
   StudentName          Names                 not null,
   StudentNum           Numbers               not null,
   TextbookID           uniqueidentifier      not null,
   TextbookNum          bigint                not null,
   TextbookName         Names                 not null,
   Isbn                 Numbers               not null,
   Press                Names                 not null,
   Edition              Quality               not null,
   PrintCount           Quality               not null,
   Author               Names                 not null,
   RetailPrice          number2               not null,
   Discount             number2               not null,
   DiscountPrice        number2               not null,
   ReleaseCount         Quality               not null,
   ReleaseDate          Datetimes             not null,
   Telphone             Numbers               not null,
   constraint PK_StudentReleaseDetail primary key nonclustered (StudentReleaseDetailID)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Index: Idx_StudentReleaseDetail_Num                          */
/*==============================================================*/
create unique clustered index Idx_StudentReleaseDetail_Num on Textbook.StudentReleaseDetail (
Num ASC
)
go

/*==============================================================*/
/* Index: Idx_StudentReleaseDetail_StudentId                    */
/*==============================================================*/
create index Idx_StudentReleaseDetail_StudentId on Textbook.StudentReleaseDetail (
StudentID ASC,
TextbookID ASC
)
go

/*==============================================================*/
/* Table: SubscriptionPlan                                      */
/*==============================================================*/
create table Textbook.SubscriptionPlan (
   SubscriptionPlanID   uniqueidentifier      not null default newid(),
   Num                  bigint                identity(1, 1),
   DeclarationCount     Quality               not null,
   SpareCount           INT              not null
      constraint CKC_SpareCount_SubscriptionPlan check (SpareCount >= 0),
   SubscriptionPlanDate Datetimes             not null,
   Textbook_TextbookID  uniqueidentifier      not null,
   Bookseller_BookSellerID uniqueidentifier      not null,
   Term_TermYear        char(11)              not null,
   constraint PK_SubscriptionPlan primary key nonclustered (SubscriptionPlanID)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_bindefault D_0, 'Textbook.SubscriptionPlan.SpareCount'
go

/*==============================================================*/
/* Table: Textbook                                              */
/*==============================================================*/
create table Textbook.Textbook (
   TextbookID           uniqueidentifier      not null default newid(),
   Num                  bigint                identity(1, 1),
   Name                 Names                 null,
   Isbn                 Numbers               not null,
   Author               Names                 not null,
   Press                Names                 not null,
   Edition              Quality               not null,
   PrintCount           Quality               not null,
   Price                number2               not null,
   IsSelfCompile        TrueOrFalse           null,
   Type                 Names                 null,
   constraint PK_Textbook primary key nonclustered (TextbookID)
         on "PRIMARY"
)
on "PRIMARY"
go

alter table Textbook.ApprovalDeclaration
   add constraint FK_DeclarationApprovalDeclaration foreign key (Declaration_DeclarationID)
      references Textbook.Declaration (DeclarationID)
         on delete cascade
go

alter table Textbook.BooksellerStaff
   add constraint FK_BooksellerStaff_Reference_Bookseller foreign key (BookSellerID)
      references Textbook.Bookseller (BookSellerID)
         on delete cascade
go

alter table Textbook.Declaration
   add constraint FK_DeclarationTextbook foreign key (Textbook_TextbookID)
      references Textbook.Textbook (TextbookID)
go

alter table Textbook.Declaration
   add constraint FK_RecipientTypeDeclaration foreign key (RecipientType_RecipientTypeID)
      references Textbook.RecipientType (RecipientTypeID)
go

alter table Textbook.Declaration
   add constraint FK_SubscriptionPlanDeclaration foreign key (SubscriptionPlan_SubscriptionPlanID)
      references Textbook.SubscriptionPlan (SubscriptionPlanID)
go

alter table Textbook.Declaration
   add constraint FK_TeacherDeclaration foreign key (Declarant_TeacherID)
      references dbo.JCSJ_JSB (ZGID)
go

alter table Textbook.Declaration
   add constraint FK_TeachingTaskDeclaration foreign key (TeachingClassNum)
      references dbo.KK_JXBXXB (JXBBH)
         on delete cascade
go

alter table Textbook.Feedback
   add constraint FK_FeedbackSubscriptionPlan foreign key (SubscriptionPlan_SubscriptionPlanID)
      references Textbook.SubscriptionPlan (SubscriptionPlanID)
go

alter table Textbook.SubscriptionPlan
   add constraint FK_BooksellerSubscriptionPlan foreign key (Bookseller_BookSellerID)
      references Textbook.Bookseller (BookSellerID)
go

alter table Textbook.SubscriptionPlan
   add constraint FK_SubscriptionPlanTextbook foreign key (Textbook_TextbookID)
      references Textbook.Textbook (TextbookID)
go

alter table Textbook.SubscriptionPlan
   add constraint FK_TermSubscriptionPlan foreign key (Term_TermYear)
      references dbo.DM_XNXQ (XNXQ)
go



