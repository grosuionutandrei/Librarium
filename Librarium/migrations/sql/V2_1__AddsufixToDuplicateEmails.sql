USE Librarium; -- Fixed typo: Librarium
GO

-- 1. Create a Primary Key candidate
ALTER TABLE Members ADD MemberId UNIQUEIDENTIFIER NULL;
GO

UPDATE Members SET MemberId = NEWID();
GO

ALTER TABLE Members ALTER COLUMN MemberId UNIQUEIDENTIFIER NOT NULL;
GO


ALTER TABLE Members ADD IsEmailVerified BIT NOT NULL DEFAULT 1;
GO


UPDATE Members
SET
    Email = Email + '_dup_' + CAST(MemberId AS VARCHAR(36)),
    IsEmailVerified = 0
WHERE Email IN (
    SELECT Email
    FROM Members
    GROUP BY Email
    HAVING COUNT(Email) > 1
);
GO

ALTER TABLE Members ADD PhoneNumber VARCHAR(20) NULL;
GO


UPDATE Members SET PhoneNumber = 'pending';
GO

ALTER TABLE Members ALTER COLUMN PhoneNumber VARCHAR(20) NOT NULL;
GO