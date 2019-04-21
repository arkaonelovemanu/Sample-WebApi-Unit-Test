USE [TestDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 07/05/2016 6:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 07/05/2016 6:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Salary] [money] NULL,
	[EmailAddress] [varchar](255) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
 CONSTRAINT [PK_Employee_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

GO
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (1, N'Account')
GO
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (2, N'Developer')
GO
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (3, N'QA')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

GO
INSERT [dbo].[Employee] ([Id], [Name], [DepartmentId], [Salary], [EmailAddress], [PhoneNumber], [Address]) VALUES (1, N'Jignesh', 2, 10000.0000, N'test@gmail.com', N'123455', N'test')
GO
INSERT [dbo].[Employee] ([Id], [Name], [DepartmentId], [Salary], [EmailAddress], [PhoneNumber], [Address]) VALUES (2, N'Tejas', 2, 10000.0000, N'test@gmail.com', N'233433', N'werwerew')
GO
INSERT [dbo].[Employee] ([Id], [Name], [DepartmentId], [Salary], [EmailAddress], [PhoneNumber], [Address]) VALUES (3, N'Rakesh', 2, 10000.0000, N'test@gmail.com', N'3434343', N'rewrewre')
GO
INSERT [dbo].[Employee] ([Id], [Name], [DepartmentId], [Salary], [EmailAddress], [PhoneNumber], [Address]) VALUES (4, N'Amit', 1, 10000.0000, N'test@gmail.com', N'343232', N'erere')
GO
INSERT [dbo].[Employee] ([Id], [Name], [DepartmentId], [Salary], [EmailAddress], [PhoneNumber], [Address]) VALUES (5, N'Ashish', 3, 10000.0000, N'test@gmail.com', N'434343', N'ere')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
