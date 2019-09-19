CREATE TABLE [dbo].[Register] (
    [username]  VARCHAR (20) NOT NULL,
    [password]  VARCHAR (20) NOT NULL,
    [address]   VARCHAR (20) NULL,
    [mobile_no] INT          NULL,
    CONSTRAINT [PK_Register] PRIMARY KEY CLUSTERED ([username] ASC)
);

