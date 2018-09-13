

 
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

ALTER TABLE [dbo].[EMarksStudent]  WITH CHECK ADD  CONSTRAINT [FK_EMarksStudent_EMarksMaster] FOREIGN KEY([MarksMasterId])
REFERENCES [dbo].[EMarksMaster] ([Id])
GO

ALTER TABLE [dbo].[EMarksStudent] CHECK CONSTRAINT [FK_EMarksStudent_EMarksMaster]
GO

