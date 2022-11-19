
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/17/2022 15:29:47
-- Generated from EDMX file: I:\Bar Projects\MyProjects\ConsoleApp1\ConsoleApp1\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SelaPetShopDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[SelaPetShopDatabaseModelStoreContainer].[FK_AnimalCategory_Animals]', 'F') IS NOT NULL
    ALTER TABLE [SelaPetShopDatabaseModelStoreContainer].[AnimalCategory] DROP CONSTRAINT [FK_AnimalCategory_Animals];
GO
IF OBJECT_ID(N'[SelaPetShopDatabaseModelStoreContainer].[FK_AnimalCategory_Categories]', 'F') IS NOT NULL
    ALTER TABLE [SelaPetShopDatabaseModelStoreContainer].[AnimalCategory] DROP CONSTRAINT [FK_AnimalCategory_Categories];
GO
IF OBJECT_ID(N'[SelaPetShopDatabaseModelStoreContainer].[FK_AnimalImage_Animals]', 'F') IS NOT NULL
    ALTER TABLE [SelaPetShopDatabaseModelStoreContainer].[AnimalImage] DROP CONSTRAINT [FK_AnimalImage_Animals];
GO
IF OBJECT_ID(N'[SelaPetShopDatabaseModelStoreContainer].[FK_AnimalImage_Images]', 'F') IS NOT NULL
    ALTER TABLE [SelaPetShopDatabaseModelStoreContainer].[AnimalImage] DROP CONSTRAINT [FK_AnimalImage_Images];
GO
IF OBJECT_ID(N'[dbo].[FK_Comments_Animals]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_Animals];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Animals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Animals];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[SelaPetShopDatabaseModelStoreContainer].[AnimalCategory]', 'U') IS NOT NULL
    DROP TABLE [SelaPetShopDatabaseModelStoreContainer].[AnimalCategory];
GO
IF OBJECT_ID(N'[SelaPetShopDatabaseModelStoreContainer].[AnimalImage]', 'U') IS NOT NULL
    DROP TABLE [SelaPetShopDatabaseModelStoreContainer].[AnimalImage];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Animals'
CREATE TABLE [dbo].[Animals] (
    [AnimalId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Birthdate] datetime  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Value] nvarchar(50)  NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [CommentId] int IDENTITY(1,1) NOT NULL,
    [AnimalId] int  NOT NULL,
    [Value] nvarchar(50)  NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [ImageId] int  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Url] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL
);
GO

-- Creating table 'AnimalCategory'
CREATE TABLE [dbo].[AnimalCategory] (
    [Animals_AnimalId] int  NOT NULL,
    [Categories_CategoryId] int  NOT NULL
);
GO

-- Creating table 'AnimalImage'
CREATE TABLE [dbo].[AnimalImage] (
    [Animals_AnimalId] int  NOT NULL,
    [Images_ImageId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AnimalId] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [PK_Animals]
    PRIMARY KEY CLUSTERED ([AnimalId] ASC);
GO

-- Creating primary key on [CategoryId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [CommentId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([CommentId] ASC);
GO

-- Creating primary key on [ImageId] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([ImageId] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Animals_AnimalId], [Categories_CategoryId] in table 'AnimalCategory'
ALTER TABLE [dbo].[AnimalCategory]
ADD CONSTRAINT [PK_AnimalCategory]
    PRIMARY KEY CLUSTERED ([Animals_AnimalId], [Categories_CategoryId] ASC);
GO

-- Creating primary key on [Animals_AnimalId], [Images_ImageId] in table 'AnimalImage'
ALTER TABLE [dbo].[AnimalImage]
ADD CONSTRAINT [PK_AnimalImage]
    PRIMARY KEY CLUSTERED ([Animals_AnimalId], [Images_ImageId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AnimalId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comments_Animals]
    FOREIGN KEY ([AnimalId])
    REFERENCES [dbo].[Animals]
        ([AnimalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_Animals'
CREATE INDEX [IX_FK_Comments_Animals]
ON [dbo].[Comments]
    ([AnimalId]);
GO

-- Creating foreign key on [Animals_AnimalId] in table 'AnimalCategory'
ALTER TABLE [dbo].[AnimalCategory]
ADD CONSTRAINT [FK_AnimalCategory_Animals]
    FOREIGN KEY ([Animals_AnimalId])
    REFERENCES [dbo].[Animals]
        ([AnimalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Categories_CategoryId] in table 'AnimalCategory'
ALTER TABLE [dbo].[AnimalCategory]
ADD CONSTRAINT [FK_AnimalCategory_Categories]
    FOREIGN KEY ([Categories_CategoryId])
    REFERENCES [dbo].[Categories]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnimalCategory_Categories'
CREATE INDEX [IX_FK_AnimalCategory_Categories]
ON [dbo].[AnimalCategory]
    ([Categories_CategoryId]);
GO

-- Creating foreign key on [Animals_AnimalId] in table 'AnimalImage'
ALTER TABLE [dbo].[AnimalImage]
ADD CONSTRAINT [FK_AnimalImage_Animals]
    FOREIGN KEY ([Animals_AnimalId])
    REFERENCES [dbo].[Animals]
        ([AnimalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Images_ImageId] in table 'AnimalImage'
ALTER TABLE [dbo].[AnimalImage]
ADD CONSTRAINT [FK_AnimalImage_Images]
    FOREIGN KEY ([Images_ImageId])
    REFERENCES [dbo].[Images]
        ([ImageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnimalImage_Images'
CREATE INDEX [IX_FK_AnimalImage_Images]
ON [dbo].[AnimalImage]
    ([Images_ImageId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------