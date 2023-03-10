USE [DesafioNet]
GO
/****** Object:  Table [dbo].[product]    Script Date: 1/22/2023 13:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name_product] [varchar](200) NOT NULL,
	[price] [real] NOT NULL,
	[brand] [varchar](200) NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[find_product]    Script Date: 1/22/2023 13:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[find_product]
@p_id_procuct int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @p_id_procuct IS NOT NULL
		Select * From dbo.product Where(id = @p_id_procuct)
	else
    -- Insert statements for procedure here
	Select * From dbo.product  Order by dbo.product.name_product
END


GO
/****** Object:  StoredProcedure [dbo].[insert_product]    Script Date: 1/22/2023 13:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_product]
@p_name_product varchar(200),
@p_brand varchar(200),
@p_price real

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SET NOCOUNT ON;
	Insert Into dbo.product(
					name_product, 
					price,
					brand,
					createdAt) 
			Values(
					@p_name_product, 
					@p_price,
					@p_brand,					
					GETDATE()) 

SELECT CAST(scope_identity() AS int)
END
GO
/****** Object:  StoredProcedure [dbo].[update_product]    Script Date: 1/22/2023 13:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[update_product]
@p_id_product int,
@p_name_product varchar(200),
@p_brand varchar(200),
@p_price real

AS
BEGIN
Declare  @id_loc int ;
Declare  @retorno bit ;
SET @retorno = 0
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

if @p_id_product IS NOT NULL
BEGIN     
    -- Insert statements for procedure here
	UPDATE dbo.product SET
            name_product =  @p_name_product, 
			brand =  @p_brand, 
			price =  @p_price, 
			updatedAt = GETDATE()
			 WHERE id = @p_id_product
	SELECT @id_loc = @@ROWCOUNT
	if @id_loc <>0
	BEGIN
		SET @retorno = 1
	END

END

SELECT CAST(@retorno AS bit)

			
END

GO
