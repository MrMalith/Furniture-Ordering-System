/*
   Sunday, July 21, 20192:48:14 PM
   User: 
   Server: DESKTOP-3BDK76K\SQLEXPRESS
   Database: FurnitureOrdering
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.items ADD
	qty int NULL
GO
ALTER TABLE dbo.items SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
