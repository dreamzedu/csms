

 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_examtype](
	[examno] [int] NOT NULL,
	[examname] [varchar](30) NULL,
 CONSTRAINT [PK_tbl_examtype] PRIMARY KEY CLUSTERED 
(
	[examno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_examsubject](
	[examsubjectno] [int] NOT NULL,
	[examsubjecttype] [int] NOT NULL,
	[subjectno] [int] NULL,
	[examsubjectname] [varchar](40) NULL,
	[subminmarks] [int] NULL,
	[submaxmarks] [int] NULL,
	[Board] [varchar](50) NULL,
	[classNo] [int] NULL,
	[sessioncode] [int] NULL,
	[subjecttype] [varchar](50) NULL,
	[sankayname] [varchar](50) NULL,
	[examdate] [datetime] NULL,
	[examtype] [varchar](50) NULL,
	[ExaminationMonth] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_examsubject_1] PRIMARY KEY CLUSTERED 
(
	[examsubjectno] ASC,
	[examsubjecttype] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_examsheets](
	[sessioncode] [int] NULL,
	[classno] [int] NULL,
	[examno] [int] NULL,
	[studentno] [int] NULL,
	[rollno] [nchar](10) NULL,
	[examsubjectno] [int] NULL,
	[examsubjecttype] [int] NULL,
	[subjectno] [int] NULL,
	[minmarks] [int] NULL,
	[obtmarks] [numeric](18, 0) NULL,
	[maxmarks] [int] NULL,
	[ExaminationType] [varchar](50) NULL,
	[ExaminationMonth] [varchar](50) NULL,
	[Stream] [int] NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[tbl_examsheets] ADD [grade] [varchar](50) NULL

GO

SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_examsheet1](
	[sessioncode] [varchar](50) NULL,
	[classname] [varchar](50) NULL,
	[studentname] [varchar](50) NULL,
	[rollno] [varchar](15) NULL,
	[quterlytest] [varchar](50) NULL,
	[obtmarks] [numeric](18, 0) NULL,
	[maxmarks] [int] NULL,
	[probtmarks] [numeric](18, 0) NULL,
	[prmaxmarks] [int] NULL,
	[halfyearly] [varchar](50) NULL,
	[obtmarks1] [numeric](18, 0) NULL,
	[maxmarks1] [int] NULL,
	[probtmarks1] [numeric](18, 0) NULL,
	[prmaxmarks1] [int] NULL,
	[yearlytest] [varchar](50) NULL,
	[obtmarks2] [numeric](18, 0) NULL,
	[maxmarks2] [int] NULL,
	[pryobtmarks] [numeric](18, 0) NULL,
	[prymaxmarks] [int] NULL,
	[suppmaxmark] [int] NULL,
	[suppobtmark] [int] NULL,
	[examsubjectno] [int] NULL,
	[examsubjectname] [varchar](50) NULL,
	[examsubjectname1] [varchar](50) NULL,
	[grade] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_calendar](
	[HolidayNo] [int] IDENTITY(1,1) NOT NULL,
	[sessionCode] [int] NULL,
	[monthName] [varchar](50) NULL,
	[date] [varchar](50) NULL,
	[holiday] [varchar](100) NULL,
	[tpyeOfHoliday] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EGradeRange](
	[Id] [int] NOT NULL,
	[Range] [nvarchar](50) NULL,
	[FromRange] [decimal](18, 2) NULL,
	[ToRange] [decimal](18, 2) NULL,
	[Grade] [varchar](3) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModfiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_EGradeRange] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EGradeRange] ADD  CONSTRAINT [DF_EGradeRange_FromRange]  DEFAULT ((0)) FOR [FromRange]
GO

ALTER TABLE [dbo].[EGradeRange] ADD  CONSTRAINT [DF_EGradeRange_ToRange]  DEFAULT ((0)) FOR [ToRange]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EGrade](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[GradeName] [varchar](50) NULL,
	[MaxPer] [decimal](18, 2) NULL,
	[MinPer] [decimal](18, 2) NULL,
	[GradePoint] [decimal](18, 2) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModfiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_EGrade] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EExam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Exam] [nvarchar](50) NULL,
	[ExamOrder] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModfiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_EExam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EMarksMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamId] [int] NOT NULL,
	[SessionId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[SectionId] [int] NULL,
	[StreamId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[IsGrade] [bit] NULL,
	[IsMarks] [bit] NULL,
	[IsGradePoint] [bit] NULL,
	[GradeId] [int] NULL,
	[MinMarks] [decimal](18, 2) NOT NULL,
	[MaxMarks] [decimal](18, 2) NOT NULL,
	[IsPractical] [bit] NOT NULL,
	[PractMax] [decimal](18, 2) NULL,
	[PractMin] [decimal](18, 2) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModfiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_EMarksMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EMarksMaster]  WITH CHECK ADD  CONSTRAINT [FK_EMarksMaster_EExam] FOREIGN KEY([ExamId])
REFERENCES [dbo].[EExam] ([Id])
GO

ALTER TABLE [dbo].[EMarksMaster] CHECK CONSTRAINT [FK_EMarksMaster_EExam]
GO

ALTER TABLE [dbo].[EMarksMaster]  WITH CHECK ADD  CONSTRAINT [FK_EMarksMaster_EGradeRange] FOREIGN KEY([GradeId])
REFERENCES [dbo].[EGrade] ([GradeId])
GO

ALTER TABLE [dbo].[EMarksMaster] CHECK CONSTRAINT [FK_EMarksMaster_EGradeRange]
GO

ALTER TABLE [dbo].[EMarksMaster] ADD  CONSTRAINT [DF_EMarksMaster_MinMarks]  DEFAULT ((0)) FOR [MinMarks]
GO

ALTER TABLE [dbo].[EMarksMaster] ADD  CONSTRAINT [DF_EMarksMaster_MaxMarks]  DEFAULT ((0)) FOR [MaxMarks]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EMarksStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MarksMasterId] [int] NOT NULL,
	[studentno] [int] NOT NULL,
	[MarksObtained] [decimal](18, 2) NULL,
	[PractMarks] [decimal](18, 2) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModfiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_EMarksStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[tbl_student_backup](
	[studentno] [int] NOT NULL,
	[scholarno] [nvarchar](50) NULL,
	[name] [varchar](30) NULL,
	[dob] [smalldatetime] NULL,
	[P_address] [varchar](70) NULL,
	[C_address] [varchar](70) NULL,
	[father] [varchar](30) NULL,
	[mother] [varchar](30) NULL,
	[fatheroccu] [varchar](30) NULL,
	[m_tongue] [char](30) NULL,
	[casttype] [varchar](15) NULL,
	[casttype_attach] [varchar](30) NULL,
	[gargian] [varchar](30) NULL,
	[relation] [varchar](30) NULL,
	[g_address] [varchar](70) NULL,
	[fatherincome] [numeric](18, 0) NULL,
	[sp_challange] [bit] NULL,
	[bloodgroup] [varchar](5) NULL,
	[busfacility] [bit] NULL,
	[univregno] [varchar](12) NULL,
	[gapcertiinclude] [bit] NULL,
	[lastschool] [varchar](100) NULL,
	[hostelfacility] [bit] NULL,
	[isbelongrural] [bit] NULL,
	[ruralinformation] [varchar](60) NULL,
	[stdtype] [varchar](50) NULL,
	[marr_status] [varchar](10) NULL,
	[lsecrollno] [varchar](12) NULL,
	[lsecyear] [varchar](50) NULL,
	[lsecresult] [varchar](12) NULL,
	[lsecmax] [smallint] NULL,
	[lsecobt] [smallint] NULL,
	[lsecperc] [numeric](6, 2) NULL,
	[lsecdiv] [varchar](50) NULL,
	[lsecsubject] [varchar](30) NULL,
	[lsecuniv] [varchar](30) NULL,
	[lba1rollno] [varchar](12) NULL,
	[lba1year] [varchar](50) NULL,
	[lba1result] [varchar](50) NULL,
	[lba1max] [smallint] NULL,
	[lba1obt] [smallint] NULL,
	[lba1perc] [numeric](6, 2) NULL,
	[lba1div] [varchar](10) NULL,
	[lba1subject] [varchar](30) NULL,
	[lba1univ] [varchar](30) NULL,
	[lba2rollno] [varchar](12) NULL,
	[lba2year] [varchar](10) NULL,
	[lba2result] [varchar](10) NULL,
	[lba2max] [smallint] NULL,
	[lba2obt] [smallint] NULL,
	[lba2perc] [numeric](5, 2) NULL,
	[lba2div] [varchar](50) NULL,
	[lba2subject] [varchar](30) NULL,
	[lb2univ] [varchar](30) NULL,
	[lba3rollno] [varchar](12) NULL,
	[lba3year] [varchar](10) NULL,
	[lba3result] [varchar](10) NULL,
	[lba3max] [smallint] NULL,
	[lba3obt] [smallint] NULL,
	[lba3perc] [numeric](6, 2) NULL,
	[lba3div] [varchar](10) NULL,
	[lba3subject] [varchar](30) NULL,
	[lba3univ] [varchar](30) NULL,
	[marollno] [varchar](12) NULL,
	[mayear] [varchar](10) NULL,
	[maresult] [varchar](10) NULL,
	[mamax] [smallint] NULL,
	[maobt] [smallint] NULL,
	[maperc] [numeric](6, 2) NULL,
	[madiv] [varchar](10) NULL,
	[masubject] [varchar](30) NULL,
	[mauniv] [varchar](30) NULL,
	[othercertificate] [varchar](30) NULL,
	[aclassno] [int] NULL,
	[relativename1] [varchar](30) NULL,
	[relativeaddress1] [varchar](60) NULL,
	[relativename2] [varchar](30) NULL,
	[relativeaddress2] [varchar](60) NULL,
	[admissiondate] [datetime] NULL,
	[barcode] [varchar](50) NULL,
	[gaurdian1] [varchar](60) NULL,
	[gaurdian2] [varchar](60) NULL,
	[guardianaddress1] [varchar](60) NULL,
	[guardianaddress2] [varchar](60) NULL,
	[studentphoto] [image] NULL,
	[guardian1photo] [image] NULL,
	[guardian2photo] [image] NULL,
	[partnername] [varchar](30) NULL,
	[distcode] [int] NULL,
	[tehcode] [int] NULL,
	[admclass] [int] NULL,
	[admfaculty] [int] NULL,
	[admsession] [int] NULL,
	[phone] [varchar](30) NULL,
	[relative1photo] [image] NULL,
	[relative2photo] [image] NULL,
	[guardian2phone] [varchar](25) NULL,
	[relative1phone] [varchar](25) NULL,
	[relative2phone] [varchar](25) NULL,
	[bldgroup] [varchar](10) NULL,
	[enrollmentno] [varchar](12) NULL,
	[StudType] [varchar](50) NULL,
	[studentimage] [image] NULL,
	[barcodeimage] [image] NULL,
	[docimage] [image] NULL,
	[BusStopNo] [varchar](10) NULL,
	[status] [varchar](50) NULL,
	[section] [varchar](50) NULL,
	[RegDate] [datetime] NULL,
	[tc_attach] [bit] NULL,
	[slc_attach] [bit] NULL,
	[marksheet_attach] [bit] NULL,
	[income_attach] [bit] NULL,
	[cast_attach] [bit] NULL,
	[sport_attach] [bit] NULL,
	[dob_attach] [bit] NULL,
	[Cast] [varchar](50) NULL,
	[SubCast] [varchar](50) NULL,
	[Religion] [varchar](50) NULL,
	[LastClass] [varchar](50) NULL,
	[BCode] [varchar](20) NULL,
	[ACNo] [nvarchar](50) NULL,
	[SSMId] [nvarchar](50) NULL,
	[IsBPL] [bit] NULL,
	[Amount] [nvarchar](50) NULL,
	[Height] [nvarchar](10) NULL,
	[Width] [nvarchar](10) NULL,
	[VisionL] [nvarchar](10) NULL,
	[VisionR] [nvarchar](10) NULL,
	[Teeth] [nvarchar](10) NULL,
	[OHygiene] [nvarchar](10) NULL,
	[House] [nvarchar](10) NULL,
	[CGPA] [nvarchar](10) NULL,
	[OGrade] [nvarchar](10) NULL,
	[Wdob] [nvarchar](max) NULL,
	[IsRTE] [bit] NOT NULL,
	[ChielId] [nvarchar](50) NULL,
	[ParentId] [nvarchar](50) NULL,
	[IsScholarship] [bit] NULL,
	[BPLNo] [nvarchar](100) NULL,
	[APPType] [nvarchar](100) NULL,
	[APPNo] [nvarchar](100) NULL,
	[APPDate] [datetime] NULL,
	[AdharNo] [nvarchar](100) NULL,
	[CatNo] [nvarchar](100) NULL,
 CONSTRAINT [PK_tbl_student_backup] PRIMARY KEY CLUSTERED 
(
	[studentno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[tbl_classstudent_backup](
	[sessioncode] [varchar](50) NOT NULL,
	[classno] [varchar](50) NOT NULL,
	[studentno] [varchar](50) NOT NULL,
	[Section] [varchar](50) NULL,
	[Stream] [varchar](50) NULL,
	[stdtype] [nvarchar](50) NULL,
	[schamount] [decimal](18, 2) NULL,
	[schappno] [nvarchar](50) NULL,
	[schstatus] [int] NULL,
	[schdisstatus] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



ALTER TABLE [dbo].[EMarksStudent]  WITH CHECK ADD  CONSTRAINT [FK_EMarksStudent_EMarksMaster] FOREIGN KEY([MarksMasterId])
REFERENCES [dbo].[EMarksMaster] ([Id])
GO

ALTER TABLE [dbo].[EMarksStudent] CHECK CONSTRAINT [FK_EMarksStudent_EMarksMaster]
GO



alter table tbl_MCCEStudentMarks alter column FA1 numeric(5,2) null
GO
alter table tbl_MCCEStudentMarks alter column FA2 numeric(5,2) null
GO
alter table tbl_MCCEStudentMarks alter column FA3 numeric(5,2) null
GO
alter table tbl_MCCEStudentMarks alter column FA4 numeric(5,2) null
GO
alter table tbl_MCCEStudentMarks alter column SA1 numeric(5,2) null
GO
alter table tbl_MCCEStudentMarks alter column SA2 numeric(5,2) null
GO
alter table tbl_MCCEStudentMarks alter column FA3 numeric(5,2) null
GO



alter table tbl_MPCCEStudentMarks alter column TERMI float null
GO
alter table tbl_MPCCEStudentMarks alter column TERMII float null
GO
alter table tbl_MPCCEStudentMarks alter column TERMIII float null
GO


alter table tbl_MPSHHSSAStudentMarks alter column TERMI numeric(5,2) null
GO
alter table tbl_MPSHHSSAStudentMarks alter column TERMII numeric(5,2) null
GO
alter table tbl_MPSHHSSAStudentMarks alter column TERMIII numeric(5,2) null
GO
alter table tbl_MPSHHSSAStudentMarks alter column TERMIP numeric(5,2) null
GO
alter table tbl_MPSHHSSAStudentMarks alter column TERMIIP numeric(5,2) null
GO
alter table tbl_MPSHHSSAStudentMarks alter column TERMIIIP numeric(5,2) null
GO


