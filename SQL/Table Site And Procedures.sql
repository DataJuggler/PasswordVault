USE [PasswordVault]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 8/2/2019 6:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Site_Delete]    Script Date: 8/2/2019 6:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Site_Delete]

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
GO
/****** Object:  StoredProcedure [dbo].[Site_FetchAll]    Script Date: 8/2/2019 6:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Site_FetchAll]

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

GO
/****** Object:  StoredProcedure [dbo].[Site_Find]    Script Date: 8/2/2019 6:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Site_Find]

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
GO
/****** Object:  StoredProcedure [dbo].[Site_Insert]    Script Date: 8/2/2019 6:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Site_Insert]

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
GO
/****** Object:  StoredProcedure [dbo].[Site_Update]    Script Date: 8/2/2019 6:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Site_Update]

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
GO
