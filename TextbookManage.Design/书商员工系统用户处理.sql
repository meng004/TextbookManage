INSERT INTO Textbook.Bookseller
        ( BookSellerID ,
          Name ,
          Contact ,
          Telephone
        )
SELECT BooksellerID, BooksellerName, Contact, Telephone FROM dbo.NewTextbook_Bookseller


INSERT INTO Textbook.BooksellerStaff
        ( BooksellerStaffID ,
          BookSellerID ,
          StaffName ,
          Sex
        )
SELECT BooksellerstaffID, BooksellerID, StaffName, Sex FROM dbo.NewTextbook_BooksellerStaff


-- 书商员工视图

SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO
CREATE VIEW Textbook.V_BooksellerStaff
AS
SELECT     b.BooksellerID, b.Name AS BooksellerName, 
                      s.BooksellerStaffID,
                      s.StaffName, s.Sex
FROM         Textbook.Bookseller AS b INNER JOIN
                      Textbook.BooksellerStaff AS s ON b.BooksellerID = s.BooksellerID
GO






-- 系统用户视图
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO
ALTER VIEW [dbo].[V_SYS_UsersInfo]
AS
SELECT     A.XTYHID, A.YHID, A.USERID, D .YHJB, E.YHLX, C.SJBSMC, B.SSYXSID AS YXSID, B.SSYXSMC AS YXSMC, B.XM, B.XB, A.SJBS, A.YHJBM, A.YHLXM, F.UserName, 
                      G.Password, G.IsLockedOut
FROM         XT_XTYHB A INNER JOIN
                      V_BaseInfo_Teacher B ON A.YHID = B.ZGID LEFT OUTER JOIN
                      XT_SJBS C ON A.SJBS = C.SJBSID LEFT OUTER JOIN
                      DM_YHJB D ON A.YHJBM = D .YHJBM INNER JOIN
                      DM_YHLX E ON A.YHLXM = E.YHLXM AND A.YHLXM NOT IN('00','04') INNER JOIN
                      ASPNET_USERS F ON A.USERID = F.USERID INNER JOIN
                      dbo.aspnet_Membership G ON F.USERID = G.USERID
UNION
SELECT     A.XTYHID, A.YHID, A.USERID, D .YHJB, E.YHLX, C.SJBSMC, B.YXSID, B.YXSMC, B.XM, B.XB, A.SJBS, A.YHJBM, A.YHLXM, F.UserName, G.Password, 
                      G.IsLockedOut
FROM         XT_XTYHB A INNER JOIN
                      V_JCSJ_YXSXSB B ON A.YHID = B.XJID LEFT OUTER JOIN
                      XT_SJBS C ON A.SJBS = C.SJBSID LEFT OUTER JOIN
                      DM_YHJB D ON A.YHJBM = D .YHJBM INNER JOIN
                      DM_YHLX E ON A.YHLXM = E.YHLXM AND A.YHLXM = '00' INNER JOIN
                      ASPNET_USERS F ON A.USERID = F.USERID INNER JOIN
                      dbo.aspnet_Membership G ON F.USERID = G.USERID
                      
UNION
SELECT     A.XTYHID, A.YHID, A.USERID, D .YHJB, E.YHLX, C.SJBSMC, B.BooksellerID AS YXSID, B.BooksellerName as YXSMC, B.StaffName AS XM, B.Sex AS XB, A.SJBS, A.YHJBM, A.YHLXM, F.UserName, G.Password, 
                      G.IsLockedOut
FROM         XT_XTYHB A INNER JOIN
                      Textbook.V_BooksellerStaff B ON A.YHID = B.BooksellerStaffID LEFT OUTER JOIN
                      XT_SJBS C ON A.SJBS = C.SJBSID LEFT OUTER JOIN
                      DM_YHJB D ON A.YHJBM = D .YHJBM INNER JOIN
                      DM_YHLX E ON A.YHLXM = E.YHLXM AND A.YHLXM = '04' INNER JOIN
                      ASPNET_USERS F ON A.USERID = F.USERID INNER JOIN
                      dbo.aspnet_Membership G ON F.USERID = G.USERID

GO





