CREATE TABLE [dbo].[Transactions](
	[TransactionDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[OriginalDescription] [nvarchar](4000) NOT NULL,
	[Category] [nvarchar](1000),
	[Amount] [decimal](19, 2) NOT NULL,
	[TransactionType] [nvarchar](1000),
	[AccountName] [nvarchar](1000),
	[CreatedOn] [datetime2](7) NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[CustomCategory] [nvarchar](1000),
	[BatchId] [nvarchar](4000)
)

GO

CREATE TABLE [dbo].[TransactionsStaging](
	[TransactionDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[OriginalDescription] [nvarchar](4000) NOT NULL,
	[Category] [nvarchar](1000),
	[Amount] [decimal](19, 2) NOT NULL,
	[TransactionType] [nvarchar](1000),
	[AccountName] [nvarchar](1000),
	[CreatedOn] [datetime2](7) NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[CustomCategory] [nvarchar](1000),
	[BatchId] [nvarchar](4000)
)

GO


  alter table Transactions
	add Id int identity(1,1)

alter table TransactionsStaging
	add Id int identity(1,1)

CREATE TABLE [dbo].[Assets](
	[TransactionDate] [datetime2](7) NOT NULL,
	[Amount] [decimal](19, 2) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[BatchId] [nvarchar](4000)
)



CREATE TABLE [dbo].[Accounts](
	[TransactionDate] [datetime2](7) NOT NULL,
	[Amount] [decimal](19, 2) NOT NULL,
	[AccountName] [nvarchar](1000),
	[CreatedOn] [datetime2](7) NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[BatchId] [nvarchar](4000)
)


CREATE TABLE [dbo].[Budget](
	[CustomCategory] [nvarchar](1000),
	[Amount] [decimal](19, 2) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL
)

