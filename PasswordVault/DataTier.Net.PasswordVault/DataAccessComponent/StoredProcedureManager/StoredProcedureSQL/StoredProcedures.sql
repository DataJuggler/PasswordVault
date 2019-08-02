Use [PasswordVault]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Site_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   7/21/2019
-- Description:    Insert a new Site
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Site_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Site_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Site_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Site_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Site_Insert >>>'

    End

GO

Create PROCEDURE Site_Insert

    -- Add the parameters for the stored procedure here
    @Name nvarchar(50),
    @Password nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Site]
    ([Name],[Password])

    -- Begin Values List
    Values(@Name, @Password)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Site_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   7/21/2019
-- Description:    Update an existing Site
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Site_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Site_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Site_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Site_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Site_Update >>>'

    End

GO

Create PROCEDURE Site_Update

    -- Add the parameters for the stored procedure here
    @Id int,
    @Name nvarchar(50),
    @Password nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Site]

    -- Update Each field
    Set [Name] = @Name,
    [Password] = @Password

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Site_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   7/21/2019
-- Description:    Find an existing Site
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Site_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Site_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Site_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Site_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Site_Find >>>'

    End

GO

Create PROCEDURE Site_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[Name],[Password]

    -- From tableName
    From [Site]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Site_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   7/21/2019
-- Description:    Delete an existing Site
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Site_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Site_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Site_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Site_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Site_Delete >>>'

    End

GO

Create PROCEDURE Site_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Site]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Site_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   7/21/2019
-- Description:    Returns all Site objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Site_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Site_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Site_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Site_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Site_FetchAll >>>'

    End

GO

Create PROCEDURE Site_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[Name],[Password]

    -- From tableName
    From [Site]

END

-- Thank you for using DataTier.Net.

