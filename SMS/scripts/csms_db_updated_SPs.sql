/****** Object:  StoredProcedure [dbo].[EDeleteAllStudentMarks]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDeleteAllStudentMarks]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EDeleteAllStudentMarks]
GO
/****** Object:  StoredProcedure [dbo].[EGetAllEMarksStudent]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllEMarksStudent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetAllEMarksStudent]
GO
/****** Object:  StoredProcedure [dbo].[EINSERTMarksStudent]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EINSERTMarksStudent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EINSERTMarksStudent]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAllMarksMaxMinMaster]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAllMarksMaxMinMaster]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteAllMarksMaxMinMaster]
GO
/****** Object:  StoredProcedure [dbo].[EGetAllEMarksMaster]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllEMarksMaster]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetAllEMarksMaster]
GO
/****** Object:  StoredProcedure [dbo].[EGetFilteredExam]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetFilteredExam]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetFilteredExam]
GO
/****** Object:  StoredProcedure [dbo].[EGetAllSubjects]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllSubjects]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetAllSubjects]
GO
/****** Object:  StoredProcedure [dbo].[GetCurrentJVoucher]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCurrentJVoucher]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCurrentJVoucher]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeLadger]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmployeeLadger]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetEmployeeLadger]
GO
/****** Object:  StoredProcedure [dbo].[GetRecDetailFor]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecDetailFor]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetRecDetailFor]
GO
/****** Object:  StoredProcedure [dbo].[GetRecPrint]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecPrint]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetRecPrint]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentLadger]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStudentLadger]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetStudentLadger]
GO
/****** Object:  StoredProcedure [dbo].[INSERTMarksMaxMinMaster]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INSERTMarksMaxMinMaster]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[INSERTMarksMaxMinMaster]
GO
/****** Object:  StoredProcedure [dbo].[sp_AllStudentForScholar]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AllStudentForScholar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_AllStudentForScholar]
GO
/****** Object:  StoredProcedure [dbo].[sp_AllStudent]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AllStudent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_AllStudent]
GO
/****** Object:  StoredProcedure [dbo].[GetViewCCEMarksDetail]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewCCEMarksDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetViewCCEMarksDetail]
GO
/****** Object:  StoredProcedure [dbo].[GetViewMCCEMarksDetail]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewMCCEMarksDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetViewMCCEMarksDetail]
GO
/****** Object:  StoredProcedure [dbo].[GetViewMPCCEMarksDetail]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewMPCCEMarksDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetViewMPCCEMarksDetail]
GO
/****** Object:  StoredProcedure [dbo].[GetViewMPCCEMarksDetail_Format1]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewMPCCEMarksDetail_Format1]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetViewMPCCEMarksDetail_Format1]
GO
/****** Object:  StoredProcedure [dbo].[GetViewMPCCEMarksDetail_SHHSSA]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewMPCCEMarksDetail_SHHSSA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetViewMPCCEMarksDetail_SHHSSA]
GO
/****** Object:  StoredProcedure [dbo].[GetViewMSCCEMarksDetail]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewMSCCEMarksDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetViewMSCCEMarksDetail]
GO
/****** Object:  StoredProcedure [dbo].[EGetCurrentSession]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetCurrentSession]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetCurrentSession]
GO
/****** Object:  StoredProcedure [dbo].[EGetStudentList]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetStudentList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetStudentList]
GO
/****** Object:  StoredProcedure [dbo].[EGetAllClass]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllClass]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetAllClass]
GO
/****** Object:  StoredProcedure [dbo].[ECREATEExam]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ECREATEExam]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ECREATEExam]
GO
/****** Object:  StoredProcedure [dbo].[ECREATEGrade]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ECREATEGrade]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ECREATEGrade]
GO
/****** Object:  StoredProcedure [dbo].[EGetAllExam]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllExam]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetAllExam]
GO
/****** Object:  StoredProcedure [dbo].[EGetAllGrade]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllGrade]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetAllGrade]
GO
/****** Object:  StoredProcedure [dbo].[EGetAllRange]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetAllRange]
GO
/****** Object:  StoredProcedure [dbo].[EGetAllSection]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllSection]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetAllSection]
GO
/****** Object:  StoredProcedure [dbo].[EGetAllStream]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllStream]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EGetAllStream]
GO
/****** Object:  StoredProcedure [dbo].[EDELETEExam]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDELETEExam]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EDELETEExam]
GO
/****** Object:  StoredProcedure [dbo].[EDELETEGrade]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDELETEGrade]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EDELETEGrade]
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllUsers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllUsers]
GO
/****** Object:  StoredProcedure [dbo].[GetAttendanceBetWeenDate]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAttendanceBetWeenDate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAttendanceBetWeenDate]
GO
/****** Object:  StoredProcedure [dbo].[GetAttendanceByMonth]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAttendanceByMonth]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAttendanceByMonth]
GO
/****** Object:  StoredProcedure [dbo].[GetBankLadger]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBankLadger]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetBankLadger]
GO
/****** Object:  StoredProcedure [dbo].[GetCashLadger]    Script Date: 09/18/2018 18:49:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCashLadger]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCashLadger]
GO
/****** Object:  StoredProcedure [dbo].[GetCashLadger]    Script Date: 09/18/2018 18:49:33 ******/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteStudent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteStudent]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCashLadger]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetCashLadger](@SessionCode int,@Studentno int,@Fdate datetime,@Tdate datetime)as
begin
declare @Result Table(Type nvarchar(50),VchNo nvarchar(50),VDate nvarchar(20),Narrtion nvarchar(max),Reecipt numeric(18,2),StudentAc numeric(18,2),CashAc numeric(18,2))

declare  @AcCode int,@SCode int,@Type nvarchar(50),@VchNo nvarchar(50),@VDate nvarchar(20),@Narrtion nvarchar(max),@Reecipt numeric(18,2),@StudentAc numeric(18,2),@CashAc numeric(18,2),@tval int,@tvalf int,@TFee numeric(18,2),@TFeeinn numeric(18,2),@PFee numeric(18,2),@SFee numeric(18,2),@OFee numeric(18,2),@TFee1 numeric(18,2),@TFee2 numeric(18,2),@TFee11 numeric(18,2),@TFee22 numeric(18,2),@SStatus nvarchar(50),@PRec numeric(18,2),@TotRFee numeric(18,2),@TotBFee numeric(18,2)

		set @tval=0
		set @TFee1=0
		set @TFee2=0
		set @TFee11=0
		set @TFee22=0
		--/Some Logic Here /--------
		insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
			  values('''','''',convert(nvarchar(14),@Fdate,103),''Opening Balance'',0,0,0)
		DECLARE db_cursor CURSOR FOR  
		select vchtype,vchno,convert(nvarchar(14), vchdate,103),(select acname from tbl_account where accode=( select  accode from tbl_voucherdet where  vchno=ovd.vchno and sessioncode=ovd.sessioncode and VchType=ovd.VchType and accode<> ovd.accode)) as Narration,(select accode from tbl_account where accode=( select  accode from tbl_voucherdet where  vchno=ovd.vchno and sessioncode=ovd.sessioncode and VchType=ovd.VchType and accode<> ovd.accode)) as AcCode,vchamt as Receipt,0,0    from tbl_voucherdet ovd where accode=@Studentno  and vchdate between @Fdate and @Tdate
		OPEN db_cursor   
		FETCH NEXT FROM db_cursor INTO @Type ,@VchNo ,@VDate ,@Narrtion,@AcCode ,@Reecipt ,@StudentAc ,@CashAc 

		WHILE @@FETCH_STATUS = 0   
		BEGIN   
		     
			  set @TFee2=@TFee22-@Reecipt
			  set @TFee22=@TFee2
				insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
			  values(@Type,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee22,0)
			  

			  
		      
			   FETCH NEXT FROM db_cursor INTO @Type ,@VchNo ,@VDate ,@Narrtion,@AcCode  ,@Reecipt ,@StudentAc ,@CashAc
		END   

		CLOSE db_cursor   
		DEALLOCATE db_cursor

--/End/--




select *from @Result
select (select ''Cash A/c'') as StuName,*from tbl_school 
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetBankLadger]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBankLadger]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetBankLadger](@SessionCode int,@Studentno int,@Fdate datetime,@Tdate datetime)as
begin
declare @Result Table(Type nvarchar(50),VchNo nvarchar(50),VDate nvarchar(20),Narrtion nvarchar(max),Reecipt numeric(18,2),StudentAc numeric(18,2),CashAc numeric(18,2))

declare  @AcCode int,@SCode int,@Type nvarchar(50),@VchNo nvarchar(50),@VDate nvarchar(20),@Narrtion nvarchar(max),@Reecipt numeric(18,2),@StudentAc numeric(18,2),@CashAc numeric(18,2),@tval int,@tvalf int,@TFee numeric(18,2),@TFeeinn numeric(18,2),@PFee numeric(18,2),@SFee numeric(18,2),@OFee numeric(18,2),@TFee1 numeric(18,2),@TFee2 numeric(18,2),@TFee11 numeric(18,2),@TFee22 numeric(18,2),@SStatus nvarchar(50),@PRec numeric(18,2),@TotRFee numeric(18,2),@TotBFee numeric(18,2)

		set @tval=0
		set @TFee1=0
		set @TFee2=0
		set @TFee11=0
		set @TFee22=0
		--/Some Logic Here /--------
		 select @TFee22=sum(isnull( case when vchtype=''BP'' then vchamt else ''0'' end,0)) -  sum(isnull(
case when vchtype=''BR'' then vchamt else ''0'' end,0) )   from tbl_voucherdet ovd where accode=@Studentno  and vchdate< @Fdate 
		insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
			  values('''','''',convert(nvarchar(14),@Fdate,103),''Opening Balance'',0,isnull(@TFee22,0),isnull(@TFee22,0))
		DECLARE db_cursor CURSOR FOR  
		select vchtype,vchno,convert(nvarchar(14), vchdate,103),(select acname from tbl_account where accode=( select  accode from tbl_voucherdet where  vchno=ovd.vchno and sessioncode=ovd.sessioncode and VchType=ovd.VchType and accode<> ovd.accode)) as Narration,(select accode from tbl_account where accode=( select  accode from tbl_voucherdet where  vchno=ovd.vchno and sessioncode=ovd.sessioncode and VchType=ovd.VchType and accode<> ovd.accode)) as AcCode,
case when vchtype=''BR'' then vchamt else ''0'' end as Receipt, case when vchtype=''BP'' then vchamt else ''0'' end  as Payment,0    from tbl_voucherdet ovd where accode=@Studentno  and vchdate between @Fdate and @Tdate
		OPEN db_cursor   
		FETCH NEXT FROM db_cursor INTO @Type ,@VchNo ,@VDate ,@Narrtion,@AcCode ,@Reecipt ,@StudentAc ,@CashAc 

		WHILE @@FETCH_STATUS = 0   
		BEGIN   
		      if(@Type=''BP'')
		      begin
			  set @TFee2=isnull(@TFee22,0)+@StudentAc
			  set @TFee22=@TFee2
				insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
			  values(@Type,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee22,@StudentAc)
			  end
			  if(@Type=''BR'')
		      begin
			  set @TFee2=isnull(@TFee22,0)-@Reecipt
			  set @TFee22=@TFee2
				insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
			  values(@Type,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee22,@StudentAc)
			  end
			  
		      
			   FETCH NEXT FROM db_cursor INTO @Type ,@VchNo ,@VDate ,@Narrtion,@AcCode  ,@Reecipt ,@StudentAc ,@CashAc
		END   

		CLOSE db_cursor   
		DEALLOCATE db_cursor

--/End/--




select *from @Result
select (select ''Bank A/c'') as StuName,*from tbl_school 
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAttendanceByMonth]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAttendanceByMonth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE  Procedure [dbo].[GetAttendanceByMonth] @Month int,@Year int
 As Begin
Select tbl_EmployeeInfo.EmpNo,tbl_EmployeeInfo.EmpName,tbl_EmployeeInfo.FathersName,tbl_EmployeeInfo.Designation,tbl_EmployeeInfo.AccountNo,tbl_EmployeeInfo.BankName,
 Count(Case When tbl_Attendance.Attendance=''P'' Then 1 End) as Present, 
 Count(Case When tbl_Attendance.Attendance=''A'' Then 1 End) as Absent,
 Count(Case When tbl_Attendance.Attendance=''L'' Then 1 End) as PaidLeave,
 Count(Case When tbl_Attendance.Attendance=''W'' Then 1 End) as WeekOff,
 Count(Case When tbl_Attendance.Attendance=''H'' Then 1 End) as HalfDay
 From tbl_Attendance Inner Join tbl_EmployeeInfo On tbl_Attendance.EmpNo
=tbl_EmployeeInfo.EmpNo
Where Month(tbl_Attendance.AttendanceDate)=@Month And Year(tbl_Attendance.AttendanceDate)=@Year
Group By  tbl_EmployeeInfo.EmpNo,tbl_EmployeeInfo.EmpName,tbl_EmployeeInfo.FathersName,tbl_EmployeeInfo.Designation,tbl_EmployeeInfo.AccountNo,tbl_EmployeeInfo.BankName
Order By tbl_EmployeeInfo.EmpNo 
End
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAttendanceBetWeenDate]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAttendanceBetWeenDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE  Procedure [dbo].[GetAttendanceBetWeenDate] @DateFrom datetime,@ToDate datetime
 As Begin
Select tbl_EmployeeInfo.EmpNo,tbl_EmployeeInfo.EmpName,tbl_EmployeeInfo.FathersName,tbl_EmployeeInfo.Designation,
 Count(Case When tbl_Attendance.Attendance=''P'' Then 1 End) as Present, 
 Count(Case When tbl_Attendance.Attendance=''A'' Then 1 End) as Absent,
 Count(Case When tbl_Attendance.Attendance=''L'' Then 1 End) as PaidLeave,
 Count(Case When tbl_Attendance.Attendance=''W'' Then 1 End) as WeekOff,
 Count(Case When tbl_Attendance.Attendance=''H'' Then 1 End) as HalfDay
 From tbl_Attendance Inner Join tbl_EmployeeInfo On tbl_Attendance.EmpNo
=tbl_EmployeeInfo.EmpNo
Where (tbl_Attendance.AttendanceDate) BetWeen @DateFrom And @ToDate
Group By  tbl_EmployeeInfo.EmpNo,tbl_EmployeeInfo.EmpName,tbl_EmployeeInfo.FathersName,tbl_EmployeeInfo.Designation
Order By tbl_EmployeeInfo.EmpNo 
End
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[GetAllUsers]

AS
BEGIN
		SELECT * FROM dbo.tbl_User
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EDELETEGrade]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDELETEGrade]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[EDELETEGrade]  
  @id int,  
  @IsDeleted bit  
AS  
BEGIN  
  
   UPDATE EGrade     
    set IsDeleted = @IsDeleted  
    WHERE  
     GradeId = @id  
 
  
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EDELETEExam]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDELETEExam]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[EDELETEExam]  
  @id int,  
  @IsDeleted bit  
AS  
BEGIN  
  
   UPDATE EExam     
    set IsDeleted = @IsDeleted  
    WHERE  
     id = @id  
 
  
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetAllStream]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllStream]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetAllStream]  
  @id int=0  
  
AS  
BEGIN  
  if @id = 0  
  BEGIN  
  SELECT * FROM [dbo].[tbl_sankay]
  END  
  
  ELSE  
  BEGIN  
   Select * from tbl_sankay where sankaycode in( SELECT sankaycode FROM tbl_class c WHERE classcode = @id)-- 
  END   
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetAllSection]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllSection]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetAllSection]  
  @id int=0  
  
AS  
BEGIN  
  if @id = 0  
  BEGIN  
  SELECT * FROM [dbo].[tbl_section]
  END  
  
  ELSE  
  BEGIN  
   Select * from tbl_section where sectioncode in( SELECT sectioncode FROM tbl_class c WHERE classcode = @id)-- 
  END   
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetAllRange]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllRange]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetAllRange]
		@id int=0
		

AS
BEGIN
		if @id = 0
		BEGIN
		SELECT * FROM [dbo].[EGradeRange]
		END

		ELSE
		BEGIN
		SELECT * FROM [dbo].[EGradeRange] WHERE Id = @id
		END	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetAllGrade]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllGrade]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetAllGrade]  
  @id int=0  
  
AS  
BEGIN  
  if @id = 0  
  BEGIN  
  SELECT * FROM [dbo].[EGrade] where IsDeleted = 0 
  END  
  
  ELSE  
  BEGIN  
  SELECT * FROM [dbo].[EGrade] WHERE IsDeleted = 0 and GradeId = @id  
  END   
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetAllExam]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllExam]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetAllExam]  
  @id int=0  
  
AS  
BEGIN  
  if @id = 0  
  BEGIN  
  SELECT * FROM [dbo].[EExam] where IsDeleted = 0 
  END  
  
  ELSE  
  BEGIN  
  SELECT * FROM [dbo].[EExam] WHERE IsDeleted = 0 and Id = @id  
  END   
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ECREATEGrade]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ECREATEGrade]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[ECREATEGrade]
		@id int,
		@GradeName varchar(50),
		@maxper decimal,
		@minper decimal,
		@gradepoint decimal,
		@CreatedBy int,
		@ModifiedBy int,
		@IsDeleted bit
AS
BEGIN
		IF (@id = 0)		
		BEGIN
		
		
				INSERT INTO dbo.EGrade(
					GradeName,
					MaxPer,
					MinPer,
					GradePoint,
					CreatedBy,
					CreatedDate,
					ModifiedBy,
					ModfiedDate,
					IsDeleted	
				)
				VALUES(
					@GradeName,
					@maxper,
					@minper,
					@gradepoint,
					@CreatedBy,					
					GETDATE(),
					@CreatedBy,
					GETDATE(),
					@IsDeleted
				)
		END
		
		ELSE
		BEGIN
			UPDATE EGrade
				SET GradeName = @GradeName,
					MaxPer = @maxper,
					MinPer = @minper,
					GradePoint = @gradepoint,
					ModifiedBy = @ModifiedBy,
					ModfiedDate = GETDATE(),
					IsDeleted = @IsDeleted
				WHERE
					GradeId = @id
		END

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ECREATEExam]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ECREATEExam]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[ECREATEExam]
		@id int,
		@Exam varchar(50),
		@CreatedBy int,
		@ModifiedBy int,
		@IsDeleted bit
AS
BEGIN
		IF (@id = 0)		
		BEGIN
		
		
				INSERT INTO dbo.EExam(
					Exam,
					ExamOrder,
					CreatedBy,
					CreatedDate,
					ModifiedBy,
					ModfiedDate,
					IsDeleted	
				)
				VALUES(
					@Exam,
					0,
					@CreatedBy,					
					GETDATE(),
					@CreatedBy,
					GETDATE(),
					@IsDeleted
				)
		END
		
		ELSE
		BEGIN
			UPDATE EExam
				SET Exam = @Exam,
					ModifiedBy = @ModifiedBy,
					ModfiedDate = GETDATE(),
					IsDeleted = @IsDeleted
				WHERE
					id = @id
		END

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetAllClass]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllClass]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetAllClass]  
  @id int=0  
  
AS  
BEGIN  
  if @id = 0  
  BEGIN  
  SELECT * FROM [dbo].[tbl_classmaster]
  END  
  
  ELSE  
  BEGIN  
  SELECT * FROM [dbo].[tbl_classmaster] WHERE classcode = @id  
  END   
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetStudentList]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetStudentList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetStudentList] 
			@ClassId INT,
			@StreamId int,
			@SectionId INT,
			@sessionId int
  
AS  
BEGIN  
Select s.studentno StudentNo ,s.scholarno ScholarNo,s.name Name From tbl_student s, tbl_classstudent cs where s.studentno = cs.studentno and
cs.classno = @ClassId and cs.Section =@SectionId and cs.sessioncode = @sessionId and cs.Stream = @StreamId
order by s.scholarno , s.name
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetCurrentSession]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetCurrentSession]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetCurrentSession]   
      
AS    
BEGIN    
 select sessioncode from tbl_session
 where  
 SessionStatus = 1
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetViewMSCCEMarksDetail]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewMSCCEMarksDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetViewMSCCEMarksDetail](@ClassNo int,@SectionCode int,@SessionCode int)
as begin
DECLARE @NONPRIMARY BIT
SET @NONPRIMARY = (SELECT NonPrimary FROM tbl_classmaster WHERE classcode =@ClassNo)

if @ClassNo<105
begin 

SELECT tbl_session.sessioncode,
       tbl_session.sessionname,
       tbl_student.studentno,
       tbl_student.scholarno,
       tbl_student.name,
       tbl_student.Height,
       tbl_student.Width,	
       tbl_subject.subjectno,
       tbl_subject.SubjectCode,
       tbl_subject.subjectname,
       tbl_MSCCEStudentMarks.CCEID,
       tbl_MSCCEStudentMarks.Jul,
       tbl_MSCCEStudentMarks.Aug,
        tbl_MSCCEStudentMarks.Sep,
       tbl_MSCCEStudentMarks.Oct,
       tbl_MSCCEStudentMarks.HYEx,
        tbl_MSCCEStudentMarks.Dec,
         tbl_MSCCEStudentMarks.Jan,
         tbl_MSCCEStudentMarks.Feb,
         tbl_MSCCEStudentMarks.ANEx,
          tbl_MSCCEStudentMarks.YeRes,
          case when tbl_MSCCEStudentMarks.Jul not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Jul,10) else '''' end AS Jul_G,
         case when tbl_MSCCEStudentMarks.Aug not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Aug,10) else '''' end AS Aug_G,
         case when tbl_MSCCEStudentMarks.Sep not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Sep,10) else '''' end AS Sep_G,
         case when tbl_MSCCEStudentMarks.Oct not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Oct,10) else '''' end AS Oct_G,
         case when tbl_MSCCEStudentMarks.HYEx not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.HYEx,50) else '''' end AS HYEx_G,
         case when tbl_MSCCEStudentMarks.Dec not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Dec,10) else '''' end AS Dec_G,
         case when tbl_MSCCEStudentMarks.Jan not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Jan,10) else '''' end AS Jan_G,
         case when tbl_MSCCEStudentMarks.Feb not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Feb,10) else '''' end AS Feb_G,
         case when tbl_MSCCEStudentMarks.ANEx not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.ANEx,100) else '''' end AS ANEx_G
         
FROM tbl_section
INNER JOIN tbl_sankay
INNER JOIN tbl_classstudent ON tbl_sankay.sankaycode = tbl_classstudent.Stream
INNER JOIN tbl_MSCCEStudentMarks
INNER JOIN tbl_session ON tbl_MSCCEStudentMarks.SessionCode = tbl_session.sessioncode
INNER JOIN tbl_student ON tbl_MSCCEStudentMarks.StudentNo = tbl_student.studentno
INNER JOIN tbl_subject ON tbl_MSCCEStudentMarks.SubjectNo = tbl_subject.subjectno
INNER JOIN tbl_classmaster ON tbl_MSCCEStudentMarks.ClassNo = tbl_classmaster.classcode ON tbl_classstudent.classno = tbl_classmaster.classcode
AND tbl_classstudent.studentno = tbl_student.studentno
AND tbl_classstudent.sessioncode = tbl_session.sessioncode ON tbl_section.sectioncode = tbl_classstudent.Section
INNER JOIN tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode
INNER JOIN tbl_district ON tbl_student.distcode = tbl_district.distcode

WHERE  (tbl_MSCCEStudentMarks.Status = 1) AND (tbl_MSCCEStudentMarks.SessionCode = @SessionCode ) AND 
                      (tbl_MSCCEStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 
end
else 
	begin
	
SELECT tbl_session.sessioncode,
       tbl_session.sessionname,
       tbl_student.studentno,
       tbl_student.scholarno,
       tbl_student.name,
       tbl_student.Height,
       tbl_student.Width,	
       tbl_subject.subjectno,
       tbl_subject.SubjectCode,
       tbl_subject.subjectname,
       tbl_MSCCEStudentMarks.CCEID,
       tbl_MSCCEStudentMarks.Jul,
       tbl_MSCCEStudentMarks.Aug,
        tbl_MSCCEStudentMarks.Sep,
       tbl_MSCCEStudentMarks.Oct,
       tbl_MSCCEStudentMarks.HYEx,
        tbl_MSCCEStudentMarks.Dec,
         tbl_MSCCEStudentMarks.Jan,
         tbl_MSCCEStudentMarks.Feb,
         tbl_MSCCEStudentMarks.ANEx,
         tbl_MSCCEStudentMarks.YeRes,
         case when tbl_MSCCEStudentMarks.Jul not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Jul,10) else '''' end AS Jul_G,
         case when tbl_MSCCEStudentMarks.Aug not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Aug,10) else '''' end AS Aug_G,
         case when tbl_MSCCEStudentMarks.Sep not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Sep,10) else '''' end AS Sep_G,
         case when tbl_MSCCEStudentMarks.Oct not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Oct,10) else '''' end AS Oct_G,
         case when tbl_MSCCEStudentMarks.HYEx not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.HYEx,50) else '''' end AS HYEx_G,
         case when tbl_MSCCEStudentMarks.Dec not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Dec,10) else '''' end AS Dec_G,
         case when tbl_MSCCEStudentMarks.Jan not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Jan,10) else '''' end AS Jan_G,
         case when tbl_MSCCEStudentMarks.Feb not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.Feb,10) else '''' end AS Feb_G,
         case when tbl_MSCCEStudentMarks.ANEx not like ''%[^0-9.]%'' then dbo.GETGRADEMP(tbl_MSCCEStudentMarks.ANEx,100) else '''' end AS ANEx_G
         
FROM tbl_section
INNER JOIN tbl_sankay
INNER JOIN tbl_classstudent ON tbl_sankay.sankaycode = tbl_classstudent.Stream
INNER JOIN tbl_MSCCEStudentMarks
INNER JOIN tbl_session ON tbl_MSCCEStudentMarks.SessionCode = tbl_session.sessioncode
INNER JOIN tbl_student ON tbl_MSCCEStudentMarks.StudentNo = tbl_student.studentno
INNER JOIN tbl_subject ON tbl_MSCCEStudentMarks.SubjectNo = tbl_subject.subjectno
INNER JOIN tbl_classmaster ON tbl_MSCCEStudentMarks.ClassNo = tbl_classmaster.classcode ON tbl_classstudent.classno = tbl_classmaster.classcode
AND tbl_classstudent.studentno = tbl_student.studentno
AND tbl_classstudent.sessioncode = tbl_session.sessioncode ON tbl_section.sectioncode = tbl_classstudent.Section
INNER JOIN tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode
INNER JOIN tbl_district ON tbl_student.distcode = tbl_district.distcode
WHERE  (tbl_MSCCEStudentMarks.Status = 1) AND (tbl_MSCCEStudentMarks.SessionCode = @SessionCode ) AND 
                      (tbl_MSCCEStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 

	end


                      
                      
                      
                      
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetViewMPCCEMarksDetail_SHHSSA]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewMPCCEMarksDetail_SHHSSA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetViewMPCCEMarksDetail_SHHSSA](@ClassNo int,@SectionCode int,@SessionCode int,@Flag nvarchar(1) ,@Sankay nvarchar(100))
as begin
DECLARE @NONPRIMARY BIT
SET @NONPRIMARY = (SELECT NonPrimary FROM tbl_classmaster WHERE classcode =@ClassNo)

if(@Flag=''E'')
begin
if(@ClassNo=111)
begin
SELECT  tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno, tbl_student.name, dbo.tbl_subject.subjecttype,tbl_subject.subjectno , tbl_subject.SubjectCode, + dbo.tbl_student.father as father, + dbo.tbl_student.mother as mother,CONVERT(nvarchar(10), dbo.tbl_student.dob,103) as dob , dbo.tbl_student.SSMId, dbo.tbl_classmaster.classname, 
                      dbo.tbl_student.studentimage, dbo.tbl_student.Wdob, tbl_subject.subjectname, tbl_MPSHHSSAStudentMarks.CCEID, tbl_MPSHHSSAStudentMarks.TERMI, 
                      tbl_MPSHHSSAStudentMarks.TERMII,tbl_MPSHHSSAStudentMarks.TERMIII,tbl_MPSHHSSAStudentMarks.TERMIP,tbl_MPSHHSSAStudentMarks.TERMIIP,tbl_MPSHHSSAStudentMarks.TERMIIIP  
FROM         dbo.tbl_section INNER JOIN
                      dbo.tbl_sankay INNER JOIN
                      dbo.tbl_classstudent ON dbo.tbl_sankay.sankaycode = dbo.tbl_classstudent.Stream INNER JOIN
                      dbo.tbl_MPSHHSSAStudentMarks INNER JOIN
                      dbo.tbl_session ON dbo.tbl_MPSHHSSAStudentMarks.SessionCode = dbo.tbl_session.sessioncode INNER JOIN
                      dbo.tbl_student ON dbo.tbl_MPSHHSSAStudentMarks.StudentNo = dbo.tbl_student.studentno INNER JOIN
                      dbo.tbl_subject ON dbo.tbl_MPSHHSSAStudentMarks.SubjectNo = dbo.tbl_subject.subjectno INNER JOIN
                      dbo.tbl_classmaster ON dbo.tbl_MPSHHSSAStudentMarks.ClassNo = dbo.tbl_classmaster.classcode ON 
                      dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode AND dbo.tbl_classstudent.studentno = dbo.tbl_student.studentno AND 
                      dbo.tbl_classstudent.sessioncode = dbo.tbl_session.sessioncode ON dbo.tbl_section.sectioncode = dbo.tbl_classstudent.Section INNER JOIN
                      dbo.tbl_tehsil ON dbo.tbl_student.tehcode = dbo.tbl_tehsil.tehcode INNER JOIN
                      dbo.tbl_district ON dbo.tbl_student.distcode = dbo.tbl_district.distcode 
WHERE  (tbl_MPSHHSSAStudentMarks.Status = 1) AND (tbl_MPSHHSSAStudentMarks.SessionCode = @SessionCode ) AND dbo.tbl_classstudent.Stream=((select top 1 sankaycode from tbl_sankay where sankayname=@Sankay)) and
                      (tbl_MPSHHSSAStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 
end
else
begin
SELECT  tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno, tbl_student.name, dbo.tbl_subject.subjecttype,tbl_subject.subjectno , tbl_subject.SubjectCode,+ dbo.tbl_student.father as father,+ dbo.tbl_student.mother as mother,CONVERT(nvarchar(10), dbo.tbl_student.dob,103) as dob , dbo.tbl_student.SSMId, dbo.tbl_classmaster.classname, 
                      dbo.tbl_student.studentimage, dbo.tbl_student.Wdob, tbl_subject.subjectname, tbl_MPSHHSSAStudentMarks.CCEID, tbl_MPSHHSSAStudentMarks.TERMI, 
                      tbl_MPSHHSSAStudentMarks.TERMII,tbl_MPSHHSSAStudentMarks.TERMIII,tbl_MPSHHSSAStudentMarks.TERMIP,tbl_MPSHHSSAStudentMarks.TERMIIP,tbl_MPSHHSSAStudentMarks.TERMIIIP  
FROM         dbo.tbl_section INNER JOIN
                      dbo.tbl_sankay INNER JOIN
                      dbo.tbl_classstudent ON dbo.tbl_sankay.sankaycode = dbo.tbl_classstudent.Stream INNER JOIN
                      dbo.tbl_MPSHHSSAStudentMarks INNER JOIN
                      dbo.tbl_session ON dbo.tbl_MPSHHSSAStudentMarks.SessionCode = dbo.tbl_session.sessioncode INNER JOIN
                      dbo.tbl_student ON dbo.tbl_MPSHHSSAStudentMarks.StudentNo = dbo.tbl_student.studentno INNER JOIN
                      dbo.tbl_subject ON dbo.tbl_MPSHHSSAStudentMarks.SubjectNo = dbo.tbl_subject.subjectno INNER JOIN
                      dbo.tbl_classmaster ON dbo.tbl_MPSHHSSAStudentMarks.ClassNo = dbo.tbl_classmaster.classcode ON 
                      dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode AND dbo.tbl_classstudent.studentno = dbo.tbl_student.studentno AND 
                      dbo.tbl_classstudent.sessioncode = dbo.tbl_session.sessioncode ON dbo.tbl_section.sectioncode = dbo.tbl_classstudent.Section INNER JOIN
                      dbo.tbl_tehsil ON dbo.tbl_student.tehcode = dbo.tbl_tehsil.tehcode INNER JOIN
                      dbo.tbl_district ON dbo.tbl_student.distcode = dbo.tbl_district.distcode 
WHERE  (tbl_MPSHHSSAStudentMarks.Status = 1) AND (tbl_MPSHHSSAStudentMarks.SessionCode = @SessionCode ) AND 
                      (tbl_MPSHHSSAStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 
                      end
end
if(@Flag=''M'')
begin
if(@ClassNo=111)
begin
SELECT  tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno, tbl_student.name, dbo.tbl_subject.subjecttype,tbl_subject.subjectno , tbl_subject.SubjectCode, dbo.tbl_StudentAttendance.RollNo, dbo.tbl_StudentAttendance.Per,+ dbo.tbl_student.father as father,+ dbo.tbl_student.mother as mother,CONVERT(nvarchar(10), dbo.tbl_student.dob,103) as dob , dbo.tbl_student.SSMId, dbo.tbl_classmaster.classname, 
                      dbo.tbl_student.studentimage, dbo.tbl_student.Wdob, tbl_subject.subjectname, tbl_MPSHHSSAStudentMarks.CCEID, tbl_MPSHHSSAStudentMarks.TERMI, 
                      tbl_MPSHHSSAStudentMarks.TERMII,tbl_MPSHHSSAStudentMarks.TERMIII,tbl_MPSHHSSAStudentMarks.TERMIP,tbl_MPSHHSSAStudentMarks.TERMIIP,tbl_MPSHHSSAStudentMarks.TERMIIIP  
FROM         dbo.tbl_section INNER JOIN
                      dbo.tbl_sankay INNER JOIN
                      dbo.tbl_classstudent ON dbo.tbl_sankay.sankaycode = dbo.tbl_classstudent.Stream INNER JOIN
                      dbo.tbl_MPSHHSSAStudentMarks INNER JOIN
                      dbo.tbl_session ON dbo.tbl_MPSHHSSAStudentMarks.SessionCode = dbo.tbl_session.sessioncode INNER JOIN
                      dbo.tbl_student ON dbo.tbl_MPSHHSSAStudentMarks.StudentNo = dbo.tbl_student.studentno INNER JOIN
                      dbo.tbl_subject ON dbo.tbl_MPSHHSSAStudentMarks.SubjectNo = dbo.tbl_subject.subjectno INNER JOIN
                      dbo.tbl_classmaster ON dbo.tbl_MPSHHSSAStudentMarks.ClassNo = dbo.tbl_classmaster.classcode ON 
                      dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode AND dbo.tbl_classstudent.studentno = dbo.tbl_student.studentno AND 
                      dbo.tbl_classstudent.sessioncode = dbo.tbl_session.sessioncode ON dbo.tbl_section.sectioncode = dbo.tbl_classstudent.Section INNER JOIN
                      dbo.tbl_tehsil ON dbo.tbl_student.tehcode = dbo.tbl_tehsil.tehcode INNER JOIN
                      dbo.tbl_district ON dbo.tbl_student.distcode = dbo.tbl_district.distcode INNER JOIN
                      dbo.tbl_StudentAttendance ON dbo.tbl_MPSHHSSAStudentMarks.SessionCode = dbo.tbl_StudentAttendance.SessionCode AND 
                      dbo.tbl_MPSHHSSAStudentMarks.StudentNo = dbo.tbl_StudentAttendance.StudentNo AND dbo.tbl_MPSHHSSAStudentMarks.ClassNo = dbo.tbl_StudentAttendance.ClassNo
WHERE  (tbl_MPSHHSSAStudentMarks.Status = 1) AND (tbl_MPSHHSSAStudentMarks.SessionCode = @SessionCode ) AND dbo.tbl_classstudent.Stream=((select top 1 sankaycode from tbl_sankay where sankayname=@Sankay)) and
                      (tbl_MPSHHSSAStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 
end
else
begin
SELECT  tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno, tbl_student.name, dbo.tbl_subject.subjecttype,tbl_subject.subjectno , tbl_subject.SubjectCode, dbo.tbl_StudentAttendance.RollNo,dbo.tbl_StudentAttendance.Per, + dbo.tbl_student.father as father,+ dbo.tbl_student.mother as mother,CONVERT(nvarchar(10), dbo.tbl_student.dob,103) as dob , dbo.tbl_student.SSMId, dbo.tbl_classmaster.classname, 
                      dbo.tbl_student.studentimage, dbo.tbl_student.Wdob, tbl_subject.subjectname, tbl_MPSHHSSAStudentMarks.CCEID, tbl_MPSHHSSAStudentMarks.TERMI, 
                      tbl_MPSHHSSAStudentMarks.TERMII,tbl_MPSHHSSAStudentMarks.TERMIII,tbl_MPSHHSSAStudentMarks.TERMIP,tbl_MPSHHSSAStudentMarks.TERMIIP,tbl_MPSHHSSAStudentMarks.TERMIIIP  
FROM         dbo.tbl_section INNER JOIN
                      dbo.tbl_sankay INNER JOIN
                      dbo.tbl_classstudent ON dbo.tbl_sankay.sankaycode = dbo.tbl_classstudent.Stream INNER JOIN
                      dbo.tbl_MPSHHSSAStudentMarks INNER JOIN
                      dbo.tbl_session ON dbo.tbl_MPSHHSSAStudentMarks.SessionCode = dbo.tbl_session.sessioncode INNER JOIN
                      dbo.tbl_student ON dbo.tbl_MPSHHSSAStudentMarks.StudentNo = dbo.tbl_student.studentno INNER JOIN
                      dbo.tbl_subject ON dbo.tbl_MPSHHSSAStudentMarks.SubjectNo = dbo.tbl_subject.subjectno INNER JOIN
                      dbo.tbl_classmaster ON dbo.tbl_MPSHHSSAStudentMarks.ClassNo = dbo.tbl_classmaster.classcode ON 
                      dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode AND dbo.tbl_classstudent.studentno = dbo.tbl_student.studentno AND 
                      dbo.tbl_classstudent.sessioncode = dbo.tbl_session.sessioncode ON dbo.tbl_section.sectioncode = dbo.tbl_classstudent.Section INNER JOIN
                      dbo.tbl_tehsil ON dbo.tbl_student.tehcode = dbo.tbl_tehsil.tehcode INNER JOIN
                      dbo.tbl_district ON dbo.tbl_student.distcode = dbo.tbl_district.distcode INNER JOIN
                      dbo.tbl_StudentAttendance ON dbo.tbl_MPSHHSSAStudentMarks.SessionCode = dbo.tbl_StudentAttendance.SessionCode AND 
                      dbo.tbl_MPSHHSSAStudentMarks.StudentNo = dbo.tbl_StudentAttendance.StudentNo AND dbo.tbl_MPSHHSSAStudentMarks.ClassNo = dbo.tbl_StudentAttendance.ClassNo
WHERE  (tbl_MPSHHSSAStudentMarks.Status = 1) AND (tbl_MPSHHSSAStudentMarks.SessionCode = @SessionCode ) AND 
                      (tbl_MPSHHSSAStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 
                      end
end
                      
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetViewMPCCEMarksDetail_Format1]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewMPCCEMarksDetail_Format1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetViewMPCCEMarksDetail_Format1](@ClassNo int,@SectionCode int,@SessionCode int)
as begin
DECLARE @NONPRIMARY BIT
SET @NONPRIMARY = (SELECT NonPrimary FROM tbl_classmaster WHERE classcode =@ClassNo)



SELECT  tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno, tbl_student.name, dbo.tbl_subject.subjecttype,tbl_subject.subjectno , tbl_subject.SubjectCode, dbo.tbl_StudentAttendance.RollNo,''Mr. ''+ dbo.tbl_student.father as father,''Mrs. ''+ dbo.tbl_student.mother as mother,CONVERT(nvarchar(10), dbo.tbl_student.dob,103) as dob , dbo.tbl_student.SSMId, dbo.tbl_classmaster.classname, 
                      dbo.tbl_student.studentimage, dbo.tbl_student.Wdob, tbl_subject.subjectname, tbl_MPCCEStudentMarks.CCEID, tbl_MPCCEStudentMarks.TERMI, 
                      tbl_MPCCEStudentMarks.TERMII,tbl_MPCCEStudentMarks.TERMIII  
FROM         dbo.tbl_section INNER JOIN
                      dbo.tbl_sankay INNER JOIN
                      dbo.tbl_classstudent ON dbo.tbl_sankay.sankaycode = dbo.tbl_classstudent.Stream INNER JOIN
                      dbo.tbl_MPCCEStudentMarks INNER JOIN
                      dbo.tbl_session ON dbo.tbl_MPCCEStudentMarks.SessionCode = dbo.tbl_session.sessioncode INNER JOIN
                      dbo.tbl_student ON dbo.tbl_MPCCEStudentMarks.StudentNo = dbo.tbl_student.studentno INNER JOIN
                      dbo.tbl_subject ON dbo.tbl_MPCCEStudentMarks.SubjectNo = dbo.tbl_subject.subjectno INNER JOIN
                      dbo.tbl_classmaster ON dbo.tbl_MPCCEStudentMarks.ClassNo = dbo.tbl_classmaster.classcode ON 
                      dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode AND dbo.tbl_classstudent.studentno = dbo.tbl_student.studentno AND 
                      dbo.tbl_classstudent.sessioncode = dbo.tbl_session.sessioncode ON dbo.tbl_section.sectioncode = dbo.tbl_classstudent.Section INNER JOIN
                      dbo.tbl_tehsil ON dbo.tbl_student.tehcode = dbo.tbl_tehsil.tehcode INNER JOIN
                      dbo.tbl_district ON dbo.tbl_student.distcode = dbo.tbl_district.distcode INNER JOIN
                      dbo.tbl_StudentAttendance ON dbo.tbl_MPCCEStudentMarks.SessionCode = dbo.tbl_StudentAttendance.SessionCode AND 
                      dbo.tbl_MPCCEStudentMarks.StudentNo = dbo.tbl_StudentAttendance.StudentNo AND dbo.tbl_MPCCEStudentMarks.ClassNo = dbo.tbl_StudentAttendance.ClassNo
WHERE  (tbl_MPCCEStudentMarks.Status = 1) AND (tbl_MPCCEStudentMarks.SessionCode = @SessionCode ) AND 
                      (tbl_MPCCEStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 

                      
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetViewMPCCEMarksDetail]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewMPCCEMarksDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetViewMPCCEMarksDetail](@ClassNo int,@SectionCode int,@SessionCode int)
as begin
DECLARE @NONPRIMARY BIT
SET @NONPRIMARY = (SELECT NonPrimary FROM tbl_classmaster WHERE classcode =@ClassNo)


SELECT  tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno, tbl_student.name,tbl_subject.subjectno , tbl_subject.SubjectCode, tbl_subject.subjectname, tbl_MPCCEStudentMarks.CCEID, tbl_MPCCEStudentMarks.TERMI, 
                      tbl_MPCCEStudentMarks.TERMII,tbl_MPCCEStudentMarks.TERMIII  
FROM         tbl_section INNER JOIN
                      tbl_sankay INNER JOIN
                      tbl_classstudent ON tbl_sankay.sankaycode = tbl_classstudent.Stream INNER JOIN
                      tbl_MPCCEStudentMarks INNER JOIN
                      tbl_session ON tbl_MPCCEStudentMarks.SessionCode = tbl_session.sessioncode INNER JOIN
                      tbl_student ON tbl_MPCCEStudentMarks.StudentNo = tbl_student.studentno INNER JOIN
                      tbl_subject ON tbl_MPCCEStudentMarks.SubjectNo = tbl_subject.subjectno INNER JOIN
                      tbl_classmaster ON tbl_MPCCEStudentMarks.ClassNo = tbl_classmaster.classcode ON tbl_classstudent.classno = tbl_classmaster.classcode AND 
                      tbl_classstudent.studentno = tbl_student.studentno AND tbl_classstudent.sessioncode = tbl_session.sessioncode ON 
                      tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN
                      tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN
                      tbl_district ON tbl_student.distcode = tbl_district.distcode
WHERE  (tbl_MPCCEStudentMarks.Status = 1) AND (tbl_MPCCEStudentMarks.SessionCode = @SessionCode ) AND 
                      (tbl_MPCCEStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 

     
                      
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetViewMCCEMarksDetail]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewMCCEMarksDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--SELECT *FROM tbl_subject
CREATE PROCEDURE [dbo].[GetViewMCCEMarksDetail](@ClassNo int,@SectionCode int,@SessionCode int)
as begin
DECLARE @NONPRIMARY BIT
SET @NONPRIMARY = (SELECT NonPrimary FROM tbl_classmaster WHERE classcode =@ClassNo)

if @ClassNo<113
begin 

SELECT  tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno, tbl_student.name,tbl_student.Height,tbl_student.Width,tbl_subject.subjectno , tbl_subject.SubjectCode, tbl_subject.subjectname, tbl_MCCEStudentMarks.CCEID, tbl_MCCEStudentMarks.FA1, 
                      tbl_MCCEStudentMarks.FA2, CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA1 / 25.00 * 10, 2)) AS [FA1-10%],
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA1 / 25.00 * 10, 2))*10, @NONPRIMARY) as [FA1 G] ,CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_MCCEStudentMarks.FA2 / 25.00 * 10, 2)) AS [FA2-10%],
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA2 / 25.00 * 10, 2))*10, @NONPRIMARY) as [FA2 G], CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA1 / 25.00 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA2 / 25.00 * 10, 2)) AS [FA1FA2-20%],                       
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), (tbl_MCCEStudentMarks.FA1 + tbl_MCCEStudentMarks.FA2)*2), @NONPRIMARY) as [FA1FA2 G],
                      tbl_MCCEStudentMarks.SA1,dbo.GETGRADE (tbl_MCCEStudentMarks.SA1, @NONPRIMARY) AS [SA1 G]
                      , CONVERT(NUMERIC(18, 2), ROUND((tbl_MCCEStudentMarks.SA1 / 100.00) * 30, 2)) AS [SA1-30%]
                      , CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.SA1 / 100.00 * 30, 2)) 
                      + (CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA1 / 25.00 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA2 / 25.00 * 10, 2))) AS [FA1FA2SA1]
                      ,dbo.GETGRADE ((ROUND(tbl_MCCEStudentMarks.FA1 / 25.00 * 10, 2)+(ROUND(tbl_MCCEStudentMarks.FA2 / 25.00 * 10, 2)+
                      ROUND(tbl_MCCEStudentMarks.SA1 / 100.00 * 30, 2))) *2, @NONPRIMARY) AS [TOT-1-G]
                      , tbl_MCCEStudentMarks.FA3, tbl_MCCEStudentMarks.FA4, CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_MCCEStudentMarks.FA3 / 25.00 * 10, 2)) AS [FA3-10%], dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA3 / 25.00 * 10, 2))*10, @NONPRIMARY) as [FA3 G] ,CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA4 / 25.00 * 10, 2)) AS [FA4-10%],
                       dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA4 / 25.00 * 10, 2))*10, @NONPRIMARY) as [FA4 G] ,
                       CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA3 / 25.00 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA4 / 25.00 * 10, 2)) AS [FA3FA4-20%]
                      ,
                       dbo.GETGRADE(CONVERT(NUMERIC(18, 2), (tbl_MCCEStudentMarks.FA3 + tbl_MCCEStudentMarks.FA4)*2), @NONPRIMARY) as [FA3FA4 G],
                      tbl_MCCEStudentMarks.SA2, CONVERT(NUMERIC(18, 2),
                       ROUND(tbl_MCCEStudentMarks.SA2 / 100.00 * 30, 2)) AS [SA2-30%] ,CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_MCCEStudentMarks.SA2 / 100.00 * 30, 2)) + (CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA3 / 25.00 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA4 / 25.00 * 10, 2))) AS [FA3FA4SA2],dbo.GETGRADE (tbl_MCCEStudentMarks.SA2, @NONPRIMARY) AS [SA2 G],
                       dbo.GETGRADE ((ROUND(tbl_MCCEStudentMarks.FA3 / 25.00 * 10, 2)+(ROUND(tbl_MCCEStudentMarks.FA4 / 25.00 * 10, 2)+
                      ROUND(tbl_MCCEStudentMarks.SA2 / 100.00 * 30, 2)))*2, @NONPRIMARY) AS [TOT-2-G],
                       ROUND((ISNULL(tbl_MCCEStudentMarks.FA1,0)+ISNULL(tbl_MCCEStudentMarks.FA2,0)+ISNULL(tbl_MCCEStudentMarks.FA3,0)+ISNULL(tbl_MCCEStudentMarks.FA4,0)),2) AS [TOT-FA1FA2FA3FA4],
                      
                      dbo.GETGRADE(ROUND((ISNULL(tbl_MCCEStudentMarks.FA1,0)+ISNULL(tbl_MCCEStudentMarks.FA2,0)+ISNULL(tbl_MCCEStudentMarks.FA3,0)+ISNULL(tbl_MCCEStudentMarks.FA4,0)),2),@NONPRIMARY)
                       
                       AS [FA1FA2FA3FA4 G], 
                   convert ( numeric(18,2), ISNULL(tbl_MCCEStudentMarks.SA1,0)+ISNULL(tbl_MCCEStudentMarks.SA2,0))                    
                        AS [TOT-SA1SA2],
                      dbo.GETGRADE(ROUND((ISNULL(tbl_MCCEStudentMarks.SA1,0)+ISNULL(tbl_MCCEStudentMarks.SA2,0)),2)/(Case When @NONPRIMARY=1 Then 2 Else 1 End) ,@NONPRIMARY)
                       AS [SA1SA2 G],
                       ROUND(
                       ISNULL(tbl_MCCEStudentMarks.FA1,0)+ISNULL(tbl_MCCEStudentMarks.FA2,0)+
                       ISNULL(tbl_MCCEStudentMarks.FA3,0)+ISNULL(tbl_MCCEStudentMarks.FA4,0)+
                       ISNULL(tbl_MCCEStudentMarks.SA1,0)+ISNULL(tbl_MCCEStudentMarks.SA2,0),2)                        
                       AS [TOT-Marks]
                        ,dbo.GETGRADE(ROUND((
                       ISNULL(tbl_MCCEStudentMarks.FA1,0)+ISNULL(tbl_MCCEStudentMarks.FA2,0)+
                       ISNULL(tbl_MCCEStudentMarks.FA3,0)+ISNULL(tbl_MCCEStudentMarks.FA4,0)+
                       ISNULL(tbl_MCCEStudentMarks.SA1,0)+ISNULL(tbl_MCCEStudentMarks.SA2,0))/(Case When @NONPRIMARY=1 Then 3 Else 2 End),2),@NONPRIMARY)
                         AS [Finale Grade]
                         ,
                         dbo.GETGRADEPOINT((
                       ISNULL(tbl_MCCEStudentMarks.FA1,0)+ISNULL(tbl_MCCEStudentMarks.FA2,0)+
                       ISNULL(tbl_MCCEStudentMarks.FA3,0)+ISNULL(tbl_MCCEStudentMarks.FA4,0)+
                       ISNULL(tbl_MCCEStudentMarks.SA1,0)+ISNULL(tbl_MCCEStudentMarks.SA2,0))/(Case When @NONPRIMARY=1 Then 3 Else 2 End))
                         AS [Grade Point]
FROM         tbl_section INNER JOIN
                      tbl_sankay INNER JOIN
                      tbl_classstudent ON tbl_sankay.sankaycode = tbl_classstudent.Stream INNER JOIN
                      tbl_MCCEStudentMarks INNER JOIN
                      tbl_session ON tbl_MCCEStudentMarks.SessionCode = tbl_session.sessioncode INNER JOIN
                      tbl_student ON tbl_MCCEStudentMarks.StudentNo = tbl_student.studentno INNER JOIN
                      tbl_subject ON tbl_MCCEStudentMarks.SubjectNo = tbl_subject.subjectno INNER JOIN
                      tbl_classmaster ON tbl_MCCEStudentMarks.ClassNo = tbl_classmaster.classcode ON tbl_classstudent.classno = tbl_classmaster.classcode AND 
                      tbl_classstudent.studentno = tbl_student.studentno AND tbl_classstudent.sessioncode = tbl_session.sessioncode ON 
                      tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN
                      tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN
                      tbl_district ON tbl_student.distcode = tbl_district.distcode
WHERE  (tbl_MCCEStudentMarks.Status = 1) AND (tbl_MCCEStudentMarks.SessionCode = @SessionCode ) AND 
                      (tbl_MCCEStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 
end
else 
	begin
	
SELECT  tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno, tbl_student.name,tbl_student.Height,tbl_student.Width,tbl_subject.subjectno , tbl_subject.SubjectCode, tbl_subject.subjectname, tbl_MCCEStudentMarks.CCEID, tbl_MCCEStudentMarks.FA1, 
                      tbl_MCCEStudentMarks.FA2, CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA1 / 25.00 * 10, 2)) AS [FA1-10%],
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA1 / 25.00 * 10, 2))*10, @NONPRIMARY) as [FA1 G] ,CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_MCCEStudentMarks.FA2 / 25.00 * 10, 2)) AS [FA2-10%],
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA2 / 25.00 * 10, 2))*10, @NONPRIMARY) as [FA2 G], CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA1 / 25.00 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA2 / 25.00 * 10, 2)) AS [FA1FA2-20%],                       
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), (tbl_MCCEStudentMarks.FA1 + tbl_MCCEStudentMarks.FA2)*2), @NONPRIMARY) as [FA1FA2 G],
                      tbl_MCCEStudentMarks.SA1,
                      dbo.GETGRADE (tbl_MCCEStudentMarks.SA1*2, @NONPRIMARY) AS [SA1 G],
                       CONVERT(NUMERIC(18, 
                      2), ROUND(tbl_MCCEStudentMarks.SA1 / 100.00 * 30, 2)) AS [SA1-30%], CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.SA1 / 100.00 * 30, 2)) 
                      + (CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA1 / 25.00 * 10, 2)) + CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA2 / 25.00 * 10, 
                      2))) AS [FA1FA2SA1],dbo.GETGRADE ((ROUND(tbl_MCCEStudentMarks.FA1 / 25.00 * 10, 2)+(ROUND(tbl_MCCEStudentMarks.FA2 / 25.00 * 10, 2)+
                      ROUND(tbl_MCCEStudentMarks.SA1 / 100.00 * 30, 2)))
                      *2, @NONPRIMARY) AS [TOT-1-G], tbl_MCCEStudentMarks.FA3, tbl_MCCEStudentMarks.FA4, CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_MCCEStudentMarks.FA3 / 25.00 * 10, 2)) AS [FA3-10%], dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA3 / 25.00 * 10, 2))*10, @NONPRIMARY) as [FA3 G] ,CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA4 / 25.00 * 10, 2)) AS [FA4-10%],
                       dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA4 / 25.00 * 10, 2))*10, @NONPRIMARY) as [FA4 G] ,
                       CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA3 / 25.00 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA4 / 25.00 * 10, 2)) AS [FA3FA4-20%],
                       dbo.GETGRADE(CONVERT(NUMERIC(18, 2), (tbl_MCCEStudentMarks.FA3 + tbl_MCCEStudentMarks.FA4)*2), @NONPRIMARY) as [FA3FA4 G],
                      tbl_MCCEStudentMarks.SA2, CONVERT(NUMERIC(18, 2),
                       ROUND(tbl_MCCEStudentMarks.SA2 / 100.00 * 30, 2)) AS [SA2-30%] ,CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_MCCEStudentMarks.SA2 / 100.00 * 30, 2)) + (CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA3 / 25.00 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_MCCEStudentMarks.FA4 / 25.00 * 10, 2))) AS [FA3FA4SA2],
                      
                      dbo.GETGRADE (tbl_MCCEStudentMarks.SA2*2, @NONPRIMARY) AS [SA2 G],
                      
                       dbo.GETGRADE ((ROUND(tbl_MCCEStudentMarks.FA3 / 25.00 * 10, 2)+(ROUND(tbl_MCCEStudentMarks.FA4 / 25.00 * 10, 2)+
                      ROUND(tbl_MCCEStudentMarks.SA2 / 100.00 * 30, 2)))
                      *2, @NONPRIMARY) AS [TOT-2-G],
                       ROUND((ISNULL(tbl_MCCEStudentMarks.FA1,0)+ISNULL(tbl_MCCEStudentMarks.FA2,0)+ISNULL(tbl_MCCEStudentMarks.FA3,0)+ISNULL(tbl_MCCEStudentMarks.FA4,0)),2) AS [TOT-FA1FA2FA3FA4],
                      
                      dbo.GETGRADE(ROUND((ISNULL(tbl_MCCEStudentMarks.FA1,0)+ISNULL(tbl_MCCEStudentMarks.FA2,0)+ISNULL(tbl_MCCEStudentMarks.FA3,0)+ISNULL(tbl_MCCEStudentMarks.FA4,0)),2),@NONPRIMARY)
                       
                        AS [FA1FA2FA3FA4 G], 
                   convert ( numeric(18,2), ISNULL(tbl_MCCEStudentMarks.SA1,0)+ISNULL(tbl_MCCEStudentMarks.SA2,0))                    
                        AS [TOT-SA1SA2],
                      dbo.GETGRADE(ROUND((ISNULL(tbl_MCCEStudentMarks.SA1,0)+ISNULL(tbl_MCCEStudentMarks.SA2,0)),2)/(Case When @NONPRIMARY=1 Then 2 Else 1 End) ,@NONPRIMARY)
                       AS [SA1SA2 G],
                       ROUND(
                       ISNULL(tbl_MCCEStudentMarks.FA1,0)+ISNULL(tbl_MCCEStudentMarks.FA2,0)+
                       ISNULL(tbl_MCCEStudentMarks.FA3,0)+ISNULL(tbl_MCCEStudentMarks.FA4,0)+
                       ISNULL(tbl_MCCEStudentMarks.SA1,0)+ISNULL(tbl_MCCEStudentMarks.SA2,0),2)                        
                        AS [TOT-Marks]
                        ,dbo.GETGRADE(ROUND((
                       ISNULL(tbl_MCCEStudentMarks.FA1,0)+ISNULL(tbl_MCCEStudentMarks.FA2,0)+
                       ISNULL(tbl_MCCEStudentMarks.FA3,0)+ISNULL(tbl_MCCEStudentMarks.FA4,0)+
                       ISNULL(tbl_MCCEStudentMarks.SA1,0)+ISNULL(tbl_MCCEStudentMarks.SA2,0))/(Case When @NONPRIMARY=1 Then 3 Else 2 End),2),@NONPRIMARY)
                         AS [Finale Grade],
                         dbo.GETGRADEPOINT((
                       ISNULL(tbl_MCCEStudentMarks.FA1,0)+ISNULL(tbl_MCCEStudentMarks.FA2,0)+
                       ISNULL(tbl_MCCEStudentMarks.FA3,0)+ISNULL(tbl_MCCEStudentMarks.FA4,0)+
                       ISNULL(tbl_MCCEStudentMarks.SA1,0)+ISNULL(tbl_MCCEStudentMarks.SA2,0))/(Case When @NONPRIMARY=1 Then 3 Else 2 End))
                         AS [Grade Point]
FROM         tbl_section INNER JOIN
                      tbl_sankay INNER JOIN
                      tbl_classstudent ON tbl_sankay.sankaycode = tbl_classstudent.Stream INNER JOIN
                      tbl_MCCEStudentMarks INNER JOIN
                      tbl_session ON tbl_MCCEStudentMarks.SessionCode = tbl_session.sessioncode INNER JOIN
                      tbl_student ON tbl_MCCEStudentMarks.StudentNo = tbl_student.studentno INNER JOIN
                      tbl_subject ON tbl_MCCEStudentMarks.SubjectNo = tbl_subject.subjectno INNER JOIN
                      tbl_classmaster ON tbl_MCCEStudentMarks.ClassNo = tbl_classmaster.classcode ON tbl_classstudent.classno = tbl_classmaster.classcode AND 
                      tbl_classstudent.studentno = tbl_student.studentno AND tbl_classstudent.sessioncode = tbl_session.sessioncode ON 
                      tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN
                      tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN
                      tbl_district ON tbl_student.distcode = tbl_district.distcode
WHERE  (tbl_MCCEStudentMarks.Status = 1) AND (tbl_MCCEStudentMarks.SessionCode = @SessionCode ) AND 
                      (tbl_MCCEStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 

	end
               
                      
                      
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetViewCCEMarksDetail]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetViewCCEMarksDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetViewCCEMarksDetail](@ClassNo int,@SectionCode int,@SessionCode int)
as begin
DECLARE @NONPRIMARY BIT
SET @NONPRIMARY = (SELECT NonPrimary FROM tbl_classmaster WHERE classcode =@ClassNo)

if @ClassNo<113
begin 

SELECT  tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno, tbl_student.name,tbl_student.Height,tbl_student.Width,tbl_subject.subjectno , tbl_subject.SubjectCode, tbl_subject.subjectname, tbl_CCEStudentMarks.CCEID, tbl_CCEStudentMarks.FA1, 
                      tbl_CCEStudentMarks.FA2, CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA1 / 25 * 10, 2)) AS [FA1-10%],
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA1 / 25 * 10, 2))*10, @NONPRIMARY) as [FA1 G] ,CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_CCEStudentMarks.FA2 / 25 * 10, 2)) AS [FA2-10%],
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA2 / 25 * 10, 2))*10, @NONPRIMARY) as [FA2 G], CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA1 / 25 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA2 / 25 * 10, 2)) AS [FA1FA2-20%],                       
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), (tbl_CCEStudentMarks.FA1 + tbl_CCEStudentMarks.FA2)*2), @NONPRIMARY) as [FA1FA2 G],
                      tbl_CCEStudentMarks.SA1,dbo.GETGRADE (tbl_CCEStudentMarks.SA1, @NONPRIMARY) AS [SA1 G], CONVERT(NUMERIC(18, 
                      2), ROUND(tbl_CCEStudentMarks.SA1 * 0.01 * 30, 2)) AS [SA1-30%], CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.SA1 * 0.01 * 30, 2)) 
                      + (CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA1 / 25 * 10, 2)) + CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA2 / 25 * 10, 
                      2))) AS [FA1FA2SA1],dbo.GETGRADE ((ROUND(tbl_CCEStudentMarks.FA1 / 25 * 10, 2)+(ROUND(tbl_CCEStudentMarks.FA2 / 25 * 10, 2)+
                      ROUND(tbl_CCEStudentMarks.SA1 * 0.01 * 30, 2)))
                      *2, @NONPRIMARY) AS [TOT-1-G], tbl_CCEStudentMarks.FA3, tbl_CCEStudentMarks.FA4, CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_CCEStudentMarks.FA3 / 25 * 10, 2)) AS [FA3-10%], dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA3 / 25 * 10, 2))*10, @NONPRIMARY) as [FA3 G] ,CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA4 / 25 * 10, 2)) AS [FA4-10%],
                       dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA4 / 25 * 10, 2))*10, @NONPRIMARY) as [FA4 G] ,
                       CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA3 / 25 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA4 / 25 * 10, 2)) AS [FA3FA4-20%],
                       dbo.GETGRADE(CONVERT(NUMERIC(18, 2), (tbl_CCEStudentMarks.FA3 + tbl_CCEStudentMarks.FA4)*2), @NONPRIMARY) as [FA3FA4 G],
                      tbl_CCEStudentMarks.SA2, CONVERT(NUMERIC(18, 2),
                       ROUND(tbl_CCEStudentMarks.SA2 * 0.01 * 30, 2)) AS [SA2-30%] ,CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_CCEStudentMarks.SA2 * 0.01 * 30, 2)) + (CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA3 / 25 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA4 / 25 * 10, 2))) AS [FA3FA4SA2],dbo.GETGRADE (tbl_CCEStudentMarks.SA2, @NONPRIMARY) AS [SA2 G],
                       dbo.GETGRADE ((ROUND(tbl_CCEStudentMarks.FA3 / 25 * 10, 2)+(ROUND(tbl_CCEStudentMarks.FA4 / 25 * 10, 2)+
                      ROUND(tbl_CCEStudentMarks.SA2 * 0.01 * 30, 2)))
                      *2, @NONPRIMARY) AS [TOT-2-G],
                       ROUND((ISNULL(tbl_CCEStudentMarks.FA1,0)+ISNULL(tbl_CCEStudentMarks.FA2,0)+ISNULL(tbl_CCEStudentMarks.FA3,0)+ISNULL(tbl_CCEStudentMarks.FA4,0)),2) AS [TOT-FA1FA2FA3FA4],
                      
                      dbo.GETGRADE(ROUND((ISNULL(tbl_CCEStudentMarks.FA1,0)+ISNULL(tbl_CCEStudentMarks.FA2,0)+ISNULL(tbl_CCEStudentMarks.FA3,0)+ISNULL(tbl_CCEStudentMarks.FA4,0)),2),@NONPRIMARY)
                       
                        AS [FA1FA2FA3FA4 G], 
                   convert ( numeric(18,2), ISNULL(tbl_CCEStudentMarks.SA1,0)+ISNULL(tbl_CCEStudentMarks.SA2,0))                    
                        AS [TOT-SA1SA2],
                      dbo.GETGRADE(ROUND((ISNULL(tbl_CCEStudentMarks.SA1,0)+ISNULL(tbl_CCEStudentMarks.SA2,0)),2)/(Case When @NONPRIMARY=1 Then 2 Else 1 End) ,@NONPRIMARY)
                       AS [SA1SA2 G],
                       ROUND(
                       ISNULL(tbl_CCEStudentMarks.FA1,0)+ISNULL(tbl_CCEStudentMarks.FA2,0)+
                       ISNULL(tbl_CCEStudentMarks.FA3,0)+ISNULL(tbl_CCEStudentMarks.FA4,0)+
                       ISNULL(tbl_CCEStudentMarks.SA1,0)+ISNULL(tbl_CCEStudentMarks.SA2,0),2)                        
                        AS [TOT-Marks]
                        ,dbo.GETGRADE(ROUND((
                       ISNULL(tbl_CCEStudentMarks.FA1,0)+ISNULL(tbl_CCEStudentMarks.FA2,0)+
                       ISNULL(tbl_CCEStudentMarks.FA3,0)+ISNULL(tbl_CCEStudentMarks.FA4,0)+
                       ISNULL(tbl_CCEStudentMarks.SA1,0)+ISNULL(tbl_CCEStudentMarks.SA2,0))/(Case When @NONPRIMARY=1 Then 3 Else 2 End),2),@NONPRIMARY)
                         AS [Finale Grade],
                         dbo.GETGRADEPOINT((
                       ISNULL(tbl_CCEStudentMarks.FA1,0)+ISNULL(tbl_CCEStudentMarks.FA2,0)+
                       ISNULL(tbl_CCEStudentMarks.FA3,0)+ISNULL(tbl_CCEStudentMarks.FA4,0)+
                       ISNULL(tbl_CCEStudentMarks.SA1,0)+ISNULL(tbl_CCEStudentMarks.SA2,0))/(Case When @NONPRIMARY=1 Then 3 Else 2 End))
                         AS [Grade Point]
FROM         tbl_section INNER JOIN
                      tbl_sankay INNER JOIN
                      tbl_classstudent ON tbl_sankay.sankaycode = tbl_classstudent.Stream INNER JOIN
                      tbl_CCEStudentMarks INNER JOIN
                      tbl_session ON tbl_CCEStudentMarks.SessionCode = tbl_session.sessioncode INNER JOIN
                      tbl_student ON tbl_CCEStudentMarks.StudentNo = tbl_student.studentno INNER JOIN
                      tbl_subject ON tbl_CCEStudentMarks.SubjectNo = tbl_subject.subjectno INNER JOIN
                      tbl_classmaster ON tbl_CCEStudentMarks.ClassNo = tbl_classmaster.classcode ON tbl_classstudent.classno = tbl_classmaster.classcode AND 
                      tbl_classstudent.studentno = tbl_student.studentno AND tbl_classstudent.sessioncode = tbl_session.sessioncode ON 
                      tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN
                      tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN
                      tbl_district ON tbl_student.distcode = tbl_district.distcode
WHERE  (tbl_CCEStudentMarks.Status = 1) AND (tbl_CCEStudentMarks.SessionCode = @SessionCode ) AND 
                      (tbl_CCEStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 
end
else 
	begin
	
SELECT  tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno, tbl_student.name,tbl_student.Height,tbl_student.Width,tbl_subject.subjectno , tbl_subject.SubjectCode, tbl_subject.subjectname, tbl_CCEStudentMarks.CCEID, tbl_CCEStudentMarks.FA1, 
                      tbl_CCEStudentMarks.FA2, CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA1 / 25 * 10, 2)) AS [FA1-10%],
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA1 / 25 * 10, 2))*10, @NONPRIMARY) as [FA1 G] ,CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_CCEStudentMarks.FA2 / 25 * 10, 2)) AS [FA2-10%],
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA2 / 25 * 10, 2))*10, @NONPRIMARY) as [FA2 G], CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA1 / 25 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA2 / 25 * 10, 2)) AS [FA1FA2-20%],                       
                      dbo.GETGRADE(CONVERT(NUMERIC(18, 2), (tbl_CCEStudentMarks.FA1 + tbl_CCEStudentMarks.FA2)*2), @NONPRIMARY) as [FA1FA2 G],
                      tbl_CCEStudentMarks.SA1,
                      dbo.GETGRADE (tbl_CCEStudentMarks.SA1*2, @NONPRIMARY) AS [SA1 G],
                       CONVERT(NUMERIC(18, 
                      2), ROUND(tbl_CCEStudentMarks.SA1 * 0.01 * 30, 2)) AS [SA1-30%], CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.SA1 * 0.01 * 30, 2)) 
                      + (CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA1 / 25 * 10, 2)) + CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA2 / 25 * 10, 
                      2))) AS [FA1FA2SA1],dbo.GETGRADE ((ROUND(tbl_CCEStudentMarks.FA1 / 25 * 10, 2)+(ROUND(tbl_CCEStudentMarks.FA2 / 25 * 10, 2)+
                      ROUND(tbl_CCEStudentMarks.SA1 * 0.01 * 30, 2)))
                      *2, @NONPRIMARY) AS [TOT-1-G], tbl_CCEStudentMarks.FA3, tbl_CCEStudentMarks.FA4, CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_CCEStudentMarks.FA3 / 25 * 10, 2)) AS [FA3-10%], dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA3 / 25 * 10, 2))*10, @NONPRIMARY) as [FA3 G] ,CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA4 / 25 * 10, 2)) AS [FA4-10%],
                       dbo.GETGRADE(CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA4 / 25 * 10, 2))*10, @NONPRIMARY) as [FA4 G] ,
                       CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA3 / 25 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA4 / 25 * 10, 2)) AS [FA3FA4-20%],
                       dbo.GETGRADE(CONVERT(NUMERIC(18, 2), (tbl_CCEStudentMarks.FA3 + tbl_CCEStudentMarks.FA4)*2), @NONPRIMARY) as [FA3FA4 G],
                      tbl_CCEStudentMarks.SA2, CONVERT(NUMERIC(18, 2),
                       ROUND(tbl_CCEStudentMarks.SA2 * 0.01 * 30, 2)) AS [SA2-30%] ,CONVERT(NUMERIC(18, 2), 
                      ROUND(tbl_CCEStudentMarks.SA2 * 0.01 * 30, 2)) + (CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA3 / 25 * 10, 2)) 
                      + CONVERT(NUMERIC(18, 2), ROUND(tbl_CCEStudentMarks.FA4 / 25 * 10, 2))) AS [FA3FA4SA2],
                      
                      dbo.GETGRADE (tbl_CCEStudentMarks.SA2*2, @NONPRIMARY) AS [SA2 G],
                      
                       dbo.GETGRADE ((ROUND(tbl_CCEStudentMarks.FA3 / 25 * 10, 2)+(ROUND(tbl_CCEStudentMarks.FA4 / 25 * 10, 2)+
                      ROUND(tbl_CCEStudentMarks.SA2 * 0.01 * 30, 2)))
                      *2, @NONPRIMARY) AS [TOT-2-G],
                       ROUND((ISNULL(tbl_CCEStudentMarks.FA1,0)+ISNULL(tbl_CCEStudentMarks.FA2,0)+ISNULL(tbl_CCEStudentMarks.FA3,0)+ISNULL(tbl_CCEStudentMarks.FA4,0)),2) AS [TOT-FA1FA2FA3FA4],
                      
                      dbo.GETGRADE(ROUND((ISNULL(tbl_CCEStudentMarks.FA1,0)+ISNULL(tbl_CCEStudentMarks.FA2,0)+ISNULL(tbl_CCEStudentMarks.FA3,0)+ISNULL(tbl_CCEStudentMarks.FA4,0)),2),@NONPRIMARY)
                       
                        AS [FA1FA2FA3FA4 G], 
                   convert ( numeric(18,2), ISNULL(tbl_CCEStudentMarks.SA1,0)+ISNULL(tbl_CCEStudentMarks.SA2,0))                    
                        AS [TOT-SA1SA2],
                      dbo.GETGRADE(ROUND((ISNULL(tbl_CCEStudentMarks.SA1,0)+ISNULL(tbl_CCEStudentMarks.SA2,0)),2)/(Case When @NONPRIMARY=1 Then 2 Else 1 End) ,@NONPRIMARY)
                       AS [SA1SA2 G],
                       ROUND(
                       ISNULL(tbl_CCEStudentMarks.FA1,0)+ISNULL(tbl_CCEStudentMarks.FA2,0)+
                       ISNULL(tbl_CCEStudentMarks.FA3,0)+ISNULL(tbl_CCEStudentMarks.FA4,0)+
                       ISNULL(tbl_CCEStudentMarks.SA1,0)+ISNULL(tbl_CCEStudentMarks.SA2,0),2)                        
                        AS [TOT-Marks]
                        ,dbo.GETGRADE(ROUND((
                       ISNULL(tbl_CCEStudentMarks.FA1,0)+ISNULL(tbl_CCEStudentMarks.FA2,0)+
                       ISNULL(tbl_CCEStudentMarks.FA3,0)+ISNULL(tbl_CCEStudentMarks.FA4,0)+
                       ISNULL(tbl_CCEStudentMarks.SA1,0)+ISNULL(tbl_CCEStudentMarks.SA2,0))/(Case When @NONPRIMARY=1 Then 3 Else 2 End),2),@NONPRIMARY)
                         AS [Finale Grade],
                         dbo.GETGRADEPOINT((
                       ISNULL(tbl_CCEStudentMarks.FA1,0)+ISNULL(tbl_CCEStudentMarks.FA2,0)+
                       ISNULL(tbl_CCEStudentMarks.FA3,0)+ISNULL(tbl_CCEStudentMarks.FA4,0)+
                       ISNULL(tbl_CCEStudentMarks.SA1,0)+ISNULL(tbl_CCEStudentMarks.SA2,0))/(Case When @NONPRIMARY=1 Then 3 Else 2 End))
                         AS [Grade Point]
FROM         tbl_section INNER JOIN
                      tbl_sankay INNER JOIN
                      tbl_classstudent ON tbl_sankay.sankaycode = tbl_classstudent.Stream INNER JOIN
                      tbl_CCEStudentMarks INNER JOIN
                      tbl_session ON tbl_CCEStudentMarks.SessionCode = tbl_session.sessioncode INNER JOIN
                      tbl_student ON tbl_CCEStudentMarks.StudentNo = tbl_student.studentno INNER JOIN
                      tbl_subject ON tbl_CCEStudentMarks.SubjectNo = tbl_subject.subjectno INNER JOIN
                      tbl_classmaster ON tbl_CCEStudentMarks.ClassNo = tbl_classmaster.classcode ON tbl_classstudent.classno = tbl_classmaster.classcode AND 
                      tbl_classstudent.studentno = tbl_student.studentno AND tbl_classstudent.sessioncode = tbl_session.sessioncode ON 
                      tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN
                      tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN
                      tbl_district ON tbl_student.distcode = tbl_district.distcode
WHERE  (tbl_CCEStudentMarks.Status = 1) AND (tbl_CCEStudentMarks.SessionCode = @SessionCode ) AND 
                      (tbl_CCEStudentMarks.ClassNo =@ClassNo ) AND (tbl_section.sectioncode  = @SectionCode )
                      Order By tbl_student.name ,tbl_subject.SubjectOrder 

	end


                      
                      
                      
                      
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AllStudent]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AllStudent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE  Procedure [dbo].[sp_AllStudent] (@SessionCode as int)
as Begin
SELECT     dbo.tbl_student.studentimage as [Photo],dbo.tbl_student.scholarno AS [Scholar No], dbo.tbl_student.name AS Name, dbo.tbl_student.father AS [Father Name], dbo.tbl_student.mother AS [Mother Name], 
                      CONVERT(varchar, dbo.tbl_student.RegDate, 106) AS [Admission Date], CONVERT(varchar, dbo.tbl_student.dob, 106) AS [Birth Date], 
                      dbo.tbl_student.phone AS [Contact No], dbo.tbl_student.m_tongue AS [Mother Tongue], dbo.tbl_student.casttype AS Category, 
                      CASE WHEN tbl_student.sp_challange = ''False'' THEN ''No'' ELSE ''Yes'' END AS [Physically Challanged], dbo.tbl_student.SubCast AS [Sub-Cast], dbo.tbl_student.Cast, 
                      dbo.tbl_student.Religion, dbo.tbl_student.bldgroup AS Medium, dbo.tbl_student.marr_status AS Gender, 
                      dbo.tbl_classmaster.classname + '' '' + dbo.tbl_section.sectionname AS Class, dbo.tbl_sankay.sankayname AS Stream, dbo.tbl_classstudent.stdtype AS Status, 
                      dbo.tbl_session.sessionname AS Session,case when busfacility=1 then  dbo.tbl_StopDetails.StopName else '''' end AS [Bus Stop], dbo.tbl_tehsil.tehsil AS Tehsil, dbo.tbl_district.district AS District, 
                      dbo.tbl_district.statename AS State, dbo.tbl_classmaster.classcode AS ClassCode, dbo.tbl_section.sectioncode AS SectionCode, dbo.tbl_student.P_address  AS [Permanent Address], 
                      dbo.tbl_student.C_address AS [Current Address],isnull( dbo.tbl_student.SSMId,'''')+'' / ''+isnull(tbl_student.AdharNo,'''') AS [SSSM ID/Adhar No],CASE WHEN dbo.tbl_student.IsRTE = 1 THEN ''Yes'' ELSE ''No'' END AS [RTE],CASE WHEN dbo.tbl_student.IsScholarship = 1 THEN ''Yes'' ELSE ''No'' END AS [Scholarship],CASE WHEN tbl_student.tc_attach = ''False'' THEN ''No'' ELSE ''Yes'' END as TC,CASE WHEN tbl_student.slc_attach = ''False'' THEN ''No'' ELSE ''Yes'' END as SLC,CASE WHEN tbl_student.marksheet_attach = ''False'' THEN ''No'' ELSE ''Yes'' END as Marksheet,CASE WHEN tbl_student.income_attach = ''False'' THEN ''No'' ELSE ''Yes'' END as [Income Tax],CASE WHEN tbl_student.cast_attach = ''False'' THEN ''No'' ELSE ''Yes'' END as [Cast Certificate],CASE WHEN tbl_student.sport_attach = ''False'' THEN ''No'' ELSE ''Yes'' END as [Sport],CASE WHEN tbl_student.dob_attach = ''False'' THEN ''No'' ELSE ''Yes'' END as DOB ,tbl_student.APPType,tbl_student.APPNo, CONVERT(varchar, dbo.tbl_student.APPDate, 106) AS [APPDate],tbl_student.CatNo,tbl_student.AdharNo
FROM         dbo.tbl_student INNER JOIN
                      dbo.tbl_classstudent ON dbo.tbl_student.studentno = dbo.tbl_classstudent.studentno INNER JOIN
                      dbo.tbl_session ON dbo.tbl_classstudent.sessioncode = dbo.tbl_session.sessioncode INNER JOIN
                      dbo.tbl_sankay ON dbo.tbl_classstudent.Stream = dbo.tbl_sankay.sankaycode INNER JOIN
                      dbo.tbl_section ON dbo.tbl_classstudent.Section = dbo.tbl_section.sectioncode INNER JOIN
                      dbo.tbl_classmaster ON dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode INNER JOIN
                      dbo.tbl_tehsil ON dbo.tbl_student.tehcode = dbo.tbl_tehsil.tehcode INNER JOIN
                      dbo.tbl_district ON dbo.tbl_tehsil.distcode = dbo.tbl_district.distcode LEFT OUTER JOIN
                      dbo.tbl_StopDetails ON dbo.tbl_student.BusStopNo = dbo.tbl_StopDetails.BusStopNo
WHERE   (tbl_classstudent.stdtype IN (''New Student'',''Studying Student'')) AND  (tbl_classstudent.sessioncode = @SessionCode)
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AllStudentForScholar]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AllStudentForScholar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE  Procedure [dbo].[sp_AllStudentForScholar] (@SessionCode as int)
as Begin
SELECT     tbl_student.scholarno AS [Scholar No], tbl_student.name AS Name, tbl_student.father AS [Father Name],
                      tbl_student.phone AS [Contact No],tbl_student.SSMId,dbo.GetBankName(tbl_student.Bcode) as [Bank Name],tbl_student.ACNo as [IFSC Code],tbl_student.Amount as [Account No],
                      CASE WHEN tbl_student.IsBPL = ''False'' THEN ''No'' ELSE ''Yes'' END AS [BPL],    tbl_student.casttype AS Category, 
                      CASE WHEN tbl_student.sp_challange = ''False'' THEN ''No'' ELSE ''Yes'' END AS [Physically Challanged],  
                     tbl_student.Religion,   
                      tbl_classmaster.classname + '' '' + tbl_section.sectionname AS Class, tbl_classstudent.stdtype as Status ,  tbl_classmaster.classcode as ClassCode,tbl_section.sectioncode as SectionCode,tbl_session.sessionname AS Session,tbl_student.marr_status AS Gender
                      
FROM         tbl_student INNER JOIN
                      tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno INNER JOIN
                      tbl_session ON tbl_classstudent.sessioncode = tbl_session.sessioncode INNER JOIN
                      tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN
                      tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN
                      tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN
                      tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN
                      tbl_district ON tbl_tehsil.distcode = tbl_district.distcode LEFT OUTER JOIN
                      tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo
WHERE   (tbl_classstudent.stdtype IN (''New Student'',''Studying Student'')) AND  (tbl_classstudent.sessioncode = @SessionCode)
GROUP BY tbl_student.scholarno, tbl_student.name, tbl_student.father, tbl_student.mother, tbl_student.dob, tbl_student.m_tongue, tbl_student.casttype, 
                      tbl_student.sp_challange, tbl_student.phone, tbl_student.bldgroup, tbl_student.SubCast, tbl_student.Religion, tbl_student.Cast, 
                      tbl_student.marr_status, tbl_classmaster.classname, tbl_section.sectionname, tbl_sankay.sankayname, tbl_session.sessionname, tbl_tehsil.tehsil, 
                      tbl_district.district, tbl_district.statename, tbl_student.RegDate, tbl_StopDetails.StopName
                      ,tbl_classmaster.classcode ,tbl_section.sectioncode ,tbl_classstudent.stdtype,tbl_student.SSMId,tbl_student.Bcode,tbl_student.ACNo,tbl_student.Amount,tbl_student.IsBPL
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[INSERTMarksMaxMinMaster]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INSERTMarksMaxMinMaster]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[INSERTMarksMaxMinMaster]
			@ExamId INT,
			@SessionId INT,
			@ClassId INT,
			@StreamId int,
			@SectionId INT,
			@SubjectId INT,
			@IsGrade BIT,
			@IsMarks BIT,
			@IsGradePoint BIT,
			@MinMarks DECIMAL(18,2),
			@MaxMarks decimal(18, 2),
			@IsPractical bit,
			@PractMax decimal(18, 2),
			@PractMin decimal(18, 2),
			@CreatedBy INT,
			@ModifiedBy INT,
			@IsDeleted BIT
AS
BEGIN
		
					
------------------------------------------------------------------------
declare @count int
select @count = Id from dbo.EMarksMaster WHERE ExamId = @ExamId AND
					SessionId = @SessionId AND
					ClassId = @ClassId AND
					SectionId = @SectionId and
					StreamId = @StreamId and
					SubjectId = @SubjectId
					
if @count > 0

begin
			UPDATE EMarksMaster
			SET 
				SubjectId = @SubjectId,
				IsGrade = @IsGrade,
				IsMarks = @IsMarks,
				IsGradePoint = @IsGradePoint,
				MinMarks = @MinMarks,
				MaxMarks = @MaxMarks,
				IsPractical = @IsPractical,
				PractMax = @PractMax,
				PractMin = @PractMin,
				ModfiedDate = getdate(),
				ModifiedBy = @ModifiedBy,
				IsDeleted = @IsDeleted
				WHERE
					Id = @count
end
-----------------------------------------------------------------------------
else
begin
		INSERT INTO [EMarksMaster]
           ([ExamId]
           ,[SessionId]
           ,[ClassId]
           ,[SectionId]
           ,[StreamId]
           ,[SubjectId]
           ,[IsGrade]
           ,[IsMarks]
           ,[IsGradePoint]
           ,[MinMarks]
           ,[MaxMarks]
           ,[IsPractical]
           ,[PractMax]
           ,[PractMin]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[IsDeleted])
     VALUES
           (
            @ExamId ,
			@SessionId , 
			@ClassId , 
           @SectionId  ,
           @StreamId  ,
           	@SubjectId  ,
           @IsGrade ,
			@IsMarks  ,
			@IsGradePoint ,
			@MinMarks ,
			@MaxMarks  ,
			@IsPractical ,
			@PractMax  ,
			@PractMin , 
          @CreatedBy ,
           GETDATE(),
          @IsDeleted )
end		
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetStudentLadger]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStudentLadger]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetStudentLadger](@SessionCode int,@Studentno int,@Fdate datetime,@Tdate datetime)as
begin
declare @Result Table(Type nvarchar(50),VchNo nvarchar(50),VDate nvarchar(20),Narrtion nvarchar(max),Reecipt numeric(18,2),StudentAc numeric(18,2),CashAc numeric(18,2))

declare  @SCode int,@Type nvarchar(50),@VchNo nvarchar(50),@VDate nvarchar(20),@Narrtion nvarchar(max),@Reecipt numeric(18,2),@StudentAc numeric(18,2),@CashAc numeric(18,2),@tval int,@tvalf int,@TFee numeric(18,2),@TFeeinn numeric(18,2),@PFee numeric(18,2),@SFee numeric(18,2),@OFee numeric(18,2),@TFee1 numeric(18,2),@TFee2 numeric(18,2),@TFee11 numeric(18,2),@TFee22 numeric(18,2),@SStatus nvarchar(50),@PRec numeric(18,2),@TotRFee numeric(18,2),@TotBFee numeric(18,2)
declare @FHead nvarchar(max),@FAmount numeric(18,2)
select top 1 @SStatus=stdtype from tbl_classstudent where studentno= @Studentno and sessioncode=@SessionCode

if(@SStatus=''Studying Student'')
	begin
	--/Begin
	declare @TSession table(SCode int)
		insert into @TSession select distinct sessioncode  from tbl_voucherdet ovd where accode=@Studentno
		select @OFee=isnull(acopbal,0)  from tbl_account where accode= @Studentno
		if((select min(SCode) from @TSession)=(select sessioncode from tbl_session where s_from= (select max(s_from) from tbl_session where s_from<=@Fdate )))
		begin
		SELECT @TFee=dbo.GetCFeeAmount((select min(SCode) from @TSession),@Studentno,0)
		--new added method
		declare @TFdt datetime,	@TTdt datetime
		select @TFdt=s_from from tbl_session where sessioncode=(select top 1 SCode from @TSession where SCode<>(select min(SCode) from @TSession))
		select @TTdt=min(vchdate)  from tbl_voucherdet ovd where accode=@Studentno and vchdate between @FDate and @TDate

			if(@TTdt>=@TFdt)
			begin
			 set @TFeeinn=@TFee+dbo.GetCFeeAmount((select top 1 SCode from @TSession where SCode<>(select min(SCode) from @TSession)),@Studentno,1)
			  set @TFee=@TFeeinn
			end		
		
		--end method
		select @PRec=isnull(sum(vchamt),0)  from tbl_voucherdet ovd where accode=@Studentno and vchdate <@Fdate
		set @tval=0
		set @tvalf=0
		set @TFee1=0
		set @TFee2=0
		set @TFee11=(@TFee+@OFee)-@PRec
		set @TFee22=0
		--/Some Logic Here /--------
		DECLARE db_cursor CURSOR FOR  
		select sessioncode, vchtype as Type,vchno as VchNo,convert(nvarchar(14), vchdate,103) as VDate,(select remark from tbl_voucher where vchno=ovd.vchno and sessioncode=ovd.sessioncode and VchType=ovd.VchType) as Narration,vchamt as Receipt,0 as StudentAc,0 as CashAc    from tbl_voucherdet ovd where accode=@Studentno and vchdate between @FDate and @TDate
		OPEN db_cursor   
		FETCH NEXT FROM db_cursor INTO @SCode,@Type ,@VchNo ,@VDate ,@Narrtion ,@Reecipt ,@StudentAc ,@CashAc 

		WHILE @@FETCH_STATUS = 0   
		BEGIN   
			  
			  set @TFee1=@TFee11-@Reecipt
			  set @TFee2=@TFee22+@Reecipt
			  set @TFee11=@TFee1
			  set @TFee22=@TFee2
			  if(@tval<>@SCode)
				  begin
					if(@tvalf=0)
						begin
						--//Start Get Feed Head Details
						DECLARE db_cursor_F CURSOR FOR  
							select *from dbo.Fn_Tbl_FHADetails(@SCode,@Studentno,0,dbo.GetStudentStatus(@SCode,@Studentno))
							OPEN db_cursor_F   
							FETCH NEXT FROM db_cursor_F INTO @FHead ,@FAmount

							WHILE @@FETCH_STATUS = 0   
							BEGIN   
								  
								  
									insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
								  values('''','''','''',@FHead,0,0,@FAmount)
								  
								   FETCH NEXT FROM db_cursor_F INTO @FHead ,@FAmount 
							END   

							CLOSE db_cursor_F   
							DEALLOCATE db_cursor_F
						--//----End---
						  insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
				  values('''','''','''',''Opening Balance'',0,(@TFee+@OFee)-@PRec,(@TFee+@OFee)-@PRec)
				  insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
						  values(@Type,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee11,0)
						  set @PFee=@TFee11
						  set @tval=@SCode
						  set @tvalf=1
						  end
						  else
							begin
							--//Start Get Feed Head Details
						DECLARE db_cursor_F CURSOR FOR  
							select *from dbo.Fn_Tbl_FHADetails(@SCode,@Studentno,1,dbo.GetStudentStatus(@SCode,@Studentno))
							OPEN db_cursor_F   
							FETCH NEXT FROM db_cursor_F INTO @FHead ,@FAmount

							WHILE @@FETCH_STATUS = 0   
							BEGIN   
								  
								  
									insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
								  values('''','''','''',@FHead,0,0,@FAmount)
								  
								   FETCH NEXT FROM db_cursor_F INTO @FHead ,@FAmount 
							END   

							CLOSE db_cursor_F   
							DEALLOCATE db_cursor_F
						--//----End---
							insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
				  values('''','''','''',''Opening Balance'',0,(dbo.GetCFeeAmount(@SCode,@Studentno,1))+@PFee,(dbo.GetCFeeAmount(@SCode,@Studentno,1))+@PFee)
					  set @TFee11=0
					  set @TFee22=0
						set @TFee1=((dbo.GetCFeeAmount(@SCode,@Studentno,1))+@PFee)-@Reecipt
						set @TFee2=@TFee22+@Reecipt
						 set @TFee11=@TFee1
						 set @TFee22=@TFee2
				  insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
						  values(@Type,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee11,0)
						  set @PFee=@TFee11
						  set @tval=@SCode
						  set @tvalf=1
							end
				  end
			  else
				  begin
				  insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
				  values(@Type,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee11,0)
				  set @PFee=@TFee11
				  end
			
			   FETCH NEXT FROM db_cursor INTO @SCode,@Type ,@VchNo ,@VDate ,@Narrtion ,@Reecipt ,@StudentAc ,@CashAc 
		END   

		CLOSE db_cursor   
		DEALLOCATE db_cursor
		end	
		else if((select min(SCode) from @TSession)<(select sessioncode from tbl_session where s_from= (select max(s_from) from tbl_session where s_from<=@Fdate )))
	begin
	declare @TSessionI table(SCode int)
		
		insert into @TSessionI select distinct sessioncode  from tbl_voucherdet ovd where ovd.accode=@Studentno and ovd.vchdate <= (select isnull(min(vchdate),getdate()) from tbl_voucherdet where vchdate>= @Fdate and accode=@Studentno)
		
		select @OFee=isnull(acopbal,0)  from tbl_account where accode= @Studentno
		SELECT @TFee=dbo.GetCFeeAmount((select min(SCode) from @TSessionI),@Studentno,0)
		--/start inner Balance Amount
		
		DECLARE db_cursorinn CURSOR FOR  
		select SCode from @TSessionI where SCode<>(select min(SCode) from @TSessionI)
		OPEN db_cursorinn   
		FETCH NEXT FROM db_cursorinn INTO @SCode 

		WHILE @@FETCH_STATUS = 0   
		BEGIN   
			  
			  set @TFeeinn=@TFee+dbo.GetCFeeAmount(@SCode,@Studentno,1)
			  set @TFee=@TFeeinn
		   FETCH NEXT FROM db_cursorinn INTO @SCode
		END   

		CLOSE db_cursorinn   
		DEALLOCATE db_cursorinn
		
		--/end
		
		select @PRec=isnull(sum(vchamt),0)  from tbl_voucherdet ovd where accode=@Studentno and vchdate <@Fdate
	
		set @tval=0
		set @tvalf=0
		set @TFee1=0
		set @TFee2=0
		set @TFee11=(@TFee+@OFee)-@PRec
		set @TFee22=0
		--/Some Logic Here /--------
		DECLARE db_cursor CURSOR FOR  
		select sessioncode, vchtype as Type,vchno as VchNo,convert(nvarchar(14), vchdate,103) as VDate,(select remark from tbl_voucher where vchno=ovd.vchno and sessioncode=ovd.sessioncode and VchType=ovd.VchType) as Narration,vchamt as Receipt,0 as StudentAc,0 as CashAc    from tbl_voucherdet ovd where accode=@Studentno and vchdate between @FDate and @TDate
		OPEN db_cursor   
		FETCH NEXT FROM db_cursor INTO @SCode,@Type ,@VchNo ,@VDate ,@Narrtion ,@Reecipt ,@StudentAc ,@CashAc 

		WHILE @@FETCH_STATUS = 0   
		BEGIN   
			  
			  set @TFee1=@TFee11-@Reecipt
			  set @TFee2=@TFee22+@Reecipt
			  set @TFee11=@TFee1
			  set @TFee22=@TFee2
			  if(@tval<>@SCode)
				  begin
					if(@tvalf=0)
						begin
						--//Start Get Feed Head Details
						DECLARE db_cursor_F CURSOR FOR  
							select *from dbo.Fn_Tbl_FHADetails(@SCode,@Studentno,1,@SStatus)
							OPEN db_cursor_F   
							FETCH NEXT FROM db_cursor_F INTO @FHead ,@FAmount

							WHILE @@FETCH_STATUS = 0   
							BEGIN   
								  
								  
									insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
								  values('''','''','''',@FHead,0,0,@FAmount)
								  
								   FETCH NEXT FROM db_cursor_F INTO @FHead ,@FAmount 
							END   

							CLOSE db_cursor_F   
							DEALLOCATE db_cursor_F
						--//----End---
						  insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
				  values('''','''','''',''Opening Balance'',0,(@TFee+@OFee)-@PRec,(@TFee+@OFee)-@PRec)
				  insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
						  values(@Type,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee11,0)
						  set @PFee=@TFee11
						  set @tval=@SCode
						  set @tvalf=1
						  end
						  else
							begin
							--//Start Get Feed Head Details
						DECLARE db_cursor_F CURSOR FOR  
							select *from dbo.Fn_Tbl_FHADetails(@SCode,@Studentno,1,@SStatus)
							OPEN db_cursor_F   
							FETCH NEXT FROM db_cursor_F INTO @FHead ,@FAmount

							WHILE @@FETCH_STATUS = 0   
							BEGIN   
								  
								  
									insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
								  values('''','''','''',@FHead,0,0,@FAmount)
								  
								   FETCH NEXT FROM db_cursor_F INTO @FHead ,@FAmount 
							END   

							CLOSE db_cursor_F   
							DEALLOCATE db_cursor_F
						--//----End---
							insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
				  values('''','''','''',''Opening Balance'',0,(dbo.GetCFeeAmount(@SCode,@Studentno,1))+@PFee,(dbo.GetCFeeAmount(@SCode,@Studentno,1))+@PFee)
					  set @TFee11=0
					  set @TFee22=0
						set @TFee1=((dbo.GetCFeeAmount(@SCode,@Studentno,1))+@PFee)-@Reecipt
						set @TFee2=@TFee22+@Reecipt
						 set @TFee11=@TFee1
						 set @TFee22=@TFee2
				  insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
						  values(@Type,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee11,0)
						  set @PFee=@TFee11
						  set @tval=@SCode
						  set @tvalf=1
							end
				  end
			  else
				  begin
				  insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
				  values(@Type,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee11,0)
				  set @PFee=@TFee11
				  end
			
			   FETCH NEXT FROM db_cursor INTO @SCode,@Type ,@VchNo ,@VDate ,@Narrtion ,@Reecipt ,@StudentAc ,@CashAc 
		END   

		CLOSE db_cursor   
		DEALLOCATE db_cursor
	
	
	
	end	
	
	

		
	
	--/End
	end
	else if(@SStatus=''New Student'')
		begin 

		SELECT @TFee=isnull(sum( tbl_classfeeregular.feeamt),0)      FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classfeeregular INNER JOIN     tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode ON tbl_classstudent.classno = tbl_classfeeregular.classno AND     tbl_classstudent.sessioncode = tbl_classfeeregular.sessioncode and tbl_classstudent.stream=tbl_classfeeregular.stream  WHERE (tbl_classfeeregular.sessioncode = @SessionCode) And   (tbl_student.studentno = @Studentno)     


		SELECT @SFee= (Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopFee, 0) Else 0 End)  FROM tbl_classmaster INNER JOIN    tbl_classstudent ON tbl_classmaster.classcode = tbl_classstudent.classno INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno LEFT OUTER JOIN tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo   WHERE     (tbl_student.studentno = @Studentno) AND (tbl_classstudent.sessioncode = @SessionCode)

		select @OFee=isnull(acopbal,0)  from tbl_account where accode= @Studentno

		select @PRec=isnull(sum(vchamt),0)  from tbl_voucherdet ovd where accode=@Studentno and vchdate <@Fdate

		set @tval=0
		set @TFee1=0
		set @TFee2=0
		set @TFee11=(@TFee+@SFee+@OFee)-@PRec
		set @TFee22=0
		--/Some Logic Here /--------
		--//Start Get Feed Head Details
						DECLARE db_cursor_F CURSOR FOR  
							select *from dbo.Fn_Tbl_FHADetails(@SessionCode,@Studentno,0,@SStatus)
							OPEN db_cursor_F   
							FETCH NEXT FROM db_cursor_F INTO @FHead ,@FAmount

							WHILE @@FETCH_STATUS = 0   
							BEGIN   
								  
								  
									insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
								  values('''','''','''',@FHead,0,0,@FAmount)
								  
								   FETCH NEXT FROM db_cursor_F INTO @FHead ,@FAmount 
							END   

							CLOSE db_cursor_F   
							DEALLOCATE db_cursor_F
						--//----End---
		insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
			  values('''','''',convert(nvarchar(14),@Fdate,103),''Opening Balance'',0,(@TFee+@SFee+@OFee)-@PRec,(@TFee+@SFee+@OFee)-@PRec)
		DECLARE db_cursor CURSOR FOR  
		select vchtype,vchno,convert(nvarchar(14), vchdate,103),(select remark from tbl_voucher where vchno=ovd.vchno and sessioncode=ovd.sessioncode and VchType=ovd.VchType ) as Narration,vchamt as Receipt,0,0    from tbl_voucherdet ovd where accode=@Studentno and vchdate between @Fdate and @Tdate
		OPEN db_cursor   
		FETCH NEXT FROM db_cursor INTO @Type ,@VchNo ,@VDate ,@Narrtion ,@Reecipt ,@StudentAc ,@CashAc 

		WHILE @@FETCH_STATUS = 0   
		BEGIN   
			  
			  set @TFee1=@TFee11-@Reecipt
			  set @TFee2=@TFee22+@Reecipt
			  set @TFee11=@TFee1
			  set @TFee22=@TFee2
				insert into @Result(Type ,VchNo ,VDate ,Narrtion,Reecipt ,StudentAc ,CashAc )
			  values(@Type,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee11,0)
			  
			   FETCH NEXT FROM db_cursor INTO @Type ,@VchNo ,@VDate ,@Narrtion ,@Reecipt ,@StudentAc ,@CashAc 
		END   

		CLOSE db_cursor   
		DEALLOCATE db_cursor
		end
--/End/--
select *from @Result
select (select top 1 name from tbl_student where studentno=@Studentno) as StuName,*from tbl_school 
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetRecPrint]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecPrint]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetRecPrint](@sessioncode int,@RecId int)as
begin

declare @studentno int,@busfeci bit

set @studentno= (select top 1 studentno from Tbl_Received where RecId=@RecId and sessioncode=@sessioncode)

SELECT     dbo.tbl_student.studentno, dbo.tbl_student.scholarno, dbo.tbl_student.name, dbo.tbl_student.dob, 
                      dbo.tbl_classmaster.classname + '' '' + dbo.tbl_section.sectionname AS Class, dbo.tbl_session.sessionname, dbo.tbl_tehsil.tehsil, dbo.tbl_district.district, 
                      dbo.tbl_district.statename, dbo.tbl_student.P_address, dbo.tbl_student.C_address, dbo.tbl_student.father, dbo.tbl_student.mother, dbo.tbl_student.casttype, 
                      dbo.tbl_student.bloodgroup, dbo.tbl_student.marr_status AS gender,ISNULL(dbo.tbl_student.phone,'''') AS phone, 
                      (CASE WHEN tbl_student.busfacility = 1 THEN tbl_StopDetails.StopName ELSE ISNULL(tbl_student.P_address, tbl_tehsil.tehsil) END) AS StopName, 
                      dbo.tbl_StopDetails.StopFee
FROM         dbo.tbl_section INNER JOIN
                      dbo.tbl_classstudent INNER JOIN
                      dbo.tbl_student ON dbo.tbl_classstudent.studentno = dbo.tbl_student.studentno INNER JOIN
                      dbo.tbl_session ON dbo.tbl_classstudent.sessioncode = dbo.tbl_session.sessioncode INNER JOIN
                      dbo.tbl_classmaster ON dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode ON dbo.tbl_section.sectioncode = dbo.tbl_classstudent.Section INNER JOIN
                      dbo.tbl_sankay ON dbo.tbl_classstudent.Stream = dbo.tbl_sankay.sankaycode INNER JOIN
                      dbo.tbl_district ON dbo.tbl_student.distcode = dbo.tbl_district.distcode INNER JOIN
                      dbo.tbl_tehsil ON dbo.tbl_student.tehcode = dbo.tbl_tehsil.tehcode AND dbo.tbl_district.distcode = dbo.tbl_tehsil.distcode LEFT OUTER JOIN
                      dbo.tbl_StopDetails ON dbo.tbl_student.BusStopNo = dbo.tbl_StopDetails.BusStopNo WHERE (tbl_classstudent.sessioncode = @sessioncode) and dbo.tbl_student.studentno=@studentno;
              select @busfeci=busfacility from tbl_student where studentno= @studentno

if(@busfeci=1)
	begin
declare @tclassno nvarchar(50),@tfeeamt numeric(18,2),@tstream nvarchar(50),@ttodate datetime

set @tfeeamt=0
set @ttodate=getdate()

declare @t_tbl_classfeeregular table(sessioncode int,classno int,	feecode	int,feeamt	numeric(18,2),feemonth int,	Stream nvarchar(50),	Date datetime,RTE BIT )

set @studentno= (select top 1 studentno from Tbl_Received where RecId=@RecId)
set @tclassno=(select classno from tbl_classstudent where studentno=@studentno and sessioncode=@sessioncode)
set @tfeeamt=(select StopFee from tbl_StopDetails where BusStopNo=(select top 1 BusStopNo from tbl_student where studentno= @studentno))
set @tstream=(select top 1 Stream from tbl_classfeeregular where classno=@tclassno)
set @ttodate=(select top 1 s_to from tbl_session where sessioncode=@sessioncode)
insert into @t_tbl_classfeeregular select * from tbl_classfeeregular where classno=@tclassno AND sessioncode=@sessioncode

insert into @t_tbl_classfeeregular select @sessioncode as sessioncode,	@tclassno as classno,101 as	feecode	,@tfeeamt as feeamt	,'''' as feemonth,@tstream as Stream,@ttodate as	Date ,''True'' as RTE



SELECT convert(varchar, ROW_NUMBER() Over (Order by fh.feecode)) As serialno, fh.feeheads as FeeHead,dbo.GetRecAmountByHeadForRce(fh.feecode,cfr.sessioncode,st.studentno,r.RecId) as RAmount    
FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno 
INNER JOIN @t_tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  inner join Tbl_Received  r on r.sessioncode=cfr.sessioncode inner join Tbl_ReceivedDetail rd on r.RecId=rd.RecId
WHERE  (cfr.sessioncode = @sessioncode) And    (st.studentno=@studentno)  and r.RecId=@RecId and dbo.GetRecAmountByHeadForRce(fh.feecode,cfr.sessioncode,st.studentno,r.RecId)>0  GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode,r.RecId order by fh.feecode
	end
else
	begin
	SELECT convert(varchar, ROW_NUMBER() Over (Order by fh.feecode)) As serialno, fh.feeheads as FeeHead,dbo.GetRecAmountByHeadForRce(fh.feecode,cfr.sessioncode,st.studentno,r.RecId) as RAmount    
	FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno 
	INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  inner join Tbl_Received  r on r.sessioncode=cfr.sessioncode inner join Tbl_ReceivedDetail rd on r.RecId=rd.RecId
	WHERE  (cfr.sessioncode = @sessioncode) And    (st.studentno=@studentno)  and r.RecId=@RecId and dbo.GetRecAmountByHeadForRce(fh.feecode,cfr.sessioncode,st.studentno,r.RecId)>0  GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode,r.RecId order by fh.feecode
	end



select convert(varchar, r.RecId) as RecId, CONVERT(varchar, r.date, 106) as date,dbo.GetDueAmount(r.RecId,r.sessioncode,r.studentno) as DueAmount, isnull(sum(recamount),0) as RecAmount,dbo.Num_ToWords(isnull(sum(recamount),0)) as Word,r.latefee,r.consession,r.date as rdate from  Tbl_Received  r inner join Tbl_ReceivedDetail rd  on r.RecId=rd.RecId where  r.sessioncode= @sessioncode and r.RecId=@RecId group by r.RecId,r.latefee,r.consession,r.sessioncode,r.studentno,r.date

SELECT schoolname, schooladdress, affiliate_by, logoimage, schoolcity, schoolphone, principal, registrationno FROM tbl_school 



end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetRecDetailFor]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecDetailFor]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetRecDetailFor](@sessioncode int,@RecId int,@stdtype nvarchar(50))as
begin

declare @studentno nvarchar(50), @tclassno nvarchar(50),@tfeeamt numeric(18,2),@tstream nvarchar(50),@ttodate datetime,@busfeci bit,@rte bit

set @tfeeamt=0
set @ttodate=getdate()

declare @t_tbl_classfeeregular table(sessioncode int,classno int,	feecode	int,feeamt	numeric(18,2),feemonth int,	Stream nvarchar(50),	Date datetime,RTE bit )

set @studentno= (select top 1 studentno from Tbl_Received where RecId=@RecId)
set @tclassno=(select classno from tbl_classstudent where studentno=@studentno and sessioncode=@sessioncode)
set @tfeeamt=(select StopFee from tbl_StopDetails where BusStopNo=(select top 1 BusStopNo from tbl_student where studentno= @studentno))
set @tstream=(select top 1 Stream from tbl_classfeeregular where classno=@tclassno)
set @ttodate=(select top 1 s_to from tbl_session where sessioncode=@sessioncode)

set @rte=(select IsRTE from tbl_student where studentno=@studentno)

insert into @t_tbl_classfeeregular select * from tbl_classfeeregular where classno=@tclassno and RTE=@rte

  select @busfeci=busfacility from tbl_student where studentno= @studentno

if(@busfeci=1)
	begin
	insert into @t_tbl_classfeeregular select @sessioncode as sessioncode,	@tclassno as classno,101 as	feecode	,@tfeeamt as feeamt	,'''' as feemonth,@tstream as Stream,@ttodate as	Date ,''False'' as  RTE
	end
	
if(@stdtype=''New Student'')
	begin
	SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,@RecId) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,@RecId)) as BAmount,dbo.GetRecAmountByHeadRecCurrent(fh.feecode,cfr.sessioncode,st.studentno,@RecId) as PAmount    

	FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN @t_tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  WHERE  (cfr.sessioncode = @sessioncode) And    (st.studentno = @studentno)  AND (cs.stdtype = @stdtype)   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode
	end
	else
	begin
		if(@busfeci=1)
		begin
			SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,@RecId) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,@RecId)) as BAmount,dbo.GetRecAmountByHeadRecCurrent(fh.feecode,cfr.sessioncode,st.studentno,@RecId) as PAmount    

	FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN @t_tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  WHERE  (cfr.sessioncode = @sessioncode) And    (st.studentno = @studentno) and ( fh.feecode=101)  AND (cs.stdtype = @stdtype)   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode
union all
SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,@RecId) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,@RecId)) as BAmount,dbo.GetRecAmountByHeadRecCurrent(fh.feecode,cfr.sessioncode,st.studentno,@RecId) as PAmount    

	FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN @t_tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  WHERE  (cfr.sessioncode = @sessioncode) And    (st.studentno = @studentno) and ((fh.feetype = ''1'') and fh.feecode<>101)  AND (cs.stdtype = @stdtype) and cfr.RTE=@rte   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode	
		end
		else
		begin
		SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,@RecId) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,@RecId)) as BAmount,dbo.GetRecAmountByHeadRecCurrent(fh.feecode,cfr.sessioncode,st.studentno,@RecId) as PAmount    

	FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN @t_tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  WHERE  (cfr.sessioncode = @sessioncode) And    (st.studentno = @studentno) and (fh.feetype = ''1'')  AND (cs.stdtype = @stdtype)   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode
		end
	
	
	end

end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeLadger]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmployeeLadger]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetEmployeeLadger](@EmpID int,@Fdate datetime,@Tdate datetime)as
begin

declare @Result Table(Type nvarchar(50),VMonth nvarchar(50),VchNo nvarchar(50),VDate nvarchar(20),Narrtion nvarchar(max),Reecipt numeric(18,2),EmpAc numeric(18,2),CashAc numeric(18,2))

declare @Type nvarchar(50),@VMonth nvarchar(50),@VchNo nvarchar(50),@VDate nvarchar(20),@Narrtion nvarchar(max),@Reecipt numeric(18,2),@StudentAc numeric(18,2),@CashAc numeric(18,2),@TFee1 numeric(18,2),@TFee2 numeric(18,2),@TFee11 numeric(18,2),@TFee22 numeric(18,2),@PRec numeric(18,2)
		set @TFee1=0
		set @TFee2=0
		set @TFee11=0
		set @TFee22=0
		set	@PRec=0
			select @PRec=isnull(acopbal,0) from tbl_account where accode=@EmpID
		--/Some Logic Here /--------
		DECLARE db_cursor CURSOR FOR  
SELECT     vchtype,dbo.GetSalMonth(ovd.accode, ovd.vchno), vchno, CONVERT(nvarchar(14), vchdate, 103) AS vchdate,
                          
                          (SELECT     Remark
                            FROM          dbo.tbl_Voucher
                            WHERE      (VchNo = ovd.vchno) AND (sessioncode = ovd.sessioncode) and VchType=ovd.VchType) AS Narration,
                             vchamt AS Receipt, 
                             dbo.GetEmpAmount(ovd.accode, ovd.vchno) AS NetAmount, 
                      0 AS Ca
FROM         dbo.tbl_voucherdet AS ovd where accode=@EmpID and vchdate between @Fdate and @Tdate
		OPEN db_cursor   
		FETCH NEXT FROM db_cursor INTO @Type,@VMonth ,@VchNo ,@VDate ,@Narrtion ,@Reecipt ,@StudentAc ,@CashAc 

		WHILE @@FETCH_STATUS = 0   
		BEGIN   
		      
			  set @TFee1=(@StudentAc)-@Reecipt
			  set @TFee2=@TFee22+@Reecipt
			  set @TFee11=@TFee1+@PRec
			  set @TFee22=@TFee2
			  insert into @Result(Type ,VMonth,VchNo ,VDate ,Narrtion,Reecipt ,EmpAc ,CashAc )
			  values('''','''','''','''',''Opening Balance'',0,@StudentAc+@PRec,0)
			  
				insert into @Result(Type,VMonth ,VchNo ,VDate ,Narrtion,Reecipt ,EmpAc ,CashAc )
			  values(@Type,@VMonth,@VchNo,@VDate,@Narrtion,@Reecipt,@TFee11,@TFee22)
			  set @TFee22=0
		      set @PRec=@TFee11
			   FETCH NEXT FROM db_cursor INTO @Type,@VMonth ,@VchNo ,@VDate ,@Narrtion ,@Reecipt ,@StudentAc ,@CashAc 
		END   

		CLOSE db_cursor   
		DEALLOCATE db_cursor
	
--/End/--
select *from @Result
select (select top 1 EmpName from tbl_EmployeeInfo where EmpNo=@EmpID) as EmpName,*from tbl_school 
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetCurrentJVoucher]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCurrentJVoucher]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetCurrentJVoucher](@IVchno nvarchar(50))as
begin

declare @TTable table(vchdate nvarchar(20),vchno nvarchar(50),Perticular nvarchar(max),DAmount numeric(18,2),CAmount  numeric(18,2))
declare @vchdate nvarchar(20),@vchno nvarchar(50),@Perticular nvarchar(max),@DAmount numeric(18,2),@CAmount  numeric(18,2),@TVchno nvarchar(50)
set @TVchno=''0''
 
DECLARE db_Account CURSOR FOR   select *from (
select convert(nvarchar(15), vchdate,103) as vchdate,vchno,dbo.GetAccountName(accode) as Perticular,vchamt as DAmount,0 as CAmount  from tbl_voucherdet where  amttype=''Dr''  and vchtype=''JV''
union all
select convert(nvarchar(15), vchdate,103) as vchdate, vchno,dbo.GetAccountName(accode) as Perticular, 0 as DAmount,vchamt as CAmount from tbl_voucherdet where  amttype=''Cr'' and vchtype=''JV''
union all 
select convert(nvarchar(15), vchdate,103) as vchdate, vchno,''Naration : ''+Remark as Perticular, 0 as DAmount,0 as CAmount from tbl_voucher where  vchtype=''JV''
)tbl where vchno=@IVchno   order by vchno

OPEN db_Account   
FETCH NEXT FROM db_Account INTO @vchdate,@vchno ,@Perticular ,@DAmount ,@CAmount

WHILE @@FETCH_STATUS = 0   
BEGIN   
       if(@TVchno<>@vchno)
		begin 
		insert into @TTable(vchdate,vchno,Perticular,DAmount,CAmount)  values(@vchdate ,@vchno,@Perticular ,@DAmount ,@CAmount)
	set @TVchno=@vchno
	
		end
		else
			begin
			insert into @TTable(Perticular,DAmount,CAmount)  values(@Perticular ,@DAmount ,@CAmount)
			end
       FETCH NEXT FROM db_Account INTO @vchdate ,@vchno,@Perticular ,@DAmount ,@CAmount  
END   

CLOSE db_Account   
DEALLOCATE db_Account

select (select top 1 logoimage from tbl_school ) as SLogo,(select top 1 schoolname from tbl_school ) as SName,(select top 1 schooladdress from tbl_school ) as SAddress,*from @TTable

end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetAllSubjects]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllSubjects]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetAllSubjects] 
@SessionId int ,
  @ExamId int ,
  @calssid varchar(5) ,
 @sectioncode int,
  @stream varchar(50)
  
AS  
BEGIN  
 declare @Count int
  Select @Count = Count(*) From EMarksMaster Where ExamId = @ExamId and 
SessionId = @SessionId and 
ClassId	 = @calssid and
SectionId = @sectioncode	and StreamId = @stream
--Check if particular details already created in EMarksMaster  
if @Count > 0
begin 
Select sb.subjectname [SubjectName],* from EMarksMaster em , tbl_subject sb Where em.IsDeleted = 0 and em.SubjectId = sb.subjectno
---new edited
and em.SectionId = @sectioncode and em.ClassId = @calssid and em.SessionId = @SessionId and em.StreamId = @stream and em.ExamId = @ExamId
---end
end 

--Get particular details already from fresh in EMarksMaster  
else

begin 
select distinct(sub.subjectname) [SubjectName],sub.subjectno from tbl_subwiseclass sc, tbl_classmaster c, tbl_section s, tbl_sankay stm, tbl_subject sub
	where
		sc.classno = @calssid
	and
		sc.sankayname = @stream
		and
		sc.subjectno = sub.subjectno
end

 
 
	
   
 
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetFilteredExam]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetFilteredExam]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetFilteredExam] 
			@ClassId INT,
			@StreamId int,
			@SectionId INT
  
AS  
BEGIN  
  SELECT Exam ,Id FROM [dbo].[EExam] where Id in (
select distinct(ExamId) from dbo.EMarksMaster em 
where em.IsDeleted = 0 and 
em.ClassId = @ClassId 
and em.StreamId = @StreamId
and em.SectionId = @SectionId 
)   
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetAllEMarksMaster]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllEMarksMaster]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetAllEMarksMaster]
		@id int=0
		

AS
BEGIN
		if @id = 0
		BEGIN
		SELECT * FROM [dbo].[EMarksMaster]
		END

		ELSE
		BEGIN
		SELECT * FROM [dbo].[EMarksMaster] WHERE Id = @id
		END	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAllMarksMaxMinMaster]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAllMarksMaxMinMaster]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[DeleteAllMarksMaxMinMaster]
			@ExamId INT,
			@SessionId INT,
			@ClassId INT,
			@StreamId int,
			@SectionId INT
AS
BEGIN
		UPDATE EMarksMaster
			SET IsDeleted = 1 
			WHERE ExamId = @ExamId AND
					SessionId = @SessionId AND
					ClassId = @ClassId AND
					SectionId = @SectionId and
					StreamId = @StreamId
					
				
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EINSERTMarksStudent]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EINSERTMarksStudent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROC [dbo].[EINSERTMarksStudent]
			@MarksMasterId	int	,
			@studentno	int	,
			@MarksObtained	decimal,
			@PractMarks	decimal,			
			@CreatedBy INT,
			@ModifiedBy INT,
			@IsDeleted BIT
AS
BEGIN
		
					
------------------------------------------------------------------------
declare @count int
select @count = Id from dbo.EMarksStudent WHERE MarksMasterId = @MarksMasterId AND
					studentno = @studentno 
					
if @count > 0

begin
			UPDATE EMarksStudent
			SET MarksObtained =@MarksObtained, PractMarks=@PractMarks,			
			CreatedBy=@CreatedBy,
				ModfiedDate = getdate(),
				ModifiedBy = @ModifiedBy,
				IsDeleted = @IsDeleted
				WHERE
					Id = @count
end
-----------------------------------------------------------------------------
else
begin
		INSERT INTO [dbo].[EMarksStudent]
           ([MarksMasterId]
           ,[studentno]
           ,[MarksObtained]
           ,[PractMarks]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModfiedDate]
           ,[ModifiedBy]
           ,[IsDeleted])
     VALUES
           (@MarksMasterId
           ,@studentno
           ,@MarksObtained
           ,@PractMarks
           ,@CreatedBy
           ,GETDATE()
           ,GETDATE()
           ,@ModifiedBy
           ,@IsDeleted )
           
			
			
		
			
			
			
			
end
					
				
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EGetAllEMarksStudent]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EGetAllEMarksStudent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EGetAllEMarksStudent]
		@id int=0
		

AS
BEGIN
		if @id = 0
		BEGIN
		SELECT * FROM [dbo].[EMarksStudent]
		END

		ELSE
		BEGIN
		SELECT * FROM [dbo].[EMarksStudent] WHERE Id = @id
		END	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EDeleteAllStudentMarks]    Script Date: 09/18/2018 18:49:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDeleteAllStudentMarks]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EDeleteAllStudentMarks]
			@ExamId INT,
			@SessionId INT,
			@ClassId INT,
			@StreamId int,
			@SectionId INT
AS
BEGIN
		
		UPDATE EMarksStudent
			SET IsDeleted = 1 
			where Id in (Select Id from dbo.EMarksMaster  where
					ExamId = @ExamId AND
					SessionId = @SessionId AND
					ClassId = @ClassId AND
					SectionId = @SectionId and
					StreamId = @StreamId) 
			
					
				
END
' 
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteStudent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[DeleteStudent] 
	-- Add the parameters for the stored procedure here
	@ScholarNo varchar(100)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
insert into tbl_student_backup select * from tbl_student where scholarno=@ScholarNo;
insert into tbl_classstudent_backup select * from tbl_classstudent where studentno=(select studentno from tbl_student where scholarno=@ScholarNo);

delete from tbl_classstudent where studentno=(select studentno from tbl_student where scholarno=@ScholarNo);
delete from tbl_student where scholarno=@ScholarNo;

END'

END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecoverDeletedStudents]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Manoj Dwivedi
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[RecoverDeletedStudents]
	@StudentNo integer	
AS
BEGIN
	SET NOCOUNT ON;
insert into tbl_student select * from tbl_student_backup sb where sb.studentno = @StudentNo
insert into tbl_classstudent select * from tbl_classstudent_backup csb where csb.studentno = @StudentNo

delete from tbl_student_backup where studentno = @StudentNo
delete from tbl_classstudent_backup where studentno = @StudentNo

END'

END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBackupStudents]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Manoj Dwivedi
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBackupStudents]
	@SessionId integer	
AS
BEGIN
	SET NOCOUNT ON;
select scholarno, s.studentno, name, ISNULL(phone,'') as phone, father, APPDate, ISNULL(marr_status, '') as gender, classname as class, s.section from tbl_student_backup s
inner join tbl_classstudent_backup cs on s.studentno = cs.studentno and s.admsession = cs.sessioncode
inner join tbl_classmaster cm on cm.classcode = cs.classno
where admsession = @SessionId

END'

END
GO
