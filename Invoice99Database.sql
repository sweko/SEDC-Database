/****** Object:  Table [dbo].[Categories]    Script Date: 6/3/2015 6:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 6/3/2015 6:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 6/3/2015 6:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[ID] [int] NOT NULL,
	[BillingInfo] [nvarchar](max) NOT NULL,
	[BillingAddress] [nvarchar](max) NOT NULL,
	[ShippingAddress] [nvarchar](max) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[ShippingDate] [date] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/3/2015 6:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [money] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[ProductCategories]    Script Date: 6/3/2015 6:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[ProductCategories]
as
select p.ID as ProductID, p.Name as ProductName,  p.Description as ProductDescription,
	   p.Price, p.CategoryID, c.Name as CategoryName, c.ParentID
from Products p
	inner join Categories c on c.ID = p.CategoryID
GO
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (10000, N'Clothes', NULL, NULL)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (10001, N'Алишта', NULL, NULL)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (11000, N'Male', NULL, 10000)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (12000, N'Female', NULL, 10000)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (12100, N'Skirt', NULL, 12000)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (12110, N'Miniskirt', NULL, 12100)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (12200, N'Blouse', NULL, 12000)
SET IDENTITY_INSERT [dbo].[InvoiceDetails] ON 

INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductID], [Quantity]) VALUES (1, 10001, 1, 2)
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductID], [Quantity]) VALUES (2, 10001, 3, 1)
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductID], [Quantity]) VALUES (9, 10002, 1, 6)
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductID], [Quantity]) VALUES (11, 10002, 2, 3)
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductID], [Quantity]) VALUES (1009, 10003, 2, 1)
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductID], [Quantity]) VALUES (1011, 10003, 3, 100)
SET IDENTITY_INSERT [dbo].[InvoiceDetails] OFF
INSERT [dbo].[Invoices] ([ID], [BillingInfo], [BillingAddress], [ShippingAddress], [OrderDate], [ShippingDate]) VALUES (10001, N'123456790-12', N'Address 1', N'Address 7', CAST(0x6E390B00 AS Date), CAST(0x86390B00 AS Date))
INSERT [dbo].[Invoices] ([ID], [BillingInfo], [BillingAddress], [ShippingAddress], [OrderDate], [ShippingDate]) VALUES (10002, N'123456790-12', N'Address 1', N'Address 7', CAST(0x6E390B00 AS Date), CAST(0x86390B00 AS Date))
INSERT [dbo].[Invoices] ([ID], [BillingInfo], [BillingAddress], [ShippingAddress], [OrderDate], [ShippingDate]) VALUES (10003, N'123456790-12', N'Address 1', N'Address 7', CAST(0x6E390B00 AS Date), CAST(0x86390B00 AS Date))
INSERT [dbo].[Invoices] ([ID], [BillingInfo], [BillingAddress], [ShippingAddress], [OrderDate], [ShippingDate]) VALUES (10004, N'123456790-12', N'Address 1', N'Address 7', CAST(0x6E390B00 AS Date), CAST(0x86390B00 AS Date))
INSERT [dbo].[Invoices] ([ID], [BillingInfo], [BillingAddress], [ShippingAddress], [OrderDate], [ShippingDate]) VALUES (10005, N'123456790-12', N'Address 1', N'Address 7', CAST(0x6E390B00 AS Date), CAST(0x86390B00 AS Date))
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (1, N'Red Blouse (Blouse)', NULL, 150.0000, 12200)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (2, N'Baby Clothes (Clothes)', NULL, 100.0000, 10000)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (3, N'Man''s Jacket (Pink) (Male)', NULL, 200.0000, 11000)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (9, N'Fuchia Bloude (Blouse)', NULL, 100.0000, 12200)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (10, N'Red Blouse - Акција (Blouse)', NULL, 75.0000, 12200)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (11, N'Baby Clothes - Акција (Clothes)', NULL, 50.0000, 10000)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (12, N'Man''s Jacket (Pink) - Акција (Male)', NULL, 100.0000, 11000)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (13, N'Fuchia Bloude - Акција (Blouse)', NULL, 50.0000, 12200)
SET IDENTITY_INSERT [dbo].[Products] OFF
/****** Object:  Index [IX_InvoiceDetails]    Script Date: 6/3/2015 6:28:11 PM ******/
ALTER TABLE [dbo].[InvoiceDetails] ADD  CONSTRAINT [IX_InvoiceDetails] UNIQUE NONCLUSTERED 
(
	[InvoiceID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoices] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoices] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoices]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Products] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Products]
GO
