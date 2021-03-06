INSERT [dbo].[Invoices] ([ID], [BillingInfo], [BillingAddress], [ShippingAddress], [OrderDate], [ShippingDate]) VALUES (10001, N'123456790-12', N'Address 1', N'Address 7', CAST(0x6E390B00 AS Date), CAST(0x86390B00 AS Date))
INSERT [dbo].[Invoices] ([ID], [BillingInfo], [BillingAddress], [ShippingAddress], [OrderDate], [ShippingDate]) VALUES (10002, N'123456790-12', N'Address 1', N'Address 7', CAST(0x6E390B00 AS Date), CAST(0x86390B00 AS Date))
INSERT [dbo].[Invoices] ([ID], [BillingInfo], [BillingAddress], [ShippingAddress], [OrderDate], [ShippingDate]) VALUES (10003, N'123456790-12', N'Address 1', N'Address 7', CAST(0x6E390B00 AS Date), CAST(0x86390B00 AS Date))
INSERT [dbo].[Invoices] ([ID], [BillingInfo], [BillingAddress], [ShippingAddress], [OrderDate], [ShippingDate]) VALUES (10004, N'123456790-12', N'Address 1', N'Address 7', CAST(0x6E390B00 AS Date), CAST(0x86390B00 AS Date))
INSERT [dbo].[Invoices] ([ID], [BillingInfo], [BillingAddress], [ShippingAddress], [OrderDate], [ShippingDate]) VALUES (10005, N'123456790-12', N'Address 1', N'Address 7', CAST(0x6E390B00 AS Date), CAST(0x86390B00 AS Date))
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (10000, N'Clothes', NULL, NULL)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (10001, N'Алишта', NULL, NULL)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (11000, N'Male', NULL, 10000)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (12000, N'Female', NULL, 10000)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (12100, N'Skirt', NULL, 12000)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (12110, N'Miniskirt', NULL, 12100)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [ParentID]) VALUES (12200, N'Blouse', NULL, 12000)

SET IDENTITY_INSERT [dbo].[Products] ON 
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (1, N'Red Blouse', NULL, 150.0000, 12200)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (2, N'Baby Clothes', NULL, 100.0000, 10000)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (3, N'Man''s Jacket (Pink)', NULL, 200.0000, 11000)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Price], [CategoryID]) VALUES (9, N'Fuchia Bloude', NULL, 100.0000, 12200)
SET IDENTITY_INSERT [dbo].[Products] OFF

SET IDENTITY_INSERT [dbo].[InvoiceDetails] ON 
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductID], [Quantity]) VALUES (1, 10001, 1, 2)
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductID], [Quantity]) VALUES (2, 10001, 3, 1)
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductID], [Quantity]) VALUES (9, 10002, 1, 6)
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductID], [Quantity]) VALUES (11, 10002, 2, 3)
SET IDENTITY_INSERT [dbo].[InvoiceDetails] OFF
