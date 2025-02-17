USE [CherA]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 06.11.2024 18:11:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](50) NULL,
	[RequestID] [int] NULL,
 CONSTRAINT [PK__Comments__C3B4DFAA4A4409DB] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parts]    Script Date: 06.11.2024 18:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parts](
	[PartsID] [int] IDENTITY(1,1) NOT NULL,
	[Parts] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__Parts__1038D962F854F176] PRIMARY KEY CLUSTERED 
(
	[PartsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestStatus]    Script Date: 06.11.2024 18:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestStatus](
	[RequestStatusID] [int] IDENTITY(1,1) NOT NULL,
	[RequestStatus] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__RequestS__7094B7BB88C0F765] PRIMARY KEY CLUSTERED 
(
	[RequestStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProblemDescryption]    Script Date: 06.11.2024 18:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProblemDescryption](
	[ProblemDescryptionID] [int] IDENTITY(1,1) NOT NULL,
	[ProblemDescryption] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__ProblemD__1C8980F399DFB122] PRIMARY KEY CLUSTERED 
(
	[ProblemDescryptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClimateTechModel]    Script Date: 06.11.2024 18:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClimateTechModel](
	[ClimateTechModelID] [int] IDENTITY(1,1) NOT NULL,
	[ClimateTechModel] [nvarchar](100) NOT NULL,
	[ClimateTechTypeID] [int] NULL,
 CONSTRAINT [PK__ClimateT__D5C9E5AB046F7906] PRIMARY KEY CLUSTERED 
(
	[ClimateTechModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 06.11.2024 18:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NOT NULL,
	[ClimateTechModelID] [int] NOT NULL,
	[ProblemDescryptionID] [int] NOT NULL,
	[RequestStatusID] [int] NOT NULL,
	[CompletionData] [date] NULL,
	[RepairPartsID] [int] NULL,
	[MasterID] [int] NULL,
	[clientID] [int] NOT NULL,
 CONSTRAINT [PK__Requests__33A8519A6FF42F99] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClimateTechType]    Script Date: 06.11.2024 18:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClimateTechType](
	[ClimateTechTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ClimateTechType] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__ClimateT__F46AD04F832C3948] PRIMARY KEY CLUSTERED 
(
	[ClimateTechTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06.11.2024 18:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Patronymic] [nvarchar](20) NOT NULL,
	[Phone] [char](16) NOT NULL,
	[Login] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK__Users__1788CCACB251C017] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Request]    Script Date: 06.11.2024 18:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Request]
as
select Requests.RequestID, Requests.StartDate, ClimateTechModel.ClimateTechModel, ClimateTechType.ClimateTechType, ProblemDescryption.ProblemDescryption, 
RequestStatus.RequestStatus, Requests.CompletionData, Parts.Parts, Requests.MasterID, mast.Surname as masterSurname, Requests.clientID, clie.Surname as clientSurname, Comments.Message
from Requests left join 
ClimateTechModel on Requests.ClimateTechModelID=ClimateTechModel.ClimateTechModelID left join
ClimateTechType on ClimateTechModel.ClimateTechTypeID=ClimateTechType.ClimateTechTypeID left join
ProblemDescryption on Requests.ProblemDescryptionID=ProblemDescryption.ProblemDescryptionID left join 
RequestStatus on Requests.RequestStatusID=RequestStatus.RequestStatusID left join
Parts on Requests.RepairPartsID=Parts.PartsID left join
Users as mast on Requests.MasterID=mast.UserID left join
Users as clie on Requests.clientID=clie.UserID left join
Comments on Requests.RequestID=Comments.RequestID
GO
/****** Object:  Table [dbo].[HistoryLogin]    Script Date: 06.11.2024 18:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryLogin](
	[Login] [nvarchar](10) NOT NULL,
	[DateLogin] [date] NOT NULL,
	[Suc/NotSuc] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 06.11.2024 18:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__Type__516F039533E09026] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ClimateTechModel] ON 

INSERT [dbo].[ClimateTechModel] ([ClimateTechModelID], [ClimateTechModel], [ClimateTechTypeID]) VALUES (1, N'TCL TAC-12CHSA/TPG-W белый', 1)
INSERT [dbo].[ClimateTechModel] ([ClimateTechModelID], [ClimateTechModel], [ClimateTechTypeID]) VALUES (2, N'Electrolux EACS/I-09HAT/N3_21Y белый', 1)
INSERT [dbo].[ClimateTechModel] ([ClimateTechModelID], [ClimateTechModel], [ClimateTechTypeID]) VALUES (3, N'Xiaomi Smart Humidifier 2', 2)
INSERT [dbo].[ClimateTechModel] ([ClimateTechModelID], [ClimateTechModel], [ClimateTechTypeID]) VALUES (4, N'Polaris PUH 2300 WIFI IQ Home', 2)
INSERT [dbo].[ClimateTechModel] ([ClimateTechModelID], [ClimateTechModel], [ClimateTechTypeID]) VALUES (5, N'Ballu BAHD-1250', 3)
SET IDENTITY_INSERT [dbo].[ClimateTechModel] OFF
GO
SET IDENTITY_INSERT [dbo].[ClimateTechType] ON 

INSERT [dbo].[ClimateTechType] ([ClimateTechTypeID], [ClimateTechType]) VALUES (1, N'Кондиционер')
INSERT [dbo].[ClimateTechType] ([ClimateTechTypeID], [ClimateTechType]) VALUES (2, N'Увлажнитель воздуха')
INSERT [dbo].[ClimateTechType] ([ClimateTechTypeID], [ClimateTechType]) VALUES (3, N'Сушилка для рук')
SET IDENTITY_INSERT [dbo].[ClimateTechType] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([CommentID], [Message], [RequestID]) VALUES (1, N'dfsddfsdf', 1)
INSERT [dbo].[Comments] ([CommentID], [Message], [RequestID]) VALUES (2, N'Всё сделаем!
', 2)
INSERT [dbo].[Comments] ([CommentID], [Message], [RequestID]) VALUES (3, N'Починим в момент.', 3)
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login1', CAST(N'2024-11-03' AS Date), 1)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login6', CAST(N'2024-11-03' AS Date), 1)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login2', CAST(N'2024-11-03' AS Date), 0)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login2', CAST(N'2024-11-03' AS Date), 1)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login7', CAST(N'2024-11-03' AS Date), 1)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login6', CAST(N'2024-11-03' AS Date), 0)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login8', CAST(N'2024-11-04' AS Date), 1)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login2', CAST(N'2024-11-04' AS Date), 1)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login5', CAST(N'2024-11-04' AS Date), 1)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login1', CAST(N'2024-11-04' AS Date), 1)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login8', CAST(N'2024-11-03' AS Date), 1)
INSERT [dbo].[HistoryLogin] ([Login], [DateLogin], [Suc/NotSuc]) VALUES (N'login4', CAST(N'2024-11-04' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[Parts] ON 

INSERT [dbo].[Parts] ([PartsID], [Parts]) VALUES (1, N'Гайка')
INSERT [dbo].[Parts] ([PartsID], [Parts]) VALUES (2, N'Шуруп')
INSERT [dbo].[Parts] ([PartsID], [Parts]) VALUES (3, N'Вентильятор')
INSERT [dbo].[Parts] ([PartsID], [Parts]) VALUES (4, N'Отвертка')
INSERT [dbo].[Parts] ([PartsID], [Parts]) VALUES (5, N'Труба')
INSERT [dbo].[Parts] ([PartsID], [Parts]) VALUES (6, N'Шланг')
INSERT [dbo].[Parts] ([PartsID], [Parts]) VALUES (7, N'Крышка')
INSERT [dbo].[Parts] ([PartsID], [Parts]) VALUES (8, N'Молоток')
INSERT [dbo].[Parts] ([PartsID], [Parts]) VALUES (9, N'Защепка')
INSERT [dbo].[Parts] ([PartsID], [Parts]) VALUES (10, N'Прищепка')
SET IDENTITY_INSERT [dbo].[Parts] OFF
GO
SET IDENTITY_INSERT [dbo].[ProblemDescryption] ON 

INSERT [dbo].[ProblemDescryption] ([ProblemDescryptionID], [ProblemDescryption]) VALUES (1, N'Не охлаждает воздух')
INSERT [dbo].[ProblemDescryption] ([ProblemDescryptionID], [ProblemDescryption]) VALUES (2, N'Выключается сам по себе')
INSERT [dbo].[ProblemDescryption] ([ProblemDescryptionID], [ProblemDescryption]) VALUES (3, N'Пар имеет неприятный запах')
INSERT [dbo].[ProblemDescryption] ([ProblemDescryptionID], [ProblemDescryption]) VALUES (4, N'Увлажнитель воздуха продолжает работать при предельном снижении уровня воды')
INSERT [dbo].[ProblemDescryption] ([ProblemDescryptionID], [ProblemDescryption]) VALUES (5, N'Не работает')
SET IDENTITY_INSERT [dbo].[ProblemDescryption] OFF
GO
SET IDENTITY_INSERT [dbo].[Requests] ON 

INSERT [dbo].[Requests] ([RequestID], [StartDate], [ClimateTechModelID], [ProblemDescryptionID], [RequestStatusID], [CompletionData], [RepairPartsID], [MasterID], [clientID]) VALUES (1, CAST(N'2023-06-06' AS Date), 1, 1, 2, CAST(N'2024-11-04' AS Date), 1, 2, 7)
INSERT [dbo].[Requests] ([RequestID], [StartDate], [ClimateTechModelID], [ProblemDescryptionID], [RequestStatusID], [CompletionData], [RepairPartsID], [MasterID], [clientID]) VALUES (2, CAST(N'2023-05-05' AS Date), 5, 5, 1, NULL, NULL, 3, 8)
INSERT [dbo].[Requests] ([RequestID], [StartDate], [ClimateTechModelID], [ProblemDescryptionID], [RequestStatusID], [CompletionData], [RepairPartsID], [MasterID], [clientID]) VALUES (3, CAST(N'2022-07-07' AS Date), 3, 3, 2, CAST(N'2023-01-01' AS Date), NULL, 3, 9)
INSERT [dbo].[Requests] ([RequestID], [StartDate], [ClimateTechModelID], [ProblemDescryptionID], [RequestStatusID], [CompletionData], [RepairPartsID], [MasterID], [clientID]) VALUES (4, CAST(N'2023-08-02' AS Date), 4, 4, 3, NULL, NULL, NULL, 8)
INSERT [dbo].[Requests] ([RequestID], [StartDate], [ClimateTechModelID], [ProblemDescryptionID], [RequestStatusID], [CompletionData], [RepairPartsID], [MasterID], [clientID]) VALUES (5, CAST(N'2023-08-02' AS Date), 5, 5, 3, NULL, NULL, 3, 9)
INSERT [dbo].[Requests] ([RequestID], [StartDate], [ClimateTechModelID], [ProblemDescryptionID], [RequestStatusID], [CompletionData], [RepairPartsID], [MasterID], [clientID]) VALUES (6, CAST(N'2024-11-03' AS Date), 3, 2, 3, NULL, NULL, NULL, 6)
SET IDENTITY_INSERT [dbo].[Requests] OFF
GO
SET IDENTITY_INSERT [dbo].[RequestStatus] ON 

INSERT [dbo].[RequestStatus] ([RequestStatusID], [RequestStatus]) VALUES (1, N'В процессе ремонта')
INSERT [dbo].[RequestStatus] ([RequestStatusID], [RequestStatus]) VALUES (2, N'Готова к выдаче')
INSERT [dbo].[RequestStatus] ([RequestStatusID], [RequestStatus]) VALUES (3, N'Новая заявка')
SET IDENTITY_INSERT [dbo].[RequestStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([TypeID], [Type]) VALUES (1, N'Менеджер')
INSERT [dbo].[Type] ([TypeID], [Type]) VALUES (2, N'Специалист')
INSERT [dbo].[Type] ([TypeID], [Type]) VALUES (3, N'Оператор')
INSERT [dbo].[Type] ([TypeID], [Type]) VALUES (4, N' 
Заказчик')
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Surname], [Name], [Patronymic], [Phone], [Login], [Password], [Type]) VALUES (1, N'Широков ', N'Василий ', N'Матвеевич', N'8 921-056-31-28 ', N'login1', N'pass1', 1)
INSERT [dbo].[Users] ([UserID], [Surname], [Name], [Patronymic], [Phone], [Login], [Password], [Type]) VALUES (2, N'Кудрявцева ', N'Ева ', N'Ивановна', N'8 953-507-89-85 ', N'login2', N'pass2', 2)
INSERT [dbo].[Users] ([UserID], [Surname], [Name], [Patronymic], [Phone], [Login], [Password], [Type]) VALUES (3, N'Гончарова ', N'Ульяна ', N'Ярославовна', N'8 921-067-38-49 ', N'login3
', N'pass3', 2)
INSERT [dbo].[Users] ([UserID], [Surname], [Name], [Patronymic], [Phone], [Login], [Password], [Type]) VALUES (4, N'Гусева', N'Виктория ', N'Данииловна', N'8 999-056-37-48 ', N'login4', N'pass4', 3)
INSERT [dbo].[Users] ([UserID], [Surname], [Name], [Patronymic], [Phone], [Login], [Password], [Type]) VALUES (5, N'Баранов ', N'Артём ', N'Юрьевич', N'8 999-456-38-47 ', N'login5', N'pass5', 3)
INSERT [dbo].[Users] ([UserID], [Surname], [Name], [Patronymic], [Phone], [Login], [Password], [Type]) VALUES (6, N'Овчинников ', N'Фёдор ', N'Никитич', N'8 921-956-78-49 ', N'login6', N'pass6', 4)
INSERT [dbo].[Users] ([UserID], [Surname], [Name], [Patronymic], [Phone], [Login], [Password], [Type]) VALUES (7, N'Петров', N'Никита ', N'Артёмович', N'8 921-956-78-41 ', N'login7', N'pass7', 4)
INSERT [dbo].[Users] ([UserID], [Surname], [Name], [Patronymic], [Phone], [Login], [Password], [Type]) VALUES (8, N'Ковалева', N'Софья ', N'Владимировна', N'8 921-956-78-42 ', N'login8', N'pass8', 4)
INSERT [dbo].[Users] ([UserID], [Surname], [Name], [Patronymic], [Phone], [Login], [Password], [Type]) VALUES (9, N'Кузнецов ', N'Сергей ', N'Матвеевич', N'8 921-956-78-43 ', N'login9', N'pass9', 4)
INSERT [dbo].[Users] ([UserID], [Surname], [Name], [Patronymic], [Phone], [Login], [Password], [Type]) VALUES (10, N'Беспалова ', N'Екатерина ', N'Даниэльевна', N'8 921-956-78-44 ', N'login10', N'pass10', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[ClimateTechModel]  WITH CHECK ADD  CONSTRAINT [FK_ClimateTechModel_ClimateTechType] FOREIGN KEY([ClimateTechTypeID])
REFERENCES [dbo].[ClimateTechType] ([ClimateTechTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClimateTechModel] CHECK CONSTRAINT [FK_ClimateTechModel_ClimateTechType]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Requests] FOREIGN KEY([RequestID])
REFERENCES [dbo].[Requests] ([RequestID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Requests]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_ClimateTechModel] FOREIGN KEY([ClimateTechModelID])
REFERENCES [dbo].[ClimateTechModel] ([ClimateTechModelID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_ClimateTechModel]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Parts] FOREIGN KEY([RepairPartsID])
REFERENCES [dbo].[Parts] ([PartsID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Parts]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_ProblemDescryption] FOREIGN KEY([ProblemDescryptionID])
REFERENCES [dbo].[ProblemDescryption] ([ProblemDescryptionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_ProblemDescryption]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_RequestStatus] FOREIGN KEY([RequestStatusID])
REFERENCES [dbo].[RequestStatus] ([RequestStatusID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_RequestStatus]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Users] FOREIGN KEY([MasterID])
REFERENCES [dbo].[Users] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Users]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Users1] FOREIGN KEY([clientID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Users1]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Type] FOREIGN KEY([Type])
REFERENCES [dbo].[Type] ([TypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Type]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK__Users__Phone__05D8E0BE] CHECK  (([Phone] like '8 [0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK__Users__Phone__05D8E0BE]
GO
