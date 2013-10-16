/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2012/11/26 ÐÇÆÚÒ» 22:10:34                      */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.ApprovalDeclaration') and o.name = 'FK_DeclarationApprovalDeclaration')
alter table Textbook.ApprovalDeclaration
   drop constraint FK_DeclarationApprovalDeclaration
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Declaration') and o.name = 'FK_DeclarationApprovalState')
alter table Textbook.Declaration
   drop constraint FK_DeclarationApprovalState
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
   where r.fkeyid = object_id('Textbook.Department') and o.name = 'FK_SchoolDepartment')
alter table Textbook.Department
   drop constraint FK_SchoolDepartment
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.DepartmentCourse') and o.name = 'FK_DepartmentCourse_Course')
alter table Textbook.DepartmentCourse
   drop constraint FK_DepartmentCourse_Course
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.DepartmentCourse') and o.name = 'FK_DepartmentCourse_Department')
alter table Textbook.DepartmentCourse
   drop constraint FK_DepartmentCourse_Department
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.DepartmentTeacher') and o.name = 'FK_DepartmentTeacher_Department')
alter table Textbook.DepartmentTeacher
   drop constraint FK_DepartmentTeacher_Department
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.DepartmentTeacher') and o.name = 'FK_DepartmentTeacher_Teacher')
alter table Textbook.DepartmentTeacher
   drop constraint FK_DepartmentTeacher_Teacher
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Feedback') and o.name = 'FK_FeedbackSubscriptionPlan')
alter table Textbook.Feedback
   drop constraint FK_FeedbackSubscriptionPlan
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.ProfessionalClass') and o.name = 'FK_SchoolProfessionalClass')
alter table Textbook.ProfessionalClass
   drop constraint FK_SchoolProfessionalClass
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.ProfessionalClassTeachingTask') and o.name = 'FK_ProfessionalClassTeachingTask_ProfessionalClass')
alter table Textbook.ProfessionalClassTeachingTask
   drop constraint FK_ProfessionalClassTeachingTask_ProfessionalClass
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.ProfessionalClassTeachingTask') and o.name = 'FK_ProfessionalClassTeachingTask_Reference_TeachingTask')
alter table Textbook.ProfessionalClassTeachingTask
   drop constraint FK_ProfessionalClassTeachingTask_Reference_TeachingTask
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.Student') and o.name = 'FK_ProfessionalClassStudent')
alter table Textbook.Student
   drop constraint FK_ProfessionalClassStudent
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
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.TeacherTeachingTask') and o.name = 'FK_TeacherTeachingTask_Teacher')
alter table Textbook.TeacherTeachingTask
   drop constraint FK_TeacherTeachingTask_Teacher
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.TeacherTeachingTask') and o.name = 'FK_TeacherTeachingTask_Reference_TeachingTask')
alter table Textbook.TeacherTeachingTask
   drop constraint FK_TeacherTeachingTask_Reference_TeachingTask
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Textbook.TeachingTask') and o.name = 'FK_CourseTeachingTask')
alter table Textbook.TeachingTask
   drop constraint FK_CourseTeachingTask
go

alter table Textbook.ApprovalDeclaration
   drop constraint PK_ApprovalDeclaration
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.ApprovalDeclaration')
            and   type = 'U')
   drop table Textbook.ApprovalDeclaration
go

alter table Textbook.ApprovalState
   drop constraint PK_ApprovalState
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.ApprovalState')
            and   type = 'U')
   drop table Textbook.ApprovalState
go

alter table Textbook.Bookseller
   drop constraint PK_Bookseller
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Bookseller')
            and   type = 'U')
   drop table Textbook.Bookseller
go

alter table Textbook.Course
   drop constraint PK_Course
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Course')
            and   type = 'U')
   drop table Textbook.Course
go

alter table Textbook.Declaration
   drop constraint PK_Declaration
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Declaration')
            and   type = 'U')
   drop table Textbook.Declaration
go

alter table Textbook.Department
   drop constraint PK_Department
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Department')
            and   type = 'U')
   drop table Textbook.Department
go

alter table Textbook.DepartmentCourse
   drop constraint PK_DepartmentCourse
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.DepartmentCourse')
            and   type = 'U')
   drop table Textbook.DepartmentCourse
go

alter table Textbook.DepartmentTeacher
   drop constraint PK_DepartmentTeacher
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.DepartmentTeacher')
            and   type = 'U')
   drop table Textbook.DepartmentTeacher
go

alter table Textbook.Feedback
   drop constraint PK_Feedback
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Feedback')
            and   type = 'U')
   drop table Textbook.Feedback
go

alter table Textbook.ProfessionalClass
   drop constraint PK_ProfessionalClass
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.ProfessionalClass')
            and   type = 'U')
   drop table Textbook.ProfessionalClass
go

alter table Textbook.ProfessionalClassTeachingTask
   drop constraint PK_ProfessionalClassTeachingTask
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.ProfessionalClassTeachingTask')
            and   type = 'U')
   drop table Textbook.ProfessionalClassTeachingTask
go

alter table Textbook.RecipientType
   drop constraint PK_RecipientType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.RecipientType')
            and   type = 'U')
   drop table Textbook.RecipientType
go

alter table Textbook.School
   drop constraint PK_School
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.School')
            and   type = 'U')
   drop table Textbook.School
go

alter table Textbook.Student
   drop constraint PK_Student
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Student')
            and   type = 'U')
   drop table Textbook.Student
go

alter table Textbook.StudentReleaseDetail
   drop constraint PK_StudentReleaseDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.StudentReleaseDetail')
            and   type = 'U')
   drop table Textbook.StudentReleaseDetail
go

alter table Textbook.SubscriptionPlan
   drop constraint PK_SubscriptionPlan
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.SubscriptionPlan')
            and   type = 'U')
   drop table Textbook.SubscriptionPlan
go

alter table Textbook.Teacher
   drop constraint PK_Teacher
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Teacher')
            and   type = 'U')
   drop table Textbook.Teacher
go

alter table Textbook.TeacherTeachingTask
   drop constraint PK_TeacherTeachingTask
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.TeacherTeachingTask')
            and   type = 'U')
   drop table Textbook.TeacherTeachingTask
go

alter table Textbook.TeachingTask
   drop constraint PK_TeachingTask
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.TeachingTask')
            and   type = 'U')
   drop table Textbook.TeachingTask
go

alter table Textbook.Term
   drop constraint PK_Term
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Textbook.Term')
            and   type = 'U')
   drop table Textbook.Term
go

alter table Textbook.Textbook
   drop constraint PK_Textbook
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
   and name = '[D_getdate()]'
   )
   drop default [D_getdate()]
go

if exists (select 1
   from  sysobjects where type = 'D'
   and name = '[Default_0.00]'
   )
   drop default [Default_0.00]
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

create rule R_Quality as
      @column >= 1
go

create rule R_TrueOrFalse as
      @column in (0,1)
go

create rule R_number2 as
      @column >= 0
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
/* Default: [D_getdate()]                                       */
/*==============================================================*/
create default [D_getdate()]
    as getdate()
go

/*==============================================================*/
/* Default: [Default_0.00]                                      */
/*==============================================================*/
create default [Default_0.00]
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

execute sp_bindefault '[D_getdate()]', 'Datetimes'
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

execute sp_bindefault '[Default_0.00]', 'number2'
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
   Remark               Remarks               not null,
   Declaration_DeclarationID uniqueidentifier      not null
)
on "PRIMARY"
go

alter table Textbook.ApprovalDeclaration
   add constraint PK_ApprovalDeclaration primary key nonclustered (ApprovalDeclarationID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: ApprovalState                                         */
/*==============================================================*/
create table Textbook.ApprovalState (
   ApprovalStateID      int                   identity(1, 1),
   Name                 Names                 not null
)
on "PRIMARY"
go

alter table Textbook.ApprovalState
   add constraint PK_ApprovalState primary key nonclustered (ApprovalStateID)
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
   Telephone            Numbers               not null
)
on "PRIMARY"
go

alter table Textbook.Bookseller
   add constraint PK_Bookseller primary key nonclustered (BookSellerID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: Course                                                */
/*==============================================================*/
create table Textbook.Course (
   CourseID             uniqueidentifier      not null default newid(),
   Num                  Names                 not null,
   Name                 Names                 not null
)
on "PRIMARY"
go

alter table Textbook.Course
   add constraint PK_Course primary key nonclustered (CourseID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: Declaration                                           */
/*==============================================================*/
create table Textbook.Declaration (
   DeclarationID        uniqueidentifier      not null default newid(),
   Num                  bigint                identity(1, 1),
   Declarant_TeacherID  uniqueidentifier      not null,
   RecipientType_RecipientTypeID int                   not null,
   DeclarationCount     Quality               not null,
   DeclarationDate      Datetimes             not null,
   HomeTelphone         Numbers               not null,
   Mobile               Numbers               not null,
   ApprovalState_ApprovalStateID int                   not null,
   IsLookedFeedback     TrueOrFalse           not null,
   TeachingClassNum     Numbers               not null,
   SubscriptionPlan_SubscriptionPlanID uniqueidentifier      not null,
   Textbook_TextbookID  uniqueidentifier      not null
)
on "PRIMARY"
go

alter table Textbook.Declaration
   add constraint PK_Declaration primary key nonclustered (DeclarationID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: Department                                            */
/*==============================================================*/
create table Textbook.Department (
   DepartmentID         uniqueidentifier      not null,
   Num                  Numbers               not null,
   Name                 Names                 not null,
   School_SchoolID      uniqueidentifier      not null
)
on "PRIMARY"
go

alter table Textbook.Department
   add constraint PK_Department primary key nonclustered (DepartmentID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: DepartmentCourse                                      */
/*==============================================================*/
create table Textbook.DepartmentCourse (
   Department_DepartmentID uniqueidentifier      not null,
   Course_CourseID      uniqueidentifier      not null
)
on "PRIMARY"
go

alter table Textbook.DepartmentCourse
   add constraint PK_DepartmentCourse primary key nonclustered (Department_DepartmentID, Course_CourseID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: DepartmentTeacher                                     */
/*==============================================================*/
create table Textbook.DepartmentTeacher (
   Department_DepartmentID uniqueidentifier      not null,
   Teacher_TeacherID    uniqueidentifier      not null
)
on "PRIMARY"
go

alter table Textbook.DepartmentTeacher
   add constraint PK_DepartmentTeacher primary key nonclustered (Department_DepartmentID, Teacher_TeacherID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: Feedback                                              */
/*==============================================================*/
create table Textbook.Feedback (
   FeedbackID           int                   identity(1, 1),
   FeedbackPerson       Names                 not null,
   FeedBackDate         Datetimes             not null,
   FeedBackState        TrueOrFalse           not null,
   Remark               Remarks               not null,
   SubscriptionPlan_SubscriptionPlanID uniqueidentifier      not null
)
on "PRIMARY"
go

alter table Textbook.Feedback
   add constraint PK_Feedback primary key nonclustered (FeedbackID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: ProfessionalClass                                     */
/*==============================================================*/
create table Textbook.ProfessionalClass (
   ProfessionalClassID  uniqueidentifier      not null default newid(),
   Num                  Numbers               not null,
   Name                 Names                 not null,
   Grade                Numbers               not null,
   School_SchoolID      uniqueidentifier      not null
)
on "PRIMARY"
go

alter table Textbook.ProfessionalClass
   add constraint PK_ProfessionalClass primary key nonclustered (ProfessionalClassID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: ProfessionalClassTeachingTask                         */
/*==============================================================*/
create table Textbook.ProfessionalClassTeachingTask (
   ProfessionalClass_ProfessionalClassID uniqueidentifier      not null,
   TeachingTask_TeachingClassNum Numbers               not null
)
on "PRIMARY"
go

alter table Textbook.ProfessionalClassTeachingTask
   add constraint PK_ProfessionalClassTeachingTask primary key nonclustered (ProfessionalClass_ProfessionalClassID, TeachingTask_TeachingClassNum)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: RecipientType                                         */
/*==============================================================*/
create table Textbook.RecipientType (
   RecipientTypeID      int                   identity(1, 1),
   Name                 Names                 not null
)
on "PRIMARY"
go

alter table Textbook.RecipientType
   add constraint PK_RecipientType primary key nonclustered (RecipientTypeID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: School                                                */
/*==============================================================*/
create table Textbook.School (
   SchoolID             uniqueidentifier      not null default newid(),
   Num                  Numbers               not null,
   Name                 Names                 not null
)
on "PRIMARY"
go

alter table Textbook.School
   add constraint PK_School primary key nonclustered (SchoolID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: Student                                               */
/*==============================================================*/
create table Textbook.Student (
   StudentID            uniqueidentifier      not null default newid(),
   Num                  Numbers               not null,
   Name                 Names                 not null,
   Sex                  Numbers               not null,
   ProfessionalClass_ProfessionalClassID uniqueidentifier      not null
)
on "PRIMARY"
go

alter table Textbook.Student
   add constraint PK_Student primary key nonclustered (StudentID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: StudentReleaseDetail                                  */
/*==============================================================*/
create table Textbook.StudentReleaseDetail (
   StudentReleaseDetailID uniqueidentifier      not null default newid(),
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
   Telphone             Numbers               not null
)
on "PRIMARY"
go

alter table Textbook.StudentReleaseDetail
   add constraint PK_StudentReleaseDetail primary key nonclustered (StudentReleaseDetailID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: SubscriptionPlan                                      */
/*==============================================================*/
create table Textbook.SubscriptionPlan (
   SubscriptionPlanID   uniqueidentifier      not null default newid(),
   Num                  bigint                identity(1, 1),
   DeclarationCount     Quality               not null,
   SpareCount           Quality               not null,
   SubscriptionPlanDate Datetimes             not null,
   Textbook_TextbookID  uniqueidentifier      not null,
   Bookseller_BookSellerID uniqueidentifier      not null,
   Term_TermYear        Numbers               not null
)
on "PRIMARY"
go

alter table Textbook.SubscriptionPlan
   add constraint PK_SubscriptionPlan primary key nonclustered (SubscriptionPlanID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: Teacher                                               */
/*==============================================================*/
create table Textbook.Teacher (
   TeacherID            uniqueidentifier      not null default newid(),
   Num                  Numbers               not null,
   Name                 Names                 not null,
   Sex                  Numbers               not null
)
on "PRIMARY"
go

alter table Textbook.Teacher
   add constraint PK_Teacher primary key nonclustered (TeacherID)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: TeacherTeachingTask                                   */
/*==============================================================*/
create table Textbook.TeacherTeachingTask (
   Teacher_TeacherID    uniqueidentifier      not null,
   TeachingTask_TeachingClassNum Numbers               not null
)
on "PRIMARY"
go

alter table Textbook.TeacherTeachingTask
   add constraint PK_TeacherTeachingTask primary key nonclustered (Teacher_TeacherID, TeachingTask_TeachingClassNum)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: TeachingTask                                          */
/*==============================================================*/
create table Textbook.TeachingTask (
   TeachingClassNum     Numbers               not null,
   Course_CourseID      uniqueidentifier      not null,
   Term                 Numbers               not null
)
on "PRIMARY"
go

alter table Textbook.TeachingTask
   add constraint PK_TeachingTask primary key nonclustered (TeachingClassNum)
      on "PRIMARY"
go

/*==============================================================*/
/* Table: Term                                                  */
/*==============================================================*/
create table Textbook.Term (
   YearTerm             Numbers               not null,
   IsCurrent            TrueOrFalse           not null
)
on "PRIMARY"
go

alter table Textbook.Term
   add constraint PK_Term primary key nonclustered (YearTerm)
      on "PRIMARY"
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
   IsSelfCompile        TrueOrFalse           not null,
   Type                 Names                 not null
)
on "PRIMARY"
go

alter table Textbook.Textbook
   add constraint PK_Textbook primary key nonclustered (TextbookID)
      on "PRIMARY"
go

alter table Textbook.ApprovalDeclaration
   add constraint FK_DeclarationApprovalDeclaration foreign key (Declaration_DeclarationID)
      references Textbook.Declaration (DeclarationID)
go

alter table Textbook.Declaration
   add constraint FK_DeclarationApprovalState foreign key (ApprovalState_ApprovalStateID)
      references Textbook.ApprovalState (ApprovalStateID)
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
      references Textbook.Teacher (TeacherID)
go

alter table Textbook.Declaration
   add constraint FK_TeachingTaskDeclaration foreign key (TeachingClassNum)
      references Textbook.TeachingTask (TeachingClassNum)
go

alter table Textbook.Department
   add constraint FK_SchoolDepartment foreign key (School_SchoolID)
      references Textbook.School (SchoolID)
go

alter table Textbook.DepartmentCourse
   add constraint FK_DepartmentCourse_Course foreign key (Course_CourseID)
      references Textbook.Course (CourseID)
go

alter table Textbook.DepartmentCourse
   add constraint FK_DepartmentCourse_Department foreign key (Department_DepartmentID)
      references Textbook.Department (DepartmentID)
go

alter table Textbook.DepartmentTeacher
   add constraint FK_DepartmentTeacher_Department foreign key (Department_DepartmentID)
      references Textbook.Department (DepartmentID)
go

alter table Textbook.DepartmentTeacher
   add constraint FK_DepartmentTeacher_Teacher foreign key (Teacher_TeacherID)
      references Textbook.Teacher (TeacherID)
go

alter table Textbook.Feedback
   add constraint FK_FeedbackSubscriptionPlan foreign key (SubscriptionPlan_SubscriptionPlanID)
      references Textbook.SubscriptionPlan (SubscriptionPlanID)
go

alter table Textbook.ProfessionalClass
   add constraint FK_SchoolProfessionalClass foreign key (School_SchoolID)
      references Textbook.School (SchoolID)
go

alter table Textbook.ProfessionalClassTeachingTask
   add constraint FK_ProfessionalClassTeachingTask_ProfessionalClass foreign key (ProfessionalClass_ProfessionalClassID)
      references Textbook.ProfessionalClass (ProfessionalClassID)
go

alter table Textbook.ProfessionalClassTeachingTask
   add constraint FK_ProfessionalClassTeachingTask_Reference_TeachingTask foreign key (TeachingTask_TeachingClassNum)
      references Textbook.TeachingTask (TeachingClassNum)
go

alter table Textbook.Student
   add constraint FK_ProfessionalClassStudent foreign key (ProfessionalClass_ProfessionalClassID)
      references Textbook.ProfessionalClass (ProfessionalClassID)
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
      references Textbook.Term (YearTerm)
go

alter table Textbook.TeacherTeachingTask
   add constraint FK_TeacherTeachingTask_Teacher foreign key (Teacher_TeacherID)
      references Textbook.Teacher (TeacherID)
go

alter table Textbook.TeacherTeachingTask
   add constraint FK_TeacherTeachingTask_Reference_TeachingTask foreign key (TeachingTask_TeachingClassNum)
      references Textbook.TeachingTask (TeachingClassNum)
go

alter table Textbook.TeachingTask
   add constraint FK_CourseTeachingTask foreign key (Course_CourseID)
      references Textbook.Course (CourseID)
go

