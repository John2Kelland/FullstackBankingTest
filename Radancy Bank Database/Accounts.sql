CREATE TABLE [dbo].[Accounts]
(
	[USERNAME] VARCHAR(20) NOT NULL, 
    [ACCOUNT_ID] NCHAR(10) NOT NULL,
    [ACCOUNT_NAME] VARCHAR(40) NOT NULL,
    [BALANCE] MONEY NOT NULL DEFAULT 100, 
    CONSTRAINT [PK_Accounts] PRIMARY KEY ([ACCOUNT_ID]), 
    CONSTRAINT [CK_Accounts_Column] CHECK (BALANCE > 0), 
    CONSTRAINT [FK_Accounts_ToTable] FOREIGN KEY ([USERNAME]) REFERENCES [Users]([USERNAME]) 
)
