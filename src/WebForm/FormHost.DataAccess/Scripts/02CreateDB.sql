create table [dbo].[User] (
    [Id] [int] not null identity,
    [Name] [nvarchar](80) not null,
    primary key ([Id])
);
create table [dbo].[Organization] (
    [Id] [int] not null identity,
    [Name] [nvarchar](20) not null,
    [Description] [nvarchar](100) not null,
    [Active] [bit] not null,
    primary key ([Id])
);
create table [dbo].[DocumentType] (
    [Id] [int] not null identity,
    [Name] [nvarchar](20) not null,
    [Description] [nvarchar](100) not null,
    [ValidFrom] [datetime] not null,
    [ValidTo] [datetime] not null,
    [Active] [bit] not null,
    [Organization_Id] [int] not null,
    primary key ([Id])
);
create table [dbo].[DocTypeVersion] (
    [Id] [int] not null identity,
    [VersionString] [nvarchar](10) not null,
    [Major] [int] not null,
    [Minor] [int] not null,
    [IsLast] [bit] not null,
    [Active] [bit] not null,
    [DocumentType_Id] [int] not null,
    primary key ([Id])
);

alter table [dbo].[DocTypeVersion] add constraint [DocTypeVersion_DocumentType] foreign key ([DocumentType_Id]) references [dbo].[DocumentType]([Id])
alter table [dbo].[DocumentType] add constraint [DocumentType_Organization] foreign key ([Organization_Id]) references [dbo].[Organization]([Id])

create table [dbo].[Fill] (
    [Id] [int] not null identity,
    [StartTime] [datetime] not null,
    [FinishTime] [datetime] null,
    [SendInTime] [datetime] null,
    [Active] [bit] not null,
    [User_Id] [int] not null,
    [StartVersion_Id] [int] not null,
    [ActualVersion_Id] [int] not null,
    [Content_Id] [int] not null,
    primary key ([Id])
);
create table [dbo].[FillContent] (
    [Id] [int] not null identity,
    [EnyK] [varbinary](max) not null,
    primary key ([Id])
);
alter table [dbo].[Fill] add constraint [Fill_ActualVersion] foreign key ([ActualVersion_Id]) references [dbo].[DocTypeVersion]([Id])
alter table [dbo].[Fill] add constraint [Fill_Content] foreign key ([Content_Id]) references [dbo].[FillContent]([Id])
alter table [dbo].[Fill] add constraint [Fill_StartVersion] foreign key ([StartVersion_Id]) references [dbo].[DocTypeVersion]([Id])
alter table [dbo].[Fill] add constraint [Fill_User] foreign key ([User_Id]) references [dbo].[User]([Id])
