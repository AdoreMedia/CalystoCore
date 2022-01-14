USE [dbCalystoUnittest]
GO
/****** Object:  StoredProcedure [dbo].[spSysRebuildAllIndexes]    Script Date: 2020-08-13 23:12:15 ******/
DROP PROCEDURE [dbo].[spSysRebuildAllIndexes]
GO
/****** Object:  StoredProcedure [dbo].[spRandomNumber]    Script Date: 2020-08-13 23:12:15 ******/
DROP PROCEDURE [dbo].[spRandomNumber]
GO
/****** Object:  StoredProcedure [dbo].[spNoTablesResults]    Script Date: 2020-08-13 23:12:15 ******/
DROP PROCEDURE [dbo].[spNoTablesResults]
GO
/****** Object:  StoredProcedure [dbo].[spMultiResults]    Script Date: 2020-08-13 23:12:15 ******/
DROP PROCEDURE [dbo].[spMultiResults]
GO
/****** Object:  StoredProcedure [dbo].[spGetBillClientSaldo]    Script Date: 2020-08-13 23:12:15 ******/
DROP PROCEDURE [dbo].[spGetBillClientSaldo]
GO
/****** Object:  StoredProcedure [dbo].[spGetAppMembers]    Script Date: 2020-08-13 23:12:15 ******/
DROP PROCEDURE [dbo].[spGetAppMembers]
GO
ALTER TABLE [dbo].[tblAppMobileLog] DROP CONSTRAINT [FK_AppMobileLog_AppMember]
GO
ALTER TABLE [dbo].[tblAppMemberPicture2] DROP CONSTRAINT [FK_tblAppMemberPicture2_tblAppMember]
GO
ALTER TABLE [dbo].[tblAppMemberPicture] DROP CONSTRAINT [FK_AppMemberPicture_AppMember]
GO
ALTER TABLE [dbo].[tblAppMemberPermission] DROP CONSTRAINT [FK_AppMemberPermission_AppPermission]
GO
ALTER TABLE [dbo].[tblAppMemberPermission] DROP CONSTRAINT [FK_AppMemberPermission_AppMember]
GO
ALTER TABLE [dbo].[tblAppMember2] DROP CONSTRAINT [FK_AppMember_AppMemberStatus2]
GO
ALTER TABLE [dbo].[tblAppMember] DROP CONSTRAINT [FK_AppMember_AppMemberStatus]
GO
ALTER TABLE [dbo].[tblAppMemberStatus] DROP CONSTRAINT [DF_MemberStatus_IsActive]
GO
ALTER TABLE [dbo].[tblAppMember2] DROP CONSTRAINT [DF_AppMember_LoginsCount2]
GO
ALTER TABLE [dbo].[tblAppMember] DROP CONSTRAINT [DF_AppMember_LoginsCount]
GO
/****** Object:  Table [dbo].[tblAppPermission]    Script Date: 2020-08-13 23:12:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAppPermission]') AND type in (N'U'))
DROP TABLE [dbo].[tblAppPermission]
GO
/****** Object:  Table [dbo].[tblAppNewsletter]    Script Date: 2020-08-13 23:12:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAppNewsletter]') AND type in (N'U'))
DROP TABLE [dbo].[tblAppNewsletter]
GO
/****** Object:  Table [dbo].[tblAppMobileLogKind]    Script Date: 2020-08-13 23:12:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAppMobileLogKind]') AND type in (N'U'))
DROP TABLE [dbo].[tblAppMobileLogKind]
GO
/****** Object:  Table [dbo].[tblAppMobileLog]    Script Date: 2020-08-13 23:12:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAppMobileLog]') AND type in (N'U'))
DROP TABLE [dbo].[tblAppMobileLog]
GO
/****** Object:  Table [dbo].[tblAppMemberStatus]    Script Date: 2020-08-13 23:12:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAppMemberStatus]') AND type in (N'U'))
DROP TABLE [dbo].[tblAppMemberStatus]
GO
/****** Object:  Table [dbo].[tblAppMemberPicture2]    Script Date: 2020-08-13 23:12:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAppMemberPicture2]') AND type in (N'U'))
DROP TABLE [dbo].[tblAppMemberPicture2]
GO
/****** Object:  Table [dbo].[tblAppMemberPicture]    Script Date: 2020-08-13 23:12:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAppMemberPicture]') AND type in (N'U'))
DROP TABLE [dbo].[tblAppMemberPicture]
GO
/****** Object:  Table [dbo].[tblAppMemberPermission]    Script Date: 2020-08-13 23:12:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAppMemberPermission]') AND type in (N'U'))
DROP TABLE [dbo].[tblAppMemberPermission]
GO
/****** Object:  Table [dbo].[tblAppMember2]    Script Date: 2020-08-13 23:12:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAppMember2]') AND type in (N'U'))
DROP TABLE [dbo].[tblAppMember2]
GO
/****** Object:  Table [dbo].[tblAppMember]    Script Date: 2020-08-13 23:12:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAppMember]') AND type in (N'U'))
DROP TABLE [dbo].[tblAppMember]
GO
/****** Object:  View [dbo].[viewRandom]    Script Date: 2020-08-13 23:12:15 ******/
DROP VIEW [dbo].[viewRandom]
GO
/****** Object:  UserDefinedFunction [dbo].[fnSumNumbers]    Script Date: 2020-08-13 23:12:15 ******/
DROP FUNCTION [dbo].[fnSumNumbers]
GO
/****** Object:  UserDefinedFunction [dbo].[fnSplitStringByPattern]    Script Date: 2020-08-13 23:12:15 ******/
DROP FUNCTION [dbo].[fnSplitStringByPattern]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetStariNoviGranica]    Script Date: 2020-08-13 23:12:15 ******/
DROP FUNCTION [dbo].[fnGetStariNoviGranica]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetRandomIntegerValue]    Script Date: 2020-08-13 23:12:15 ******/
DROP FUNCTION [dbo].[fnGetRandomIntegerValue]
GO
/****** Object:  UserDefinedFunction [dbo].[fnFormatDateToStringISO]    Script Date: 2020-08-13 23:12:15 ******/
DROP FUNCTION [dbo].[fnFormatDateToStringISO]
GO
/****** Object:  UserDefinedFunction [dbo].[fnConvertCsvArgsToIntTable]    Script Date: 2020-08-13 23:12:15 ******/
DROP FUNCTION [dbo].[fnConvertCsvArgsToIntTable]
GO
/****** Object:  UserDefinedFunction [dbo].[fnCalculateDatumValuteRokPlacanja]    Script Date: 2020-08-13 23:12:15 ******/
DROP FUNCTION [dbo].[fnCalculateDatumValuteRokPlacanja]
GO
/****** Object:  UserDefinedFunction [dbo].[fnAddPaddingSpace]    Script Date: 2020-08-13 23:12:15 ******/
DROP FUNCTION [dbo].[fnAddPaddingSpace]
GO
/****** Object:  UserDefinedFunction [dbo].[fnAddPaddingSpace]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
select dbo.fnAddPaddingChars(null, 17, 'ktemny', null)
select dbo.fnAddPaddingChars(null, 17, null, 'ktemny')
select dbo.fnAddPaddingChars('bjuielewqrtyewer', 7, null, null)
space can not be @prefix or @sufix since SQL ignores empty space
*/
CREATE FUNCTION [dbo].[fnAddPaddingSpace]
(
	@str nvarchar(max),
	@expectedLength int,
	@addPrefix bit
)
RETURNS nvarchar(max)
AS
BEGIN
	
	if(@str is null)
		set @str = '';

	if(@addPrefix = 1)
	begin
		while(len(@str) < @expectedLength)
			set @str = ' ' + @str;
		-- trim from start to expected length
		return substring(@str, 1 + len(@str) - @expectedLength, @expectedLength);
	end
	else if(@addPrefix = 0)
	begin
		while(len(@str) < @expectedLength)
			set @str = @str + ' ';
		-- trim to expected length
		return substring(@str, 1, @expectedLength);
	end

	return dbo.fnThrowErrorMessage(
		null, 
		N'Invalid argument, eigher @prefix or @sufix has to be defined, @expectedLength: ' + cast(@expectedLength as varchar) + ', @str: ' + @str, 
		null
	);

END
GO
/****** Object:  UserDefinedFunction [dbo].[fnCalculateDatumValuteRokPlacanja]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	select * from dbo.fnCalculateDatumValuteRokPlacanja()
*/
create FUNCTION [dbo].[fnCalculateDatumValuteRokPlacanja]
(
)
RETURNS 
@result1 TABLE 
(
	DatumDokumenta datetime not null,
	DatumValute datetime not null,
	DatumDospijeca datetime not null
)
AS
BEGIN

		declare @datumDokumenta datetime = dateadd(hour, 10, cast(cast(getdate() as date) as datetime));
		-- pronaci prvi prethodni radni dan, ako nije radni dan
		while(datepart(weekday, @datumDokumenta) in (1, 7)) 
		set @datumDokumenta = @datumDokumenta - 1;

		declare @datumDospijeca datetime = dateadd(hour, 15, cast(cast(getdate() as date) as datetime)) + 14;
		-- pronaci prvi sljedeci radni dan, ako nije radni dan
		while(datepart(weekday, @datumDospijeca) in (1, 7)) 
		set @datumDospijeca = @datumDospijeca + 1;
	
	insert into @result1 (DatumDokumenta, DatumValute, DatumDospijeca)
	select @datumDokumenta, @datumDokumenta, @datumDospijeca

	RETURN 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fnConvertCsvArgsToIntTable]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
--	select * from dbo.fnConvertCsvArgsToIntTable('2, 5, 8, 11')
-- =============================================
CREATE FUNCTION [dbo].[fnConvertCsvArgsToIntTable]
(
	@list nvarchar(MAX)
)
RETURNS @tbl TABLE (number int not null) AS
BEGIN
   DECLARE @pos        int,
           @nextpos    int,
           @valuelen   int,
		   @intval int,
		   @strval varchar(100)

   SELECT @pos = 0, @nextpos = 1
   
   set @list = REPLACE(@list, ' ', ''); -- remove any white space

   WHILE @nextpos > 0
   BEGIN
      SELECT @nextpos = charindex(',', @list, @pos + 1)
      SELECT @valuelen = CASE WHEN @nextpos > 0
                              THEN @nextpos
                              ELSE len(@list) + 1
								END - @pos - 1
		SELECT @strval = LTRIM(RTRIM(substring(@list, @pos + 1, @valuelen)));
		SELECT @intval = convert(int, @strval); -- convert(int, '') vraca 0, zato treba provjeriti @intval == @strval
		IF(cast(@intval as varchar(100)) = @strval) 
		begin
			INSERT @tbl (number) VALUES (@intval);
		end
      SELECT @pos = @nextpos
   END
   RETURN
END



GO
/****** Object:  UserDefinedFunction [dbo].[fnFormatDateToStringISO]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnFormatDateToStringISO]
(
	@value datetime
)
returns varchar(50)
as
begin
	if(@value is null) return null;
	--return replace(convert(varchar(50), @value, 111), '/', '-'); -- 111: format yyyy/mm/dd
	return format(@value, 'yyyy-MM-dd'); -- novo u sql 2016
end
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetRandomIntegerValue]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	select dbo.fnGetRandomIntegerValue('22, 42, 12, 843')
*/
CREATE FUNCTION [dbo].[fnGetRandomIntegerValue] 
(
	@csvValues varchar(max)
)
RETURNS int
AS
BEGIN

	declare @variants table(number int);

	insert into @variants
	select number from dbo.fnConvertCsvArgsToIntTable(@csvValues)

	declare @rnd1 int = (select * from viewRandom) * (select count(1) from @variants) + 1;

	declare @var1 int = (
		select t2.number from (
			select ROW_NUMBER() over (order by t1.number) as RowNum, t1.*
			from @variants t1
		) t2
		where t2.RowNum = @rnd1
	)

	return @var1;

END
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetStariNoviGranica]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	select * from dbo.fnGetStariNoviGranica()
*/
create FUNCTION [dbo].[fnGetStariNoviGranica]
(
)
RETURNS 
@result1 TABLE 
(
	StartDate datetime not null,
	EndDate datetime not null
)
AS
BEGIN
	-- Fill the table variable with the rows for your result set
		if(DB_NAME() = 'dbArizonaApp')
			insert into @result1 values ('2018-01-01', '2220-04-02 23:59');
		else if(DB_NAME() = 'dbPoduzetnikApp')
			insert into @result1 values ('2020-04-03', '2220-01-01 23:59');
		else
			declare @err1 float = dbo.fnThrowErrorMessage(100, 'database not supported', 'database not found');

	RETURN 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fnSplitStringByPattern]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	select * from dbo.fnSplitStringByPattern('hešđčllo hšđčow are yšđčou today 1234 todšđčay 1234 hello', 'šđč')
	select * from dbo.fnSplitStringByPattern('hešđčllo hšđčow are yšđčou today 1234 todšđčay 1234 hello', ' ')
	select * from dbo.fnSplitStringByPattern('hešđčllo hšđčow  are yšđčou  today 1234  todšđčay  1234 hello', '  ')
*/
CREATE FUNCTION [dbo].[fnSplitStringByPattern]
(
	@strToSplit varchar(max),
	@pattern varchar(100)
)
RETURNS @tbl TABLE (
	position int IDENTITY(1,1) NOT NULL,
	part varchar(max)
) AS
BEGIN
   
	declare @nextpos int;
	declare @strval varchar(max);
	declare @tmpstr varchar(max) = @strToSplit;
	declare @len int = datalength(@pattern); -- works with spaces: '   ', while len('   ') gives 0
   
   while @len > 0
   begin
		
		set @nextpos = charindex(@pattern, @tmpstr);
		--set @nextpos = patindex(@pattern, @tmpstr); -- doesn't work
		
		if(@nextpos > 1)
		begin
			-- @pattern found
			set @strval = substring(@tmpstr, 1, @nextpos - 1);
		
			insert into @tbl (part) values (@strval);
		
			set @tmpstr = substring(@tmpstr, 1 + datalength(@strval) + datalength(@pattern), datalength(@tmpstr));
			
		end
		else if(@nextpos > 0)
		begin
			-- @pattern is at the begining of the string
			set @tmpstr = substring(@tmpstr, 1 + datalength(@pattern), datalength(@tmpstr));
		end
		else
		begin
			-- @pattern not found, use the rest
			
			if(datalength(@tmpstr) > 0)
				insert into @tbl (part) values (@tmpstr);

			break; -- break from while 1 = 1
		end

	end 

	return;

end
GO
/****** Object:  UserDefinedFunction [dbo].[fnSumNumbers]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
--	select dbo.fnSumNumbers(2, 5)
-- =============================================
CREATE FUNCTION [dbo].[fnSumNumbers]
(
	@num1 float,
	@num2 float
)
RETURNS float
AS
BEGIN
	
	return @num1 + @num2;

END
GO
/****** Object:  View [dbo].[viewRandom]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create VIEW [dbo].[viewRandom]
AS
	select rand(cast(newid() as varbinary)) as Random
GO
/****** Object:  Table [dbo].[tblAppMember]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppMember](
	[AppMemberID] [int] IDENTITY(1,1) NOT NULL,
	[AppMemberStatusID] [int] NOT NULL,
	[MSISDN] [varchar](15) NULL,
	[FacebookId] [varchar](50) NULL,
	[GoogleId] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[BirthDate] [datetime] NULL,
	[CreationDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[LoginsCount] [int] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Gender] [varchar](10) NULL,
	[PersonalNote] [nvarchar](1000) NULL,
	[WebUrl] [varchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[City] [nvarchar](250) NULL,
	[Country] [nvarchar](250) NULL,
	[IP] [varchar](50) NULL,
	[PosFirmaID] [int] NULL,
	[ReferentNote] [nvarchar](1000) NULL,
	[IsQuizQuestionsEditor] [bit] NULL,
 CONSTRAINT [PK_AppMember] PRIMARY KEY CLUSTERED 
(
	[AppMemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppMember2]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppMember2](
	[AppMemberID] [int] NOT NULL,
	[AppMemberStatusID] [int] NOT NULL,
	[MSISDN] [varchar](15) NULL,
	[FacebookId] [varchar](50) NULL,
	[GoogleId] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[BirthDate] [datetime] NULL,
	[CreationDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[LoginsCount] [int] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Gender] [varchar](10) NULL,
	[PersonalNote] [nvarchar](1000) NULL,
	[WebUrl] [varchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[City] [nvarchar](250) NULL,
	[Country] [nvarchar](250) NULL,
	[IP] [varchar](50) NULL,
	[PosFirmaID] [int] NULL,
	[ReferentNote] [nvarchar](1000) NULL,
	[IsQuizQuestionsEditor] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppMemberPermission]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppMemberPermission](
	[AppPermissionID] [int] NOT NULL,
	[AppMemberID] [int] NOT NULL,
	[DateInserted] [datetime] NOT NULL,
	[InsertedByAppMemberID] [int] NULL,
 CONSTRAINT [PK_AppMemberPermission] PRIMARY KEY CLUSTERED 
(
	[AppPermissionID] ASC,
	[AppMemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppMemberPicture]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppMemberPicture](
	[AppMemberPictureID] [int] IDENTITY(1,1) NOT NULL,
	[AppMemberID] [int] NULL,
	[InsertionDate] [datetime] NULL,
	[FileName] [nvarchar](500) NULL,
	[ImageData] [varbinary](max) NULL,
	[ImageMimeType] [varchar](20) NULL,
	[ThumbData] [varbinary](max) NULL,
	[ThumbMimeType] [varchar](20) NULL,
 CONSTRAINT [PK_AppMemberPicture] PRIMARY KEY CLUSTERED 
(
	[AppMemberPictureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppMemberPicture2]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppMemberPicture2](
	[AppMemberPictureID] [int] IDENTITY(1,1) NOT NULL,
	[AppMemberID] [int] NULL,
	[InsertionDate] [datetime] NULL,
	[ImageData] [image] NULL,
	[ThumbData] [image] NULL,
	[FileName] [nvarchar](500) NULL,
	[ImageMimeType] [varchar](20) NULL,
	[ThumbMimeType] [varchar](20) NULL,
 CONSTRAINT [PK_tblAppMemberPicture2] PRIMARY KEY CLUSTERED 
(
	[AppMemberPictureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppMemberStatus]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppMemberStatus](
	[AppMemberStatusID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_AppMemberStatus] PRIMARY KEY CLUSTERED 
(
	[AppMemberStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppMobileLog]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppMobileLog](
	[ServerDate] [datetime] NOT NULL,
	[MobileDate] [datetime] NULL,
	[IMEI] [varchar](50) NULL,
	[MSISDN] [varchar](20) NULL,
	[AppMobileLogKindID] [int] NULL,
	[AppMemberID] [int] NULL,
	[CurrentUrl] [varchar](255) NULL,
	[RemainingChargePercent] [int] NULL,
	[PowerSource] [varchar](50) NULL,
	[BatteryStatus] [varchar](50) NULL,
	[SubscriberId] [varchar](50) NULL,
	[NetworkType] [varchar](50) NULL,
	[PhoneType] [varchar](50) NULL,
	[SimState] [varchar](50) NULL,
	[NetworkOperator] [varchar](50) NULL,
	[LocationDate] [datetime] NULL,
	[LocationError] [varchar](200) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[AccuracyMeters] [float] NULL,
	[Address] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppMobileLogKind]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppMobileLogKind](
	[AppMobileLogKindID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AppMobileLogKind] PRIMARY KEY CLUSTERED 
(
	[AppMobileLogKindID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppNewsletter]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppNewsletter](
	[Email] [varchar](150) NOT NULL,
	[InsertionDate] [datetime] NOT NULL,
	[SubscribeDate] [datetime] NULL,
	[UnsubscribeDate] [datetime] NULL,
	[IsSubscribed] [bit] NOT NULL,
 CONSTRAINT [PK_AppNewsletter_1] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppPermission]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppPermission](
	[AppPermissionID] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[GroupName] [nvarchar](50) NULL,
	[Ordinal] [int] NULL,
 CONSTRAINT [PK_AppPermission] PRIMARY KEY CLUSTERED 
(
	[AppPermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblAppMember] ON 
GO
INSERT [dbo].[tblAppMember] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (2, 200, NULL, NULL, NULL, N'mail@fsda.com', N'bnerew', N'fyyrewq', NULL, NULL, CAST(N'2017-10-08T23:31:21.520' AS DateTime), 182, N'Imbro', N'432632', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (17, 100, NULL, NULL, NULL, N'memo@nn.com', N'tare', N'ahs4252', NULL, NULL, CAST(N'2017-05-19T13:18:13.807' AS DateTime), 12, N'Jovo', N'Ante', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (18, 50, NULL, NULL, NULL, N'evi@htj.com', N'amebbs', N'432hsd', NULL, NULL, CAST(N'2017-10-07T11:23:33.250' AS DateTime), 19, N'Jovan', N'Ahoj', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (19, 50, NULL, NULL, NULL, N'toto@mbds.com', N'adhas', N'has432', NULL, NULL, CAST(N'2017-10-17T17:10:37.693' AS DateTime), 18, N'Daria', N'Nesto', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (20, 50, NULL, NULL, NULL, N'tomba@fsa.rh', N'hsadf532', N'juert634', NULL, NULL, CAST(N'2017-03-10T12:00:34.763' AS DateTime), 16, N'Antonija', N'Timba', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (21, 50, NULL, NULL, NULL, N'hr@htr.cm', N'surewt43', N'asgh24123', NULL, NULL, CAST(N'2017-10-17T16:18:32.197' AS DateTime), 49, N'Juliana', N'Bumds', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (22, 50, NULL, NULL, NULL, N'mm@nyyws.com', N'user56234', N'aghh', NULL, NULL, CAST(N'2017-06-27T15:58:09.023' AS DateTime), 10, N'Ivan', N'Urew', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (24, 50, NULL, NULL, NULL, N'aier.ag@fsa.fs', N'user23432', N'523432', NULL, NULL, CAST(N'2017-10-10T10:38:42.540' AS DateTime), 24, N'Marko', N'Antisa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tblAppMember] OFF
GO
INSERT [dbo].[tblAppMember2] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (2, 200, NULL, NULL, NULL, N'mail@fsda.com', N'bnerew', N'fyyrewq', NULL, NULL, CAST(N'2017-10-08T23:31:21.520' AS DateTime), 182, N'Imbro', N'432632', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember2] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (17, 100, NULL, NULL, NULL, N'memo@nn.com', N'tare', N'ahs4252', NULL, NULL, CAST(N'2017-05-19T13:18:13.807' AS DateTime), 12, N'Jovo', N'Ante', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember2] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (18, 50, NULL, NULL, NULL, N'evi@htj.com', N'amebbs', N'432hsd', NULL, NULL, CAST(N'2017-10-07T11:23:33.250' AS DateTime), 19, N'Jovan', N'Ahoj', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember2] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (19, 50, NULL, NULL, NULL, N'toto@mbds.com', N'adhas', N'has432', NULL, NULL, CAST(N'2017-10-17T17:10:37.693' AS DateTime), 18, N'Daria', N'Nesto', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember2] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (20, 50, NULL, NULL, NULL, N'tomba@fsa.rh', N'hsadf532', N'juert634', NULL, NULL, CAST(N'2017-03-10T12:00:34.763' AS DateTime), 16, N'Antonija', N'Timba', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember2] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (21, 50, NULL, NULL, NULL, N'hr@htr.cm', N'surewt43', N'asgh24123', NULL, NULL, CAST(N'2017-10-17T16:18:32.197' AS DateTime), 49, N'Juliana', N'Bumds', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember2] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (22, 50, NULL, NULL, NULL, N'mm@nyyws.com', N'user56234', N'aghh', NULL, NULL, CAST(N'2017-06-27T15:58:09.023' AS DateTime), 10, N'Ivan', N'Urew', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMember2] ([AppMemberID], [AppMemberStatusID], [MSISDN], [FacebookId], [GoogleId], [Email], [Username], [Password], [BirthDate], [CreationDate], [LastLoginDate], [LoginsCount], [FirstName], [LastName], [Gender], [PersonalNote], [WebUrl], [Address], [ZipCode], [City], [Country], [IP], [PosFirmaID], [ReferentNote], [IsQuizQuestionsEditor]) VALUES (24, 50, NULL, NULL, NULL, N'aier.ag@fsa.fs', N'user23432', N'523432', NULL, NULL, CAST(N'2017-10-10T10:38:42.540' AS DateTime), 24, N'Marko', N'Antisa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblAppMemberPermission] ([AppPermissionID], [AppMemberID], [DateInserted], [InsertedByAppMemberID]) VALUES (1, 21, CAST(N'2017-03-15T12:20:47.847' AS DateTime), 2)
GO
INSERT [dbo].[tblAppMemberPermission] ([AppPermissionID], [AppMemberID], [DateInserted], [InsertedByAppMemberID]) VALUES (2, 21, CAST(N'2017-03-15T12:20:47.847' AS DateTime), 2)
GO
INSERT [dbo].[tblAppMemberPermission] ([AppPermissionID], [AppMemberID], [DateInserted], [InsertedByAppMemberID]) VALUES (3, 21, CAST(N'2017-03-15T12:20:47.847' AS DateTime), 2)
GO
INSERT [dbo].[tblAppMemberPermission] ([AppPermissionID], [AppMemberID], [DateInserted], [InsertedByAppMemberID]) VALUES (3, 22, CAST(N'2017-03-24T15:41:45.007' AS DateTime), 2)
GO
INSERT [dbo].[tblAppMemberPermission] ([AppPermissionID], [AppMemberID], [DateInserted], [InsertedByAppMemberID]) VALUES (8, 21, CAST(N'2017-03-15T12:20:47.847' AS DateTime), 2)
GO
INSERT [dbo].[tblAppMemberPermission] ([AppPermissionID], [AppMemberID], [DateInserted], [InsertedByAppMemberID]) VALUES (8, 22, CAST(N'2017-03-24T15:41:45.007' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[tblAppMemberPicture] ON 
GO
INSERT [dbo].[tblAppMemberPicture] ([AppMemberPictureID], [AppMemberID], [InsertionDate], [FileName], [ImageData], [ImageMimeType], [ThumbData], [ThumbMimeType]) VALUES (64, 20, CAST(N'2016-12-06T14:47:50.733' AS DateTime), N'fotka.jpg', NULL, N'image/jpeg', NULL, N'image/jpeg')
GO
INSERT [dbo].[tblAppMemberPicture] ([AppMemberPictureID], [AppMemberID], [InsertionDate], [FileName], [ImageData], [ImageMimeType], [ThumbData], [ThumbMimeType]) VALUES (66, 2, CAST(N'2017-03-13T02:09:39.993' AS DateTime), N'prod_381.jpg', NULL, N'image/jpeg', NULL, N'image/jpeg')
GO
INSERT [dbo].[tblAppMemberPicture] ([AppMemberPictureID], [AppMemberID], [InsertionDate], [FileName], [ImageData], [ImageMimeType], [ThumbData], [ThumbMimeType]) VALUES (67, 17, CAST(N'2017-03-14T21:34:11.583' AS DateTime), N'prod_306.jpg', NULL, N'image/jpeg', NULL, N'image/jpeg')
GO
INSERT [dbo].[tblAppMemberPicture] ([AppMemberPictureID], [AppMemberID], [InsertionDate], [FileName], [ImageData], [ImageMimeType], [ThumbData], [ThumbMimeType]) VALUES (69, 19, CAST(N'2017-03-14T21:34:29.880' AS DateTime), N'prod_311.jpg', NULL, N'image/jpeg', NULL, N'image/jpeg')
GO
INSERT [dbo].[tblAppMemberPicture] ([AppMemberPictureID], [AppMemberID], [InsertionDate], [FileName], [ImageData], [ImageMimeType], [ThumbData], [ThumbMimeType]) VALUES (70, 21, CAST(N'2017-03-15T12:20:30.203' AS DateTime), N'prod_525.jpg', NULL, N'image/jpeg', NULL, N'image/jpeg')
GO
INSERT [dbo].[tblAppMemberPicture] ([AppMemberPictureID], [AppMemberID], [InsertionDate], [FileName], [ImageData], [ImageMimeType], [ThumbData], [ThumbMimeType]) VALUES (73, 22, CAST(N'2017-07-25T09:49:59.130' AS DateTime), N'Snapshot_20150918_2.JPG', NULL, N'image/jpeg', NULL, N'image/jpeg')
GO
SET IDENTITY_INSERT [dbo].[tblAppMemberPicture] OFF
GO
INSERT [dbo].[tblAppMemberStatus] ([AppMemberStatusID], [IsActive], [Name], [Description]) VALUES (5, 1, N'Forbidden', NULL)
GO
INSERT [dbo].[tblAppMemberStatus] ([AppMemberStatusID], [IsActive], [Name], [Description]) VALUES (10, 1, N'Customer', NULL)
GO
INSERT [dbo].[tblAppMemberStatus] ([AppMemberStatusID], [IsActive], [Name], [Description]) VALUES (40, 1, N'JobCompanyReferent', NULL)
GO
INSERT [dbo].[tblAppMemberStatus] ([AppMemberStatusID], [IsActive], [Name], [Description]) VALUES (50, 1, N'StellaReferent', NULL)
GO
INSERT [dbo].[tblAppMemberStatus] ([AppMemberStatusID], [IsActive], [Name], [Description]) VALUES (100, 1, N'Administrator', NULL)
GO
INSERT [dbo].[tblAppMemberStatus] ([AppMemberStatusID], [IsActive], [Name], [Description]) VALUES (200, 1, N'SuperAdmin', NULL)
GO
INSERT [dbo].[tblAppMobileLogKind] ([AppMobileLogKindID], [Name]) VALUES (5, N'LocationReport')
GO
INSERT [dbo].[tblAppMobileLogKind] ([AppMobileLogKindID], [Name]) VALUES (6, N'ManualLocationReport')
GO
INSERT [dbo].[tblAppMobileLogKind] ([AppMobileLogKindID], [Name]) VALUES (10, N'PageLoaded')
GO
INSERT [dbo].[tblAppMobileLogKind] ([AppMobileLogKindID], [Name]) VALUES (100, N'WheelGameOpen')
GO
INSERT [dbo].[tblAppMobileLogKind] ([AppMobileLogKindID], [Name]) VALUES (110, N'WheelGameSpinStart')
GO
INSERT [dbo].[tblAppMobileLogKind] ([AppMobileLogKindID], [Name]) VALUES (120, N'WheelGameSpinResult')
GO
SET IDENTITY_INSERT [dbo].[tblAppPermission] ON 
GO
INSERT [dbo].[tblAppPermission] ([AppPermissionID], [IsActive], [Name], [Description], [GroupName], [Ordinal]) VALUES (1, 1, N'knjiziNovuUplatu', N'- omogućava knjiženje uplate na Financije -> Knjiži uplatu 
- generiranje exporta računa na Financije -> Export računa', N'Administrativno', NULL)
GO
INSERT [dbo].[tblAppPermission] ([AppPermissionID], [IsActive], [Name], [Description], [GroupName], [Ordinal]) VALUES (2, 1, N'popisRacuna', N'- popis računa na Financije -> Računi', N'Administrativno', NULL)
GO
INSERT [dbo].[tblAppPermission] ([AppPermissionID], [IsActive], [Name], [Description], [GroupName], [Ordinal]) VALUES (3, 1, N'printanje', N'- printanje dokumenata na Financije -> Printanje', N'Administrativno', NULL)
GO
INSERT [dbo].[tblAppPermission] ([AppPermissionID], [IsActive], [Name], [Description], [GroupName], [Ordinal]) VALUES (4, 1, N'upravljanjeKorisnicima', N'- upravljanje korisnicima na Administrativno -> Korisnici', N'Administrativno', NULL)
GO
INSERT [dbo].[tblAppPermission] ([AppPermissionID], [IsActive], [Name], [Description], [GroupName], [Ordinal]) VALUES (5, 1, N'stornoNarudzbiRacuna', N'- storno narudžbi - ne koristi se', N'Administrativno', NULL)
GO
INSERT [dbo].[tblAppPermission] ([AppPermissionID], [IsActive], [Name], [Description], [GroupName], [Ordinal]) VALUES (6, 1, N'izdavanjeGotovinskihRacuna', N'- ne koristi se', N'Power referenti', NULL)
GO
INSERT [dbo].[tblAppPermission] ([AppPermissionID], [IsActive], [Name], [Description], [GroupName], [Ordinal]) VALUES (7, 1, N'rucnoSolventnost', N'- ne koristi se', N'Administrativno', NULL)
GO
INSERT [dbo].[tblAppPermission] ([AppPermissionID], [IsActive], [Name], [Description], [GroupName], [Ordinal]) VALUES (8, 1, N'printingHistory', N'- povijest printanja na Financije -> Printing history', N'Administrativno', NULL)
GO
INSERT [dbo].[tblAppPermission] ([AppPermissionID], [IsActive], [Name], [Description], [GroupName], [Ordinal]) VALUES (9, 1, N'upravljanjeTvrtkama', N'- upravljanje tvrtkama na Administrativno -> Tvrtke', N'Administrativno', NULL)
GO
SET IDENTITY_INSERT [dbo].[tblAppPermission] OFF
GO
ALTER TABLE [dbo].[tblAppMember] ADD  CONSTRAINT [DF_AppMember_LoginsCount]  DEFAULT ((0)) FOR [LoginsCount]
GO
ALTER TABLE [dbo].[tblAppMember2] ADD  CONSTRAINT [DF_AppMember_LoginsCount2]  DEFAULT ((0)) FOR [LoginsCount]
GO
ALTER TABLE [dbo].[tblAppMemberStatus] ADD  CONSTRAINT [DF_MemberStatus_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblAppMember]  WITH NOCHECK ADD  CONSTRAINT [FK_AppMember_AppMemberStatus] FOREIGN KEY([AppMemberStatusID])
REFERENCES [dbo].[tblAppMemberStatus] ([AppMemberStatusID])
GO
ALTER TABLE [dbo].[tblAppMember] CHECK CONSTRAINT [FK_AppMember_AppMemberStatus]
GO
ALTER TABLE [dbo].[tblAppMember2]  WITH NOCHECK ADD  CONSTRAINT [FK_AppMember_AppMemberStatus2] FOREIGN KEY([AppMemberStatusID])
REFERENCES [dbo].[tblAppMemberStatus] ([AppMemberStatusID])
GO
ALTER TABLE [dbo].[tblAppMember2] CHECK CONSTRAINT [FK_AppMember_AppMemberStatus2]
GO
ALTER TABLE [dbo].[tblAppMemberPermission]  WITH CHECK ADD  CONSTRAINT [FK_AppMemberPermission_AppMember] FOREIGN KEY([AppMemberID])
REFERENCES [dbo].[tblAppMember] ([AppMemberID])
GO
ALTER TABLE [dbo].[tblAppMemberPermission] CHECK CONSTRAINT [FK_AppMemberPermission_AppMember]
GO
ALTER TABLE [dbo].[tblAppMemberPermission]  WITH CHECK ADD  CONSTRAINT [FK_AppMemberPermission_AppPermission] FOREIGN KEY([AppPermissionID])
REFERENCES [dbo].[tblAppPermission] ([AppPermissionID])
GO
ALTER TABLE [dbo].[tblAppMemberPermission] CHECK CONSTRAINT [FK_AppMemberPermission_AppPermission]
GO
ALTER TABLE [dbo].[tblAppMemberPicture]  WITH CHECK ADD  CONSTRAINT [FK_AppMemberPicture_AppMember] FOREIGN KEY([AppMemberID])
REFERENCES [dbo].[tblAppMember] ([AppMemberID])
GO
ALTER TABLE [dbo].[tblAppMemberPicture] CHECK CONSTRAINT [FK_AppMemberPicture_AppMember]
GO
ALTER TABLE [dbo].[tblAppMemberPicture2]  WITH CHECK ADD  CONSTRAINT [FK_tblAppMemberPicture2_tblAppMember] FOREIGN KEY([AppMemberID])
REFERENCES [dbo].[tblAppMember] ([AppMemberID])
GO
ALTER TABLE [dbo].[tblAppMemberPicture2] CHECK CONSTRAINT [FK_tblAppMemberPicture2_tblAppMember]
GO
ALTER TABLE [dbo].[tblAppMobileLog]  WITH CHECK ADD  CONSTRAINT [FK_AppMobileLog_AppMember] FOREIGN KEY([AppMemberID])
REFERENCES [dbo].[tblAppMember] ([AppMemberID])
GO
ALTER TABLE [dbo].[tblAppMobileLog] CHECK CONSTRAINT [FK_AppMobileLog_AppMember]
GO
/****** Object:  StoredProcedure [dbo].[spGetAppMembers]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAppMembers]
	@skip int = 0,
	@take int = 100
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select ROW_NUMBER() over (order by AppMemberID) as num,
	t1.AppMemberID
	into #table1
	from tblAppMember t1

	-- table1: data
	select * from #table1 t2
	inner join tblAppMember t1 on t1.AppMemberID = t2.AppMemberID
	where t2.num between (@skip+1) and (@skip+@take)

	-- table 2: total count
	select count(1) from #table1;

END
GO
/****** Object:  StoredProcedure [dbo].[spGetBillClientSaldo]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/*
	exec spGetBillClientSaldo 1
	exec spGetBillClientSaldo 1, '608724,579140,265196'
*/
/*
	prebaceno je u storu da se moze podatke staviti u #temp tablicu, brze radi
*/
CREATE PROCEDURE [dbo].[spGetBillClientSaldo]
	@billFirmaID bigint,
	@billClientsIdsCSV varchar(max) = null -- csv values or * to get all
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select
		res1.BillClientID,
		sum(res1.BankaUplata) as UkupnoUplata,
		sum(res1.BankaIsplata) as UkupnoIsplata
	into #clients
	from dbo.fnGetBillClientUplate(@billFirmaID, @billClientsIdsCSV) as res1 -- odabire uplate samo za zadane @billClientsIdsCSV
	group by res1.BillClientID

	select b1.SumUkupno,
		m1.IsRacunType,
		d1.BillClientID,
		d1.ParentBillDocumentID
	into #docs
	from #clients t2
	inner join tblBillDocument d1 on d1.BillClientID = t2.BillClientID -- samo one koji su vec odabrani u prvom selectu
			and d1.IsDeleted = 0
	inner join tblBillDocumentCalculated b1 on d1.BillDocumentID = b1.BillDocumentID
	inner join tblBillNaplatniUredjaj nap1 on nap1.BillNaplatniUredjajID = d1.BillNaplatniUredjajID
	inner join tblBillDocumentTip m1 on m1.BillDocumentTipID = nap1.BillDocumentTipID 


	select * from #clients t2
	
	outer apply (
		select coalesce(UkupnoUplata, 0) - coalesce(UkupnoIsplata, 0) as Ballance
	) t21

	outer apply (
		-- izdani racuni za uplate i storno racuni
		select 
			sum(case when d1.SumUkupno > 0 then d1.SumUkupno else 0 end) as IzdaniNaplatniRacuni,
			sum(case when d1.SumUkupno < 0 then -d1.SumUkupno else 0 end) as IzdaniStornoRacuni
		from #docs d1
		where d1.BillClientID = t2.BillClientID
			and d1.IsRacunType = 1 -- samo racuni
	) as t4
	
	outer apply (
		select coalesce(Ballance, 0) - coalesce(IzdaniNaplatniRacuni, 0) + coalesce(IzdaniStornoRacuni, 0) as Neproknjizeno
	) as t41
			
	outer apply (
		-- zaduzenje ponude ili racuni bez prethodne ponude
		select
			sum(case when d1.IsRacunType = 0 then d1.SumUkupno else 0 end) as ZaduzenjePonude,
			sum(case when d1.IsRacunType = 1 then d1.SumUkupno else 0 end) as ZaduzenjeRacuni
		from #docs d1
		where d1.BillClientID = t2.BillClientID
			and d1.SumUkupno > 0 -- naplatni racuni i ponude
			and d1.ParentBillDocumentID is null -- prvi dokument
	) as t31
	
	outer apply (
		-- zaduzenje storno
		select
			sum(case when d1.IsRacunType = 1 then d1.SumUkupno else 0 end) as ZaduzenjeStorno
		from #docs d1
		where d1.BillClientID = t2.BillClientID
			and d1.SumUkupno < 0 -- storno
	) as t32
	
	outer apply (
		select 
			coalesce(ZaduzenjePonude, 0) + coalesce(ZaduzenjeRacuni, 0) + coalesce(ZaduzenjeStorno, 0) as ZaduzenjeUkupno,
			coalesce(ZaduzenjePonude, 0) + coalesce(ZaduzenjeRacuni, 0) + coalesce(ZaduzenjeStorno, 0) - coalesce(Ballance, 0) as Dug 
	) as t33

	outer apply (
		select case when Neproknjizeno > 0 then cast(1 as bit) else cast(0 as bit) end as AllowKnjizenje
	) as t5

END
GO
/****** Object:  StoredProcedure [dbo].[spMultiResults]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spMultiResults]
	@skip int = 0,
	@take int = 100,
	@res int null = 1 out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select getdate() as CurrentDate1;

	select 1 as RowID, 2 as [Name]

	declare @t1 table([Name] varchar(100), [Value] varchar(100));

	insert into @t1
	execute sp_executesql N'DBCC useroptions'

	select * from @t1;

	select getdate() as CurrentDate2;

	return 123;

END
GO
/****** Object:  StoredProcedure [dbo].[spNoTablesResults]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spNoTablesResults]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

	return 22;
END
GO
/****** Object:  StoredProcedure [dbo].[spRandomNumber]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRandomNumber]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	select RAND() as Random;

	return 22;
END
GO
/****** Object:  StoredProcedure [dbo].[spSysRebuildAllIndexes]    Script Date: 2020-08-13 23:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	exec spSysRebuildAllIndexes 1
*/
CREATE PROCEDURE [dbo].[spSysRebuildAllIndexes]
	@doRebuild int = 1 -- mode 1 or 2
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- ************************************************************************
	-- TABLES INDEXES
	-- ************************************************************************
	declare @total int = (select count(1) from information_schema.tables where table_type = 'base table');

	declare @sql nvarchar(1000);
	declare @fillfactor int = 90;

	declare @curr int = 0;

	declare @tableName varchar(255) ;
 
	declare tableCursor cursor for
	select table_name from information_schema.tables where table_type = 'base table';
 
	open tableCursor; 
  
	while (1 = 1)
	begin
		fetch next from tableCursor into @TableName 
		if(@@FETCH_STATUS != 0) break;
		set @curr += 1;
		print cast(@curr as varchar) + '/' + cast(@total as varchar) + ': ' + @tableName;
		if(@doRebuild = 1)
		begin
			dbcc DBREINDEX(@tableName,' ',90);
			print 'DBREINDEX: ' + @tableName;
		end
		else if(@doRebuild = 2)
		begin
			set @sql = 'ALTER INDEX ALL ON ' + @TableName + ' REBUILD WITH (FILLFACTOR = ' + CONVERT(VARCHAR(3),@fillfactor) + ')'
			exec (@sql)
			print 'ALTER INDEX ALL ON: ' + @tableName;
		end
	end

	close tableCursor 
	deallocate tableCursor 

	-- ************************************************************************
	-- FULL TEXT CATALOGS
	-- ************************************************************************
	declare catalogCursor cursor for
	select [name] from sys.fulltext_catalogs
	
	open catalogCursor; 
	declare @catalogName nvarchar(500);

	while (1 = 1)
	begin
		fetch next from catalogCursor into @catalogName 
		if(@@FETCH_STATUS != 0) break;
		
		set @sql = 'ALTER FULLTEXT CATALOG ' + @catalogName + ' REBUILD WITH ACCENT_SENSITIVITY = OFF'
		exec (@sql)

		print 'REBUILD FULLTEXT CATALOG: ' + @catalogName;
	end

	close catalogCursor 
	deallocate catalogCursor 

	-- ************************************************************************
	-- SHRINK DATABASE
	-- ************************************************************************
	declare @dbName varchar(500) = (select top 1 TABLE_CATALOG from information_schema.tables where table_type = 'base table');

	dbcc SHRINKDATABASE(@dbName)

	print 'SHRINKDATABASE: ' + @dbName;

	-- ************************************************************************
	-- SELECT STATISTICS
	-- ************************************************************************

	SELECT dbschemas.[name] as 'Schema',
	dbtables.[name] as 'Table',
	dbindexes.[name] as 'Index',
	indexstats.avg_fragmentation_in_percent,
	indexstats.page_count
	FROM sys.dm_db_index_physical_stats (DB_ID(), NULL, NULL, NULL, NULL) AS indexstats
	INNER JOIN sys.tables dbtables on dbtables.[object_id] = indexstats.[object_id]
	INNER JOIN sys.schemas dbschemas on dbtables.[schema_id] = dbschemas.[schema_id]
	INNER JOIN sys.indexes AS dbindexes ON dbindexes.[object_id] = indexstats.[object_id]
	AND indexstats.index_id = dbindexes.index_id
	WHERE indexstats.database_id = DB_ID() AND dbtables.[name] like '%%'
	ORDER BY indexstats.avg_fragmentation_in_percent desc

	print 'ALL DONE';
	
END
GO
