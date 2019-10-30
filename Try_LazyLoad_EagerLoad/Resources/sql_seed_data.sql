Create Function GetMapId(@leftId int, @max int)
returns int
as
begin
	declare @res int
	if (@leftId % @max = 0)
		set @res = @max
	else
		set @res = @leftId % @max
	return @res
end
Go

Declare @MAP int = 2
Declare @PRODUCT int = 100
Declare @FACTORY int = 10
Declare @PRODUCTTAG int = 10
Declare @PRODUCTTYPE int = 10
Declare @BRANCH int = 100
Declare @BRANCHGROUP int = 10
Declare @id int

IF NOT EXISTS (
	select *
	from
		BranchGroups
)
begin
	DBCC CHECKIDENT ('BranchGroups', RESEED, 0)
	Set @id = 1
	while (@id <= @BRANCHGROUP)
	begin
		Insert into BranchGroups(Name, Description)
		Values('BranchGroup - ' + CAST(@id as nvarchar(20)), 'Descript BranchGroup - ' + CAST(@id as nvarchar(20)))
		Set @id = @id + 1		
	end
end

IF NOT EXISTS (
	select *
	from
		Branches
)
begin
	DBCC CHECKIDENT ('Branches', RESEED, 0)
	Set @id = 1
	while (@id <= @BRANCH)
	begin
		Insert into Branches(Name, Description)
		Values('Branch - ' + CAST(@id as nvarchar(20)), 'Descript Branch - ' + CAST(@id as nvarchar(20)))
		Set @id = @id + 1		
	end
end

IF NOT EXISTS (
	select *
	from
		BranchGroupMaps
)
begin
	Set @id = 0
	While (@id < @MAP)
	begin 
		Insert into BranchGroupMaps(BranchId, BranchGroupId)
		Select Branches.Id, dbo.GetMapId(Branches.Id + @id, @BRANCHGROUP)
		from Branches
		Set @id = @id + 1
	end
end

IF NOT EXISTS (
	select *
	from
		Factories
)
begin
	DBCC CHECKIDENT ('Factories', RESEED, 0)
	Set @id = 1
	while (@id <= @FACTORY)
	begin
		Insert into Factories(Name, Description, BranchId)
		Values('Factory - ' + CAST(@id as nvarchar(20)), 'Descript Factory - ' + CAST(@id as nvarchar(20)), dbo.GetMapId(@id, @BRANCH))
		Set @id = @id + 1		
	end
end

IF NOT EXISTS (
	select *
	from
		ProductTypes
)
begin
	DBCC CHECKIDENT ('ProductTypes', RESEED, 0)
	Set @id = 1
	while (@id <= @PRODUCTTYPE)
	begin
		Insert into ProductTypes(Name, Description)
		Values('ProductType - ' + CAST(@id as nvarchar(20)), 'Descript ProductType - ' + CAST(@id as nvarchar(20)))
		Set @id = @id + 1		
	end
end

IF NOT EXISTS (
	select *
	from
		ProductTags
)
begin
	DBCC CHECKIDENT ('ProductTags', RESEED, 0)
	Set @id = 1
	while (@id <= @PRODUCTTAG)
	begin
		Insert into ProductTags(Name, Description)
		Values('ProductTag - ' + CAST(@id as nvarchar(20)), 'Descript ProductTag - ' + CAST(@id as nvarchar(20)))
		Set @id = @id + 1		
	end
end

IF NOT EXISTS (
	select *
	from
		Products
)
begin
	DBCC CHECKIDENT ('Products', RESEED, 0)
	Set @id = 1
	while (@id <= @PRODUCT)
	begin
		Insert into Products(Name, Description, ProductTypeId)
		Values('Product - ' + CAST(@id as nvarchar(20)), 'Descript Product - ' + CAST(@id as nvarchar(20)), dbo.GetMapId(@id, @PRODUCTTYPE))
		Set @id = @id + 1		
	end
end

IF NOT EXISTS (
	select *
	from
		ProductFactoryMaps
)
begin
	Set @id = 0
	While (@id < @MAP)
	begin 
		Insert into ProductFactoryMaps(ProductId, FactoryId)
		Select Products.Id, dbo.GetMapId(Products.Id + @id, @FACTORY)
		from Products
		Set @id = @id + 1
	end
end

IF NOT EXISTS (
	select *
	from
		ProductTagMaps
)
begin
	Set @id = 0
	While (@id < @MAP)
	begin 
		Insert into ProductTagMaps(ProductId, ProductTagId)
		Select Products.Id, dbo.GetMapId(Products.Id + @id, @PRODUCTTAG)
		from Products
		Set @id = @id + 1
	end
end

drop function GetMapId